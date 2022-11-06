using System;
using Microsoft.VisualBasic;
using UnitTestGenerator.Logic.Entities;
using UnitTestGenerator.Logic.Support.Extensions;

namespace UnitTestGenerator
{
    public partial class UnitTestGeneratorScreen
	{
		//
		// Colors use for rich-text rendering of generated Unit Test code.
		//
		private readonly Color keywordColor = Color.FromArgb (86, 156, 214);				// Navy Blue.
		private readonly Color regularTextColor = Color.FromArgb (220, 220, 186);			// White.
		private readonly Color classNameColor = Color.FromArgb (78, 201, 176);				// Teal.
		private readonly Color interfaceAndStructColor = Color.FromArgb (184, 215, 153);    // Pale Yellow.
		private readonly Color methodNameColor = Color.FromArgb (220, 220, 170);			// Yellow.
		private readonly Color commentColor = Color.FromArgb (87, 166, 74);					// Green.
		private readonly Color stringColor = Color.FromArgb (214, 157, 133);                // Orange.
		private readonly Color todoCommentColor = Color.HotPink;

		// Delimiters for identifying keywords.
		private readonly char [] delimiterCharsPrevious = new [] { '{', '\0', '[', ',', '.', '<', '>', '(' };
		private readonly char [] delimiterCharsNext = new [] { '}', '\0', ']', ',', ';', '.', '<', '>', ')' };

		// C# keywords.
		private readonly string [] knownCSharpKeywords = new []
		{
			"using","namespace",
			"public", "private", "protected", "readonly", "sealed", "class", "void", "this",
			"byte", "short", "int", "long", "float", "double", "decimal", "char", "string", "bool", "true", "false",
			"var", "object", "null", "default", "new",
			"try", "catch"
		};

		// C# class names that can typically appear in Unit Tests.
		private readonly string [] knownClassNames = new []
		{
			"List", "Dictionary", "Exception",
			"nspec",
			"TestFixture", "TestClass", "Test", "TestMethod", "TestInitialize", "SetUp", "Background", "Scenario", "Fact",
			"Mock", "MockRepository", "Arg","A","It", "Substitute",
			"Ensure", "Check",
			"Builder", "Fixture"
		};

		// Known string literals in the generated Unit Test codes.
		private readonly string [] knownStrings = new string []
		{
			"\"When I attempt to instantiate the target class with non-null Constructor arguments\"",
			"\"Should successfully instantiate the target class\"",
			"\"Null value expected.\"",
			"\"Null value is expected.\"",
			"\"Null value is not expected.\"",
			"\"Expected value is different.\"",
			"\"Given that I have valid inputs for the constructor method\"",
			"\"When I call the constructor method with valid parameters\"",
			"\"Should execute successfully\"",
			"\"It should execute successfully\"",
			"\"It should fail to execute\"",
			"\"Should fail to execute\"",
			"\"some string\"",
			"\"some other string\"",
			"\"abc\"",
			"\"def\"",
			"\"ghi\"",
			"\"pqr\"",
			"\"uvw\"",
			"\"xyz\""
		};

		// Known names of methods of classes in the generated Unit Test codes.
		private readonly string [] knownMethodNames = new []
		{
			// .NET
			"Equals", "ToList", "ForEach",

			// Mocking.
			"VerifyAll", "AssertWasCalled", "MustHaveHappened", "MustBeCalled", "CallTo",
			"IsAny", "Any",
			"GenerateStub", "Stub", "Arrange", "Setup",
			"For", "Create",
			"Return", "Returns",
			"Invokes", "DoInstead", "Do", "Callback", "Received",

			// Assertion.
			"IsNull", "IsNotNull", "IsEqualTo", "That",
			"Should", "Be", "NotBe", "ShouldBe", "ShouldNotBe", "BeNull", "ShouldBeNull", "ShouldNotBeNull", "ShouldBeType", "ShouldEqual", "NotBeNull", "HaveSameCount",

			// Test Data preparation.
			"CreateNew", "Build"
		};
		private string [] knownComments = new []
		{
			"// Happy path.",
			"// Edge case.",
			"// Method parameters",
			"// Please specify valid expected result here.",
			"// Please set the correct value.",
			"// Expected and actual results",
			"// Mock dependency method calls",
			"// Test data preparation support.",
			"// Test data for each parameter",
			"// Target concrete class.",
			"// Others.",
			"// Mocked dependencies.",
			"// Mocked dependencies of this Constructor.",
			"// Please specify the correct return data here.",
			"// Please set the correct test data for this Unit Test.",
			"// Callback statement is dummy. Please correct. E.g. a.Id = 1;",
			"// ============", "// Test Cases",
			"// Arrange", "// Act", "// Assert",
			"// =========================================",
			"// Setting up mocked dependency method calls",
			"// ========================================="
		};

		private string [] knownToDoComments = new []
		{
			"// TODO: ↓↓ Please set the correct expected value below.",
			"// TODO: ↓↓ Please set the correct positive assert statement below.",
			"// TODO: ↓↓ Please set the correct negative assert statement below.",
			"// TODO: ↓↓ Please prepare the correct test data below for this Unit Test.",
			"// TODO: ↓↓ In Edge Case scenarios, sometimes calls to the dependencies might not happen.",
			"// TODO: ↓↓ Please check if the below \"void\" dependency method calls do make sense for this Unit Test or not."
		};

		private void selectedMethodsListBox_SelectedIndexChanged (object sender, EventArgs e)
		{
			if (selectedMethodsListBox.SelectedIndex != -1)
			{
				// Identify the Public Member.
				var publicMember = (PublicMember) selectedMethodsListBox.SelectedItem;

				if (this.generatedUnitTests.ContainsKey (publicMember))
				{
					// Get generated Unit Test code.
					var generatedUnitTest = this.generatedUnitTests? [publicMember];
					this.generatedUnitTestRichTextBox.Visible = false;
					this.generatedUnitTestRichTextBox.Text = generatedUnitTest;

					//
					// Identify possible class names in the generated Unit Test code
					// and apply Teal color.
					//
					var targetClassName = publicMember?.ReflectedMemberInfo?.DeclaringType?.Name;
					var targetMethodName = publicMember?.ReflectedMemberInfo.Name;
					
					var classNames = new List<string> ();
					classNames.AddRange (this.knownClassNames);
					classNames.Add (targetClassName);

					var concreteClassNames = new List<string> ();

					publicMember
						.ReflectedMemberInfo
						.GetParameters ()
						.ToList ()
						.Where (p => p.ParameterType.IsClass && p.ParameterType.IsPublic)
						?.ToList ()
						.ForEach (i => concreteClassNames.Add (i.ParameterType.Name));

					publicMember
						.DependencyCalls
						?.ToList ()
						.ForEach (dc => {
							dc.ParameterTypes
								.Where (p => p.IsClass && p.IsPublic)
								.ToList ()
								.ForEach (i =>
									concreteClassNames.Add (i.Name)
								);
						});

					classNames.AddRange (concreteClassNames);

					// Add constructor Unit Test class names.
					classNames.Add ($"{targetClassName}_Ctor_Test");

					for (var i = 2; i <= 12; i++)
					{
						classNames.Add ($"{targetClassName}_Ctor_{i}_Test");
					}
					
					this.ApplyColorToKeywords (classNames, this.classNameColor);

					//
					// Identify the interfaces and structures present in the
					// generated Unit Test code and apply Pale Yellow color.
					//
					var interfacesAndStructs
						= publicMember
							?.ReflectedMemberInfo
							.GetParameters ()
							.Where (p => p.ParameterType.IsInterface)
							.Select (p => p.ParameterType.GetRealGenericTypeName ())
							.ToList ();

					publicMember
						.DependencyCalls
						?.ToList ()
						.ForEach (dc => {
							interfacesAndStructs.Add (dc.Dependency.DependencyAbstractionType.GetRealGenericTypeName ());
						});

					publicMember
						.DependencyCalls
						?.ToList ()
						.ForEach (dc => {
							dc.ParameterTypes
								.Where (p => p.IsInterface)
								.ToList ()
								.ForEach (i =>
									interfacesAndStructs.Add (i.Name)
								);
						});

					//
					// Include the interfaces that are perhaps used in the
					// dependency method calls within the target class.
					// NOTE: The chances are extremely slim for this.
					//
					var dependencyCallInterfaces = new List<string> ();

					publicMember
						.DependencyCalls
						?.ToList ()
						.ForEach (dc => {
							dc.ParameterTypes
								.Where (p => p.IsInterface)
								.ToList ()
								.ForEach (i =>
									dependencyCallInterfaces.Add (i.Name)
								);
						});

					interfacesAndStructs?.AddRange (dependencyCallInterfaces);

					interfacesAndStructs?.Add ("IEnumerable");
					interfacesAndStructs?.Add ("IList");
					interfacesAndStructs?.Add ("IDictionary");
					interfacesAndStructs?.Add ("DateTime");

					this.ApplyColorToKeywords (interfacesAndStructs, this.interfaceAndStructColor);

					//
					// Identify the method calls in the generated Unit Test code
					// and apply Yellow color.
					//

					var calledMethods = new List<string> ();

					calledMethods.AddRange
						(
							publicMember
								.DependencyCalls
								.Select (dc => dc.Method.Name)
								.ToList ()
						);

					publicMember
						.DependencyCalls
						.ToList ()
						.ForEach (dc => {
							calledMethods.Add ($"SetUp_{ dc.Dependency.PrivateReadOnlyFieldName.ToPascalCase () }_ForHappyPath");
							calledMethods.Add ($"SetUp_{ dc.Dependency.PrivateReadOnlyFieldName.ToPascalCase () }_ForEdgeCase");
						});

					calledMethods.AddRange (this.knownMethodNames);

					calledMethods.Add (publicMember.ReflectedMemberInfo.Name);
					calledMethods.Add ("Constructor_Test");
					for (var i = 2; i <= 12; i++)
					{
						calledMethods.Add ($"Constructor_{i}_Test");
					}

					this.ApplyColorToKeywords (calledMethods, this.methodNameColor);

					//
					// Identify the C# language keywords
					// and apply Navy Blue color.
					//
					this.ApplyColorToKeywords (this.knownCSharpKeywords, this.keywordColor);

					//
					// Identify Comments in the generated Unit Test code
					// and apply Green color.
					//
					this.ApplyColorToKeywords (this.knownComments, this.commentColor);

					//
					// Identify TODO: Comments in the generated Unit Test code
					// and apply Misty Rose color.
					//
					this.ApplyColorToKeywords (this.knownToDoComments, this.todoCommentColor);

					//
					// Identify strings in the generated Unit Test code
					// and apply Orange color.
					//
					var strings = new List<string> ();
					
					strings.AddRange (this.knownStrings);
					var humanReadableMethodName = publicMember.ReflectedMemberInfo.Name.ToHumanReadable ();
					strings.Add ($"\"Given that I have valid inputs to {humanReadableMethodName}\"");
					strings.Add ($"\"Given that I have invalid inputs to {humanReadableMethodName}\"");

					if (publicMember.ReflectedMemberInfo.IsConstructor == false)
					{
						strings.Add ($"\"When I call the '{publicMember.ReflectedMemberInfo.Name}' method with valid parameters\"");
						strings.Add ($"\"When I call the '{publicMember.ReflectedMemberInfo.Name}' method with invalid parameters\"");
					}

					this.ApplyColorToKeywords (strings, stringColor);

					//
					// Apply any corrections in the text colors (such as, presence of 'Test' in
					// namespaces should not be in Teal color (which was meant for [Test] attribute.)
					//
					this.ApplyColorToKeywords (new [] { "Should;", ".Test.", ".Test", "string." }, this.regularTextColor, true);

					this.generatedUnitTestRichTextBox.Visible = true;
				}
			}
		}

		private void ApplyColorToKeywords (IEnumerable<string>? wordsToLookFor, Color colorToApply, bool ignorePrevAndNextCheck = false)
		{
			var utCode = this.generatedUnitTestRichTextBox.Text;
			var utCodeLength = utCode.Length;

			foreach (var oneWord in wordsToLookFor)
			{
				var wordLength = oneWord.Length;

				if (utCode.Contains (oneWord))
				{
					int index = -1;

					// Locate the matching word.
					while ((index = utCode.IndexOf (oneWord, (index + 1))) != -1)
					{
						// Check if it is a valid token, and not part of any other word.
						var prevChar = (index == 0) ? '\0' : utCode [index - 1];
						var nextChar = (index + wordLength >= utCodeLength)
							? '\0'
							: utCode [index + wordLength];

						var prevCharIsFine = ignorePrevAndNextCheck || string.IsNullOrWhiteSpace (prevChar.ToString ()) || delimiterCharsPrevious.Contains (prevChar);
						var nextCharIsFine = ignorePrevAndNextCheck || string.IsNullOrWhiteSpace (nextChar.ToString ()) || delimiterCharsNext.Contains (nextChar);

						// Is it a valid token?
						if (prevCharIsFine && nextCharIsFine)
						{
							this.generatedUnitTestRichTextBox.Select (index, wordLength);
							this.generatedUnitTestRichTextBox.SelectionColor = colorToApply;
						}
					}
				}
			}
		}
	}
}