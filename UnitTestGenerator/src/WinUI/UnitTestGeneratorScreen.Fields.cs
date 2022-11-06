using UnitTestGenerator.Logic.Entities;

namespace UnitTestGenerator
{
    public partial class UnitTestGeneratorScreen
    {
		private readonly Color radioOptionBackColor = Color.Silver;

		private readonly List<RadioButton> utRadios = new List<RadioButton> ();
		private readonly List<RadioButton> mockRadios = new List<RadioButton> ();
		private readonly List<RadioButton> fluentRadios = new List<RadioButton> ();
		private readonly List<RadioButton> testDataRadios = new List<RadioButton> ();

		private readonly IDictionary<RadioButton, UnitTestLibrary> utRadiosDictionary = new Dictionary<RadioButton, UnitTestLibrary> ();
		private readonly IDictionary<RadioButton, MockingLibrary> mockRadiosDictionary = new Dictionary<RadioButton, MockingLibrary> ();
		private readonly IDictionary<RadioButton, FluentAssertionLibrary> fluentRadiosDictionary = new Dictionary<RadioButton, FluentAssertionLibrary> ();
		private readonly IDictionary<RadioButton, TestDataPreparationLibrary> testDataRadiosDictionary = new Dictionary<RadioButton, TestDataPreparationLibrary> ();

		private void PrepareRadiosCollection ()
        {
			this.utRadios.AddRange (new [] {
				this.nUnitRadioButton,  this.xUnitRadioButton, this.msTestRadioButton,
				this.xBehaveRadioButton, this.nSpecRadioButton
			});

			this.mockRadios.AddRange (new [] {
				this.moqRadioButton, this.nSubstituteRadioButton,
				this.justMockLiteRadioButton, this.fakeItEasyRadioButton, this.rhinoMockRadioButton
			});

			this.fluentRadios.AddRange (new [] {
				this.fluentAssertionsRadioButton, this.shouldlyRadioButton,
				this.shouldRadioButton, this.nFluentRadioButton, this.nSureRadioButton
			});

			this.testDataRadios.AddRange (new [] {
				this.nBuilderRadioButton,
				this.autoFixtureRadioButton
			});
		}

		private void PrepareRadiosAndEnumsDictionary ()
		{
			// Unit Test Libraries.
			this.utRadiosDictionary.Add (this.nUnitRadioButton, UnitTestLibrary.NUnit);
			this.utRadiosDictionary.Add (this.xUnitRadioButton, UnitTestLibrary.XUnit);
			this.utRadiosDictionary.Add (this.msTestRadioButton, UnitTestLibrary.MicrosoftTest);
			this.utRadiosDictionary.Add (this.xBehaveRadioButton, UnitTestLibrary.XBehave);
			this.utRadiosDictionary.Add (this.nSpecRadioButton, UnitTestLibrary.NSpec);

			// Mocking Libraries.
			this.mockRadiosDictionary.Add (this.moqRadioButton, MockingLibrary.Moq);
			this.mockRadiosDictionary.Add (this.nSubstituteRadioButton, MockingLibrary.NSubstitute);
			this.mockRadiosDictionary.Add (this.justMockLiteRadioButton, MockingLibrary.TelerikJustMock);
			this.mockRadiosDictionary.Add (this.fakeItEasyRadioButton, MockingLibrary.FakeItEasy);
			this.mockRadiosDictionary.Add (this.rhinoMockRadioButton, MockingLibrary.RhinoMock);

			// Fluent Assertions Libraries.
			this.fluentRadiosDictionary.Add (this.fluentAssertionsRadioButton, FluentAssertionLibrary.FluentAssertions);
			this.fluentRadiosDictionary.Add (this.shouldlyRadioButton, FluentAssertionLibrary.Shouldly);
			this.fluentRadiosDictionary.Add (this.shouldRadioButton, FluentAssertionLibrary.Should);
			this.fluentRadiosDictionary.Add (this.nFluentRadioButton, FluentAssertionLibrary.NFluent);
			this.fluentRadiosDictionary.Add (this.nSureRadioButton, FluentAssertionLibrary.NSure);

			// Test Data Preparation Libraries.
			this.testDataRadiosDictionary.Add (this.nBuilderRadioButton, TestDataPreparationLibrary.FizzwareNBuilder);
			this.testDataRadiosDictionary.Add (this.autoFixtureRadioButton, TestDataPreparationLibrary.AutoFixture);
		}

		private void CheckAppropriateLibraryRadios ()
		{
			this.CheckTheseRadios (this.options.UnitTestLibrary, this.utRadios, this.utRadiosDictionary);
			this.CheckTheseRadios (this.options.MockingLibrary, this.mockRadios, this.mockRadiosDictionary);
			this.CheckTheseRadios (this.options.FluentAssertionLibrary, this.fluentRadios, this.fluentRadiosDictionary);
			this.CheckTheseRadios (this.options.TestDataPreparationLibrary, this.testDataRadios, this.testDataRadiosDictionary);
		}

		private void CheckTheseRadios<TEnum> (
				TEnum optionValue,
				List<RadioButton> radios,
				IDictionary<RadioButton, TEnum> radiosDictionary
			)
			where TEnum : Enum
		{
			radios.ForEach (r => {
				var correspEnum = radiosDictionary [r];
				r.Checked = (optionValue.Equals (correspEnum));
			});
		}

		private void HighlightUTRadio (RadioButton selectedRadio, UnitTestLibrary utLibrary)
		{
			this.GenericHighlightRadio (utLibrary, this.utRadios,
					this.radioOptionBackColor, this.utLibraryHighlighterLabel,
					selectedRadio);
		}

		private void HighlightMockRadio (RadioButton selectedRadio, MockingLibrary mockingLibrary)
		{
			this.GenericHighlightRadio (mockingLibrary, this.mockRadios,
					this.radioOptionBackColor, this.mockLibraryHighlighterLabel,
					selectedRadio);
		}

		private void HighlightFluentRadio (RadioButton selectedRadio, FluentAssertionLibrary fluentLibrary)
		{
			this.GenericHighlightRadio (fluentLibrary, this.fluentRadios,
					this.radioOptionBackColor, this.fluentLibraryHighlighterLabel,
					selectedRadio);
		}

		private void HighlightTestDataRadio (RadioButton selectedRadio, TestDataPreparationLibrary testDataLibrary)
		{
			this.GenericHighlightRadio (testDataLibrary, this.testDataRadios,
					this.radioOptionBackColor, this.testDataPrepLibraryHighlighterLabel,
					selectedRadio);
		}

		private void GenericHighlightRadio<TEnumType>
			(
				TEnumType enumTypeValue,
				IList<RadioButton> radios,
				Color regularBackColor,
				Label highlighterLabel,
				RadioButton selectedRadio
			)
				where TEnumType : Enum
		{
			var enumName = typeof (TEnumType).FullName;

			var utEnumName = typeof (UnitTestLibrary).FullName;
			var mockEnumName = typeof (MockingLibrary).FullName;
			var fleuntEnumName = typeof (FluentAssertionLibrary).FullName;
			var testDataEnumName = typeof (TestDataPreparationLibrary).FullName;

			if (enumName == utEnumName)
			{
				this.options.SetUnitTestLibraryTo ((UnitTestLibrary) Enum.Parse (typeof (UnitTestLibrary), enumTypeValue.ToString ()));
			}
			else if (enumName == mockEnumName)
			{
				this.options.SetMockingLibraryTo ((MockingLibrary) Enum.Parse (typeof (MockingLibrary), enumTypeValue.ToString ()));
			}
			else if (enumName == fleuntEnumName)
			{
				this.options.SetFluentAssertionLibraryTo ((FluentAssertionLibrary) Enum.Parse (typeof (FluentAssertionLibrary), enumTypeValue.ToString ()));
			}
			else if (enumName == testDataEnumName)
			{
				this.options.SetTestDataPreparationLibraryTo ((TestDataPreparationLibrary) Enum.Parse (typeof (TestDataPreparationLibrary), enumTypeValue.ToString ()));
			}

			highlighterLabel.Top = selectedRadio.Top - this.uiInfo.HeighlighterLabelDepthDifference;
			selectedRadio.BackColor = highlighterLabel.BackColor;

			radios
				.ToList ()
				.ForEach (r => {
					if (!r.Equals (selectedRadio))
					{
						r.BackColor = regularBackColor;
						r.ForeColor = Color.Black;
					}
				});
		}
	}
}