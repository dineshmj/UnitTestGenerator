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

				foreach (var oneParameter in methodParamDictionary)
				{
					var paramAssignment
						= testDataPrep.GetNewInstanceFor (
							oneParameter.Key,
							oneParameter.Value,
							isHappy
						);

					builder.AppendLine ($"\t\t\t{additionalIndent}{(utProvider.HasSectionsForBDD ? string.Empty : "var ")}{paramAssignment}");
				}
			}
		}
	}
}