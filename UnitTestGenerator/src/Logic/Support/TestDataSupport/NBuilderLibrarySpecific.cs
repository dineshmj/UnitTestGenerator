using System;

using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Extensions;
using UnitTestGenerator.Logic.Support.Utilities;

namespace UnitTestGenerator.Logic.Support.TestDataSupport
{
    public sealed class NBuilderLibrarySpecific
        : ITestDataLibrarySpecific
    {
        public TestDataPreparationLibrary CanHandleTestDataPreparationLibrary ()
        {
            return TestDataPreparationLibrary.FizzwareNBuilder;
        }

		public string GetPrivateFieldDeclaration ()
		{
			return string.Empty;
		}

		public bool IsTestDataLibraryUsed { get; private set; }

		public string GetNewInstanceFor (string variableName, Type type, bool isHappy)
		{
			var typeName = type.GetRealGenericTypeName ();
            var meaningfulData = typeName.GetMeaningfulData (isHappy);

			if (null != meaningfulData)
			{
				return $"{variableName} = { meaningfulData};\t\t// Please set the correct value.";
			}

			if (type.IsEnum)
			{
				var enumValue = $"{type.Name}.{Enum.GetNames (type) [0]}";
                return $"{variableName} = {enumValue};";
            }

            this.IsTestDataLibraryUsed = true;
			return $"{variableName} = Builder<{typeName}>.CreateNew ().Build ();";
		}
	}
}