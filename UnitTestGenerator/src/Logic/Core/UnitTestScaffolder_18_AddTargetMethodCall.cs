using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void AddTargetMethodCall (StringBuilder builder, IDictionary<string, Type> methodParamDictionary, string additionalIndent)
		{
			// Context.
			var isTargetTypeStatic = this.context.DeclaringType.IsStatic ();
			var isExtension = this.context.IsExtension;
			var methodName = this.context.MethodName;
			var targetClassName = this.context.DeclaringTypeName;
			var methodReturnType = this.context.MethodReturnType;
			var isReturnTypeVoid = methodReturnType == typeof (void);

			if (isTargetTypeStatic)
			{
				if (isExtension)
				{
					var thisArgument = methodParamDictionary.ToList () [0].Key;

					var paramSubSet
						= methodParamDictionary
							.OrderBy (d => d.Key)
							.Skip (1)
							.Take (methodParamDictionary.Keys.Count - 1)
							.ToDictionary (k => k.Key, v => v.Value);

					if (isReturnTypeVoid)
					{
						// It is a void method.
						builder.AppendLine ($"\t\t\t{additionalIndent}{thisArgument}.{methodName} ({String.Join (", ", paramSubSet.Keys.ToArray ())});");
					}
					else
					{
						builder.AppendLine ($"\t\t\t{additionalIndent}result = {thisArgument}.{methodName} ({String.Join (", ", paramSubSet.Keys.ToArray ())});");
					}
				}
				else
				{
					if (isReturnTypeVoid)
					{
						// It is a void method.
						builder.AppendLine ($"\t\t\t{additionalIndent}{targetClassName}.{methodName} ({String.Join (", ", methodParamDictionary.Keys.ToArray ())});");
					}
					else
					{
						builder.AppendLine ($"\t\t\t{additionalIndent}result = {targetClassName}.{methodName} ({String.Join (", ", methodParamDictionary.Keys.ToArray ())});");
					}
				}
			}
			else
			{
				if (isReturnTypeVoid)
				{
					// It is a void method.
					builder.AppendLine ($"\t\t\t{additionalIndent}this.{targetClassName.ToCamelCase ()}.{methodName} ({String.Join (", ", methodParamDictionary.Keys.ToArray ())});");
				}
				else
				{
					builder.AppendLine ($"\t\t\t{additionalIndent}result = this.{targetClassName.ToCamelCase ()}.{methodName} ({String.Join (", ", methodParamDictionary.Keys.ToArray ())});");
				}
			}
		}
	}
}