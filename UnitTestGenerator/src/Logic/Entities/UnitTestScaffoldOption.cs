namespace UnitTestGenerator.Logic.Entities
{
	public sealed class UnitTestScaffoldOption
	{
		public UnitTestLibrary UnitTestLibrary { get; }

		public MockingLibrary MockingLibrary { get; }

		public FluentAssertionLibrary FluentAssertionLibrary { get; }

		public TestDataPreparationLibrary TestDataPreparationLibrary { get; }

		public UnitTestMethodNamingStyle UnitTestMethodNamingStyle { get; }

		public bool AddAssertionsForVoidDependencyMethodCalls { get; }

		public bool AddRelevantUsingNamespacesEvenIfNotUsed { get; }

		public bool AddToDoDirectiveComments { get; }

		public bool AddFriendlyComments { get; }

		public UnitTestScaffoldOption
			(
				UnitTestLibrary unitTestLibrary,
				MockingLibrary mockingLibrary,
				FluentAssertionLibrary fluentAssertionLibrary,
				TestDataPreparationLibrary testDataPreparationLibrary,
				UnitTestMethodNamingStyle unitTestMethodNamingStyle,
				bool addAssertionsForVoidDependencyMethodCalls,
				bool addRelevantUsingNamespacesEvenIfNotUsed,
				bool addToDoDirectiveComments,
				bool addFriendlyComments
			)
		{
			// Libraries.
			this.UnitTestLibrary = unitTestLibrary;
			this.MockingLibrary = mockingLibrary;
			this.FluentAssertionLibrary = fluentAssertionLibrary;
			this.TestDataPreparationLibrary = testDataPreparationLibrary;

			// UT method naming style.
			this.UnitTestMethodNamingStyle = unitTestMethodNamingStyle;

			// Options.
			this.AddAssertionsForVoidDependencyMethodCalls = addAssertionsForVoidDependencyMethodCalls;
			this.AddRelevantUsingNamespacesEvenIfNotUsed = addRelevantUsingNamespacesEvenIfNotUsed;
			this.AddToDoDirectiveComments = addToDoDirectiveComments;
			this.AddFriendlyComments = addFriendlyComments;
		}
	}
}