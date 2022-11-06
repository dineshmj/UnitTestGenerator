namespace UnitTestGenerator.Logic.Test.LibraryExamples.Support
{
	public sealed class CustomerBusinessFacade
	{
		private readonly ICustomerValidator customerValidator;
		private readonly ICustomerDataAccess customerDataAccess;

		public CustomerBusinessFacade (ICustomerValidator customerValidator, ICustomerDataAccess customerDataAccess)
		{
			this.customerValidator = customerValidator;
			this.customerDataAccess = customerDataAccess;
		}

		public IDictionary<string, string> CreateCustomer (Customer newCustomer)
		{
			var validationFailures = this.customerValidator.Validate (newCustomer);

			if (validationFailures?.Count > 0)
			{
				return validationFailures;
			}

			var loyaltyStatus = new LoyaltyStatus { IsLoyal = false };
			this.customerDataAccess.SaveCustomer (newCustomer, loyaltyStatus);
			return null;
		}
	}
}