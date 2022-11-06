namespace UnitTestGenerator.Logic.Test.Reflection.Support
{
	internal interface ISomeClass
	{
		string HelloMessage ();

		string PrintMessage (string message);

		string PrintMessage (string salutation, string message);
	}
}