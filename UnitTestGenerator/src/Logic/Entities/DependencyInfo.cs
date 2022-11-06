namespace UnitTestGenerator.Logic.Entities
{
	public sealed class DependencyInfo
	{
		public Type DependencyAbstractionType { get; }

		public string Namespace { get; }

		public string PrivateReadOnlyFieldName { get; }

		public DependencyInfo (Type dependencyAbstractionType, string privateReadOnlyFieldName)
		{
			this.DependencyAbstractionType = dependencyAbstractionType;
			this.Namespace = dependencyAbstractionType.Namespace;

			this.PrivateReadOnlyFieldName = privateReadOnlyFieldName;
		}
	}
}