using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator
{
	public sealed class UnitTestGenerationOptions
	{
		private const string UT_LIBRARY = "UT_LIBRARY";
		private const string MOCK_LIBRARY = "MOCK_LIBRARY";
		private const string FLUENT_LIBRARY = "FLUENT_LIBRARY";
		private const string TEST_DATA_LIBRARY = "TEST_DATA_LIBRARY";
		private const string LAST_BROWSED_DLL_PATH = "LAST_BROWSED_DLL_PATH";
		private const string LAST_UNIT_TEST_SAVE_LOCATION = "LAST_UNIT_TEST_SAVE_LOCATION";
		private const string SEARCH_TEXT = "SEARCH_TEXT";
		private const string REMEMBER_PREFERENCES = "REMEMBER_PREFERENCES";
		private const string UT_METHOD_NAMING_STYLE = "UT_METHOD_NAMING_STYLE";
		private const string ADD_VOID_ASSERTIONS = "ADD_VOID_ASSERTIONS";
		private const string ADD_USING = "ADD_USING";
		private const string ADD_TODO_COMMENTS = "ADD_TODO_COMMENTS";
		private const string ADD_FRIENDLY_COMMENTS = "ADD_FRIENDLY_COMMENTS";

		private readonly string iniFilePath = Path.GetDirectoryName (Application.ExecutablePath) + @"\utgenoptions.ini";

		private static UnitTestGenerationOptions? definedInstance;
		private static readonly object syncLocker = new ();

		public bool IsReady { get; private set; }
		public string SearchText { get; private set; }

		public UnitTestLibrary UnitTestLibrary { get; private set; }

		public MockingLibrary MockingLibrary { get; private set; }

		public FluentAssertionLibrary FluentAssertionLibrary { get; private set; }

		public TestDataPreparationLibrary TestDataPreparationLibrary { get; private set; }

		public UnitTestMethodNamingStyle UnitTestMethodNamingStyle { get; private set; }

		public bool RememberMyPreferences { get; private set; }

		public string? LastBrowsedDllPath { get; private set; }

		public string LastUnitTestSaveLocation { get; private set; }

		public bool AddAssertionsForVoidDependencyCalls { get; private set; }
		
		public bool AddUsingStatementsForUnusedLibrariesAlso { get; private set; }

		public bool AddToDoComments { get; private set; }

		public bool AddFriendlyComments { get; private set; }

		public static UnitTestGenerationOptions DefinedInstance
		{
			get
			{
				lock (syncLocker)
				{
					if (UnitTestGenerationOptions.definedInstance == null)
					{
						UnitTestGenerationOptions.definedInstance = new ();
					}

					return UnitTestGenerationOptions.definedInstance;
				}
			}
		}

		private UnitTestGenerationOptions ()
		{
			this.IsReady = false;
			this.SearchText = string.Empty;
			this.LastBrowsedDllPath = null;
			this.LastUnitTestSaveLocation = null;

			this.Reset ();
			this.ReadIniFile ();
		}

		public void SetReady ()
		{
			this.IsReady = true;
		}

		public void Reset ()
		{
			// Libraries.
			this.UnitTestLibrary = UnitTestLibrary.NUnit;
			this.MockingLibrary = MockingLibrary.Moq;
			this.FluentAssertionLibrary = FluentAssertionLibrary.FluentAssertions;
			this.TestDataPreparationLibrary = TestDataPreparationLibrary.FizzwareNBuilder;

			// UT method naming style.
			this.UnitTestMethodNamingStyle = UnitTestMethodNamingStyle.MethodNameStartsWithShould;

			// Options.
			this.AddAssertionsForVoidDependencyCalls = false;
			this.AddUsingStatementsForUnusedLibrariesAlso = false;
			this.AddToDoComments = false;
			this.AddFriendlyComments = true;

			this.RememberMyPreferences = true;
		}

		public void SetUnitTestLibraryTo (UnitTestLibrary unitTestLibrary)
		{
			if (this.IsReady)
			{
				this.UnitTestLibrary = unitTestLibrary;
				this.WriteIniFile ();
			}
		}

		public void SetMockingLibraryTo (MockingLibrary mockingLibrary)
		{
			if (this.IsReady)
			{
				this.MockingLibrary = mockingLibrary;
				this.WriteIniFile ();
			}
		}

		public void SetFluentAssertionLibraryTo (FluentAssertionLibrary fluentAssertionLibrary)
		{
			if (this.IsReady)
			{
				this.FluentAssertionLibrary = fluentAssertionLibrary;
				this.WriteIniFile ();
			}
		}

		public void SetTestDataPreparationLibraryTo (TestDataPreparationLibrary testDataPreparationLibrary)
		{
			if (this.IsReady)
			{
				this.TestDataPreparationLibrary = testDataPreparationLibrary;
				this.WriteIniFile ();
			}
		}

		public void SetUnitTestMethodNamingStyleTo (UnitTestMethodNamingStyle unitTestMethodNamingStyle)
		{
			if (this.IsReady)
			{
				this.UnitTestMethodNamingStyle = unitTestMethodNamingStyle;
				this.WriteIniFile ();
			}
		}

		public void SetLastBrowsedDllTo (string dllFilePath)
		{
			if (this.IsReady)
			{
				if (File.Exists (dllFilePath))
				{
					this.LastBrowsedDllPath = dllFilePath;
				}
				this.WriteIniFile ();
			}
		}

		public void SetLastUnitTestSaveLocationTo (string selectedPath)
		{
			if (this.IsReady)
			{
				if (Directory.Exists (selectedPath))
				{
					this.LastUnitTestSaveLocation = selectedPath;
				}
				this.WriteIniFile ();
			}
		}

		public void SetSearchPatternTo (string searchPattern)
		{
			if (this.IsReady)
			{
				this.SearchText = searchPattern;
				this.WriteIniFile ();
			}
		}

		public void SetAddAssertionsForVoidDependencyCallsTo (bool addAssertionsForVoidDependencyCalls)
		{
			if (this.IsReady)
			{
				this.AddAssertionsForVoidDependencyCalls = addAssertionsForVoidDependencyCalls;
				this.WriteIniFile ();
			}
		}

		public void SetAddUsingStatementsTo (bool addUsingStatements)
		{
			if (this.IsReady)
			{
				this.AddUsingStatementsForUnusedLibrariesAlso = addUsingStatements;
				this.WriteIniFile ();
			}
		}

		public void SetAddToDoStatementsTo (bool addToDo)
		{
			if (this.IsReady)
			{
				this.AddToDoComments = addToDo;
				this.WriteIniFile ();
			}
		}

		public void SetAddFriendlyCommentsTo (bool addFriendlyComments)
		{
			if (this.IsReady)
			{
				this.AddFriendlyComments = addFriendlyComments;
				this.WriteIniFile ();
			}
		}

		public void SetRememberPreferencesTo (bool rememberMyPreferences)
		{
			if (this.IsReady)
			{
				this.RememberMyPreferences = rememberMyPreferences;
				this.WriteIniFile ();
			}
		}

		private void WriteIniFile ()
		{
			if (this.IsReady == false)
			{
				return;
			}

			if (this.RememberMyPreferences)
			{
				File.WriteAllText
					(
						this.iniFilePath,
						// Libraries.
						$"{UT_LIBRARY}={this.UnitTestLibrary}"
						+ $"\r\n{MOCK_LIBRARY}={this.MockingLibrary}"
						+ $"\r\n{FLUENT_LIBRARY}={this.FluentAssertionLibrary}"
						+ $"\r\n{TEST_DATA_LIBRARY}={this.TestDataPreparationLibrary}"

						// UT Method naming style.
						+ $"\r\n{UT_METHOD_NAMING_STYLE}={this.UnitTestMethodNamingStyle}"

						// Locate classes.
						+ $"\r\n{LAST_BROWSED_DLL_PATH}={this.LastBrowsedDllPath}"
						+ $"\r\n{LAST_UNIT_TEST_SAVE_LOCATION}={this.LastUnitTestSaveLocation}"
						+ $"\r\n{SEARCH_TEXT}={this.SearchText}"

						// Options.
						+ $"\r\n{ADD_VOID_ASSERTIONS}={this.AddAssertionsForVoidDependencyCalls}"
						+ $"\r\n{ADD_USING}={this.AddUsingStatementsForUnusedLibrariesAlso}"
						+ $"\r\n{ADD_TODO_COMMENTS}={this.AddToDoComments}"
						+ $"\r\n{ADD_FRIENDLY_COMMENTS}={this.AddFriendlyComments}"
						+ $"\r\n{REMEMBER_PREFERENCES}={this.RememberMyPreferences}"
					);
			}
		}

		private void ReadIniFile ()
		{
			if (File.Exists (this.iniFilePath))
			{
				var lines = File.ReadAllLines (this.iniFilePath);

				foreach (var line in lines)
				{
					var equalToLocation = line.IndexOf ('=');

					if (equalToLocation != -1)
					{
						var firstPart = line [..equalToLocation];
						var secondPart = line [(equalToLocation + 1)..];

						switch (firstPart)
						{
							// Libraries.
							case UT_LIBRARY:
								UnitTestLibrary parsedValueOfUtLibrary;
								if (Enum.TryParse (secondPart, out parsedValueOfUtLibrary))
								{
									this.UnitTestLibrary = parsedValueOfUtLibrary;
								}
								break;

							case MOCK_LIBRARY:
								MockingLibrary parsedValueOfMockLibrary;
								if (Enum.TryParse (secondPart, out parsedValueOfMockLibrary))
								{
									this.MockingLibrary = parsedValueOfMockLibrary;
								}
								break;

							case FLUENT_LIBRARY:
								FluentAssertionLibrary parsedValueOfFluentLibrary;
								if (Enum.TryParse (secondPart, out parsedValueOfFluentLibrary))
								{
									this.FluentAssertionLibrary = parsedValueOfFluentLibrary;
								}
								break;

							case TEST_DATA_LIBRARY:
								TestDataPreparationLibrary parsedValueOfTestDataPrepLibrary;
								if (Enum.TryParse (secondPart, out parsedValueOfTestDataPrepLibrary))
								{
									this.TestDataPreparationLibrary = parsedValueOfTestDataPrepLibrary;
								}
								break;

							// UT Method naming style.
							case UT_METHOD_NAMING_STYLE:
								UnitTestMethodNamingStyle parsedValueOfUnitTestMethodNamingStyle;
								if (Enum.TryParse (secondPart, out parsedValueOfUnitTestMethodNamingStyle))
								{
									this.UnitTestMethodNamingStyle = parsedValueOfUnitTestMethodNamingStyle;
								}
								break;

							// Locate classes.
							case LAST_BROWSED_DLL_PATH:
								if (File.Exists (secondPart))
								{
									this.LastBrowsedDllPath = secondPart;
								}
								break;

							// Locate classes.
							case LAST_UNIT_TEST_SAVE_LOCATION:
								if (Directory.Exists (secondPart))
								{
									this.LastUnitTestSaveLocation = secondPart;
								}
								break;

							case SEARCH_TEXT:
								this.SearchText = secondPart;
								break;

							// Options.
							case ADD_VOID_ASSERTIONS:
								var addAssertions = false;
								if (bool.TryParse (secondPart, out addAssertions))
								{
									this.AddAssertionsForVoidDependencyCalls = addAssertions;
								}
								break;

							case ADD_USING:
								var addUsing = false;
								if (bool.TryParse (secondPart, out addUsing))
								{
									this.AddUsingStatementsForUnusedLibrariesAlso = addUsing;
								}
								break;

							case ADD_TODO_COMMENTS:
								var addToDo = false;
								if (bool.TryParse (secondPart, out addToDo))
								{
									this.AddToDoComments = addToDo;
								}
								break;

							case ADD_FRIENDLY_COMMENTS:
								var addFriendlyComments = false;
								if (bool.TryParse (secondPart, out addFriendlyComments))
								{
									this.AddFriendlyComments = addFriendlyComments;
								}
								break;

							// Remember preferences.
							case REMEMBER_PREFERENCES:
								bool parsedValueOfRememberPreferences;
								if (bool.TryParse (secondPart, out parsedValueOfRememberPreferences))
								{
									this.RememberMyPreferences = parsedValueOfRememberPreferences;
								}
								break;
						}
					}
				}
			}
		}
	}
}