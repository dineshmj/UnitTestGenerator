using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.UTLibrarySupport
{
    public sealed class XUnitSpecific
		: IUnitTestLibrarySpecific
    {
        public UnitTestLibrary CanHandleUnitTestLibrary ()
        {
            return UnitTestLibrary.XUnit;
        }

		public bool HasSectionsForBDD => false;

		public string GetTestClassDecorator ()
		{
			return string.Empty;
		}

		public string UnitTestClassInherits ()
		{
			return string.Empty;
		}

		public string GetTestMethodDecorator ()
		{
			return "[Fact]";
		}

		public string GetInitializeMethodDecorator ()
		{
			return string.Empty;
		}
		public string GetInitializeMethodSignature ()
		{
			return string.Empty;
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