namespace UnitTestGenerator.Logic.Support.Utilities
{
	public static class UTGenHelper
	{
		public static string GetMeaningfulData (this string typeName, bool isHappy)
		{
			switch (typeName)
			{
				case "byte":
				case "short":
				case "int":
				case "long":
				case "float":
				case "double":
					return "0";

				case "string":
					return isHappy ? "\"some string\"" : "\"some other string\"";

				case "bool":
					return isHappy ? "true" : "false";

				case "byte []":
				case "short []":
				case "int []":
				case "long []":
				case "float []":
				case "double []":
					return isHappy ? "new [] { 1, 2, 3 }" : "new [] { 8, 9, 10 }";

				case "string []":
					return isHappy ? "new [] { \"abc\", \"def\", \"ghi\" }" : "new [] { \"pqr\", \"uvw\", \"xyz\" }";

				case "DateTime":
					return isHappy ? "new DateTime (2000, 1, 1)" : "new DateTime (1980, 1, 1)";

				default:
					return null;
			}
		}
	}
}