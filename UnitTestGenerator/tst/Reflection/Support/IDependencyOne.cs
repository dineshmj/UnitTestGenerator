namespace UnitTestGenerator.Logic.Test.Reflection.Support
{
	internal interface IDependencyOne
	{
		int AddNumbers (int a, int b);

		int AddNumbers (int a, int b, int c);

		int AddNumbers (int a, int b, int c, int d);

		string Concatenate (string s1, string s2);

		string Concatenate (string s1, string s2, string s3);
	}
}