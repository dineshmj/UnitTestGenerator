using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.FALibrarySupport
{
	public interface IFALibrarySpecific
	{
		FluentAssertionLibrary CanHandleFluentAssertionLibrary ();
		
		string GetShouldBeNull (string value);

		string GetShouldNotBeNull (string value);

		IList<string> GetShouldBe (string value, string expectedValue, string typeName = "");

		IList<string> GetShouldNotBe (string value, string expectedValue, string typeName = "");

		string GetShouldBeOfType (string value, string typeName);
	}
}