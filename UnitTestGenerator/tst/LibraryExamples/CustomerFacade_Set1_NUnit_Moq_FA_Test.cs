using NUnit.Framework;
using Moq;
using FluentAssertions;
using FizzWare.NBuilder;

using UnitTestGenerator.Logic.Test.LibraryExamples.Support;

namespace UnitTestGenerator.Logic.Test.LibraryExamples
{
	[TestFixture]
	public sealed class CustomerFacade_Set1_NUnit_Moq_FA_Test
	{
		private CustomerBusinessFacade customerBusinessFacade;
		private Mock<ICustomerValidator> custValidatorMock;
		private Mock<ICustomerDataAccess> custDataAccessMock;

		[SetUp]
		public void SetUp ()
		{
			this.custValidatorMock = new Mock<ICustomerValidator>();
			this.custDataAccessMock = new Mock<ICustomerDataAccess>();

			this.customerBusinessFacade
				= new CustomerBusinessFacade
					(
						this.custValidatorMock.Object,
						this.custDataAccessMock.Object
					);
		}

		// ============
		// Test Cases
		// ============

		[Test]
		public void ShouldCreateCustomer_WhenValidCustomerPassed ()
		{
			// Arrange
			this.SetUpCustomerValidator_HappyPath ();
			this.SetUpCustomerDataAccess_HappyPath ();
			var newCustomer = Builder<Customer>.CreateNew ().Build ();

			// Act
			var result = this.customerBusinessFacade.CreateCustomer (newCustomer);

			// Assert
			result.Should ().BeNull ();
			newCustomer.Id.Should ().Be (1);
			this.custDataAccessMock.VerifyAll ();
		}

		[Test]
		public void ShouldReturnValidationErrors_WhenInvalidCustomerPassed ()
		{
			// Arrange
			this.SetUpCustomerValidator_EdgeCase ();
			var newCustomer = Builder<Customer>.CreateNew ().Build ();

			// Act
			var result = this.customerBusinessFacade.CreateCustomer (newCustomer);

			// Assert
			result.Should ().NotBeNull ();
		}

		// ================
		// Mocking Methods
		// ================

		private void SetUpCustomerValidator_HappyPath ()
		{
			this.custValidatorMock
				.Setup (cv => cv.Validate (It.IsAny<Customer> ()))
				.Returns (default (IDictionary<string, string>));
		}

		private void SetUpCustomerDataAccess_HappyPath ()
		{
			this.custDataAccessMock
				.Setup (cv => cv.SaveCustomer (It.IsAny<Customer> (), It.IsAny <LoyaltyStatus> ()))
				.Callback ((Customer c, LoyaltyStatus l) => {
					c.Id = 1;
					l.IsLoyal = true;
				});
		}

		private void SetUpCustomerValidator_EdgeCase ()
		{
			this.custValidatorMock
				.Setup (cv => cv.Validate (It.IsAny<Customer> ()))
				.Returns (new Dictionary<string, string> { { "FirstName", "FirstName cannot be null."} });
		}
	}
}