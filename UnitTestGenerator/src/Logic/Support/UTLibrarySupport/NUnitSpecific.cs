using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.UTLibrarySupport
{
    public sealed class NUnitSpecific
        : IUnitTestLibrarySpecific
    {
        public UnitTestLibrary CanHandleUnitTestLibrary ()
        {
            return UnitTestLibrary.NUnit;
        }

		public bool HasSectionsForBDD => false;

		public string GetTestClassDecorator ()
		{
			return "[TestFixture]";
		}

		public string UnitTestClassInherits ()
		{
			return string.Empty;
		}

		public string GetTestMethodDecorator ()
		{
			return "[Test]";
		}

		public string GetInitializeMethodDecorator ()
		{
			return "[SetUp]";
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