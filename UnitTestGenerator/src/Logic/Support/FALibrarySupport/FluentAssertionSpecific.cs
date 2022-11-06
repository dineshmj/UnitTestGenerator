using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.FALibrarySupport
{
	public sealed class FluentAssertionSpecific
		: IFALibrarySpecific
	{
		public FluentAssertionLibrary CanHandleFluentAssertionLibrary ()
		{
			return FluentAssertionLibrary.FluentAssertions;
		}
		
		public string GetShouldBeNull (string value)
		{
			return $"{ value }.Should ().BeNull ();";
		}

		public string GetShouldNotBeNull (string value)
		{
			return $"{ value }.Should ().NotBeNull ();";
		}

		public IList<string> GetShouldBe (string value, string expectedValue, string typeName)
		{
			var statements = new List<string> ();

			if (typeName.StartsWith ("IList<") || typeName.StartsWith ("List<"))
			{
				statements.Add ($"var argIndex = 0;");
				statements.Add ($"");
				statements.Add ($"{value}");
				statements.Add ($"\t.ToList ()");
				statements.Add ($"\t.ForEach (li => {{");
				statements.Add ($"\t\tli.Should ().Be ({expectedValue} [argIndex]);");
				statements.Add ($"\t\targIndex ++;");
				statements.Add ($"\t}});");

				return statements;
			}
			else if (typeName.StartsWith ("IDictionary<") || typeName.StartsWith ("Dictionary<"))
			{
				statements.Add ($"{value}.Should ().BeEquivalentTo ({expectedValue});");

				return statements;
			}

			return new List<string> { $"{value}.Should ().Be ({ expectedValue});" };
		}

		public IList<string> GetShouldNotBe (string value, string expectedValue, string typeName)
		{
			if (typeName.StartsWith ("IDictionary<") || typeName.StartsWith ("Dictionary<"))
			{
				return new List<string> { $"{value}.Should ().NotBeEquivalentTo ({expectedValue});" };
			}

			return new List<string> { $"{value}.Should ().NotBe ({expectedValue});" };
		}

		public string GetShouldBeOfType (string value, string typeName)
		{
			return $"{value}.Should ().BeOfType<{typeName}> ();";
		}
	}
}