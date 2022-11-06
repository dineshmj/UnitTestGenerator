namespace UnitTestGenerator.Logic.Test.LibraryExamples.Support
{
	public interface ICustomerValidator
	{
		IDictionary<string, string>? Validate(Customer customer);
	}
}