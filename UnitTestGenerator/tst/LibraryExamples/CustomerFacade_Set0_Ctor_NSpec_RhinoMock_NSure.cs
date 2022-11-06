using NSpec;
using Rhino.Mocks;
using NSure;
using FizzWare.NBuilder;

using UnitTestGenerator.Logic.Test.LibraryExamples.Support;

namespace UnitTestGenerator.Logic.Test.LibraryExamples
{
	public sealed class CustomerFacade_Set0_Ctor_NSpec_RhinoMock_NSure
		: nspec
	{
		// Target class.
		private CustomerBusinessFacade customerBusinessFacade;

		// Mocked dependenceis.
		private ICustomerValidator custValidatorMock;
		private ICustomerDataAccess custDataAccessMock;

		// Others.
		private Exception caughtException = null;


		// ============
		// Test Cases
		// ============

		public void Constructor_Test ()
		{
			// Arrange
			before = () => {
				this.custValidatorMock = MockRepository.GenerateStub<ICustomerValidator> ();
				this.custDataAccessMock = MockRepository.GenerateStub<ICustomerDataAccess> ();
				this.caughtException = null;
			};

			// Act
			context ["When I try to instantiate the Customer Facade"] = () => {
				act = () =>
				{
					try
					{
						this.customerBusinessFacade = new CustomerBusinessFacade (this.custValidatorMock, this.custDataAccessMock);
					}
					catch (Exception ex)
					{
						this.caughtException = ex;
					}
				};

				// Assert
				it ["Should instantiate successfully."] = () => {
					Ensure.That (this.caughtException == null, "Null value is not expected.");
				};
			};
		}
	}
}