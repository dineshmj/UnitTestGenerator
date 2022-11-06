using FluentAssertions;
using NUnit.Framework;

using UnitTestGenerator.Logic.Core;
using UnitTestGenerator.Logic.Test.Reflection.Support;

namespace UnitTestGenerator.Test.ILReader
{
	[TestFixture]
    public sealed class IntLangReaderTest
    {
        [Test]
        public void ShouldTakeGreediatestConstructor ()
        {
            // Arrange.
            var target = new IntermediateLanguageReader ();
            var targetType = typeof (SomeClass);

            var depTypeOne = typeof (IDependencyOne);
            var depTypeTwo = typeof (IDependencyTwo);
            var depTypeThree = typeof (IGenericDependencyThree<int, IGenericDependency<char>>);

            // Act
			var dependencies = target.GetDependencies (targetType);

            // Assert
            dependencies.Count.Should ().Be (3);

            // Expectations on dependency type.
            dependencies [0].DependencyAbstractionType.Should ().Be (depTypeOne);
            dependencies [1].DependencyAbstractionType.Should ().Be (depTypeTwo);
            dependencies [2].DependencyAbstractionType.Should ().Be (depTypeThree);

			// Expectations on namespaces.
			dependencies [0].Namespace.Should ().Be (depTypeOne.Namespace);
			dependencies [1].Namespace.Should ().Be (depTypeTwo.Namespace);
			dependencies [2].Namespace.Should ().Be (depTypeThree.Namespace);

			// Expectations on the field that remembers the injected dependencies.
			dependencies [0].PrivateReadOnlyFieldName.Should ().Be (nameof (SomeClass.dependencyOne));
			dependencies [1].PrivateReadOnlyFieldName.Should ().Be (nameof (SomeClass.dependencyTwo));
			dependencies [2].PrivateReadOnlyFieldName.Should ().Be (nameof (SomeClass.dependencyThree));
		}

		[Test]
		public void ShouldGetListOfDependencyMethodCalls ()
		{
			// Arrange.
			var ilReader = new IntermediateLanguageReader ();
			var targetType = typeof (SomeClass);
			var targetMethod = targetType.GetMethod (nameof (SomeClass.HelloMessage));

			var depTypeOne = typeof (IDependencyOne);
			var depTypeTwo = typeof (IDependencyTwo);
			var depTypeThree = typeof (IGenericDependencyThree<int, IGenericDependency<char>>);

			// Act
			var dependencyMethodCalls = ilReader.GetDependencyMethodCalls (targetMethod);

			// Assert
			dependencyMethodCalls.Count.Should ().Be (4);

			// Expectations on dependency method name.
			dependencyMethodCalls [0].Method.Name.Should ().Be (nameof (IDependencyOne.AddNumbers));
			dependencyMethodCalls [1].Method.Name.Should ().Be (nameof (IDependencyTwo.MultiplyNumbers));
			dependencyMethodCalls [2].Method.Name.Should ().Be (nameof (IGenericDependencyThree<int, IGenericDependency<char>>.FindBiggest));
			dependencyMethodCalls [3].Method.Name.Should ().Be (nameof (IDependencyOne.Concatenate));

			// Expectations on dependency method parameters.
			dependencyMethodCalls [0].ParameterTypes.Count.Should ().Be (4);                // AddNumbers () - the greadiest overload has 4 arguments.
			dependencyMethodCalls [0].ParameterTypes [0].Name.Should ().Be (nameof (Int32));
			dependencyMethodCalls [0].ParameterTypes [1].Name.Should ().Be (nameof (Int32));
			dependencyMethodCalls [0].ParameterTypes [2].Name.Should ().Be (nameof (Int32));
			dependencyMethodCalls [0].ParameterTypes [3].Name.Should ().Be (nameof (Int32));

			dependencyMethodCalls [1].ParameterTypes.Count.Should ().Be (4);                // MultiplyNumbers () - the greadiest overload has 4 arguments.
			dependencyMethodCalls [1].ParameterTypes [0].Name.Should ().Be (nameof (Int32));
			dependencyMethodCalls [1].ParameterTypes [1].Name.Should ().Be (nameof (Int32));
			dependencyMethodCalls [1].ParameterTypes [2].Name.Should ().Be (nameof (Int32));
			dependencyMethodCalls [1].ParameterTypes [3].Name.Should ().Be (nameof (Int32));

			dependencyMethodCalls [2].ParameterTypes.Count.Should ().Be (3);                // FindBiggest () - the greadiest overload has 3 arguments.
			dependencyMethodCalls [2].ParameterTypes [0].Name.Should ().Be (nameof (Int32));
			dependencyMethodCalls [2].ParameterTypes [1].Name.Should ().Be (nameof (Int32));
			dependencyMethodCalls [2].ParameterTypes [2].Name.Should ().Be (nameof (Int32));

			dependencyMethodCalls [3].ParameterTypes.Count.Should ().Be (3);                // Concatenate () - the greadiest overload has 3 arguments.
			dependencyMethodCalls [3].ParameterTypes [0].Name.Should ().Be (nameof (String));
			dependencyMethodCalls [3].ParameterTypes [1].Name.Should ().Be (nameof (String));
			dependencyMethodCalls [3].ParameterTypes [2].Name.Should ().Be (nameof (String));

			// Expectations on dependency abstraction types.
			dependencyMethodCalls [0].Dependency.DependencyAbstractionType.Should ().Be (typeof (IDependencyOne));          // AddNumbers ().
			dependencyMethodCalls [1].Dependency.DependencyAbstractionType.Should ().Be (typeof (IDependencyTwo));          // MultiplyNumbers ().
			dependencyMethodCalls [2].Dependency.DependencyAbstractionType.Should ().Be (typeof (IGenericDependencyThree<int, IGenericDependency<char>>));          // FindBiggest ().
			dependencyMethodCalls [3].Dependency.DependencyAbstractionType.Should ().Be (typeof (IDependencyOne));          // Concatenate ().
		}
	}
}