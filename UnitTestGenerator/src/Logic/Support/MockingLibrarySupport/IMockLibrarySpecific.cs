using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator.Logic.Support.MockingLibrarySupport
{
	public interface IMockLibrarySpecific
	{
		MockingLibrary [] CanHandleMockingLibraries ();
		
		bool IsMockingLibraryUsed { get; }

		string DeclareDependency (DependencyInfo dependency);

		string AssignDependency (DependencyInfo dependency);

		string GetMockedObject (DependencyInfo dependency);

		string GetVerifyAll (DependencyCallInfo oneDependencyCall);

		IList<string> GetMockedDependencyCall (DependencyCallInfo dependencyCallInfo, bool voidAssertionsRequired);
	}
}