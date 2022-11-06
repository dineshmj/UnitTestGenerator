using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.FALibrarySupport;
using UnitTestGenerator.Logic.Support.MockingLibrarySupport;
using UnitTestGenerator.Logic.Support.TestDataSupport;
using UnitTestGenerator.Logic.Support.UTLibrarySupport;

namespace UnitTestGenerator.Logic.Support
{
	public sealed class UTGenerationSupport
	{
		public IPrepareUsingDirectives UsingProvider { get; }

		public IUnitTestLibrarySpecific UtLibraryProvider { get; }

		public IMockLibrarySpecific MockLibraryProvider { get; }

		public IFALibrarySpecific FluentLibraryProvider { get; }

		public ITestDataLibrarySpecific TestDataProvider { get; }

		public UnitTestMethodNamingStyle UnitTestMethodNamingStyle { get; }

		public TargetMethodCallContext TargetMethodCallContext { get; set; }

		public bool AddAssertionsForVoidDependencyCalls { get; }

		public bool AddRelevantUsingNamespacesEvenIfNotUsed { get; }

		public bool AddToDoDirectiveComments { get; }

		public bool AddFriendlyComments { get; }

		public UTGenerationSupport
			(
				IPrepareUsingDirectives usingProvider,
				IUnitTestLibrarySpecific utLibraryProvider,
				IMockLibrarySpecific mockLibraryProvider,
				IFALibrarySpecific faLibraryProvider,
				ITestDataLibrarySpecific testDataProvider,
				bool addAssertionsForVoidDependencyCalls,
				bool addRelevantUsingNamespacesEvenIfNotUsed,
				bool addToDoDirectiveComments,
				bool addFriendlyComments
			)
		{
			this.UsingProvider = usingProvider;

			this.UtLibraryProvider = utLibraryProvider;
			this.MockLibraryProvider = mockLibraryProvider;
			this.FluentLibraryProvider = faLibraryProvider;
			this.TestDataProvider = testDataProvider;

			this.AddAssertionsForVoidDependencyCalls = addAssertionsForVoidDependencyCalls;
			this.AddRelevantUsingNamespacesEvenIfNotUsed = addRelevantUsingNamespacesEvenIfNotUsed;
			this.AddToDoDirectiveComments = addToDoDirectiveComments;
			this.AddFriendlyComments = addFriendlyComments;
		}

		public void SetContextFor
			(
				PublicMember publicMember,
				IList<DependencyInfo> dependencies,
				IList<Type> parameterTypes
			)
		{
			this.TargetMethodCallContext = new TargetMethodCallContext (publicMember, dependencies, parameterTypes, publicMember.DependencyCalls);
		}
	}
}