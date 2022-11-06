using Xbehave;
using FakeItEasy;
using NFluent;
using FizzWare.NBuilder;

using UnitTestGenerator.Logic.Test.LibraryExamples.Support;

namespace UnitTestGenerator.Logic.Test.LibraryExamples
{
	public sealed class CustomerFacade_Set6_XBehave_FakeItEasy_NFluent_Test
	{
		private CustomerBusinessFacade customerBusinessFacade;
		private ICustomerValidator custValidatorMock;
		private ICustomerDataAccess custDataAccessMock;

		// ============
		// Test Cases
		// ============

		[Background]
		public void SetUp ()
		{
			this.custValidatorMock = A.Fake<ICustomerValidator>();
			this.custDataAccessMock = A.Fake<ICustomerDataAccess>();

			this.customerBusinessFacade
				= new CustomerBusinessFacade
					(
						this.custValidatorMock,
						this.custDataAccessMock
					);
		}

		[Scenario]
		public void ShouldCreateCustomer_WhenValidCustomerPassed ()
		{
			Customer newCustomer = null;
			IDictionary<string, string> result = null;

			// Arrange
			"Given that I have a valid customer"
				.x (() => {
					this.SetUpCustomerValidator_HappyPath ();
					this.SetUpCustomerDataAccess_HappyPath ();
					newCustomer = Builder<Customer>.CreateNew ().Build ();
				});


			// Act
			"When I call CreateCustomer on the Customer Facade"
				.x (() => {
					result = this.customerBusinessFacade.CreateCustomer (newCustomer);
				});

			// Assert
			"Then it should create the customer successfully."
				.x (() => {

					Check.That (result).IsNull ();
					A.CallTo (() => this.custDataAccessMock.SaveCustomer (A<Customer>.Ignored, A<LoyaltyStatus>.Ignored))
						.MustHaveHappened ();
					Check.That (newCustomer.Id).IsEqualTo (1);
				});
		}

		[Scenario]
		public void ShouldReturnValidationErrors_WhenInvalidCustomerPassed ()
		{
			Customer newCustomer = null;
			IDictionary<string, string> result = null;

			// Arrange
			"Given that I have an invalid customer"
				.x (() => {
					this.SetUpCustomerValidator_EdgeCase ();
					newCustomer = Builder<Customer>.CreateNew ().Build ();
				});


			// Act
			"When I call CreateCustomer on the Customer Facade"
				.x (() => {
					result = this.customerBusinessFacade.CreateCustomer (newCustomer);
				});

			// Assert
			"Then it should return validation failure results."
				.x (() => {
					Check.That (result).IsNotNull ();
				});
		}

		// ================
		// Mocking Methods
		// ================

		private void SetUpCustomerValidator_HappyPath ()
		{
			A.CallTo (() => this.custValidatorMock.Validate (A<Customer>.Ignored))
				.Returns (default (IDictionary<string, string>));
		}

		private void SetUpCustomerDataAccess_HappyPath ()
		{
			A.CallTo (() => this.custDataAccessMock.SaveCustomer (A<Customer>.Ignored, A<LoyaltyStatus>.Ignored))
				.Invokes ((Customer c, LoyaltyStatus l) =>
				{
					c.Id = 1;
					l.IsLoyal = true;
				});
		}

		private void SetUpCustomerValidator_EdgeCase ()
		{
			A.CallTo (() => this.custValidatorMock.Validate (A<Customer>.Ignored))
				.Returns (new Dictionary<string, string> { { "FirstName", "FirstName cannot be null." } });
		}
	}
}