using NSpec;
using Rhino.Mocks;
using NSure;
using FizzWare.NBuilder;

using UnitTestGenerator.Logic.Test.LibraryExamples.Support;

namespace UnitTestGenerator.Logic.Test.LibraryExamples
{
	public sealed class CustomerFacade_Set7_NSpec_RhinoMock_NSure
		: nspec
	{
		private CustomerBusinessFacade customerBusinessFacade;
		private ICustomerValidator custValidatorMock;
		private ICustomerDataAccess custDataAccessMock;

		// ============
		// Test Cases
		// ============

		public void before_each ()
		{
			this.custValidatorMock = MockRepository.GenerateStub<ICustomerValidator> ();
			this.custDataAccessMock = MockRepository.GenerateStub<ICustomerDataAccess> ();

			this.customerBusinessFacade
				= new CustomerBusinessFacade
					(
						this.custValidatorMock,
						this.custDataAccessMock
					);
		}

		public void Given_that_I_have_a_valid_Customer ()
		{
			Customer newCustomer = null;
			IDictionary<string, string> result = null;

			// Arrange
			before = () => { 
					this.SetUpCustomerValidator_HappyPath ();
					this.SetUpCustomerDataAccess_HappyPath ();
					newCustomer = Builder<Customer>.CreateNew ().Build ();
				};

			// Act
			context ["When I call CreateCustomer on the Customer Facade"] = () => {
				act = () =>
				{
					result = this.customerBusinessFacade.CreateCustomer (newCustomer);
				};

				// Assert
				it ["Should create the customer successfully."] = () => {
					Ensure.That (result != null, "There should not be any validation failures");
					this.custDataAccessMock.AssertWasCalled (x => x.SaveCustomer (Arg<Customer>.Is.Anything, Arg<LoyaltyStatus>.Is.Anything));
					Ensure.That (newCustomer.Id == 1, "Customer ID must be set when customer is saved.");
				};
			};
		}

		public void Given_that_I_have_an_invalid_Customer ()
		{
			Customer newCustomer = null;
			IDictionary<string, string> result = null;

			// Arrange
			before = () => {
				this.SetUpCustomerValidator_EdgeCase ();
				newCustomer = Builder<Customer>.CreateNew ().Build ();
			};

			// Act
			context ["When I call CreateCustomer on the Customer Facade"] = () => {
				act = () =>
				{
					result = this.customerBusinessFacade.CreateCustomer (newCustomer);
				};

				// Assert
				it ["Should create the customer successfully."] = () => {
					Ensure.That (null != result, "There should be validation failures");
				};
			};
		}

		// ================
		// Mocking Methods
		// ================

		private void SetUpCustomerValidator_HappyPath ()
		{
			this.custValidatorMock
				.Stub (x => x.Validate (Arg<Customer>.Is.Anything))
				.Return (default (IDictionary<string, string>));
		}

		private void SetUpCustomerDataAccess_HappyPath ()
		{
			this.custDataAccessMock
				.Stub (x => x.SaveCustomer (Arg<Customer>.Is.Anything, Arg<LoyaltyStatus>.Is.Anything))
				.Callback ((Customer c, LoyaltyStatus l) => {
					c.Id = 1;
					l.IsLoyal = true;
				});
		}

		private void SetUpCustomerValidator_EdgeCase ()
		{
			this.custValidatorMock
				.Stub (x => x.Validate (Arg<Customer>.Is.Anything))
				.Return (new Dictionary<string, string> { { "FirstName", "FirstName cannot be null." } });
		}
	}
}