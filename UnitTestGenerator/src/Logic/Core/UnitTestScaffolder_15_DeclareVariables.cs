using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;
using UnitTestGenerator.Logic.Support.Utilities;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void DeclareVariablesForMethodUnitTest (StringBuilder builder, IDictionary<string, Type> methodParamDictionary, bool isHappy)
		{
			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;

			// Context.
			var methodReturnType = this.context.MethodReturnType;
			var isReturnTypeClassOrInterface = methodReturnType.IsInterface || methodReturnType.IsClass;
			var returnTypeName = methodReturnType.GetRealGenericTypeName ().ToAlias ();

			// Options.
			var addToDoComments = utGen.AddToDoDirectiveComments;
			var addFriendlyComments = utGen.AddFriendlyComments;

			if (utProvider.HasSectionsForBDD && addFriendlyComments && methodParamDictionary.Count > 0)
			{
				builder.AppendLine ("\t\t\t// Method parameters");
			}

			if (utProvider.HasSectionsForBDD)
			{
				foreach (var oneParameter in methodParamDictionary)
				{
					var typeName = oneParameter.Value.GetRealGenericTypeName ();

					if (oneParameter.Value.IsInterface || oneParameter.Value.IsClass)
					{
						builder.AppendLine ($"\t\t\t{typeName} {oneParameter.Key} = null;");
					}
					else
					{
						// var defaultValueText = this.GetDefaultValueTextOf (typeName);
						var defaultValueText = typeName.GetMeaningfulData (isHappy);
						builder.AppendLine ($"\t\t\t{typeName} {oneParameter.Key} = {defaultValueText};");
					}
				}
			}

			if (methodReturnType != typeof (void))
			{
				if (addFriendlyComments)
				{
					builder.AppendLine ("\t\t\t// Expected and actual results");
				}

				if (isReturnTypeClassOrInterface)
				{
					builder.AppendLine ($"\t\t\t{returnTypeName} result = null;");
				}
				else
				{
					// var defaultValueText = this.GetDefaultValueTextOf (returnTypeName);
					var defaultValueText = returnTypeName.GetMeaningfulData (isHappy);
					builder.AppendLine ($"\t\t\t{returnTypeName} result = {defaultValueText};");
				}

				if (addToDoComments)
				{
					builder.AppendLine ($"\t\t\t// TODO: ↓↓ Please set the correct expected value below.");
				}

				var inlineComment = "// Please specify valid expected result here.";

				if (isReturnTypeClassOrInterface)
				{
					if (returnTypeName.StartsWith ("IList<") || returnTypeName.StartsWith ("IDictionary<"))
					{
						if (utProvider.HasSectionsForBDD)
						{
							builder.AppendLine ($"\t\t\t{returnTypeName} expectedResult = new {returnTypeName.Substring (1)} ();\t\t{inlineComment}");
						}
						else
						{
							builder.AppendLine ($"\t\t\tvar expectedResult = new {returnTypeName.Substring (1)} ();\t\t{inlineComment}");
						}
					}
					else
					{
						builder.AppendLine ($"\t\t\t{returnTypeName} expectedResult = null;\t\t{inlineComment}");
					}

					builder.Append ("\r\n");
				}
				else
				{
					var meaningfulData = returnTypeName.GetMeaningfulData (isHappy);

					if (null != meaningfulData)
					{
						builder.AppendLine ($"\t\t\t{returnTypeName} expectedResult = {meaningfulData};\t\t{inlineComment}");
					}
					else
					{
						builder.AppendLine ($"\t\t\t{returnTypeName} expectedResult = default ({returnTypeName});\t\t{inlineComment}");
					}

					builder.Append ("\r\n");
				}
			}
		}
	}
}