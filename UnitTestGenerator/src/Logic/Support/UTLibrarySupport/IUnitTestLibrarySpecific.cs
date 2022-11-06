using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.UTLibrarySupport
{
    public interface IUnitTestLibrarySpecific
    {
        UnitTestLibrary CanHandleUnitTestLibrary();

        bool HasSectionsForBDD { get; }

        string GetTestClassDecorator ();

        string UnitTestClassInherits ();

        string GetTestMethodDecorator ();

        string GetInitializeMethodDecorator ();

		string GetInitializeMethodSignature ();

        string GetArrangeBlockStarting (out string additionalIndent, string methodName = "", bool isHappy = false);

        string GetArrangeBlockEnding ();

		string GetActBlockStarting (out string additionalIndent, string methodName = "", bool isHappy = false);

		string GetActBlockEnding ();

		string GetAssertBlockStarting (out string additionalIndent, bool isHappy = false);

		string GetAssertBlockEnding ();
	}
}