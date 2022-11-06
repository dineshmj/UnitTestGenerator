using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.FALibrarySupport
{
	public sealed class ShouldlyLibrarySpecific
		: IFALibrarySpecific
	{
		public FluentAssertionLibrary CanHandleFluentAssertionLibrary ()
		{
			return FluentAssertionLibrary.Shouldly;
		}
		
		public string GetShouldBeNull (string value)
		{
			return $"{ value }.ShouldBe (null);";
		}

		public string GetShouldNotBeNull (string value)
		{
			return $"{ value }.ShouldNotBe (null);";
		}

		public IList<string> GetShouldBe (string value, string expectedValue, string typeName = "")
		{
			var statements = new List<string> ();

			if (typeName.StartsWith ("IList<") || typeName.StartsWith ("List<"))
			{
				statements.Add ($"{value}.ShouldBe ({expectedValue}?.AsEnumerable ());");
				return statements;
			}
			else if (typeName.StartsWith ("IDictionary<") || typeName.StartsWith ("Dictionary<"))
			{
				statements.Add ($"{value}.ShouldBeEquivalentTo ({expectedValue});");
				return statements;
			}

			statements.Add ($"{value}.ShouldBe ({expectedValue});");
			return statements;
		}

		public IList<string> GetShouldNotBe (string value, string expectedValue, string typeName = "")
		{
			return new List<string> { $"{value}.ShouldNotBe ({expectedValue});" };
		}

		public string GetShouldBeOfType (string value, string typeName)
		{
			return $"{value}.ShouldBeAssignableTo<{typeName}> ();";
		}
	}
}