namespace UnitTestGenerator.Logic.Test.LibraryExamples.Support
{
	public interface ICustomerDataAccess
	{
		void SaveCustomer (Customer newCustomer, LoyaltyStatus loyaltyStatus);
	}
}