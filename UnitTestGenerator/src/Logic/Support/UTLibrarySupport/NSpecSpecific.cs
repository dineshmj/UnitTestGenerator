using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.UTLibrarySupport
{
	public sealed class NSpecSpecific
		: IUnitTestLibrarySpecific
    {
        public UnitTestLibrary CanHandleUnitTestLibrary ()
        {
            return UnitTestLibrary.NSpec;
        }

		public bool HasSectionsForBDD => true;

		public string GetTestClassDecorator ()
		{
			return string.Empty;
		}

		public string UnitTestClassInherits ()
		{
			return "nspec";
		}

		public string GetTestMethodDecorator ()
		{
			return string.Empty;
		}

		public string GetInitializeMethodDecorator ()
		{
			return string.Empty;
		}

		public string GetInitializeMethodSignature ()
		{
			return "public void before_each ()";
		}

		public string GetArrangeBlockStarting (out string additionalIndent, string methodName = "", bool isHappy = false)
		{
			additionalIndent = "\t";
			return "\t\t\tbefore = () => {";
		}

		public string GetArrangeBlockEnding ()
		{
			return "\t\t\t};";
		}

		public string GetActBlockStarting (out string additionalIndent, string methodName = "", bool isHappy = false)
		{
			additionalIndent = "\t\t";

			if (methodName == "Constructor")
			{
				return $"\t\t\tcontext [\"When I call the constructor method with { (isHappy ? "valid" : "invalid") } parameters\"] = () => {{" + @"
				act = () => {";
			}
			else
			{
				return "\t\t\tcontext [\"When I call the '" + methodName + $"' method with {(isHappy ? "valid" : "invalid") } parameters\"] = () => {{" + @"
				act = () => {";
			}
		}

		public string GetActBlockEnding ()
		{
			return @"				};

	";
		}

		public string GetAssertBlockStarting (out string additionalIndent, bool isHappy = false)
		{
			additionalIndent = "\t\t";
			return $"\t\t\t\tit [\"Should {(isHappy ? "execute successfully" : "fail to execute")}\"] = () => {{";
		}

		public string GetAssertBlockEnding ()
		{
			return @"				};
			};";
		}
	}
}