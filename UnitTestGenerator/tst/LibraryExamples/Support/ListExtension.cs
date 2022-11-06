namespace UnitTestGenerator.Logic.Test.LibraryExamples.Support
{
	public static class ListExtension
	{
		public static bool In (this string text, params string [] textValues)
		{
			return textValues.Contains (text);
		}

		public static bool IsOneOf (this int number, params int [] numbers)
		{
			return numbers.Contains (number);
		}
	}
}