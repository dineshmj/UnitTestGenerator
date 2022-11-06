using NUnit.Framework;
using Moq;
using FluentAssertions;
using FizzWare.NBuilder;

using UnitTestGenerator.Logic.Test.LibraryExamples.Support;

namespace UnitTestGenerator.Logic.Test.LibraryExamples
{
	[TestFixture]
	public sealed class CustomerFacade_Set0_Ctor_NUnit_Moq_FA_Test
	{
		private CustomerBusinessFacade customerBusinessFacade;
		private Mock<ICustomerValidator> custValidatorMock;
		private Mock<ICustomerDataAccess> custDataAccessMock;

		// ============
		// Test Cases
		// ============

		[Test]
		public void Constructor_Test ()
		{
			// Arrange
			this.custValidatorMock = new Mock<ICustomerValidator> ();
			this.custDataAccessMock = new Mock<ICustomerDataAccess> ();
			Exception caughtException = null;

			// Act
			try
			{
				this.customerBusinessFacade
					= new CustomerBusinessFacade
						(
							this.custValidatorMock.Object,
							this.custDataAccessMock.Object
						);
			}
			catch (Exception ex)
			{
				caughtException = ex;
			}

			// Assert
			caughtException.Should ().BeNull ();
			this.customerBusinessFacade.Should ().NotBeNull ();
		}
	}
}