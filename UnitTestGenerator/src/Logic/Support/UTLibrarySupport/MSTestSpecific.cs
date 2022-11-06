using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.UTLibrarySupport
{
	public sealed class MSTestSpecific
		: IUnitTestLibrarySpecific
	{
		public UnitTestLibrary CanHandleUnitTestLibrary ()
		{
			return UnitTestLibrary.MicrosoftTest;
		}

		public bool HasSectionsForBDD => false;

		public string GetTestClassDecorator ()
		{
			return "[TestClass]";
		}

		public string UnitTestClassInherits ()
		{
			return string.Empty;
		}

		public string GetTestMethodDecorator ()
		{
			return "[TestMethod]";
		}

		public string GetInitializeMethodDecorator ()
		{
			return "[TestInitialize]";
		}

		public string GetInitializeMethodSignature ()
		{
			return "public void SetUp ()";
		}

		public string GetArrangeBlockStarting (out string additionalIndent, string methodName = "", bool isHappy = false)
		{
			additionalIndent = string.Empty;
			return string.Empty;
		}

		public string GetArrangeBlockEnding ()
		{
			return string.Empty;
		}

		public string GetActBlockStarting (out string additionalIndent, string methodName = "", bool isHappy = false)
		{
			additionalIndent = string.Empty;
			return string.Empty;
		}

		public string GetActBlockEnding ()
		{
			return "\r\n";
		}

		public string GetAssertBlockStarting (out string additionalIndent, bool isHappy = false)
		{
			additionalIndent = string.Empty;
			return string.Empty;
		}

		public string GetAssertBlockEnding ()
		{
			return string.Empty;
		}
	}
}