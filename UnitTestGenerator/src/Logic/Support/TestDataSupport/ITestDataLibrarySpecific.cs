using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.TestDataSupport
{
    public interface ITestDataLibrarySpecific
    {
        TestDataPreparationLibrary CanHandleTestDataPreparationLibrary ();

        string GetPrivateFieldDeclaration ();

        bool IsTestDataLibraryUsed { get; }

        string GetNewInstanceFor (string variableName, Type type, bool isHappy);
    }
}