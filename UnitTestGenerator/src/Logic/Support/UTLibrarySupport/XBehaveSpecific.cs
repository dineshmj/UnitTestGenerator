using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator.Logic.Support.UTLibrarySupport
{
    public sealed class XBehaveSpecific
		: IUnitTestLibrarySpecific
    {
        public UnitTestLibrary CanHandleUnitTestLibrary ()
        {
            return UnitTestLibrary.XBehave;
        }

		public bool HasSectionsForBDD => true;

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
			return "[Scenario]";
		}

		public string GetInitializeMethodDecorator ()
		{
			return "[Background]";
		}
		public string GetInitializeMethodSignature ()
		{
			return "public void SetUp ()";
		}

		public string GetArrangeBlockStarting (out string additionalIndent, string methodName = "", bool isHappy = false)
		{
			if (methodName == ".ctor")
			{
				methodName = "for the constructor method";
			}
			else
			{
				methodName = "to " + methodName.ToHumanReadable ();
			}

			additionalIndent = "\t\t";
			return @$"			""Given that I have { (isHappy ? "valid" : "invalid") } inputs { methodName }""
				.x (() => {{";
		}

		public string GetArrangeBlockEnding ()
		{
			return @"				});";
		}

		public string GetActBlockStarting (out string additionalIndent, string methodName = "", bool isHappy = false)
		{
			additionalIndent = "\t\t";

			if (methodName == "Constructor")
			{
				return @$"			""When I call the constructor method with {(isHappy ? "valid" : "invalid")} parameters""
				.x (() => {{";
			}

			return @$"			""When I call the '{methodName}' method with { (isHappy ? "valid" : "invalid" ) } parameters""
				.x (() => {{";
		}

		public string GetActBlockEnding ()
		{
			return @"				});

";
		}

		public string GetAssertBlockStarting (out string additionalIndent, bool isHappy = false)
		{
			additionalIndent = "\t\t";
			return $@"			""It should {(isHappy ? "execute successfully" : "fail to execute")}""
				.x (() => {{";
		}

		public string GetAssertBlockEnding ()
		{
			return @"				});";
		}
	}
}