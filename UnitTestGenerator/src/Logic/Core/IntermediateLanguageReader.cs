using System.Reflection;
using System.Reflection.Emit;

using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Core
{
	public sealed class IntermediateLanguageReader
		: IILReader
	{
		private const string LOAD_ARGUMENT = "ldarg.";
		private const string STORE_IN_FIELD = "stfld (";
		private const string LOAD_FIELD = "ldfld (";
		private const string CALL_VIRTUAL = "callvirt (";

		private const string UNKNOWN = "--unknown--";
		private const string OPEN_PARENTHESIS = "(";
		private const string CLOSE_PARENTHESIS = ")";

		public IList<DependencyInfo> GetDependencies (Type targetType)
		{
			var constructorArgs
				= new List<DependencyInfo> ();

			var greadiestConstructor
				= targetType
					.GetConstructors ()
					.OrderByDescending (c => c.GetParameters ().Length)
					.FirstOrDefault ();

			var parameterTypes
				= greadiestConstructor
					?.GetParameters ()
					.ToList ()
					.Select (p => p.ParameterType)
					.ToList ();

			var ilStatements
				= this.GetILStatementsOf (greadiestConstructor);

			if (null != ilStatements)
			{
				for (var i = 0; i < ilStatements.Length - 1; i++)
				{
					var thisIl = ilStatements [i];
					var nextIl = ilStatements [i + 1];

					var argIndex = 0;

					if
						(
							thisIl.StartsWith (LOAD_ARGUMENT)
							&& int.TryParse (thisIl.Substring (thisIl.IndexOf (".") + 1), out argIndex)
							&& nextIl.StartsWith (STORE_IN_FIELD)
						)
					{
						var fieldName
							= nextIl
								.Substring (nextIl.IndexOf (OPEN_PARENTHESIS) + 1)
								.Replace (CLOSE_PARENTHESIS, string.Empty);

						constructorArgs.Add (new DependencyInfo (parameterTypes [argIndex - 1], fieldName));
					}
				}
			}

			return constructorArgs;
		}

		public IList<DependencyCallInfo> GetDependencyMethodCalls (MethodBase targetMethod)
		{
			var dependencies = this.GetDependencies (targetMethod.DeclaringType);
			var dependencyMethodCalls = new List<DependencyCallInfo> ();

			var ilStatements = this.GetILStatementsOf (targetMethod);

			for (var i = 0; i < ilStatements.Length - 1; i++)
			{
				var thisIl = ilStatements [i];

				if (thisIl.StartsWith (LOAD_FIELD))
				{
					var fieldName
						= thisIl
							.Substring (thisIl.IndexOf (OPEN_PARENTHESIS) + 1)
							.Replace (CLOSE_PARENTHESIS, string.Empty);

					var dependencyInfo = dependencies.FirstOrDefault (di => di.PrivateReadOnlyFieldName == fieldName);

					if (null != dependencyInfo)
					{
						for (var j = i + 1; j < ilStatements.Length; j++)
						{
							var nextIl = ilStatements [j];

							if (nextIl.StartsWith (CALL_VIRTUAL))
							{
								var methodName = nextIl.Substring (nextIl.IndexOf (OPEN_PARENTHESIS) + 1);
								methodName = methodName.Substring (0, methodName.Length - 3).Trim ();
								var declaringType = dependencyInfo.DependencyAbstractionType;

								// if (methodName != "ToString" && declaringType.IsClass && declaringType.IsPublic && declaringType.IsAbstract == false)
								if (methodName != "ToString" && methodName.StartsWith ("get_") == false && declaringType.IsInterface && declaringType.IsPublic)
								{
									var greadiestOverload
										= dependencyInfo
											.DependencyAbstractionType
											.GetMethods ()
											.Where (m => m.Name == methodName)
											.OrderByDescending (m => m.GetParameters ().Length)
											.FirstOrDefault ();

									var parameterTypes
										= greadiestOverload
											.GetParameters ()
											.Select (m => m.ParameterType)
											.ToList ();

									var dependencyCallInfo = new DependencyCallInfo (greadiestOverload, parameterTypes, dependencyInfo);
									dependencyMethodCalls.Add (dependencyCallInfo);

									i = j;
									break;
								}
							}
						}
					}
				}
			}

			return dependencyMethodCalls;
		}

		private string [] GetILStatementsOf (MethodBase? targetMethod)
		{
			var ilStatements = new List<string> ();

			if (null == targetMethod)
			{
				return null;
			}

			try
			{
				var ilStatementsAsBytes
					= targetMethod
						?.GetMethodBody ()
						?.GetILAsByteArray ();

				var operationCodes
					= typeof (OpCodes)
						.GetFields ()
						.Select (f => (OpCode) f.GetValue (null));

				var ilOfTargetMethod
					= ilStatementsAsBytes
						?.Select (il => operationCodes.FirstOrDefault (oc => oc.Value == il));

				var targetIlWalker = ilOfTargetMethod?.GetEnumerator ();

				while (targetIlWalker.MoveNext ())
				{
					var operationCode = targetIlWalker.Current;

					if (operationCode.OperandType != OperandType.InlineNone)
					{
						var byteCount = 4;
						long operand = 0;
						var token = string.Empty;

						var targetMethodModule = targetMethod?.Module;
						Func<int, string> tokenResolver = token => string.Empty;

						switch (operationCode.OperandType)
						{
							case OperandType.InlineMethod:
								tokenResolver = token =>
								{
									var resolvedMethod = targetMethodModule?.ResolveMethod (token);
									return $"({(null == resolvedMethod ? UNKNOWN : resolvedMethod.Name)}())";
								};
								break;

							case OperandType.InlineField:
								tokenResolver = token =>
								{
									var resolvedField = targetMethodModule?.ResolveField (token);
									return $"({(null == resolvedField ? UNKNOWN : resolvedField.Name)})";
								};
								break;

							case OperandType.InlineSig:
								tokenResolver = token =>
								{
									var resolvedSignature
									= string.Join (",", targetMethodModule.ResolveSignature (token));
									return $"(SIG:{(null == resolvedSignature ? UNKNOWN : resolvedSignature)})";
								};
								break;

							case OperandType.InlineString:
								tokenResolver = token =>
								{
									try
									{
										var resolvedString = targetMethodModule?.ResolveString (token);
										return $"('{(null == resolvedString ? UNKNOWN : resolvedString)})";
									}
									catch
									{
										return string.Empty;
									}
								};
								break;

							case OperandType.InlineType:
								tokenResolver = token =>
								{
									var resolvedType = targetMethodModule?.ResolveType (token);
									return $"(typeof({(null == resolvedType ? UNKNOWN : resolvedType.Name)})";
								};
								break;

							case OperandType.InlineI:
							case OperandType.InlineBrTarget:
							case OperandType.InlineSwitch:
							case OperandType.ShortInlineR:
								break;

							case OperandType.InlineI8:
							case OperandType.InlineR:
								byteCount = 8;
								break;

							case OperandType.ShortInlineBrTarget:
							case OperandType.ShortInlineI:
							case OperandType.ShortInlineVar:
								byteCount = 1;
								break;
						}

						for (var i = 0; i < byteCount; i++)
						{
							targetIlWalker.MoveNext ();
							operand |= (long) targetIlWalker.Current.Value << 8 * i;
						}

						var resolvedIlStatement = tokenResolver ((int) operand);
						resolvedIlStatement = string.IsNullOrEmpty (resolvedIlStatement) ? operand.ToString () : resolvedIlStatement;

						ilStatements.Add ($"{operationCode.Name} {resolvedIlStatement}");
					}
					else
					{
						ilStatements.Add (operationCode.Name);
					}
				}
			}
			catch (Exception ex)
			{

			}

			return ilStatements.ToArray ();
		}
	}
}