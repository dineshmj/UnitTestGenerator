using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.FALibrarySupport
{
	public sealed class ShouldLibrarySpecific
		: IFALibrarySpecific
	{
		public FluentAssertionLibrary CanHandleFluentAssertionLibrary ()
		{
			return FluentAssertionLibrary.Should;
		}
		
		public string GetShouldBeNull (string value)
		{
			return $"{ value }.ShouldBeNull ();";
		}

		public string GetShouldNotBeNull (string value)
		{
			return $"{ value }.ShouldNotBeNull ();";
		}

		public IList<string> GetShouldBe (string value, string expectedValue, string typeName = "")
		{
			var statements = new List<string> ();

			if (typeName.StartsWith ("IList<") || typeName.StartsWith ("List<"))
			{
				statements.Add ($"var argIndex = 0;");
				statements.Add ($"");
				statements.Add ($"{value}");
				statements.Add ($"\t.ToList ()");
				statements.Add ($"\t.ForEach (li => {{");
				statements.Add ($"\t\tli.ShouldEqual ({expectedValue} [argIndex]);");
				statements.Add ($"\t\targIndex ++;");
				statements.Add ($"\t}});");

				return statements;
			}
			else if (typeName.StartsWith ("IDictionary<") || typeName.StartsWith ("Dictionary<"))
			{
				statements.Add ($"{value}");
				statements.Add ($"\t.ToList ()");
				statements.Add ($"\t.ForEach (kv => {{");
				statements.Add ($"\t\t{expectedValue} [kv.Key].ShouldEqual (kv.Value);");
				statements.Add ($"\t}});");

				return statements;
			}

			statements.Add ($"{value}.ShouldEqual ({expectedValue});");
			return statements;
		}

		public IList<string> GetShouldNotBe (string value, string expectedValue, string typeName)
		{
			return new List<string> { $"{value}.ShouldNotEqual ({expectedValue});" };
		}

		public string GetShouldBeOfType (string value, string typeName)
		{
			return $"{value}.ShouldBeType<{typeName}> ();";
		}
	}
}