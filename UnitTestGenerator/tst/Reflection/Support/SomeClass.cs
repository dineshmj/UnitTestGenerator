namespace UnitTestGenerator.Logic.Test.Reflection.Support
{
	internal sealed class SomeClass
		: ISomeClass
	{
		// Fields are declared to be internal so that they can be accessed for their names
		// from within Unit Tests.
		internal readonly IDependencyOne dependencyOne;
		internal readonly IDependencyTwo dependencyTwo;
		internal readonly IGenericDependencyThree<int, IGenericDependency<char>> dependencyThree;

		public SomeClass ()
		{
			this.dependencyOne = null;
			this.dependencyTwo = null;
			this.dependencyThree = null;
		}

		public SomeClass (IDependencyOne dependencyOne)
		{
			this.dependencyOne = dependencyOne;
			this.dependencyTwo = null;
			this.dependencyThree = null;
		}

		public SomeClass (IDependencyOne dependencyOne, IDependencyTwo dependencyTwo)
		{
			this.dependencyOne = dependencyOne;
			this.dependencyTwo = dependencyTwo;
			this.dependencyThree = null;
		}

		public SomeClass (IDependencyOne dependencyOne, IDependencyTwo dependencyTwo, IGenericDependencyThree<int, IGenericDependency<char>> dependencyThree)
		{
			this.dependencyOne = dependencyOne;
			this.dependencyTwo = dependencyTwo;
			this.dependencyThree = dependencyThree;
		}

		public string HelloMessage ()
		{
			var sum = this.dependencyOne.AddNumbers(1, 2);
			var product = this.dependencyTwo.MultiplyNumbers(sum, 5);
			var biggest = this.dependencyThree.FindBiggest(1, 2, 3);

			return  this.dependencyOne.Concatenate (sum.ToString (), product.ToString (), biggest.ToString ());
		}

		public string PrintMessage (string message)
		{
			var sum = this.dependencyOne.AddNumbers (1, 2);
			var product = this.dependencyTwo.MultiplyNumbers (sum, 5);
			var biggest = this.dependencyThree.FindBiggest (1, 2, 3);

			return message + ": " + this.dependencyOne.Concatenate (sum.ToString (), product.ToString (), biggest.ToString ());
		}

		public string PrintMessage (string salutation, string message)
		{
			var sum = this.dependencyOne.AddNumbers (1, 2);
			var product = this.dependencyTwo.MultiplyNumbers (sum, 5);
			var biggest = this.dependencyThree.FindBiggest (1, 2, 3);

			return salutation + ", " + message + ": " + this.dependencyOne.Concatenate (sum.ToString (), product.ToString (), biggest.ToString ());
		}
	}
}