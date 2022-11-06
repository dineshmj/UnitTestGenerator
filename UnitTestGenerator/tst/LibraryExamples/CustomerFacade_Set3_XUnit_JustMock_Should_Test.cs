﻿using Xunit;
using Telerik.JustMock;
using Should;
using FizzWare.NBuilder;

using UnitTestGenerator.Logic.Test.LibraryExamples.Support;

namespace UnitTestGenerator.Logic.Test.LibraryExamples
{
	public sealed class CustomerFacade_Set3_XUnit_JustMock_Should_Test
	{
		private CustomerBusinessFacade customerBusinessFacade;
		private ICustomerValidator custValidatorMock;
		private ICustomerDataAccess custDataAccessMock;

		// ============
		// Test Cases
		// ============

		public CustomerFacade_Set3_XUnit_JustMock_Should_Test ()
		{
			this.custValidatorMock = Mock.Create<ICustomerValidator>();
			this.custDataAccessMock = Mock.Create<ICustomerDataAccess>();

			this.customerBusinessFacade
				= new CustomerBusinessFacade
					(
						this.custValidatorMock,
						this.custDataAccessMock
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
			var validationFailures = this.customerBusinessFacade.CreateCustomer (newCustomer);

			// Assert
			validationFailures.ShouldBeNull ();
			newCustomer.Id.ShouldEqual (1);
		}

		[Fact]
		public void ShouldReturnValidationErrors_WhenInvalidCustomerPassed ()
		{
			// Arrange
			this.SetUpCustomerValidator_EdgeCase ();
			var newCustomer = Builder<Customer>.CreateNew ().Build ();

			// Act
			var validationFailures = this.customerBusinessFacade.CreateCustomer (newCustomer);

			// Assert
			validationFailures.ShouldNotBeNull ();
		}

		~CustomerFacade_Set3_XUnit_JustMock_Should_Test ()
		{
			this.custValidatorMock = null;
			this.custDataAccessMock = null;
		}

		// ================
		// Mocking Methods
		// ================

		private void SetUpCustomerValidator_HappyPath ()
		{
			Mock.Arrange (() => this.custValidatorMock.Validate (Arg.IsAny<Customer> ()))
				.Returns (default (IDictionary<string, string>));
		}

		private void SetUpCustomerDataAccess_HappyPath ()
		{
			Mock.Arrange (() => this.custDataAccessMock.SaveCustomer (Arg.IsAny<Customer> (), Arg.IsAny<LoyaltyStatus> ()))
				.DoInstead ((Customer c, LoyaltyStatus l) =>
				{
					c.Id = 1;
					l.IsLoyal = true;
				})
				.MustBeCalled ();
				// TODO: Dummy lambda function inside Do () method - please correct the lambda
				// TODO: expression to deal with the expectation after the void method call.
		}

		private void SetUpCustomerValidator_EdgeCase ()
		{
			Mock.Arrange (() => this.custValidatorMock.Validate (Arg.IsAny<Customer> ()))
				.Returns (new Dictionary<string, string> { { "FirstName", "FirstName cannot be null."} });
		}
	}
}