namespace UnitTestGenerator.Logic.Test.Reflection.Support
{
	internal interface IGenericDependency<TNumber>
		where TNumber : IComparable
	{
		TNumber GetSquareOf (TNumber number);
	}
}