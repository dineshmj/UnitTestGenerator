using Xunit;
using NSubstitute;
using Shouldly;
using FizzWare.NBuilder;

using UnitTestGenerator.Logic.Test.LibraryExamples.Support;

namespace UnitTestGenerator.Logic.Test.LibraryExamples
{
	public sealed class CustomerFacade_Set2_XUnit_NSub_Shouldly_Test
	{
		private CustomerBusinessFacade customerBusinessFacade;
		private ICustomerValidator custValidatorSub;
		private ICustomerDataAccess custDataAccessSub;

		// ============
		// Test Cases
		// ============

		public CustomerFacade_Set2_XUnit_NSub_Shouldly_Test ()
		{
			this.custValidatorSub = Substitute.For<ICustomerValidator>();
			this.custDataAccessSub = Substitute.For<ICustomerDataAccess>();

			this.customerBusinessFacade
				= new CustomerBusinessFacade
					(
						this.custValidatorSub,
						this.custDataAccessSub
					);
		}

		[Fact]
		public void ShouldCreateCustomer_WhenValidCustomerPassed ()
		{
			// Arrange
			this.SetUpCustomerValidator_HappyPath ();
			this.SetUpCustomerDataAccess_HappyPath ();
			var newCustomer = Builder<Customer>.CreateNew ().Build ();

			// Act
			var result = this.customerBusinessFacade.CreateCustomer (newCustomer);

			// Assert
			result.ShouldBe (null);
			newCustomer.Id.ShouldBe (1);
			this.custDataAccessSub.Received ();
		}

		[Fact]
		public void ShouldReturnValidationErrors_WhenInvalidCustomerPassed ()
		{
			// Arrange
			this.SetUpCustomerValidator_EdgeCase ();
			var newCustomer = Builder<Customer>.CreateNew ().Build ();

			// Act
			var result = this.customerBusinessFacade.CreateCustomer (newCustomer);

			// Assert
			result.ShouldNotBe (null);
		}

		~CustomerFacade_Set2_XUnit_NSub_Shouldly_Test ()
		{
			this.custValidatorSub = null;
			this.custDataAccessSub = null;
		}

		// ================
		// Mocking Methods
		// ================

		private void SetUpCustomerValidator_HappyPath ()
		{
			this.custValidatorSub
				.Validate (Arg.Any<Customer> ())
				.Returns (default (IDictionary<string, string>));
		}

		private void SetUpCustomerDataAccess_HappyPath ()
		{
			this.custDataAccessSub
				.SaveCustomer
					(
						Arg.Do<Customer> (c =>
						{
							c.Id = 1;
						}),
						Arg.Do<LoyaltyStatus> (l =>
						{
							l.IsLoyal = true;
						})
					);
				// TODO: Dummy lambda function inside Do () method - please correct the lambda
				// TODO: expression to deal with the expectation after the void method call.
		}

		private void SetUpCustomerValidator_EdgeCase ()
		{
			this.custValidatorSub
				.Validate (Arg.Any<Customer> ())
				.Returns (new Dictionary<string, string> { { "FirstName", "FirstName cannot be null."} });
		}
	}
}