using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Utilities;

namespace UnitTestGenerator.Logic.Support.TestDataSupport
{
    public sealed class AutoFixtureLibrarySpecific
		: ITestDataLibrarySpecific
    {
        public TestDataPreparationLibrary CanHandleTestDataPreparationLibrary ()
        {
            return TestDataPreparationLibrary.AutoFixture;
        }

		public string GetPrivateFieldDeclaration ()
		{
			return "private readonly Fixture fixture = new Fixture ();";
		}

		public bool IsTestDataLibraryUsed { get; private set; }

		public string GetNewInstanceFor (string variableName, string typeName, bool isHappy)
		{
			var meaningfulData = typeName.GetMeaningfulData (isHappy);

			if (null != meaningfulData)
			{
				return $"{variableName} = {meaningfulData};\t\t// Please set the correct value.";
			}

			this.IsTestDataLibraryUsed = true;
			return $"{variableName} = this.fixture.Build<{typeName}> ().Create ();";
		}
	}
}