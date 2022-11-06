using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.FALibrarySupport
{
	public sealed class NFluentLibrarySpecific
		: IFALibrarySpecific
	{
		public FluentAssertionLibrary CanHandleFluentAssertionLibrary ()
		{
			return FluentAssertionLibrary.NFluent;
		}
		
		public string GetShouldBeNull (string value)
		{
			return $"Check.That ({value}).IsNull ();";
		}

		public string GetShouldNotBeNull (string value)
		{
			return $"Check.That ({value}).IsNotNull ();";
		}

		public IList<string> GetShouldBe (string value, string expectedValue, string typeName = "")
		{
			var statements = new List<string> ();

			if (typeName.StartsWith ("IList<") || typeName.StartsWith ("List<"))
			{
				statements.Add ($"Check.That ({value}).SameSequenceAs ({expectedValue});");
				return statements;
			}
			else if (typeName.StartsWith ("IDictionary<") || typeName.StartsWith ("Dictionary<"))
			{
				statements.Add ($"{value}");
				statements.Add ($"\t.ToList ()");
				statements.Add ($"\t.ForEach (kv => {{");
				statements.Add ($"\t\tCheck.That ({expectedValue} [kv.Key]).IsEqualTo (kv.Value);");
				statements.Add ($"\t}});");

				return statements;
			}

			return new List<string> { $"Check.That ({value}).IsEqualTo ({expectedValue});" };
		}

		public IList<string> GetShouldNotBe (string value, string expectedValue, string typeName)
		{
			return new List<string> { $"Check.That ({value}).IsNotEqualTo ({expectedValue});" };
		}

		public string GetShouldBeOfType (string value, string typeName)
		{
			return $"Check.That ({value}).IsAnInstanceOfOneOf<{typeName}> ();";
		}
	}
}