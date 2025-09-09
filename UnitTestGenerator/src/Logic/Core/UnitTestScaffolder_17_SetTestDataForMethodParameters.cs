using System.Text;

using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private void SetMethodParametersTestData (StringBuilder builder, IDictionary<string, Type> methodParamDictionary, string additionalIndent, bool isHappy)
		{
			// Libraries.
			var utProvider = this.utGen.UtLibraryProvider;
			var testDataPrep = this.utGen.TestDataProvider;

			// Options.
			var addFriendlyComments = this.utGen.AddFriendlyComments;
			var addToDoComments = this.utGen.AddToDoDirectiveComments;

			if (methodParamDictionary.Count > 0)
			{
				if (addFriendlyComments)
				{
					builder.AppendLine ($"\t\t\t{additionalIndent}// Test data for each parameter");
				}

				if (addToDoComments)
				{
					builder.AppendLine ($"\t\t\t{additionalIndent}// TODO: ↓↓ Please prepare the correct test data below for this Unit Test.");
				}

				var last = methodParamDictionary.Last();

				foreach (var oneParameter in methodParamDictionary)
				{
					var genericTypeName = oneParameter.Value.GetRealGenericTypeName();

                    var paramAssignment
						= testDataPrep.GetNewInstanceFor (
							oneParameter.Key,
                            genericTypeName,
							isHappy
						);

					builder.AppendLine ($"\t\t\t{additionalIndent}{(utProvider.HasSectionsForBDD ? string.Empty : "var ")}{paramAssignment}");

					var underlyingElementType = oneParameter.Value.GetElementType ();
					var isUnderlyingTypeGeneric
							= (underlyingElementType != null)
								? underlyingElementType.IsGenericType || underlyingElementType.IsGenericParameter
								: false;

					if (oneParameter.Value.IsGenericType || oneParameter.Value.IsGenericParameter || genericTypeName.Contains('<') || isUnderlyingTypeGeneric) 
					{
						builder.AppendLine("\t\t\t// TODO: ↑↑ Please replace the generic parameter type used above with a valid runtime type.");

						if (! oneParameter.Equals (last)) 
						{
                            builder.AppendLine();
                        }
					}
				}
			}
		}
	}
}