namespace UnitTestGenerator.Logic.NewCore
{
	public sealed class DependencyDetail
	{
		public string FieldName { get; set; }

		public string Abstraction { get; set; }

		public string MethodName { get; set; }

		public List<string> Arguments { get; set; } = new List<string> ();
	}
}