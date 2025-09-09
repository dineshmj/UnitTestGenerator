using System.Text;

using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support;
using UnitTestGenerator.Logic.Support.Extensions;
using UnitTestGenerator.Logic.Support.FALibrarySupport;
using UnitTestGenerator.Logic.Support.MockingLibrarySupport;
using UnitTestGenerator.Logic.Support.TestDataSupport;
using UnitTestGenerator.Logic.Support.UTLibrarySupport;

namespace UnitTestGenerator.Logic.Core
{
	public sealed partial class UnitTestScaffolder
		: IUnitTestScaffolder
	{
		private const string TEST_DATA_LIBRARY_DECLARATION_LINE_PLACE_HOLDER = ">>]--TEST_DATA_LIBRARY_DECLARATION_LINE_PLACE_HOLDER--[<<";
		private readonly IILReader reflector;
		private readonly IDictionary<PublicMember, string> utCodeDictionary;
		private UTGenerationSupport utGen;
		private TargetMethodCallContext context;

		public UnitTestScaffolder ()
		{
			this.reflector = new IntermediateLanguageReader ();
			this.utCodeDictionary = new Dictionary<PublicMember, string> ();
		}

		public IDictionary<PublicMember, string> GenerateUnitTestsFor
			(
				IList<PublicMember> selectedPublicMembers,
				UnitTestScaffoldOption scaffoldOption
			)
		{
			this.utCodeDictionary.Clear ();
			this.utGen = this.PrepareUTGenerationSupport (scaffoldOption);

			selectedPublicMembers
				.ToList ()
				.ForEach (publicMember => {
					// Get target class, and target method details.
					var targetClassDependencies = this.reflector.GetDependencies (publicMember.ReflectedMemberInfo.DeclaringType);
					var methodParameterTypes = publicMember.ReflectedMemberInfo.GetParameters ().Select (p => p.ParameterType).ToList ();

					// Set the method call context.
					this.utGen.SetContextFor (publicMember, targetClassDependencies, methodParameterTypes);
					this.context = this.utGen.TargetMethodCallContext;

					var builder = new StringBuilder ();

					// UT class's Namespace.
					this.AddNamespace (builder);

					// UT class's name.
					this.AddUTClassDecoratorAttribute (builder);
					this.AddUTClassName (builder);
					this.AddUTClassInheritingParentName (builder);

					// Private fields of the Unit Test class.
					this.DeclareTargetClassPrivateFields (builder);

					var testDataLibraryDeclarationLine = this.DeclareTestDataSupportField ();
					builder.Append (TEST_DATA_LIBRARY_DECLARATION_LINE_PLACE_HOLDER);

					this.DeclareDependenciesIfRelevant (builder);
					this.AddCaughtExceptionDeclaration (builder);

					// Add Unit Test Initialier method. For some UT libraries, it would be the constructor of the class itself.
					this.AddInitializerMethodIfRegularMethod (builder);

					// Add TEST CASES flower comment.
					this.AddTestCasesFlowerComment (builder);

					// If this is a constructor, add happy and edge-case Unit Tests for the same.
					var targetVaribleName = publicMember.ReflectedMemberInfo.DeclaringType.Name.ToCamelCase ();

					this.AddConstructorUnitTestIfRelevant (builder, isHappy: true, targetVaribleName);
					builder.Append ("\r\n");
					this.AddConstructorUnitTestIfRelevant (builder, isHappy: false, targetVaribleName);

					// Add a sample happy path and edge case Unit Tests, if it is a method.
					this.AddUnitTestsForMethodIfRelevant (builder);

					// End Unit Test clss.
					builder.AppendLine ("\t}");
					builder.Append ("}");

					var usingBlock
						= utGen
							.UsingProvider
							.ScaffoldUsingStatements
								(
									publicMember,
									scaffoldOption,
									utGen.MockLibraryProvider.IsMockingLibraryUsed,
									utGen.TestDataProvider.IsTestDataLibraryUsed
								);
					// Add generated Unit Test code to dictionary.
					var utCode = $"{usingBlock}\r\n\r\n{builder}";
					utCode = utCode
						.Replace (
							TEST_DATA_LIBRARY_DECLARATION_LINE_PLACE_HOLDER,
							(utGen.TestDataProvider.IsTestDataLibraryUsed ? testDataLibraryDeclarationLine : string.Empty)
						);

					utCodeDictionary.Add (publicMember, utCode);
				});

			return utCodeDictionary;
		}

		private string ArriveAtUnitTestMethodNameFor (bool isHappyPath)
		{
			// Context.
			var methodName = utGen.TargetMethodCallContext.MethodName;
			var overloadRankText = this.utGen.TargetMethodCallContext.OverloadRankText;

			// Options.
			var utMethodNamingStyle = this.utGen.UnitTestMethodNamingStyle;

			switch (utMethodNamingStyle)
			{
				case UnitTestMethodNamingStyle.MethodNameStartsWithShould:
					if (isHappyPath)
					{
						return $"ShouldSuccessfullyExecute_WhenICall_{methodName}_WithValid_InputParameters";
					}
					else
					{
						return $"ShouldFailToExecute_WhenICall_{methodName}_WithInvalid_InputParameters";
					}

				case UnitTestMethodNamingStyle.MethodNameStartsWithWhen:
					if (isHappyPath)
					{
						return $"WhenICall_{methodName}_WithValid_InputParameters_ItShould_SuccessfullyExecute";
					}
					else
					{
						return $"WhenICall_{methodName}_WithInvalid_InputParameters_ItShould_FailToExecute";
					}
			}

			return $"{methodName}{overloadRankText}_Test";
		}

		private UTGenerationSupport PrepareUTGenerationSupport (UnitTestScaffoldOption scaffoldOption)
		{
			var utProviders = new IUnitTestLibrarySpecific []
			{
				new NUnitSpecific (),
				new XUnitSpecific (),
				new MSTestSpecific (),
				new NSpecSpecific (),
				new XBehaveSpecific ()
			};

			var mockers = new IMockLibrarySpecific []
			{
				new MoqSpecific (),
				new NSubstituteSpecific (),
				new JustMockSpecific (),
				new FakeItEasySpecific (),
				new RhinoMockSpecific ()
			};

			var asserters = new IFALibrarySpecific []
			{
				new FluentAssertionSpecific (),
				new ShouldlyLibrarySpecific (),
				new ShouldLibrarySpecific (),
				new NFluentLibrarySpecific (),
				new NSureLibrarySpecific ()
			};

			var testDataProviders = new ITestDataLibrarySpecific []
			{
				new NBuilderLibrarySpecific (),
				new AutoFixtureLibrarySpecific ()
			};

			var usingProvider = new PrepareUsingDirectives ();

			var utProvider
				= utProviders
					.FirstOrDefault (csp => csp.CanHandleUnitTestLibrary () == scaffoldOption.UnitTestLibrary);

			var mocker
				= mockers
					.FirstOrDefault (csp => csp.CanHandleMockingLibraries ().Contains (scaffoldOption.MockingLibrary));

			var asserter
				= asserters
					.FirstOrDefault (a => a.CanHandleFluentAssertionLibrary () == scaffoldOption.FluentAssertionLibrary);

			var testDataProvider
				= testDataProviders
					.FirstOrDefault (t => t.CanHandleTestDataPreparationLibrary () == scaffoldOption.TestDataPreparationLibrary);

			return new UTGenerationSupport
				(
					usingProvider,
					utProvider,
					mocker,
					asserter,
					testDataProvider,
					scaffoldOption.AddAssertionsForVoidDependencyMethodCalls,
					scaffoldOption.AddRelevantUsingNamespacesEvenIfNotUsed,
					scaffoldOption.AddToDoDirectiveComments,
					scaffoldOption.AddFriendlyComments
				);
		}
	}
}