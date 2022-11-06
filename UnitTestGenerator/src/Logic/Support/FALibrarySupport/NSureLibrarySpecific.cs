using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.FALibrarySupport
{
	public sealed class NSureLibrarySpecific
		: IFALibrarySpecific
	{
		public FluentAssertionLibrary CanHandleFluentAssertionLibrary ()
		{
			return FluentAssertionLibrary.NSure;
		}
		
		public string GetShouldBeNull (string value)
		{
			return $"Ensure.That ({value} == null, \"Null value is expected.\");";
		}

		public string GetShouldNotBeNull (string value)
		{
			return $"Ensure.That ({value} != null, \"Null value is not expected.\");";
		}

		public IList<string> GetShouldBe (string value, string expectedValue, string typeName = "")
		{
			var statements = new List<string> ();

			if (typeName.StartsWith ("IList<") || typeName.StartsWith ("List<"))
			{
				statements.Add ($"var index = 0;\r\n");
				statements.Add ($"{value}");
				statements.Add ($"\t.ToList ()");
				statements.Add ($"\t.ForEach (e => {{");
				statements.Add ($"\t\tEnsure.That ({expectedValue} [index].Equals ({value} [index]), \"Expected value is different.\");");
				statements.Add ($"\t\tindex ++;");
				statements.Add ($"\t}});");

				return statements;
			}
			else if (typeName.StartsWith ("IDictionary<") || typeName.StartsWith ("Dictionary<"))
			{
				statements.Add ($"{value}");
				statements.Add ($"\t.ToList ()");
				statements.Add ($"\t.ForEach (kv => {{");
				statements.Add ($"\t\tEnsure.That ({expectedValue} [kv.Key].Equals (kv.Value), \"Expected value is different.\");");
				statements.Add ($"\t}});");

				return statements;
			}

			statements.Add ($"Ensure.That ({value}.Equals ({expectedValue}), \"Expected value is different.\");");
			return statements;
		}

		public IList<string> GetShouldNotBe (string value, string expectedValue, string typeName)
		{
			return new List<string> { $"Ensure.That ({value} != {expectedValue}, \"Expected value is same.\");" };
		}

		public string GetShouldBeOfType (string value, string typeName)
		{
			return $"Ensure.That ({value} is {typeName}, \"Expected type is {typeName}.\");";
		}
	}
}