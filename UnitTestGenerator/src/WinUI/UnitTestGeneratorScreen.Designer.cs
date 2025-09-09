namespace UnitTestGenerator
{
    partial class UnitTestGeneratorScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			components = new System.ComponentModel.Container ();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (UnitTestGeneratorScreen));
			unitGenTabControl = new TabControl ();
			targetPublicMethodsTabPage = new TabPage ();
			panel6 = new Panel ();
			deselectAllButton = new Button ();
			selectAllButton = new Button ();
			generateUnitTestsButton = new Button ();
			publicMethodsPresentCheckedListBox = new CheckedListBox ();
			quickSearchTextBox = new TextBox ();
			quickSearchLabel = new Label ();
			concreteClassesDropDownList = new ComboBox ();
			browseDllButton = new Button ();
			dllPathTextBox = new TextBox ();
			concreteClassLabel = new Label ();
			dllPathLabel = new Label ();
			selectTargetClassSectionLabel = new Label ();
			concreteClassPictureBox = new PictureBox ();
			generatedUnitTestsTabPage = new TabPage ();
			panel7 = new Panel ();
			selectedMethodsListBox = new ListBox ();
			copyUnitTestCodeButton = new Button ();
			saveUnitTestsButton = new Button ();
			generatedUnitTestRichTextBox = new RichTextBox ();
			unitTestOptionsTabPage = new TabPage ();
			resetToDefaultOptionsButton = new Button ();
			rememberMyPreferencesCheckBox = new CheckBox ();
			addFriendlyCommentsCheckBox = new CheckBox ();
			addToDoStatementsCheckBox = new CheckBox ();
			addAssertionForVoidDependencyCallsCheckBox = new CheckBox ();
			addUsingNamespacesCheckBox = new CheckBox ();
			panel5 = new Panel ();
			utMethodNameStartsWithWhenRadioButton = new RadioButton ();
			utMethodNameStartsWithShouldRadioButton = new RadioButton ();
			utMethodNamingStyleHighlighterLabel = new Label ();
			unitTestMethodNamingStyleSectionLabel = new Label ();
			panel4 = new Panel ();
			testData5RadioButton = new RadioButton ();
			testData4RadioButton = new RadioButton ();
			testData3RadioButton = new RadioButton ();
			autoFixtureRadioButton = new RadioButton ();
			nBuilderRadioButton = new RadioButton ();
			testDataPrepLibraryHighlighterLabel = new Label ();
			testDataPrepLibraryPictureBox = new PictureBox ();
			testDataPrepLibrarySectionLabel = new Label ();
			panel3 = new Panel ();
			nSureRadioButton = new RadioButton ();
			nFluentRadioButton = new RadioButton ();
			shouldRadioButton = new RadioButton ();
			shouldlyRadioButton = new RadioButton ();
			fluentAssertionsRadioButton = new RadioButton ();
			fluentLibraryHighlighterLabel = new Label ();
			fluentAssertionLibraryPictureBox = new PictureBox ();
			fluentAssertionLibrarySectionLabel = new Label ();
			panel2 = new Panel ();
			rhinoMockRadioButton = new RadioButton ();
			fakeItEasyRadioButton = new RadioButton ();
			justMockLiteRadioButton = new RadioButton ();
			nSubstituteRadioButton = new RadioButton ();
			moqRadioButton = new RadioButton ();
			mockLibraryHighlighterLabel = new Label ();
			mockLibraryPictureBox = new PictureBox ();
			mockingLibrarySectionLabel = new Label ();
			panel1 = new Panel ();
			unitTestFrameworkSectionLabel = new Label ();
			nSpecRadioButton = new RadioButton ();
			xBehaveRadioButton = new RadioButton ();
			msTestRadioButton = new RadioButton ();
			xUnitRadioButton = new RadioButton ();
			nUnitRadioButton = new RadioButton ();
			utLibraryHighlighterLabel = new Label ();
			utLibraryPictureBox = new PictureBox ();
			openDllDialog = new OpenFileDialog ();
			backgroundImageList = new ImageList (components);
			whereToSaveFolderDialog = new FolderBrowserDialog ();
			unitGenTabControl.SuspendLayout ();
			targetPublicMethodsTabPage.SuspendLayout ();
			panel6.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize) concreteClassPictureBox).BeginInit ();
			generatedUnitTestsTabPage.SuspendLayout ();
			panel7.SuspendLayout ();
			unitTestOptionsTabPage.SuspendLayout ();
			panel5.SuspendLayout ();
			panel4.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize) testDataPrepLibraryPictureBox).BeginInit ();
			panel3.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize) fluentAssertionLibraryPictureBox).BeginInit ();
			panel2.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize) mockLibraryPictureBox).BeginInit ();
			panel1.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize) utLibraryPictureBox).BeginInit ();
			SuspendLayout ();
			// 
			// unitGenTabControl
			// 
			unitGenTabControl.Controls.Add (targetPublicMethodsTabPage);
			unitGenTabControl.Controls.Add (generatedUnitTestsTabPage);
			unitGenTabControl.Controls.Add (unitTestOptionsTabPage);
			unitGenTabControl.Font = new Font ("Helvetica-Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
			unitGenTabControl.Location = new Point (17, 18);
			unitGenTabControl.Name = "unitGenTabControl";
			unitGenTabControl.SelectedIndex = 0;
			unitGenTabControl.Size = new Size (1873, 1003);
			unitGenTabControl.TabIndex = 0;
			// 
			// targetPublicMethodsTabPage
			// 
			targetPublicMethodsTabPage.BackColor = Color.MediumAquamarine;
			targetPublicMethodsTabPage.Controls.Add (panel6);
			targetPublicMethodsTabPage.Font = new Font ("Bookman Old Style", 14F,  FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			targetPublicMethodsTabPage.ForeColor = Color.Gray;
			targetPublicMethodsTabPage.Location = new Point (4, 29);
			targetPublicMethodsTabPage.Name = "targetPublicMethodsTabPage";
			targetPublicMethodsTabPage.Padding = new Padding (3);
			targetPublicMethodsTabPage.Size = new Size (1865, 970);
			targetPublicMethodsTabPage.TabIndex = 1;
			targetPublicMethodsTabPage.Text = "        Target Concrete Class && Method        ";
			// 
			// panel6
			// 
			panel6.BackColor = Color.Silver;
			panel6.BorderStyle = BorderStyle.Fixed3D;
			panel6.Controls.Add (deselectAllButton);
			panel6.Controls.Add (selectAllButton);
			panel6.Controls.Add (generateUnitTestsButton);
			panel6.Controls.Add (publicMethodsPresentCheckedListBox);
			panel6.Controls.Add (quickSearchTextBox);
			panel6.Controls.Add (quickSearchLabel);
			panel6.Controls.Add (concreteClassesDropDownList);
			panel6.Controls.Add (browseDllButton);
			panel6.Controls.Add (dllPathTextBox);
			panel6.Controls.Add (concreteClassLabel);
			panel6.Controls.Add (dllPathLabel);
			panel6.Controls.Add (selectTargetClassSectionLabel);
			panel6.Controls.Add (concreteClassPictureBox);
			panel6.Location = new Point (20, 20);
			panel6.Name = "panel6";
			panel6.Size = new Size (1826, 923);
			panel6.TabIndex = 7;
			// 
			// deselectAllButton
			// 
			deselectAllButton.BackColor = Color.Silver;
			deselectAllButton.Font = new Font ("Candara", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			deselectAllButton.ForeColor = Color.Black;
			deselectAllButton.Location = new Point (1460, 720);
			deselectAllButton.Name = "deselectAllButton";
			deselectAllButton.Size = new Size (309, 52);
			deselectAllButton.TabIndex = 33;
			deselectAllButton.Text = "De-select All";
			deselectAllButton.UseVisualStyleBackColor = false;
			deselectAllButton.Click += deselectAllButton_Click;
			// 
			// selectAllButton
			// 
			selectAllButton.BackColor = Color.Silver;
			selectAllButton.Font = new Font ("Candara", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			selectAllButton.ForeColor = Color.Black;
			selectAllButton.Location = new Point (1460, 778);
			selectAllButton.Name = "selectAllButton";
			selectAllButton.Size = new Size (309, 52);
			selectAllButton.TabIndex = 33;
			selectAllButton.Text = "Select All";
			selectAllButton.UseVisualStyleBackColor = false;
			selectAllButton.Click += selectAllButton_Click;
			// 
			// generateUnitTestsButton
			// 
			generateUnitTestsButton.BackColor = Color.ForestGreen;
			generateUnitTestsButton.Font = new Font ("Candara", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			generateUnitTestsButton.ForeColor = Color.White;
			generateUnitTestsButton.Location = new Point (1460, 836);
			generateUnitTestsButton.Name = "generateUnitTestsButton";
			generateUnitTestsButton.Size = new Size (309, 52);
			generateUnitTestsButton.TabIndex = 33;
			generateUnitTestsButton.Text = "Generate Unit Tests";
			generateUnitTestsButton.UseVisualStyleBackColor = false;
			generateUnitTestsButton.Click += generateUnitTestsButton_Click;
			// 
			// publicMethodsPresentCheckedListBox
			// 
			publicMethodsPresentCheckedListBox.CheckOnClick = true;
			publicMethodsPresentCheckedListBox.Font = new Font ("Cascadia Code SemiLight", 12F, FontStyle.Regular, GraphicsUnit.Point);
			publicMethodsPresentCheckedListBox.FormattingEnabled = true;
			publicMethodsPresentCheckedListBox.Location = new Point (15, 125);
			publicMethodsPresentCheckedListBox.Name = "publicMethodsPresentCheckedListBox";
			publicMethodsPresentCheckedListBox.Size = new Size (1789, 781);
			publicMethodsPresentCheckedListBox.TabIndex = 34;
			publicMethodsPresentCheckedListBox.ItemCheck += publicMethodsPresentCheckedListBox_ItemCheck;
			// 
			// quickSearchTextBox
			// 
			quickSearchTextBox.Font = new Font ("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
			quickSearchTextBox.Location = new Point (442, 81);
			quickSearchTextBox.Name = "quickSearchTextBox";
			quickSearchTextBox.Size = new Size (1362, 26);
			quickSearchTextBox.TabIndex = 32;
			quickSearchTextBox.TextChanged += quickSearchTextBox_TextChanged;
			// 
			// quickSearchLabel
			// 
			quickSearchLabel.AutoSize = true;
			quickSearchLabel.Font = new Font ("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			quickSearchLabel.ForeColor = Color.Black;
			quickSearchLabel.Location = new Point (340, 84);
			quickSearchLabel.Name = "quickSearchLabel";
			quickSearchLabel.Size = new Size (102, 18);
			quickSearchLabel.TabIndex = 31;
			quickSearchLabel.Text = "Quick Search :";
			quickSearchLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// concreteClassesDropDownList
			// 
			concreteClassesDropDownList.DropDownStyle = ComboBoxStyle.DropDownList;
			concreteClassesDropDownList.Font = new Font ("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
			concreteClassesDropDownList.FormattingEnabled = true;
			concreteClassesDropDownList.Location = new Point (442, 48);
			concreteClassesDropDownList.Name = "concreteClassesDropDownList";
			concreteClassesDropDownList.Size = new Size (1362, 27);
			concreteClassesDropDownList.TabIndex = 30;
			concreteClassesDropDownList.SelectedIndexChanged += concreteClassesDropDownList_SelectedIndexChanged;
			// 
			// browseDllButton
			// 
			browseDllButton.Font = new Font ("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			browseDllButton.ForeColor = Color.Black;
			browseDllButton.Location = new Point (1772, 15);
			browseDllButton.Name = "browseDllButton";
			browseDllButton.Size = new Size (32, 26);
			browseDllButton.TabIndex = 29;
			browseDllButton.Text = "...";
			browseDllButton.UseVisualStyleBackColor = true;
			browseDllButton.Click += browseDllButton_Click;
			// 
			// dllPathTextBox
			// 
			dllPathTextBox.Font = new Font ("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dllPathTextBox.Location = new Point (442, 15);
			dllPathTextBox.Name = "dllPathTextBox";
			dllPathTextBox.Size = new Size (1324, 26);
			dllPathTextBox.TabIndex = 28;
			dllPathTextBox.TextChanged += dllPathTextBox_TextChanged;
			// 
			// concreteClassLabel
			// 
			concreteClassLabel.AutoSize = true;
			concreteClassLabel.Font = new Font ("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			concreteClassLabel.ForeColor = Color.Black;
			concreteClassLabel.Location = new Point (328, 51);
			concreteClassLabel.Name = "concreteClassLabel";
			concreteClassLabel.Size = new Size (114, 18);
			concreteClassLabel.TabIndex = 26;
			concreteClassLabel.Text = "Concrete Class :";
			concreteClassLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// dllPathLabel
			// 
			dllPathLabel.AutoSize = true;
			dllPathLabel.Font = new Font ("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
			dllPathLabel.ForeColor = Color.Black;
			dllPathLabel.Location = new Point (366, 20);
			dllPathLabel.Name = "dllPathLabel";
			dllPathLabel.Size = new Size (76, 18);
			dllPathLabel.TabIndex = 27;
			dllPathLabel.Text = "DLL Path :";
			dllPathLabel.TextAlign = ContentAlignment.MiddleRight;
			// 
			// selectTargetClassSectionLabel
			// 
			selectTargetClassSectionLabel.FlatStyle = FlatStyle.Popup;
			selectTargetClassSectionLabel.Font = new Font ("Candara", 18F, FontStyle.Underline, GraphicsUnit.Point);
			selectTargetClassSectionLabel.ForeColor = Color.Black;
			selectTargetClassSectionLabel.Image = Properties.Resources.Target_Method_Label21;
			selectTargetClassSectionLabel.ImageAlign = ContentAlignment.TopRight;
			selectTargetClassSectionLabel.Location = new Point (130, 15);
			selectTargetClassSectionLabel.Name = "selectTargetClassSectionLabel";
			selectTargetClassSectionLabel.Size = new Size (191, 94);
			selectTargetClassSectionLabel.TabIndex = 25;
			selectTargetClassSectionLabel.Text = "Select Target C# Concrete Class Method";
			selectTargetClassSectionLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// concreteClassPictureBox
			// 
			concreteClassPictureBox.BackgroundImageLayout = ImageLayout.None;
			concreteClassPictureBox.Image = (Image) resources.GetObject ("concreteClassPictureBox.Image");
			concreteClassPictureBox.InitialImage = Properties.Resources.Mock;
			concreteClassPictureBox.Location = new Point (15, 15);
			concreteClassPictureBox.Name = "concreteClassPictureBox";
			concreteClassPictureBox.Size = new Size (98, 94);
			concreteClassPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			concreteClassPictureBox.TabIndex = 24;
			concreteClassPictureBox.TabStop = false;
			// 
			// generatedUnitTestsTabPage
			// 
			generatedUnitTestsTabPage.Controls.Add (panel7);
			generatedUnitTestsTabPage.Location = new Point (4, 29);
			generatedUnitTestsTabPage.Name = "generatedUnitTestsTabPage";
			generatedUnitTestsTabPage.Size = new Size (1865, 970);
			generatedUnitTestsTabPage.TabIndex = 2;
			generatedUnitTestsTabPage.Text = "        Generated Unit Tests        ";
			generatedUnitTestsTabPage.UseVisualStyleBackColor = true;
			// 
			// panel7
			// 
			panel7.BackColor = Color.Silver;
			panel7.BorderStyle = BorderStyle.Fixed3D;
			panel7.Controls.Add (selectedMethodsListBox);
			panel7.Controls.Add (copyUnitTestCodeButton);
			panel7.Controls.Add (saveUnitTestsButton);
			panel7.Controls.Add (generatedUnitTestRichTextBox);
			panel7.Location = new Point (20, 22);
			panel7.Name = "panel7";
			panel7.Size = new Size (1824, 924);
			panel7.TabIndex = 8;
			// 
			// selectedMethodsListBox
			// 
			selectedMethodsListBox.Font = new Font ("Cascadia Code SemiLight", 12F, FontStyle.Regular, GraphicsUnit.Point);
			selectedMethodsListBox.FormattingEnabled = true;
			selectedMethodsListBox.ItemHeight = 21;
			selectedMethodsListBox.Location = new Point (19, 19);
			selectedMethodsListBox.Name = "selectedMethodsListBox";
			selectedMethodsListBox.Size = new Size (1781, 130);
			selectedMethodsListBox.TabIndex = 36;
			selectedMethodsListBox.SelectedIndexChanged += selectedMethodsListBox_SelectedIndexChanged;
			// 
			// copyUnitTestCodeButton
			// 
			copyUnitTestCodeButton.BackColor = Color.Plum;
			copyUnitTestCodeButton.Font = new Font ("Candara", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			copyUnitTestCodeButton.ForeColor = Color.Black;
			copyUnitTestCodeButton.Location = new Point (1460, 836);
			copyUnitTestCodeButton.Name = "copyUnitTestCodeButton";
			copyUnitTestCodeButton.Size = new Size (309, 52);
			copyUnitTestCodeButton.TabIndex = 33;
			copyUnitTestCodeButton.Text = "Copy Code";
			copyUnitTestCodeButton.UseVisualStyleBackColor = false;
			copyUnitTestCodeButton.Click += copyUnitTestCodeButton_Click;
			// 
			// saveUnitTestsButton
			// 
			saveUnitTestsButton.BackColor = Color.Turquoise;
			saveUnitTestsButton.Font = new Font ("Candara", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			saveUnitTestsButton.ForeColor = Color.Black;
			saveUnitTestsButton.Location = new Point (1460, 778);
			saveUnitTestsButton.Name = "saveUnitTestsButton";
			saveUnitTestsButton.Size = new Size (309, 52);
			saveUnitTestsButton.TabIndex = 33;
			saveUnitTestsButton.Text = "Save Unit Tests";
			saveUnitTestsButton.UseVisualStyleBackColor = false;
			saveUnitTestsButton.Click += saveUnitTestsButton_Click;
			// 
			// generatedUnitTestRichTextBox
			// 
			generatedUnitTestRichTextBox.BackColor = Color.FromArgb (  30,   30,   30);
			generatedUnitTestRichTextBox.Font = new Font ("Cascadia Code SemiLight", 12F, FontStyle.Regular, GraphicsUnit.Point);
			generatedUnitTestRichTextBox.ForeColor = Color.White;
			generatedUnitTestRichTextBox.Location = new Point (19, 164);
			generatedUnitTestRichTextBox.Name = "generatedUnitTestRichTextBox";
			generatedUnitTestRichTextBox.Size = new Size (1781, 736);
			generatedUnitTestRichTextBox.TabIndex = 37;
			generatedUnitTestRichTextBox.Text = "";
			generatedUnitTestRichTextBox.WordWrap = false;
			generatedUnitTestRichTextBox.KeyDown += generatedUnitTestRichTextBox_KeyDown;
			// 
			// unitTestOptionsTabPage
			// 
			unitTestOptionsTabPage.BackColor = Color.PaleTurquoise;
			unitTestOptionsTabPage.Controls.Add (resetToDefaultOptionsButton);
			unitTestOptionsTabPage.Controls.Add (rememberMyPreferencesCheckBox);
			unitTestOptionsTabPage.Controls.Add (addFriendlyCommentsCheckBox);
			unitTestOptionsTabPage.Controls.Add (addToDoStatementsCheckBox);
			unitTestOptionsTabPage.Controls.Add (addAssertionForVoidDependencyCallsCheckBox);
			unitTestOptionsTabPage.Controls.Add (addUsingNamespacesCheckBox);
			unitTestOptionsTabPage.Controls.Add (panel5);
			unitTestOptionsTabPage.Controls.Add (panel4);
			unitTestOptionsTabPage.Controls.Add (panel3);
			unitTestOptionsTabPage.Controls.Add (panel2);
			unitTestOptionsTabPage.Controls.Add (panel1);
			unitTestOptionsTabPage.Font = new Font ("Candara", 12F, FontStyle.Regular, GraphicsUnit.Point);
			unitTestOptionsTabPage.ForeColor = Color.Gray;
			unitTestOptionsTabPage.Location = new Point (4, 29);
			unitTestOptionsTabPage.Name = "unitTestOptionsTabPage";
			unitTestOptionsTabPage.Padding = new Padding (3);
			unitTestOptionsTabPage.Size = new Size (1865, 970);
			unitTestOptionsTabPage.TabIndex = 0;
			unitTestOptionsTabPage.Text = "        Unit Test Platform Options        ";
			// 
			// resetToDefaultOptionsButton
			// 
			resetToDefaultOptionsButton.BackColor = Color.MediumVioletRed;
			resetToDefaultOptionsButton.Font = new Font ("Candara", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
			resetToDefaultOptionsButton.ForeColor = Color.White;
			resetToDefaultOptionsButton.Location = new Point (20, 575);
			resetToDefaultOptionsButton.Name = "resetToDefaultOptionsButton";
			resetToDefaultOptionsButton.Size = new Size (385, 50);
			resetToDefaultOptionsButton.TabIndex = 34;
			resetToDefaultOptionsButton.Text = "Reset to Default Options";
			resetToDefaultOptionsButton.UseVisualStyleBackColor = false;
			resetToDefaultOptionsButton.Click += resetToDefaultOptionsButton_Click;
			// 
			// rememberMyPreferencesCheckBox
			// 
			rememberMyPreferencesCheckBox.AutoSize = true;
			rememberMyPreferencesCheckBox.Font = new Font ("Candara", 12F, FontStyle.Bold, GraphicsUnit.Point);
			rememberMyPreferencesCheckBox.Location = new Point (20, 922);
			rememberMyPreferencesCheckBox.Name = "rememberMyPreferencesCheckBox";
			rememberMyPreferencesCheckBox.Size = new Size (212, 23);
			rememberMyPreferencesCheckBox.TabIndex = 8;
			rememberMyPreferencesCheckBox.Text = "Remember my preferences";
			rememberMyPreferencesCheckBox.UseVisualStyleBackColor = true;
			// 
			// addFriendlyCommentsCheckBox
			// 
			addFriendlyCommentsCheckBox.AutoSize = true;
			addFriendlyCommentsCheckBox.Checked = true;
			addFriendlyCommentsCheckBox.CheckState = CheckState.Checked;
			addFriendlyCommentsCheckBox.ForeColor = Color.Black;
			addFriendlyCommentsCheckBox.Location = new Point (1050, 540);
			addFriendlyCommentsCheckBox.Name = "addFriendlyCommentsCheckBox";
			addFriendlyCommentsCheckBox.Size = new Size (256, 23);
			addFriendlyCommentsCheckBox.TabIndex = 7;
			addFriendlyCommentsCheckBox.Text = "Add friendly single-line comments";
			addFriendlyCommentsCheckBox.UseVisualStyleBackColor = true;
			addFriendlyCommentsCheckBox.CheckedChanged += addFriendlyCommentsCheckBox_CheckedChanged;
			// 
			// addToDoStatementsCheckBox
			// 
			addToDoStatementsCheckBox.AutoSize = true;
			addToDoStatementsCheckBox.Checked = true;
			addToDoStatementsCheckBox.CheckState = CheckState.Checked;
			addToDoStatementsCheckBox.ForeColor = Color.Black;
			addToDoStatementsCheckBox.Location = new Point (1050, 505);
			addToDoStatementsCheckBox.Name = "addToDoStatementsCheckBox";
			addToDoStatementsCheckBox.Size = new Size (399, 23);
			addToDoStatementsCheckBox.TabIndex = 7;
			addToDoStatementsCheckBox.Text = "Add '// TODO: ' comments that instruct what to do next";
			addToDoStatementsCheckBox.UseVisualStyleBackColor = true;
			addToDoStatementsCheckBox.CheckedChanged += addToDoStatementsCheckBox_CheckedChanged;
			// 
			// addAssertionForVoidDependencyCallsCheckBox
			// 
			addAssertionForVoidDependencyCallsCheckBox.AutoSize = true;
			addAssertionForVoidDependencyCallsCheckBox.Checked = true;
			addAssertionForVoidDependencyCallsCheckBox.CheckState = CheckState.Checked;
			addAssertionForVoidDependencyCallsCheckBox.ForeColor = Color.Black;
			addAssertionForVoidDependencyCallsCheckBox.Location = new Point (1050, 435);
			addAssertionForVoidDependencyCallsCheckBox.Name = "addAssertionForVoidDependencyCallsCheckBox";
			addAssertionForVoidDependencyCallsCheckBox.Size = new Size (442, 23);
			addAssertionForVoidDependencyCallsCheckBox.TabIndex = 7;
			addAssertionForVoidDependencyCallsCheckBox.Text = "Add assertion statements for 'void' dependency method calls";
			addAssertionForVoidDependencyCallsCheckBox.UseVisualStyleBackColor = true;
			addAssertionForVoidDependencyCallsCheckBox.CheckedChanged += addAssertionForVoidDependencyCallsCheckBox_CheckedChanged;
			// 
			// addUsingNamespacesCheckBox
			// 
			addUsingNamespacesCheckBox.AutoSize = true;
			addUsingNamespacesCheckBox.Checked = true;
			addUsingNamespacesCheckBox.CheckState = CheckState.Checked;
			addUsingNamespacesCheckBox.ForeColor = Color.Black;
			addUsingNamespacesCheckBox.Location = new Point (1050, 470);
			addUsingNamespacesCheckBox.Name = "addUsingNamespacesCheckBox";
			addUsingNamespacesCheckBox.Size = new Size (438, 23);
			addUsingNamespacesCheckBox.TabIndex = 7;
			addUsingNamespacesCheckBox.Text = "Add library 'using &Namespaces;' statements, even if not used";
			addUsingNamespacesCheckBox.UseVisualStyleBackColor = true;
			addUsingNamespacesCheckBox.CheckedChanged += addNamespacesCheckBox_CheckedChanged;
			// 
			// panel5
			// 
			panel5.BackColor = Color.Silver;
			panel5.BorderStyle = BorderStyle.Fixed3D;
			panel5.Controls.Add (utMethodNameStartsWithWhenRadioButton);
			panel5.Controls.Add (utMethodNameStartsWithShouldRadioButton);
			panel5.Controls.Add (utMethodNamingStyleHighlighterLabel);
			panel5.Controls.Add (unitTestMethodNamingStyleSectionLabel);
			panel5.Location = new Point (20, 435);
			panel5.Name = "panel5";
			panel5.Size = new Size (1000, 127);
			panel5.TabIndex = 6;
			// 
			// utMethodNameStartsWithWhenRadioButton
			// 
			utMethodNameStartsWithWhenRadioButton.AutoSize = true;
			utMethodNameStartsWithWhenRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			utMethodNameStartsWithWhenRadioButton.ForeColor = Color.Black;
			utMethodNameStartsWithWhenRadioButton.Location = new Point (260, 75);
			utMethodNameStartsWithWhenRadioButton.Name = "utMethodNameStartsWithWhenRadioButton";
			utMethodNameStartsWithWhenRadioButton.Size = new Size (469, 25);
			utMethodNameStartsWithWhenRadioButton.TabIndex = 9;
			utMethodNameStartsWithWhenRadioButton.TabStop = true;
			utMethodNameStartsWithWhenRadioButton.Text = "public void WhenListIsEmpty_ItShouldReturnTrue ()";
			utMethodNameStartsWithWhenRadioButton.UseVisualStyleBackColor = true;
			utMethodNameStartsWithWhenRadioButton.CheckedChanged += utMethodNameStartsWithWhenRadioButton_CheckedChanged;
			// 
			// utMethodNameStartsWithShouldRadioButton
			// 
			utMethodNameStartsWithShouldRadioButton.AutoSize = true;
			utMethodNameStartsWithShouldRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			utMethodNameStartsWithShouldRadioButton.ForeColor = Color.Black;
			utMethodNameStartsWithShouldRadioButton.Location = new Point (260, 30);
			utMethodNameStartsWithShouldRadioButton.Name = "utMethodNameStartsWithShouldRadioButton";
			utMethodNameStartsWithShouldRadioButton.Size = new Size (433, 25);
			utMethodNameStartsWithShouldRadioButton.TabIndex = 10;
			utMethodNameStartsWithShouldRadioButton.TabStop = true;
			utMethodNameStartsWithShouldRadioButton.Text = "public void ShouldReturnTrue_IfListIsEmpty ()";
			utMethodNameStartsWithShouldRadioButton.UseVisualStyleBackColor = true;
			utMethodNameStartsWithShouldRadioButton.CheckedChanged += utMethodNameStartsWithShouldRadioButton_CheckedChanged;
			// 
			// utMethodNamingStyleHighlighterLabel
			// 
			utMethodNamingStyleHighlighterLabel.BackColor = Color.Yellow;
			utMethodNamingStyleHighlighterLabel.BorderStyle = BorderStyle.FixedSingle;
			utMethodNamingStyleHighlighterLabel.Location = new Point (250, 20);
			utMethodNamingStyleHighlighterLabel.Name = "utMethodNamingStyleHighlighterLabel";
			utMethodNamingStyleHighlighterLabel.Size = new Size (730, 45);
			utMethodNamingStyleHighlighterLabel.TabIndex = 11;
			// 
			// unitTestMethodNamingStyleSectionLabel
			// 
			unitTestMethodNamingStyleSectionLabel.FlatStyle = FlatStyle.Popup;
			unitTestMethodNamingStyleSectionLabel.Font = new Font ("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			unitTestMethodNamingStyleSectionLabel.ForeColor = Color.Black;
			unitTestMethodNamingStyleSectionLabel.Image = (Image) resources.GetObject ("unitTestMethodNamingStyleSectionLabel.Image");
			unitTestMethodNamingStyleSectionLabel.Location = new Point (15, 15);
			unitTestMethodNamingStyleSectionLabel.Name = "unitTestMethodNamingStyleSectionLabel";
			unitTestMethodNamingStyleSectionLabel.Size = new Size (221, 94);
			unitTestMethodNamingStyleSectionLabel.TabIndex = 8;
			unitTestMethodNamingStyleSectionLabel.Text = "Unit Test Method Naming Style";
			unitTestMethodNamingStyleSectionLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel4
			// 
			panel4.BackColor = Color.Silver;
			panel4.BorderStyle = BorderStyle.Fixed3D;
			panel4.Controls.Add (testData5RadioButton);
			panel4.Controls.Add (testData4RadioButton);
			panel4.Controls.Add (testData3RadioButton);
			panel4.Controls.Add (autoFixtureRadioButton);
			panel4.Controls.Add (nBuilderRadioButton);
			panel4.Controls.Add (testDataPrepLibraryHighlighterLabel);
			panel4.Controls.Add (testDataPrepLibraryPictureBox);
			panel4.Controls.Add (testDataPrepLibrarySectionLabel);
			panel4.Location = new Point (1160, 20);
			panel4.Name = "panel4";
			panel4.Size = new Size (360, 395);
			panel4.TabIndex = 6;
			// 
			// testData5RadioButton
			// 
			testData5RadioButton.AutoSize = true;
			testData5RadioButton.Enabled = false;
			testData5RadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			testData5RadioButton.ForeColor = Color.Black;
			testData5RadioButton.Location = new Point (25, 340);
			testData5RadioButton.Name = "testData5RadioButton";
			testData5RadioButton.Size = new Size (136, 25);
			testData5RadioButton.TabIndex = 25;
			testData5RadioButton.TabStop = true;
			testData5RadioButton.Text = "(Yet to add)";
			testData5RadioButton.UseVisualStyleBackColor = true;
			testData5RadioButton.CheckedChanged += testDataFrameworkChanged;
			// 
			// testData4RadioButton
			// 
			testData4RadioButton.AutoSize = true;
			testData4RadioButton.Enabled = false;
			testData4RadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			testData4RadioButton.ForeColor = Color.Black;
			testData4RadioButton.Location = new Point (25, 290);
			testData4RadioButton.Name = "testData4RadioButton";
			testData4RadioButton.Size = new Size (136, 25);
			testData4RadioButton.TabIndex = 26;
			testData4RadioButton.TabStop = true;
			testData4RadioButton.Text = "(Yet to add)";
			testData4RadioButton.UseVisualStyleBackColor = true;
			testData4RadioButton.CheckedChanged += testDataFrameworkChanged;
			// 
			// testData3RadioButton
			// 
			testData3RadioButton.AutoSize = true;
			testData3RadioButton.Enabled = false;
			testData3RadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			testData3RadioButton.ForeColor = Color.Black;
			testData3RadioButton.Location = new Point (25, 240);
			testData3RadioButton.Name = "testData3RadioButton";
			testData3RadioButton.Size = new Size (136, 25);
			testData3RadioButton.TabIndex = 27;
			testData3RadioButton.TabStop = true;
			testData3RadioButton.Text = "(Yet to add)";
			testData3RadioButton.UseVisualStyleBackColor = true;
			testData3RadioButton.CheckedChanged += testDataFrameworkChanged;
			// 
			// autoFixtureRadioButton
			// 
			autoFixtureRadioButton.AutoSize = true;
			autoFixtureRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			autoFixtureRadioButton.ForeColor = Color.Black;
			autoFixtureRadioButton.Location = new Point (25, 190);
			autoFixtureRadioButton.Name = "autoFixtureRadioButton";
			autoFixtureRadioButton.Size = new Size (127, 25);
			autoFixtureRadioButton.TabIndex = 28;
			autoFixtureRadioButton.TabStop = true;
			autoFixtureRadioButton.Text = "AutoFixture";
			autoFixtureRadioButton.UseVisualStyleBackColor = true;
			autoFixtureRadioButton.CheckedChanged += testDataFrameworkChanged;
			// 
			// nBuilderRadioButton
			// 
			nBuilderRadioButton.AutoSize = true;
			nBuilderRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			nBuilderRadioButton.ForeColor = Color.Black;
			nBuilderRadioButton.Location = new Point (25, 140);
			nBuilderRadioButton.Name = "nBuilderRadioButton";
			nBuilderRadioButton.Size = new Size (181, 25);
			nBuilderRadioButton.TabIndex = 29;
			nBuilderRadioButton.TabStop = true;
			nBuilderRadioButton.Text = "Fizzware NBuilder";
			nBuilderRadioButton.UseVisualStyleBackColor = true;
			nBuilderRadioButton.CheckedChanged += testDataFrameworkChanged;
			// 
			// testDataPrepLibraryHighlighterLabel
			// 
			testDataPrepLibraryHighlighterLabel.BackColor = Color.Yellow;
			testDataPrepLibraryHighlighterLabel.BorderStyle = BorderStyle.FixedSingle;
			testDataPrepLibraryHighlighterLabel.ForeColor = Color.White;
			testDataPrepLibraryHighlighterLabel.Location = new Point (15, 130);
			testDataPrepLibraryHighlighterLabel.Name = "testDataPrepLibraryHighlighterLabel";
			testDataPrepLibraryHighlighterLabel.Size = new Size (327, 45);
			testDataPrepLibraryHighlighterLabel.TabIndex = 30;
			// 
			// testDataPrepLibraryPictureBox
			// 
			testDataPrepLibraryPictureBox.BackgroundImageLayout = ImageLayout.None;
			testDataPrepLibraryPictureBox.Image = Properties.Resources.Test_Data;
			testDataPrepLibraryPictureBox.InitialImage = Properties.Resources.Mock;
			testDataPrepLibraryPictureBox.Location = new Point (15, 15);
			testDataPrepLibraryPictureBox.Name = "testDataPrepLibraryPictureBox";
			testDataPrepLibraryPictureBox.Size = new Size (100, 100);
			testDataPrepLibraryPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			testDataPrepLibraryPictureBox.TabIndex = 24;
			testDataPrepLibraryPictureBox.TabStop = false;
			// 
			// testDataPrepLibrarySectionLabel
			// 
			testDataPrepLibrarySectionLabel.FlatStyle = FlatStyle.Popup;
			testDataPrepLibrarySectionLabel.Font = new Font ("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			testDataPrepLibrarySectionLabel.ForeColor = Color.Transparent;
			testDataPrepLibrarySectionLabel.Image = (Image) resources.GetObject ("testDataPrepLibrarySectionLabel.Image");
			testDataPrepLibrarySectionLabel.ImageAlign = ContentAlignment.TopRight;
			testDataPrepLibrarySectionLabel.Location = new Point (130, 15);
			testDataPrepLibrarySectionLabel.Margin = new Padding (0);
			testDataPrepLibrarySectionLabel.Name = "testDataPrepLibrarySectionLabel";
			testDataPrepLibrarySectionLabel.Size = new Size (210, 100);
			testDataPrepLibrarySectionLabel.TabIndex = 8;
			testDataPrepLibrarySectionLabel.Text = "Test Data Preparation Library";
			testDataPrepLibrarySectionLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			panel3.BackColor = Color.Silver;
			panel3.BorderStyle = BorderStyle.Fixed3D;
			panel3.Controls.Add (nSureRadioButton);
			panel3.Controls.Add (nFluentRadioButton);
			panel3.Controls.Add (shouldRadioButton);
			panel3.Controls.Add (shouldlyRadioButton);
			panel3.Controls.Add (fluentAssertionsRadioButton);
			panel3.Controls.Add (fluentLibraryHighlighterLabel);
			panel3.Controls.Add (fluentAssertionLibraryPictureBox);
			panel3.Controls.Add (fluentAssertionLibrarySectionLabel);
			panel3.Location = new Point (780, 20);
			panel3.Name = "panel3";
			panel3.Size = new Size (360, 395);
			panel3.TabIndex = 6;
			// 
			// nSureRadioButton
			// 
			nSureRadioButton.AutoSize = true;
			nSureRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			nSureRadioButton.ForeColor = Color.Black;
			nSureRadioButton.Location = new Point (25, 340);
			nSureRadioButton.Name = "nSureRadioButton";
			nSureRadioButton.Size = new Size (73, 25);
			nSureRadioButton.TabIndex = 18;
			nSureRadioButton.TabStop = true;
			nSureRadioButton.Text = "NSure";
			nSureRadioButton.UseVisualStyleBackColor = true;
			nSureRadioButton.CheckedChanged += fluentFrameworkChanged;
			// 
			// nFluentRadioButton
			// 
			nFluentRadioButton.AutoSize = true;
			nFluentRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			nFluentRadioButton.ForeColor = Color.Black;
			nFluentRadioButton.Location = new Point (25, 290);
			nFluentRadioButton.Name = "nFluentRadioButton";
			nFluentRadioButton.Size = new Size (91, 25);
			nFluentRadioButton.TabIndex = 19;
			nFluentRadioButton.TabStop = true;
			nFluentRadioButton.Text = "nFluent";
			nFluentRadioButton.UseVisualStyleBackColor = true;
			nFluentRadioButton.CheckedChanged += fluentFrameworkChanged;
			// 
			// shouldRadioButton
			// 
			shouldRadioButton.AutoSize = true;
			shouldRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			shouldRadioButton.ForeColor = Color.Black;
			shouldRadioButton.Location = new Point (25, 240);
			shouldRadioButton.Name = "shouldRadioButton";
			shouldRadioButton.Size = new Size (82, 25);
			shouldRadioButton.TabIndex = 20;
			shouldRadioButton.TabStop = true;
			shouldRadioButton.Text = "Should";
			shouldRadioButton.UseVisualStyleBackColor = true;
			shouldRadioButton.CheckedChanged += fluentFrameworkChanged;
			// 
			// shouldlyRadioButton
			// 
			shouldlyRadioButton.AutoSize = true;
			shouldlyRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			shouldlyRadioButton.ForeColor = Color.Black;
			shouldlyRadioButton.Location = new Point (25, 190);
			shouldlyRadioButton.Name = "shouldlyRadioButton";
			shouldlyRadioButton.Size = new Size (100, 25);
			shouldlyRadioButton.TabIndex = 21;
			shouldlyRadioButton.TabStop = true;
			shouldlyRadioButton.Text = "Shouldly";
			shouldlyRadioButton.UseVisualStyleBackColor = true;
			shouldlyRadioButton.CheckedChanged += fluentFrameworkChanged;
			// 
			// fluentAssertionsRadioButton
			// 
			fluentAssertionsRadioButton.AutoSize = true;
			fluentAssertionsRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			fluentAssertionsRadioButton.ForeColor = Color.Black;
			fluentAssertionsRadioButton.Location = new Point (25, 140);
			fluentAssertionsRadioButton.Name = "fluentAssertionsRadioButton";
			fluentAssertionsRadioButton.Size = new Size (172, 25);
			fluentAssertionsRadioButton.TabIndex = 22;
			fluentAssertionsRadioButton.TabStop = true;
			fluentAssertionsRadioButton.Text = "FluentAssertions";
			fluentAssertionsRadioButton.UseVisualStyleBackColor = true;
			fluentAssertionsRadioButton.CheckedChanged += fluentFrameworkChanged;
			// 
			// fluentLibraryHighlighterLabel
			// 
			fluentLibraryHighlighterLabel.BackColor = Color.Yellow;
			fluentLibraryHighlighterLabel.BorderStyle = BorderStyle.FixedSingle;
			fluentLibraryHighlighterLabel.ForeColor = Color.White;
			fluentLibraryHighlighterLabel.Location = new Point (15, 130);
			fluentLibraryHighlighterLabel.Name = "fluentLibraryHighlighterLabel";
			fluentLibraryHighlighterLabel.Size = new Size (327, 45);
			fluentLibraryHighlighterLabel.TabIndex = 23;
			// 
			// fluentAssertionLibraryPictureBox
			// 
			fluentAssertionLibraryPictureBox.BackgroundImageLayout = ImageLayout.None;
			fluentAssertionLibraryPictureBox.Image = Properties.Resources.Assert;
			fluentAssertionLibraryPictureBox.InitialImage = Properties.Resources.Mock;
			fluentAssertionLibraryPictureBox.Location = new Point (15, 15);
			fluentAssertionLibraryPictureBox.Name = "fluentAssertionLibraryPictureBox";
			fluentAssertionLibraryPictureBox.Size = new Size (100, 100);
			fluentAssertionLibraryPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			fluentAssertionLibraryPictureBox.TabIndex = 17;
			fluentAssertionLibraryPictureBox.TabStop = false;
			// 
			// fluentAssertionLibrarySectionLabel
			// 
			fluentAssertionLibrarySectionLabel.FlatStyle = FlatStyle.Popup;
			fluentAssertionLibrarySectionLabel.Font = new Font ("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			fluentAssertionLibrarySectionLabel.ForeColor = Color.Transparent;
			fluentAssertionLibrarySectionLabel.Image = (Image) resources.GetObject ("fluentAssertionLibrarySectionLabel.Image");
			fluentAssertionLibrarySectionLabel.ImageAlign = ContentAlignment.TopRight;
			fluentAssertionLibrarySectionLabel.Location = new Point (130, 15);
			fluentAssertionLibrarySectionLabel.Margin = new Padding (0);
			fluentAssertionLibrarySectionLabel.Name = "fluentAssertionLibrarySectionLabel";
			fluentAssertionLibrarySectionLabel.Size = new Size (210, 100);
			fluentAssertionLibrarySectionLabel.TabIndex = 8;
			fluentAssertionLibrarySectionLabel.Text = "Fluent Assertion Library";
			fluentAssertionLibrarySectionLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			panel2.BackColor = Color.Silver;
			panel2.BorderStyle = BorderStyle.Fixed3D;
			panel2.Controls.Add (rhinoMockRadioButton);
			panel2.Controls.Add (fakeItEasyRadioButton);
			panel2.Controls.Add (justMockLiteRadioButton);
			panel2.Controls.Add (nSubstituteRadioButton);
			panel2.Controls.Add (moqRadioButton);
			panel2.Controls.Add (mockLibraryHighlighterLabel);
			panel2.Controls.Add (mockLibraryPictureBox);
			panel2.Controls.Add (mockingLibrarySectionLabel);
			panel2.Location = new Point (400, 20);
			panel2.Name = "panel2";
			panel2.Size = new Size (360, 395);
			panel2.TabIndex = 6;
			// 
			// rhinoMockRadioButton
			// 
			rhinoMockRadioButton.AutoSize = true;
			rhinoMockRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			rhinoMockRadioButton.ForeColor = Color.Black;
			rhinoMockRadioButton.Location = new Point (25, 340);
			rhinoMockRadioButton.Name = "rhinoMockRadioButton";
			rhinoMockRadioButton.Size = new Size (118, 25);
			rhinoMockRadioButton.TabIndex = 11;
			rhinoMockRadioButton.TabStop = true;
			rhinoMockRadioButton.Text = "Rhino Mock";
			rhinoMockRadioButton.UseVisualStyleBackColor = true;
			rhinoMockRadioButton.CheckedChanged += mockFrameworkChanged;
			// 
			// fakeItEasyRadioButton
			// 
			fakeItEasyRadioButton.AutoSize = true;
			fakeItEasyRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			fakeItEasyRadioButton.ForeColor = Color.Black;
			fakeItEasyRadioButton.Location = new Point (25, 290);
			fakeItEasyRadioButton.Name = "fakeItEasyRadioButton";
			fakeItEasyRadioButton.Size = new Size (136, 25);
			fakeItEasyRadioButton.TabIndex = 12;
			fakeItEasyRadioButton.TabStop = true;
			fakeItEasyRadioButton.Text = "Fake It Easy";
			fakeItEasyRadioButton.UseVisualStyleBackColor = true;
			fakeItEasyRadioButton.CheckedChanged += mockFrameworkChanged;
			// 
			// justMockLiteRadioButton
			// 
			justMockLiteRadioButton.AutoSize = true;
			justMockLiteRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			justMockLiteRadioButton.ForeColor = Color.Black;
			justMockLiteRadioButton.Location = new Point (25, 240);
			justMockLiteRadioButton.Name = "justMockLiteRadioButton";
			justMockLiteRadioButton.Size = new Size (181, 25);
			justMockLiteRadioButton.TabIndex = 13;
			justMockLiteRadioButton.TabStop = true;
			justMockLiteRadioButton.Text = "Telerik Just Mock";
			justMockLiteRadioButton.UseVisualStyleBackColor = true;
			justMockLiteRadioButton.CheckedChanged += mockFrameworkChanged;
			// 
			// nSubstituteRadioButton
			// 
			nSubstituteRadioButton.AutoSize = true;
			nSubstituteRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			nSubstituteRadioButton.ForeColor = Color.Black;
			nSubstituteRadioButton.Location = new Point (25, 190);
			nSubstituteRadioButton.Name = "nSubstituteRadioButton";
			nSubstituteRadioButton.Size = new Size (127, 25);
			nSubstituteRadioButton.TabIndex = 14;
			nSubstituteRadioButton.TabStop = true;
			nSubstituteRadioButton.Text = "nSubstitute";
			nSubstituteRadioButton.UseVisualStyleBackColor = true;
			nSubstituteRadioButton.CheckedChanged += mockFrameworkChanged;
			// 
			// moqRadioButton
			// 
			moqRadioButton.AutoSize = true;
			moqRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			moqRadioButton.ForeColor = Color.Black;
			moqRadioButton.Location = new Point (25, 140);
			moqRadioButton.Name = "moqRadioButton";
			moqRadioButton.Size = new Size (55, 25);
			moqRadioButton.TabIndex = 15;
			moqRadioButton.TabStop = true;
			moqRadioButton.Text = "Moq";
			moqRadioButton.UseVisualStyleBackColor = true;
			moqRadioButton.CheckedChanged += mockFrameworkChanged;
			// 
			// mockLibraryHighlighterLabel
			// 
			mockLibraryHighlighterLabel.BackColor = Color.Yellow;
			mockLibraryHighlighterLabel.BorderStyle = BorderStyle.FixedSingle;
			mockLibraryHighlighterLabel.Location = new Point (15, 130);
			mockLibraryHighlighterLabel.Name = "mockLibraryHighlighterLabel";
			mockLibraryHighlighterLabel.Size = new Size (327, 45);
			mockLibraryHighlighterLabel.TabIndex = 16;
			// 
			// mockLibraryPictureBox
			// 
			mockLibraryPictureBox.BackgroundImageLayout = ImageLayout.None;
			mockLibraryPictureBox.Image = Properties.Resources.Mock;
			mockLibraryPictureBox.InitialImage = Properties.Resources.Mock;
			mockLibraryPictureBox.Location = new Point (15, 15);
			mockLibraryPictureBox.Name = "mockLibraryPictureBox";
			mockLibraryPictureBox.Size = new Size (100, 100);
			mockLibraryPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			mockLibraryPictureBox.TabIndex = 10;
			mockLibraryPictureBox.TabStop = false;
			// 
			// mockingLibrarySectionLabel
			// 
			mockingLibrarySectionLabel.FlatStyle = FlatStyle.Popup;
			mockingLibrarySectionLabel.Font = new Font ("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			mockingLibrarySectionLabel.ForeColor = Color.Transparent;
			mockingLibrarySectionLabel.Image = (Image) resources.GetObject ("mockingLibrarySectionLabel.Image");
			mockingLibrarySectionLabel.ImageAlign = ContentAlignment.TopRight;
			mockingLibrarySectionLabel.Location = new Point (130, 15);
			mockingLibrarySectionLabel.Margin = new Padding (0);
			mockingLibrarySectionLabel.Name = "mockingLibrarySectionLabel";
			mockingLibrarySectionLabel.Size = new Size (210, 100);
			mockingLibrarySectionLabel.TabIndex = 8;
			mockingLibrarySectionLabel.Text = "Mocking Library";
			mockingLibrarySectionLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			panel1.BackColor = Color.Silver;
			panel1.BorderStyle = BorderStyle.Fixed3D;
			panel1.Controls.Add (unitTestFrameworkSectionLabel);
			panel1.Controls.Add (nSpecRadioButton);
			panel1.Controls.Add (xBehaveRadioButton);
			panel1.Controls.Add (msTestRadioButton);
			panel1.Controls.Add (xUnitRadioButton);
			panel1.Controls.Add (nUnitRadioButton);
			panel1.Controls.Add (utLibraryHighlighterLabel);
			panel1.Controls.Add (utLibraryPictureBox);
			panel1.Location = new Point (20, 20);
			panel1.Name = "panel1";
			panel1.Size = new Size (360, 395);
			panel1.TabIndex = 5;
			// 
			// unitTestFrameworkSectionLabel
			// 
			unitTestFrameworkSectionLabel.FlatStyle = FlatStyle.Popup;
			unitTestFrameworkSectionLabel.Font = new Font ("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			unitTestFrameworkSectionLabel.ForeColor = Color.Black;
			unitTestFrameworkSectionLabel.Image = Properties.Resources.Unit_Test_Framework_Label2;
			unitTestFrameworkSectionLabel.ImageAlign = ContentAlignment.TopRight;
			unitTestFrameworkSectionLabel.Location = new Point (130, 15);
			unitTestFrameworkSectionLabel.Margin = new Padding (0);
			unitTestFrameworkSectionLabel.Name = "unitTestFrameworkSectionLabel";
			unitTestFrameworkSectionLabel.Size = new Size (210, 100);
			unitTestFrameworkSectionLabel.TabIndex = 8;
			unitTestFrameworkSectionLabel.Text = "Unit Test Framework";
			unitTestFrameworkSectionLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// nSpecRadioButton
			// 
			nSpecRadioButton.AutoSize = true;
			nSpecRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			nSpecRadioButton.ForeColor = Color.Black;
			nSpecRadioButton.Location = new Point (25, 340);
			nSpecRadioButton.Name = "nSpecRadioButton";
			nSpecRadioButton.Size = new Size (73, 25);
			nSpecRadioButton.TabIndex = 2;
			nSpecRadioButton.TabStop = true;
			nSpecRadioButton.Text = "nSpec";
			nSpecRadioButton.UseVisualStyleBackColor = true;
			nSpecRadioButton.CheckedChanged += utFrameworkChanged;
			// 
			// xBehaveRadioButton
			// 
			xBehaveRadioButton.AutoSize = true;
			xBehaveRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			xBehaveRadioButton.ForeColor = Color.Black;
			xBehaveRadioButton.Location = new Point (25, 290);
			xBehaveRadioButton.Name = "xBehaveRadioButton";
			xBehaveRadioButton.Size = new Size (91, 25);
			xBehaveRadioButton.TabIndex = 3;
			xBehaveRadioButton.TabStop = true;
			xBehaveRadioButton.Text = "xBehave";
			xBehaveRadioButton.UseVisualStyleBackColor = true;
			xBehaveRadioButton.CheckedChanged += utFrameworkChanged;
			// 
			// msTestRadioButton
			// 
			msTestRadioButton.AutoSize = true;
			msTestRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			msTestRadioButton.ForeColor = Color.Black;
			msTestRadioButton.Location = new Point (25, 240);
			msTestRadioButton.Name = "msTestRadioButton";
			msTestRadioButton.Size = new Size (154, 25);
			msTestRadioButton.TabIndex = 4;
			msTestRadioButton.TabStop = true;
			msTestRadioButton.Text = "Microsoft Test";
			msTestRadioButton.UseVisualStyleBackColor = true;
			msTestRadioButton.CheckedChanged += utFrameworkChanged;
			// 
			// xUnitRadioButton
			// 
			xUnitRadioButton.AutoSize = true;
			xUnitRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			xUnitRadioButton.ForeColor = Color.Black;
			xUnitRadioButton.Location = new Point (25, 190);
			xUnitRadioButton.Name = "xUnitRadioButton";
			xUnitRadioButton.Size = new Size (73, 25);
			xUnitRadioButton.TabIndex = 5;
			xUnitRadioButton.TabStop = true;
			xUnitRadioButton.Text = "xUnit";
			xUnitRadioButton.UseVisualStyleBackColor = true;
			xUnitRadioButton.CheckedChanged += utFrameworkChanged;
			// 
			// nUnitRadioButton
			// 
			nUnitRadioButton.AutoSize = true;
			nUnitRadioButton.Font = new Font ("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point);
			nUnitRadioButton.ForeColor = Color.Black;
			nUnitRadioButton.Location = new Point (25, 140);
			nUnitRadioButton.Name = "nUnitRadioButton";
			nUnitRadioButton.Size = new Size (73, 25);
			nUnitRadioButton.TabIndex = 6;
			nUnitRadioButton.TabStop = true;
			nUnitRadioButton.Text = "nUnit";
			nUnitRadioButton.UseVisualStyleBackColor = true;
			nUnitRadioButton.CheckedChanged += utFrameworkChanged;
			// 
			// utLibraryHighlighterLabel
			// 
			utLibraryHighlighterLabel.BackColor = Color.Yellow;
			utLibraryHighlighterLabel.BorderStyle = BorderStyle.FixedSingle;
			utLibraryHighlighterLabel.Location = new Point (15, 130);
			utLibraryHighlighterLabel.Name = "utLibraryHighlighterLabel";
			utLibraryHighlighterLabel.Size = new Size (327, 45);
			utLibraryHighlighterLabel.TabIndex = 7;
			// 
			// utLibraryPictureBox
			// 
			utLibraryPictureBox.BackgroundImageLayout = ImageLayout.None;
			utLibraryPictureBox.Image = Properties.Resources.UnitTest;
			utLibraryPictureBox.Location = new Point (15, 15);
			utLibraryPictureBox.Name = "utLibraryPictureBox";
			utLibraryPictureBox.Size = new Size (100, 100);
			utLibraryPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			utLibraryPictureBox.TabIndex = 9;
			utLibraryPictureBox.TabStop = false;
			// 
			// openDllDialog
			// 
			openDllDialog.DefaultExt = "*.dll";
			openDllDialog.FileName = "*.dll";
			openDllDialog.Filter = "*.dll|DLL Files";
			openDllDialog.FilterIndex = 0;
			openDllDialog.Title = "Locate the DLL where Target Concrete Classes are present";
			// 
			// backgroundImageList
			// 
			backgroundImageList.ColorDepth = ColorDepth.Depth32Bit;
			backgroundImageList.ImageStream = (ImageListStreamer) resources.GetObject ("backgroundImageList.ImageStream");
			backgroundImageList.TransparentColor = Color.Transparent;
			backgroundImageList.Images.SetKeyName (0, "Unit Test Framework Label.jpg");
			backgroundImageList.Images.SetKeyName (1, "Mock Library Label.jpg");
			backgroundImageList.Images.SetKeyName (2, "Fluent Assertion Library Label.jpg");
			backgroundImageList.Images.SetKeyName (3, "Test Data Library Label.jpg");
			backgroundImageList.Images.SetKeyName (4, "Target Method Label.png");
			// 
			// whereToSaveFolderDialog
			// 
			whereToSaveFolderDialog.Description = "Select the folder where you want to save the scaffolded Unit Test";
			whereToSaveFolderDialog.RootFolder = Environment.SpecialFolder.Recent;
			whereToSaveFolderDialog.SelectedPath = "C:\\";
			// 
			// UnitTestGeneratorScreen
			// 
			AutoScaleDimensions = new SizeF (9F, 19F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.PowderBlue;
			ClientSize = new Size (1904, 1041);
			Controls.Add (unitGenTabControl);
			Font = new Font ("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			Icon = (Icon) resources.GetObject ("$this.Icon");
			Margin = new Padding (5, 6, 5, 6);
			MaximizeBox = false;
			Name = "UnitTestGeneratorScreen";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Unit Test Generator";
			Load += UnitTestGeneratorScreen_Load;
			unitGenTabControl.ResumeLayout (false);
			targetPublicMethodsTabPage.ResumeLayout (false);
			panel6.ResumeLayout (false);
			panel6.PerformLayout ();
			((System.ComponentModel.ISupportInitialize) concreteClassPictureBox).EndInit ();
			generatedUnitTestsTabPage.ResumeLayout (false);
			panel7.ResumeLayout (false);
			unitTestOptionsTabPage.ResumeLayout (false);
			unitTestOptionsTabPage.PerformLayout ();
			panel5.ResumeLayout (false);
			panel5.PerformLayout ();
			panel4.ResumeLayout (false);
			panel4.PerformLayout ();
			((System.ComponentModel.ISupportInitialize) testDataPrepLibraryPictureBox).EndInit ();
			panel3.ResumeLayout (false);
			panel3.PerformLayout ();
			((System.ComponentModel.ISupportInitialize) fluentAssertionLibraryPictureBox).EndInit ();
			panel2.ResumeLayout (false);
			panel2.PerformLayout ();
			((System.ComponentModel.ISupportInitialize) mockLibraryPictureBox).EndInit ();
			panel1.ResumeLayout (false);
			panel1.PerformLayout ();
			((System.ComponentModel.ISupportInitialize) utLibraryPictureBox).EndInit ();
			ResumeLayout (false);

		}

		#endregion

		private TabControl unitGenTabControl;
        private TabPage unitTestOptionsTabPage;
        private TabPage targetPublicMethodsTabPage;
		private OpenFileDialog openDllDialog;
		private Panel panel1;
		private PictureBox utLibraryPictureBox;
		private Label unitTestFrameworkSectionLabel;
		private RadioButton nSpecRadioButton;
		private RadioButton xBehaveRadioButton;
		private RadioButton msTestRadioButton;
		private RadioButton xUnitRadioButton;
		private RadioButton nUnitRadioButton;
		private Label utLibraryHighlighterLabel;
		private Panel panel2;
		private RadioButton rhinoMockRadioButton;
		private RadioButton fakeItEasyRadioButton;
		private RadioButton justMockLiteRadioButton;
		private RadioButton nSubstituteRadioButton;
		private RadioButton moqRadioButton;
		private Label mockLibraryHighlighterLabel;
		private PictureBox mockLibraryPictureBox;
		private Label mockingLibrarySectionLabel;
		private Panel panel3;
		private PictureBox fluentAssertionLibraryPictureBox;
		private Label fluentAssertionLibrarySectionLabel;
		private RadioButton nSureRadioButton;
		private RadioButton nFluentRadioButton;
		private RadioButton shouldRadioButton;
		private RadioButton shouldlyRadioButton;
		private RadioButton fluentAssertionsRadioButton;
		private Label fluentLibraryHighlighterLabel;
		private Panel panel4;
		private PictureBox testDataPrepLibraryPictureBox;
		private Label testDataPrepLibrarySectionLabel;
		private RadioButton testData5RadioButton;
		private RadioButton testData4RadioButton;
		private RadioButton testData3RadioButton;
		private RadioButton autoFixtureRadioButton;
		private RadioButton nBuilderRadioButton;
		private Label testDataPrepLibraryHighlighterLabel;
		private Panel panel5;
		private Label unitTestMethodNamingStyleSectionLabel;
		private RadioButton utMethodNameStartsWithWhenRadioButton;
		private RadioButton utMethodNameStartsWithShouldRadioButton;
		private Label utMethodNamingStyleHighlighterLabel;
		private Panel panel6;
		private TextBox quickSearchTextBox;
		private Label quickSearchLabel;
		private ComboBox concreteClassesDropDownList;
		private Button browseDllButton;
		private TextBox dllPathTextBox;
		private Label concreteClassLabel;
		private Label dllPathLabel;
		private Label selectTargetClassSectionLabel;
		private PictureBox concreteClassPictureBox;
		private Button generateUnitTestsButton;
		private CheckedListBox publicMethodsPresentCheckedListBox;
		private TabPage generatedUnitTestsTabPage;
		private Panel panel7;
		private Button saveUnitTestsButton;
		private ListBox selectedMethodsListBox;
		private RichTextBox generatedUnitTestRichTextBox;
		private Button deselectAllButton;
		private Button selectAllButton;
		private Button copyUnitTestCodeButton;
		private CheckBox addToDoStatementsCheckBox;
		private CheckBox addUsingNamespacesCheckBox;
		private CheckBox rememberMyPreferencesCheckBox;
		private CheckBox addFriendlyCommentsCheckBox;
		private Button resetToDefaultOptionsButton;
		private ImageList backgroundImageList;
		private CheckBox addAssertionForVoidDependencyCallsCheckBox;
		private FolderBrowserDialog whereToSaveFolderDialog;
	}
}