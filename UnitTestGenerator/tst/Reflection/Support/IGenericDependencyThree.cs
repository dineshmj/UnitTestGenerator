namespace UnitTestGenerator.Logic.Test.Reflection.Support
{
	internal interface IGenericDependencyThree<TTypeOne, TTypeTwo>
	{
		TTypeTwo FindBiggest (TTypeOne numberOne, TTypeOne numberTwo, TTypeOne numberThree);
	}
}