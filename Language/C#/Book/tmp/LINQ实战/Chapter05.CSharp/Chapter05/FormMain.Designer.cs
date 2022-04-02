namespace LinqInAction.Chapter05
{
  partial class FormMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.tabPage6 = new System.Windows.Forms.TabPage();
        this.dataGridView2 = new System.Windows.Forms.DataGridView();
        this.btnQueryArrayListWithImplicitCast = new System.Windows.Forms.Button();
        this.btnQueryArrayListWithExplicitCast = new System.Windows.Forms.Button();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.txtGroupingResults = new System.Windows.Forms.TextBox();
        this.btnGrouping3 = new System.Windows.Forms.Button();
        this.btnGrouping2 = new System.Windows.Forms.Button();
        this.btnGrouping1 = new System.Windows.Forms.Button();
        this.tabPage4 = new System.Windows.Forms.TabPage();
        this.btnDynamicQueryExpressionTree = new System.Windows.Forms.Button();
        this.dataGridView1 = new System.Windows.Forms.DataGridView();
        this.btnConditionalQuery = new System.Windows.Forms.Button();
        this.cbxSortOrder = new System.Windows.Forms.ComboBox();
        this.btnCustomSort = new System.Windows.Forms.Button();
        this.btnChangingVariable = new System.Windows.Forms.Button();
        this.btnParameterizedQuery = new System.Windows.Forms.Button();
        this.tabPage5 = new System.Windows.Forms.TabPage();
        this.btnLinqtoTextFiles = new System.Windows.Forms.Button();
        this.txtLinqToTextFilesResults = new System.Windows.Forms.TextBox();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.btnFunctionalConstruction = new System.Windows.Forms.Button();
        this.btnFunctionalConstructionAnonymous = new System.Windows.Forms.Button();
        this.txtDesignPatternsResults = new System.Windows.Forms.TextBox();
        this.btnForEach = new System.Windows.Forms.Button();
        this.tabPage8 = new System.Windows.Forms.TabPage();
        this.txtLinqToTextFilesPerformanceResults = new System.Windows.Forms.TextBox();
        this.btnPerformanceLinqToTextFilesBad = new System.Windows.Forms.Button();
        this.btnPerformanceLinqToTextFilesGood = new System.Windows.Forms.Button();
        this.tabPage7 = new System.Windows.Forms.TabPage();
        this.txtImmediateCompleteIterationResults = new System.Windows.Forms.TextBox();
        this.btnImmediateCompleteIteration = new System.Windows.Forms.Button();
        this.tabPage11 = new System.Windows.Forms.TabPage();
        this.label1 = new System.Windows.Forms.Label();
        this.updMaxElementsRuns = new System.Windows.Forms.NumericUpDown();
        this.txtMaxElementResults = new System.Windows.Forms.TextBox();
        this.btnMaxElementOrderbyAndFirst = new System.Windows.Forms.Button();
        this.btnMaxElementCustomOperator = new System.Windows.Forms.Button();
        this.btnMaxElementTwoQueries = new System.Windows.Forms.Button();
        this.btnMaxElementSubquery = new System.Windows.Forms.Button();
        this.btnMaxElementWithoutLinq = new System.Windows.Forms.Button();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.rdbJoin = new System.Windows.Forms.RadioButton();
        this.rdbSort = new System.Windows.Forms.RadioButton();
        this.rdbFilterOnString = new System.Windows.Forms.RadioButton();
        this.rdbFilterOnInt = new System.Windows.Forms.RadioButton();
        this.btnCollect = new System.Windows.Forms.Button();
        this.label3 = new System.Windows.Forms.Label();
        this.updOverheadRuns = new System.Windows.Forms.NumericUpDown();
        this.btnPerformanceLinqPresized = new System.Windows.Forms.Button();
        this.btnPerformanceToList = new System.Windows.Forms.Button();
        this.txtPerformanceResults = new System.Windows.Forms.TextBox();
        this.btnPerformanceListForEach = new System.Windows.Forms.Button();
        this.btnPerformanceListFindAll = new System.Windows.Forms.Button();
        this.btnPerformanceFor = new System.Windows.Forms.Button();
        this.btnPerformanceForeach = new System.Windows.Forms.Button();
        this.tabPage9 = new System.Windows.Forms.TabPage();
        this.label2 = new System.Windows.Forms.Label();
        this.updGroupingRuns = new System.Windows.Forms.NumericUpDown();
        this.txtPerformanceGroupingResults = new System.Windows.Forms.TextBox();
        this.btnGroupingWithLinqPerf = new System.Windows.Forms.Button();
        this.btnGroupingWithLinq = new System.Windows.Forms.Button();
        this.btnGroupingWithoutLinqPerf = new System.Windows.Forms.Button();
        this.btnGroupingWithoutLinq = new System.Windows.Forms.Button();
        this.tabControl1.SuspendLayout();
        this.tabPage6.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
        this.tabPage1.SuspendLayout();
        this.tabPage4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        this.tabPage5.SuspendLayout();
        this.tabPage2.SuspendLayout();
        this.tabPage8.SuspendLayout();
        this.tabPage7.SuspendLayout();
        this.tabPage11.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.updMaxElementsRuns)).BeginInit();
        this.tabPage3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.updOverheadRuns)).BeginInit();
        this.tabPage9.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.updGroupingRuns)).BeginInit();
        this.SuspendLayout();
        // 
        // tabControl1
        // 
        this.tabControl1.Controls.Add(this.tabPage6);
        this.tabControl1.Controls.Add(this.tabPage1);
        this.tabControl1.Controls.Add(this.tabPage4);
        this.tabControl1.Controls.Add(this.tabPage5);
        this.tabControl1.Controls.Add(this.tabPage2);
        this.tabControl1.Controls.Add(this.tabPage8);
        this.tabControl1.Controls.Add(this.tabPage7);
        this.tabControl1.Controls.Add(this.tabPage11);
        this.tabControl1.Controls.Add(this.tabPage3);
        this.tabControl1.Controls.Add(this.tabPage9);
        this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControl1.Location = new System.Drawing.Point(0, 0);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(864, 459);
        this.tabControl1.TabIndex = 0;
        // 
        // tabPage6
        // 
        this.tabPage6.Controls.Add(this.dataGridView2);
        this.tabPage6.Controls.Add(this.btnQueryArrayListWithImplicitCast);
        this.tabPage6.Controls.Add(this.btnQueryArrayListWithExplicitCast);
        this.tabPage6.Location = new System.Drawing.Point(4, 22);
        this.tabPage6.Name = "tabPage6";
        this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage6.Size = new System.Drawing.Size(856, 433);
        this.tabPage6.TabIndex = 5;
        this.tabPage6.Text = "5.1.1 Non-generic collections";
        this.tabPage6.UseVisualStyleBackColor = true;
        // 
        // dataGridView2
        // 
        this.dataGridView2.AllowUserToAddRows = false;
        this.dataGridView2.AllowUserToDeleteRows = false;
        this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView2.Location = new System.Drawing.Point(3, 40);
        this.dataGridView2.Name = "dataGridView2";
        this.dataGridView2.ReadOnly = true;
        this.dataGridView2.Size = new System.Drawing.Size(850, 390);
        this.dataGridView2.TabIndex = 6;
        // 
        // btnQueryArrayListWithImplicitCast
        // 
        this.btnQueryArrayListWithImplicitCast.Location = new System.Drawing.Point(215, 6);
        this.btnQueryArrayListWithImplicitCast.Name = "btnQueryArrayListWithImplicitCast";
        this.btnQueryArrayListWithImplicitCast.Size = new System.Drawing.Size(193, 23);
        this.btnQueryArrayListWithImplicitCast.TabIndex = 0;
        this.btnQueryArrayListWithImplicitCast.Text = "Query ArrayList with implicit Cast";
        this.btnQueryArrayListWithImplicitCast.UseVisualStyleBackColor = true;
        this.btnQueryArrayListWithImplicitCast.Click += new System.EventHandler(this.btnQueryArrayListWithImplicitCast_Click);
        // 
        // btnQueryArrayListWithExplicitCast
        // 
        this.btnQueryArrayListWithExplicitCast.Location = new System.Drawing.Point(8, 6);
        this.btnQueryArrayListWithExplicitCast.Name = "btnQueryArrayListWithExplicitCast";
        this.btnQueryArrayListWithExplicitCast.Size = new System.Drawing.Size(201, 23);
        this.btnQueryArrayListWithExplicitCast.TabIndex = 0;
        this.btnQueryArrayListWithExplicitCast.Text = "Query ArrayList with explicit Cast";
        this.btnQueryArrayListWithExplicitCast.UseVisualStyleBackColor = true;
        this.btnQueryArrayListWithExplicitCast.Click += new System.EventHandler(this.btnQueryArrayListWithExplicitCast_Click);
        // 
        // tabPage1
        // 
        this.tabPage1.Controls.Add(this.txtGroupingResults);
        this.tabPage1.Controls.Add(this.btnGrouping3);
        this.tabPage1.Controls.Add(this.btnGrouping2);
        this.tabPage1.Controls.Add(this.btnGrouping1);
        this.tabPage1.Location = new System.Drawing.Point(4, 22);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(856, 433);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "5.1.2 Grouping";
        this.tabPage1.UseVisualStyleBackColor = true;
        // 
        // txtGroupingResults
        // 
        this.txtGroupingResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtGroupingResults.Location = new System.Drawing.Point(8, 71);
        this.txtGroupingResults.Multiline = true;
        this.txtGroupingResults.Name = "txtGroupingResults";
        this.txtGroupingResults.Size = new System.Drawing.Size(840, 362);
        this.txtGroupingResults.TabIndex = 3;
        // 
        // btnGrouping3
        // 
        this.btnGrouping3.Location = new System.Drawing.Point(8, 35);
        this.btnGrouping3.Name = "btnGrouping3";
        this.btnGrouping3.Size = new System.Drawing.Size(464, 23);
        this.btnGrouping3.TabIndex = 2;
        this.btnGrouping3.Text = "Groups books by subject and returns the title and publisher of each book";
        this.btnGrouping3.UseVisualStyleBackColor = true;
        this.btnGrouping3.Click += new System.EventHandler(this.btnGrouping3_Click);
        // 
        // btnGrouping2
        // 
        this.btnGrouping2.Location = new System.Drawing.Point(238, 6);
        this.btnGrouping2.Name = "btnGrouping2";
        this.btnGrouping2.Size = new System.Drawing.Size(234, 23);
        this.btnGrouping2.TabIndex = 1;
        this.btnGrouping2.Text = "Groups book titles by publisher and subject";
        this.btnGrouping2.UseVisualStyleBackColor = true;
        this.btnGrouping2.Click += new System.EventHandler(this.btnGrouping2_Click);
        // 
        // btnGrouping1
        // 
        this.btnGrouping1.Location = new System.Drawing.Point(8, 6);
        this.btnGrouping1.Name = "btnGrouping1";
        this.btnGrouping1.Size = new System.Drawing.Size(224, 23);
        this.btnGrouping1.TabIndex = 0;
        this.btnGrouping1.Text = "Groups books by publisher and subject";
        this.btnGrouping1.UseVisualStyleBackColor = true;
        this.btnGrouping1.Click += new System.EventHandler(this.btnGrouping1_Click);
        // 
        // tabPage4
        // 
        this.tabPage4.Controls.Add(this.btnDynamicQueryExpressionTree);
        this.tabPage4.Controls.Add(this.dataGridView1);
        this.tabPage4.Controls.Add(this.btnConditionalQuery);
        this.tabPage4.Controls.Add(this.cbxSortOrder);
        this.tabPage4.Controls.Add(this.btnCustomSort);
        this.tabPage4.Controls.Add(this.btnChangingVariable);
        this.tabPage4.Controls.Add(this.btnParameterizedQuery);
        this.tabPage4.Location = new System.Drawing.Point(4, 22);
        this.tabPage4.Name = "tabPage4";
        this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage4.Size = new System.Drawing.Size(856, 433);
        this.tabPage4.TabIndex = 3;
        this.tabPage4.Text = "5.1.3 Dynamic queries";
        this.tabPage4.UseVisualStyleBackColor = true;
        // 
        // btnDynamicQueryExpressionTree
        // 
        this.btnDynamicQueryExpressionTree.Location = new System.Drawing.Point(151, 94);
        this.btnDynamicQueryExpressionTree.Name = "btnDynamicQueryExpressionTree";
        this.btnDynamicQueryExpressionTree.Size = new System.Drawing.Size(121, 23);
        this.btnDynamicQueryExpressionTree.TabIndex = 9;
        this.btnDynamicQueryExpressionTree.Text = "Expression tree";
        this.btnDynamicQueryExpressionTree.UseVisualStyleBackColor = true;
        this.btnDynamicQueryExpressionTree.Click += new System.EventHandler(this.btnDynamicQueryExpressionTree_Click);
        // 
        // dataGridView1
        // 
        this.dataGridView1.AllowUserToAddRows = false;
        this.dataGridView1.AllowUserToDeleteRows = false;
        this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Location = new System.Drawing.Point(3, 123);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.ReadOnly = true;
        this.dataGridView1.Size = new System.Drawing.Size(850, 307);
        this.dataGridView1.TabIndex = 8;
        // 
        // btnConditionalQuery
        // 
        this.btnConditionalQuery.Location = new System.Drawing.Point(9, 94);
        this.btnConditionalQuery.Name = "btnConditionalQuery";
        this.btnConditionalQuery.Size = new System.Drawing.Size(135, 23);
        this.btnConditionalQuery.TabIndex = 4;
        this.btnConditionalQuery.Text = "Conditional query";
        this.btnConditionalQuery.UseVisualStyleBackColor = true;
        this.btnConditionalQuery.Click += new System.EventHandler(this.btnConditionalQuery_Click);
        // 
        // cbxSortOrder
        // 
        this.cbxSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cbxSortOrder.FormattingEnabled = true;
        this.cbxSortOrder.Items.AddRange(new object[] {
            "Title ascending",
            "Title descending",
            "Publisher ascending",
            "Page count ascending"});
        this.cbxSortOrder.Location = new System.Drawing.Point(151, 64);
        this.cbxSortOrder.Name = "cbxSortOrder";
        this.cbxSortOrder.Size = new System.Drawing.Size(121, 21);
        this.cbxSortOrder.TabIndex = 3;
        // 
        // btnCustomSort
        // 
        this.btnCustomSort.Location = new System.Drawing.Point(8, 64);
        this.btnCustomSort.Name = "btnCustomSort";
        this.btnCustomSort.Size = new System.Drawing.Size(136, 23);
        this.btnCustomSort.TabIndex = 2;
        this.btnCustomSort.Text = "Custom sort";
        this.btnCustomSort.UseVisualStyleBackColor = true;
        this.btnCustomSort.Click += new System.EventHandler(this.btnCustomSort_Click);
        // 
        // btnChangingVariable
        // 
        this.btnChangingVariable.Location = new System.Drawing.Point(8, 6);
        this.btnChangingVariable.Name = "btnChangingVariable";
        this.btnChangingVariable.Size = new System.Drawing.Size(134, 23);
        this.btnChangingVariable.TabIndex = 0;
        this.btnChangingVariable.Text = "Changing variable";
        this.btnChangingVariable.UseVisualStyleBackColor = true;
        this.btnChangingVariable.Click += new System.EventHandler(this.btnChangingVariable_Click);
        // 
        // btnParameterizedQuery
        // 
        this.btnParameterizedQuery.Location = new System.Drawing.Point(8, 35);
        this.btnParameterizedQuery.Name = "btnParameterizedQuery";
        this.btnParameterizedQuery.Size = new System.Drawing.Size(136, 23);
        this.btnParameterizedQuery.TabIndex = 1;
        this.btnParameterizedQuery.Text = "Parameterized query";
        this.btnParameterizedQuery.UseVisualStyleBackColor = true;
        this.btnParameterizedQuery.Click += new System.EventHandler(this.btnParameterizedQuery_Click);
        // 
        // tabPage5
        // 
        this.tabPage5.Controls.Add(this.btnLinqtoTextFiles);
        this.tabPage5.Controls.Add(this.txtLinqToTextFilesResults);
        this.tabPage5.Location = new System.Drawing.Point(4, 22);
        this.tabPage5.Name = "tabPage5";
        this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage5.Size = new System.Drawing.Size(856, 433);
        this.tabPage5.TabIndex = 4;
        this.tabPage5.Text = "5.1.4 LINQ to Text Files";
        this.tabPage5.UseVisualStyleBackColor = true;
        // 
        // btnLinqtoTextFiles
        // 
        this.btnLinqtoTextFiles.Location = new System.Drawing.Point(8, 6);
        this.btnLinqtoTextFiles.Name = "btnLinqtoTextFiles";
        this.btnLinqtoTextFiles.Size = new System.Drawing.Size(75, 23);
        this.btnLinqtoTextFiles.TabIndex = 5;
        this.btnLinqtoTextFiles.Text = "Run";
        this.btnLinqtoTextFiles.UseVisualStyleBackColor = true;
        this.btnLinqtoTextFiles.Click += new System.EventHandler(this.btnLinqtoTextFiles_Click);
        // 
        // txtLinqToTextFilesResults
        // 
        this.txtLinqToTextFilesResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtLinqToTextFilesResults.Location = new System.Drawing.Point(8, 35);
        this.txtLinqToTextFilesResults.Multiline = true;
        this.txtLinqToTextFilesResults.Name = "txtLinqToTextFilesResults";
        this.txtLinqToTextFilesResults.Size = new System.Drawing.Size(840, 408);
        this.txtLinqToTextFilesResults.TabIndex = 4;
        // 
        // tabPage2
        // 
        this.tabPage2.Controls.Add(this.btnFunctionalConstruction);
        this.tabPage2.Controls.Add(this.btnFunctionalConstructionAnonymous);
        this.tabPage2.Controls.Add(this.txtDesignPatternsResults);
        this.tabPage2.Controls.Add(this.btnForEach);
        this.tabPage2.Location = new System.Drawing.Point(4, 22);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(856, 433);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "5.2 Design Patterns";
        this.tabPage2.UseVisualStyleBackColor = true;
        // 
        // btnFunctionalConstruction
        // 
        this.btnFunctionalConstruction.Location = new System.Drawing.Point(269, 6);
        this.btnFunctionalConstruction.Name = "btnFunctionalConstruction";
        this.btnFunctionalConstruction.Size = new System.Drawing.Size(226, 23);
        this.btnFunctionalConstruction.TabIndex = 6;
        this.btnFunctionalConstruction.Text = "Functional Construction with existing types";
        this.btnFunctionalConstruction.UseVisualStyleBackColor = true;
        this.btnFunctionalConstruction.Click += new System.EventHandler(this.btnFunctionalConstruction_Click);
        // 
        // btnFunctionalConstructionAnonymous
        // 
        this.btnFunctionalConstructionAnonymous.Location = new System.Drawing.Point(8, 6);
        this.btnFunctionalConstructionAnonymous.Name = "btnFunctionalConstructionAnonymous";
        this.btnFunctionalConstructionAnonymous.Size = new System.Drawing.Size(255, 23);
        this.btnFunctionalConstructionAnonymous.TabIndex = 6;
        this.btnFunctionalConstructionAnonymous.Text = "Functional Construction with anonymous types";
        this.btnFunctionalConstructionAnonymous.UseVisualStyleBackColor = true;
        this.btnFunctionalConstructionAnonymous.Click += new System.EventHandler(this.btnFunctionalConstructionAnonymous_Click);
        // 
        // txtDesignPatternsResults
        // 
        this.txtDesignPatternsResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtDesignPatternsResults.Location = new System.Drawing.Point(8, 66);
        this.txtDesignPatternsResults.Multiline = true;
        this.txtDesignPatternsResults.Name = "txtDesignPatternsResults";
        this.txtDesignPatternsResults.Size = new System.Drawing.Size(840, 377);
        this.txtDesignPatternsResults.TabIndex = 5;
        // 
        // btnForEach
        // 
        this.btnForEach.Location = new System.Drawing.Point(8, 37);
        this.btnForEach.Name = "btnForEach";
        this.btnForEach.Size = new System.Drawing.Size(75, 23);
        this.btnForEach.TabIndex = 0;
        this.btnForEach.Text = "ForEach";
        this.btnForEach.UseVisualStyleBackColor = true;
        this.btnForEach.Click += new System.EventHandler(this.btnForEach_Click);
        // 
        // tabPage8
        // 
        this.tabPage8.Controls.Add(this.txtLinqToTextFilesPerformanceResults);
        this.tabPage8.Controls.Add(this.btnPerformanceLinqToTextFilesBad);
        this.tabPage8.Controls.Add(this.btnPerformanceLinqToTextFilesGood);
        this.tabPage8.Location = new System.Drawing.Point(4, 22);
        this.tabPage8.Name = "tabPage8";
        this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage8.Size = new System.Drawing.Size(856, 433);
        this.tabPage8.TabIndex = 7;
        this.tabPage8.Text = "5.3.1 Performance (LINQ to Text Files)";
        this.tabPage8.UseVisualStyleBackColor = true;
        // 
        // txtLinqToTextFilesPerformanceResults
        // 
        this.txtLinqToTextFilesPerformanceResults.AcceptsReturn = true;
        this.txtLinqToTextFilesPerformanceResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtLinqToTextFilesPerformanceResults.Location = new System.Drawing.Point(8, 64);
        this.txtLinqToTextFilesPerformanceResults.Multiline = true;
        this.txtLinqToTextFilesPerformanceResults.Name = "txtLinqToTextFilesPerformanceResults";
        this.txtLinqToTextFilesPerformanceResults.Size = new System.Drawing.Size(840, 363);
        this.txtLinqToTextFilesPerformanceResults.TabIndex = 5;
        // 
        // btnPerformanceLinqToTextFilesBad
        // 
        this.btnPerformanceLinqToTextFilesBad.Location = new System.Drawing.Point(8, 6);
        this.btnPerformanceLinqToTextFilesBad.Name = "btnPerformanceLinqToTextFilesBad";
        this.btnPerformanceLinqToTextFilesBad.Size = new System.Drawing.Size(75, 23);
        this.btnPerformanceLinqToTextFilesBad.TabIndex = 0;
        this.btnPerformanceLinqToTextFilesBad.Text = "Bad";
        this.btnPerformanceLinqToTextFilesBad.UseVisualStyleBackColor = true;
        this.btnPerformanceLinqToTextFilesBad.Click += new System.EventHandler(this.btnPerformanceLinqToTextFilesBad_Click);
        // 
        // btnPerformanceLinqToTextFilesGood
        // 
        this.btnPerformanceLinqToTextFilesGood.Location = new System.Drawing.Point(8, 35);
        this.btnPerformanceLinqToTextFilesGood.Name = "btnPerformanceLinqToTextFilesGood";
        this.btnPerformanceLinqToTextFilesGood.Size = new System.Drawing.Size(75, 23);
        this.btnPerformanceLinqToTextFilesGood.TabIndex = 1;
        this.btnPerformanceLinqToTextFilesGood.Text = "Good";
        this.btnPerformanceLinqToTextFilesGood.UseVisualStyleBackColor = true;
        this.btnPerformanceLinqToTextFilesGood.Click += new System.EventHandler(this.btnPerformanceLinqToTextFilesGood_Click);
        // 
        // tabPage7
        // 
        this.tabPage7.Controls.Add(this.txtImmediateCompleteIterationResults);
        this.tabPage7.Controls.Add(this.btnImmediateCompleteIteration);
        this.tabPage7.Location = new System.Drawing.Point(4, 22);
        this.tabPage7.Name = "tabPage7";
        this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage7.Size = new System.Drawing.Size(856, 433);
        this.tabPage7.TabIndex = 6;
        this.tabPage7.Text = "5.3.2 Performance (immediate complete iteration)";
        this.tabPage7.UseVisualStyleBackColor = true;
        // 
        // txtImmediateCompleteIterationResults
        // 
        this.txtImmediateCompleteIterationResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtImmediateCompleteIterationResults.Location = new System.Drawing.Point(6, 35);
        this.txtImmediateCompleteIterationResults.Multiline = true;
        this.txtImmediateCompleteIterationResults.Name = "txtImmediateCompleteIterationResults";
        this.txtImmediateCompleteIterationResults.Size = new System.Drawing.Size(840, 398);
        this.txtImmediateCompleteIterationResults.TabIndex = 5;
        // 
        // btnImmediateCompleteIteration
        // 
        this.btnImmediateCompleteIteration.Location = new System.Drawing.Point(8, 6);
        this.btnImmediateCompleteIteration.Name = "btnImmediateCompleteIteration";
        this.btnImmediateCompleteIteration.Size = new System.Drawing.Size(75, 23);
        this.btnImmediateCompleteIteration.TabIndex = 0;
        this.btnImmediateCompleteIteration.Text = "Run";
        this.btnImmediateCompleteIteration.UseVisualStyleBackColor = true;
        this.btnImmediateCompleteIteration.Click += new System.EventHandler(this.btnImmediateCompleteIteration_Click);
        // 
        // tabPage11
        // 
        this.tabPage11.Controls.Add(this.label1);
        this.tabPage11.Controls.Add(this.updMaxElementsRuns);
        this.tabPage11.Controls.Add(this.txtMaxElementResults);
        this.tabPage11.Controls.Add(this.btnMaxElementOrderbyAndFirst);
        this.tabPage11.Controls.Add(this.btnMaxElementCustomOperator);
        this.tabPage11.Controls.Add(this.btnMaxElementTwoQueries);
        this.tabPage11.Controls.Add(this.btnMaxElementSubquery);
        this.tabPage11.Controls.Add(this.btnMaxElementWithoutLinq);
        this.tabPage11.Location = new System.Drawing.Point(4, 22);
        this.tabPage11.Name = "tabPage11";
        this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage11.Size = new System.Drawing.Size(856, 433);
        this.tabPage11.TabIndex = 10;
        this.tabPage11.Text = "5.3.3 Performance (MaxElement)";
        this.tabPage11.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(8, 37);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(35, 13);
        this.label1.TabIndex = 10;
        this.label1.Text = "Runs:";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // updMaxElementsRuns
        // 
        this.updMaxElementsRuns.Location = new System.Drawing.Point(49, 35);
        this.updMaxElementsRuns.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
        this.updMaxElementsRuns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.updMaxElementsRuns.Name = "updMaxElementsRuns";
        this.updMaxElementsRuns.Size = new System.Drawing.Size(73, 20);
        this.updMaxElementsRuns.TabIndex = 9;
        this.updMaxElementsRuns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // txtMaxElementResults
        // 
        this.txtMaxElementResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtMaxElementResults.Location = new System.Drawing.Point(8, 59);
        this.txtMaxElementResults.Multiline = true;
        this.txtMaxElementResults.Name = "txtMaxElementResults";
        this.txtMaxElementResults.Size = new System.Drawing.Size(840, 366);
        this.txtMaxElementResults.TabIndex = 4;
        // 
        // btnMaxElementOrderbyAndFirst
        // 
        this.btnMaxElementOrderbyAndFirst.Location = new System.Drawing.Point(119, 6);
        this.btnMaxElementOrderbyAndFirst.Name = "btnMaxElementOrderbyAndFirst";
        this.btnMaxElementOrderbyAndFirst.Size = new System.Drawing.Size(110, 23);
        this.btnMaxElementOrderbyAndFirst.TabIndex = 0;
        this.btnMaxElementOrderbyAndFirst.Text = "OrderBy and First";
        this.btnMaxElementOrderbyAndFirst.UseVisualStyleBackColor = true;
        this.btnMaxElementOrderbyAndFirst.Click += new System.EventHandler(this.btnMaxElementOrderbyAndFirst_Click);
        // 
        // btnMaxElementCustomOperator
        // 
        this.btnMaxElementCustomOperator.Location = new System.Drawing.Point(397, 6);
        this.btnMaxElementCustomOperator.Name = "btnMaxElementCustomOperator";
        this.btnMaxElementCustomOperator.Size = new System.Drawing.Size(115, 23);
        this.btnMaxElementCustomOperator.TabIndex = 0;
        this.btnMaxElementCustomOperator.Text = "Custom operator";
        this.btnMaxElementCustomOperator.UseVisualStyleBackColor = true;
        this.btnMaxElementCustomOperator.Click += new System.EventHandler(this.btnMaxElementCustomOperator_Click);
        // 
        // btnMaxElementTwoQueries
        // 
        this.btnMaxElementTwoQueries.Location = new System.Drawing.Point(316, 6);
        this.btnMaxElementTwoQueries.Name = "btnMaxElementTwoQueries";
        this.btnMaxElementTwoQueries.Size = new System.Drawing.Size(75, 23);
        this.btnMaxElementTwoQueries.TabIndex = 0;
        this.btnMaxElementTwoQueries.Text = "Two queries";
        this.btnMaxElementTwoQueries.UseVisualStyleBackColor = true;
        this.btnMaxElementTwoQueries.Click += new System.EventHandler(this.btnMaxElementTwoQueries_Click);
        // 
        // btnMaxElementSubquery
        // 
        this.btnMaxElementSubquery.Location = new System.Drawing.Point(235, 6);
        this.btnMaxElementSubquery.Name = "btnMaxElementSubquery";
        this.btnMaxElementSubquery.Size = new System.Drawing.Size(75, 23);
        this.btnMaxElementSubquery.TabIndex = 0;
        this.btnMaxElementSubquery.Text = "Sub-query";
        this.btnMaxElementSubquery.UseVisualStyleBackColor = true;
        this.btnMaxElementSubquery.Click += new System.EventHandler(this.btnMaxElementSubquery_Click);
        // 
        // btnMaxElementWithoutLinq
        // 
        this.btnMaxElementWithoutLinq.Location = new System.Drawing.Point(8, 6);
        this.btnMaxElementWithoutLinq.Name = "btnMaxElementWithoutLinq";
        this.btnMaxElementWithoutLinq.Size = new System.Drawing.Size(105, 23);
        this.btnMaxElementWithoutLinq.TabIndex = 0;
        this.btnMaxElementWithoutLinq.Text = "Without LINQ";
        this.btnMaxElementWithoutLinq.UseVisualStyleBackColor = true;
        this.btnMaxElementWithoutLinq.Click += new System.EventHandler(this.btnMaxElementWithoutLinq_Click);
        // 
        // tabPage3
        // 
        this.tabPage3.Controls.Add(this.rdbJoin);
        this.tabPage3.Controls.Add(this.rdbSort);
        this.tabPage3.Controls.Add(this.rdbFilterOnString);
        this.tabPage3.Controls.Add(this.rdbFilterOnInt);
        this.tabPage3.Controls.Add(this.btnCollect);
        this.tabPage3.Controls.Add(this.label3);
        this.tabPage3.Controls.Add(this.updOverheadRuns);
        this.tabPage3.Controls.Add(this.btnPerformanceLinqPresized);
        this.tabPage3.Controls.Add(this.btnPerformanceToList);
        this.tabPage3.Controls.Add(this.txtPerformanceResults);
        this.tabPage3.Controls.Add(this.btnPerformanceListForEach);
        this.tabPage3.Controls.Add(this.btnPerformanceListFindAll);
        this.tabPage3.Controls.Add(this.btnPerformanceFor);
        this.tabPage3.Controls.Add(this.btnPerformanceForeach);
        this.tabPage3.Location = new System.Drawing.Point(4, 22);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage3.Size = new System.Drawing.Size(856, 433);
        this.tabPage3.TabIndex = 2;
        this.tabPage3.Text = "5.3.4 Performance (LINQ\'s overhead)";
        this.tabPage3.UseVisualStyleBackColor = true;
        // 
        // rdbJoin
        // 
        this.rdbJoin.AutoSize = true;
        this.rdbJoin.Location = new System.Drawing.Point(315, 34);
        this.rdbJoin.Name = "rdbJoin";
        this.rdbJoin.Size = new System.Drawing.Size(45, 17);
        this.rdbJoin.TabIndex = 10;
        this.rdbJoin.Text = "Join";
        this.rdbJoin.UseVisualStyleBackColor = true;
        // 
        // rdbSort
        // 
        this.rdbSort.AutoSize = true;
        this.rdbSort.Location = new System.Drawing.Point(365, 34);
        this.rdbSort.Name = "rdbSort";
        this.rdbSort.Size = new System.Drawing.Size(45, 17);
        this.rdbSort.TabIndex = 10;
        this.rdbSort.Text = "Sort";
        this.rdbSort.UseVisualStyleBackColor = true;
        // 
        // rdbFilterOnString
        // 
        this.rdbFilterOnString.AutoSize = true;
        this.rdbFilterOnString.Location = new System.Drawing.Point(219, 34);
        this.rdbFilterOnString.Name = "rdbFilterOnString";
        this.rdbFilterOnString.Size = new System.Drawing.Size(91, 17);
        this.rdbFilterOnString.TabIndex = 10;
        this.rdbFilterOnString.Text = "Filter on string";
        this.rdbFilterOnString.UseVisualStyleBackColor = true;
        // 
        // rdbFilterOnInt
        // 
        this.rdbFilterOnInt.AutoSize = true;
        this.rdbFilterOnInt.Checked = true;
        this.rdbFilterOnInt.Location = new System.Drawing.Point(137, 34);
        this.rdbFilterOnInt.Name = "rdbFilterOnInt";
        this.rdbFilterOnInt.Size = new System.Drawing.Size(77, 17);
        this.rdbFilterOnInt.TabIndex = 10;
        this.rdbFilterOnInt.TabStop = true;
        this.rdbFilterOnInt.Text = "Filter on int";
        this.rdbFilterOnInt.UseVisualStyleBackColor = true;
        // 
        // btnCollect
        // 
        this.btnCollect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnCollect.Location = new System.Drawing.Point(773, 7);
        this.btnCollect.Name = "btnCollect";
        this.btnCollect.Size = new System.Drawing.Size(75, 23);
        this.btnCollect.TabIndex = 9;
        this.btnCollect.Text = "GC.Collect";
        this.btnCollect.UseVisualStyleBackColor = true;
        this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(6, 36);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(35, 13);
        this.label3.TabIndex = 8;
        this.label3.Text = "Runs:";
        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // updOverheadRuns
        // 
        this.updOverheadRuns.Location = new System.Drawing.Point(47, 34);
        this.updOverheadRuns.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
        this.updOverheadRuns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.updOverheadRuns.Name = "updOverheadRuns";
        this.updOverheadRuns.Size = new System.Drawing.Size(73, 20);
        this.updOverheadRuns.TabIndex = 7;
        this.updOverheadRuns.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
        // 
        // btnPerformanceLinqPresized
        // 
        this.btnPerformanceLinqPresized.Location = new System.Drawing.Point(532, 7);
        this.btnPerformanceLinqPresized.Name = "btnPerformanceLinqPresized";
        this.btnPerformanceLinqPresized.Size = new System.Drawing.Size(136, 23);
        this.btnPerformanceLinqPresized.TabIndex = 6;
        this.btnPerformanceLinqPresized.Text = "LINQ with presized list";
        this.btnPerformanceLinqPresized.UseVisualStyleBackColor = true;
        this.btnPerformanceLinqPresized.Click += new System.EventHandler(this.btnPerformanceLinqPresized_Click);
        // 
        // btnPerformanceToList
        // 
        this.btnPerformanceToList.Location = new System.Drawing.Point(403, 7);
        this.btnPerformanceToList.Name = "btnPerformanceToList";
        this.btnPerformanceToList.Size = new System.Drawing.Size(123, 23);
        this.btnPerformanceToList.TabIndex = 5;
        this.btnPerformanceToList.Text = "LINQ with ToList";
        this.btnPerformanceToList.UseVisualStyleBackColor = true;
        this.btnPerformanceToList.Click += new System.EventHandler(this.btnPerformanceToList_Click);
        // 
        // txtPerformanceResults
        // 
        this.txtPerformanceResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtPerformanceResults.Location = new System.Drawing.Point(8, 57);
        this.txtPerformanceResults.Multiline = true;
        this.txtPerformanceResults.Name = "txtPerformanceResults";
        this.txtPerformanceResults.Size = new System.Drawing.Size(840, 368);
        this.txtPerformanceResults.TabIndex = 4;
        // 
        // btnPerformanceListForEach
        // 
        this.btnPerformanceListForEach.Location = new System.Drawing.Point(284, 6);
        this.btnPerformanceListForEach.Name = "btnPerformanceListForEach";
        this.btnPerformanceListForEach.Size = new System.Drawing.Size(113, 23);
        this.btnPerformanceListForEach.TabIndex = 3;
        this.btnPerformanceListForEach.Text = "List<T>.ForEach";
        this.btnPerformanceListForEach.UseVisualStyleBackColor = true;
        this.btnPerformanceListForEach.Click += new System.EventHandler(this.btnPerformanceListForEach_Click);
        // 
        // btnPerformanceListFindAll
        // 
        this.btnPerformanceListFindAll.Location = new System.Drawing.Point(168, 6);
        this.btnPerformanceListFindAll.Name = "btnPerformanceListFindAll";
        this.btnPerformanceListFindAll.Size = new System.Drawing.Size(110, 23);
        this.btnPerformanceListFindAll.TabIndex = 2;
        this.btnPerformanceListFindAll.Text = "List<T>.FindAll";
        this.btnPerformanceListFindAll.UseVisualStyleBackColor = true;
        this.btnPerformanceListFindAll.Click += new System.EventHandler(this.btnPerformanceListFindAll_Click);
        // 
        // btnPerformanceFor
        // 
        this.btnPerformanceFor.Location = new System.Drawing.Point(87, 6);
        this.btnPerformanceFor.Name = "btnPerformanceFor";
        this.btnPerformanceFor.Size = new System.Drawing.Size(75, 23);
        this.btnPerformanceFor.TabIndex = 1;
        this.btnPerformanceFor.Text = "for";
        this.btnPerformanceFor.UseVisualStyleBackColor = true;
        this.btnPerformanceFor.Click += new System.EventHandler(this.btnPerformanceFor_Click);
        // 
        // btnPerformanceForeach
        // 
        this.btnPerformanceForeach.Location = new System.Drawing.Point(6, 6);
        this.btnPerformanceForeach.Name = "btnPerformanceForeach";
        this.btnPerformanceForeach.Size = new System.Drawing.Size(75, 23);
        this.btnPerformanceForeach.TabIndex = 0;
        this.btnPerformanceForeach.Text = "foreach";
        this.btnPerformanceForeach.UseVisualStyleBackColor = true;
        this.btnPerformanceForeach.Click += new System.EventHandler(this.btnPerformanceForEach_Click);
        // 
        // tabPage9
        // 
        this.tabPage9.Controls.Add(this.label2);
        this.tabPage9.Controls.Add(this.updGroupingRuns);
        this.tabPage9.Controls.Add(this.txtPerformanceGroupingResults);
        this.tabPage9.Controls.Add(this.btnGroupingWithLinqPerf);
        this.tabPage9.Controls.Add(this.btnGroupingWithLinq);
        this.tabPage9.Controls.Add(this.btnGroupingWithoutLinqPerf);
        this.tabPage9.Controls.Add(this.btnGroupingWithoutLinq);
        this.tabPage9.Location = new System.Drawing.Point(4, 22);
        this.tabPage9.Name = "tabPage9";
        this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage9.Size = new System.Drawing.Size(856, 433);
        this.tabPage9.TabIndex = 8;
        this.tabPage9.Text = "5.3.5 Performance (grouping)";
        this.tabPage9.UseVisualStyleBackColor = true;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(8, 67);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(35, 13);
        this.label2.TabIndex = 12;
        this.label2.Text = "Runs:";
        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // updGroupingRuns
        // 
        this.updGroupingRuns.Location = new System.Drawing.Point(49, 65);
        this.updGroupingRuns.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
        this.updGroupingRuns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.updGroupingRuns.Name = "updGroupingRuns";
        this.updGroupingRuns.Size = new System.Drawing.Size(73, 20);
        this.updGroupingRuns.TabIndex = 11;
        this.updGroupingRuns.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
        // 
        // txtPerformanceGroupingResults
        // 
        this.txtPerformanceGroupingResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.txtPerformanceGroupingResults.Location = new System.Drawing.Point(8, 89);
        this.txtPerformanceGroupingResults.Multiline = true;
        this.txtPerformanceGroupingResults.Name = "txtPerformanceGroupingResults";
        this.txtPerformanceGroupingResults.Size = new System.Drawing.Size(840, 336);
        this.txtPerformanceGroupingResults.TabIndex = 4;
        // 
        // btnGroupingWithLinqPerf
        // 
        this.btnGroupingWithLinqPerf.Location = new System.Drawing.Point(190, 35);
        this.btnGroupingWithLinqPerf.Name = "btnGroupingWithLinqPerf";
        this.btnGroupingWithLinqPerf.Size = new System.Drawing.Size(166, 23);
        this.btnGroupingWithLinqPerf.TabIndex = 3;
        this.btnGroupingWithLinqPerf.Text = "Grouping with LINQ (perf)";
        this.btnGroupingWithLinqPerf.UseVisualStyleBackColor = true;
        this.btnGroupingWithLinqPerf.Click += new System.EventHandler(this.btnGroupingWithLinqPerf_Click);
        // 
        // btnGroupingWithLinq
        // 
        this.btnGroupingWithLinq.Location = new System.Drawing.Point(190, 6);
        this.btnGroupingWithLinq.Name = "btnGroupingWithLinq";
        this.btnGroupingWithLinq.Size = new System.Drawing.Size(166, 23);
        this.btnGroupingWithLinq.TabIndex = 1;
        this.btnGroupingWithLinq.Text = "Grouping with LINQ";
        this.btnGroupingWithLinq.UseVisualStyleBackColor = true;
        this.btnGroupingWithLinq.Click += new System.EventHandler(this.btnGroupingWithLinq_Click);
        // 
        // btnGroupingWithoutLinqPerf
        // 
        this.btnGroupingWithoutLinqPerf.Location = new System.Drawing.Point(8, 35);
        this.btnGroupingWithoutLinqPerf.Name = "btnGroupingWithoutLinqPerf";
        this.btnGroupingWithoutLinqPerf.Size = new System.Drawing.Size(176, 23);
        this.btnGroupingWithoutLinqPerf.TabIndex = 2;
        this.btnGroupingWithoutLinqPerf.Text = "Grouping without LINQ (perf)";
        this.btnGroupingWithoutLinqPerf.UseVisualStyleBackColor = true;
        this.btnGroupingWithoutLinqPerf.Click += new System.EventHandler(this.btnGroupingWithoutLinqPerf_Click);
        // 
        // btnGroupingWithoutLinq
        // 
        this.btnGroupingWithoutLinq.Location = new System.Drawing.Point(8, 6);
        this.btnGroupingWithoutLinq.Name = "btnGroupingWithoutLinq";
        this.btnGroupingWithoutLinq.Size = new System.Drawing.Size(176, 23);
        this.btnGroupingWithoutLinq.TabIndex = 0;
        this.btnGroupingWithoutLinq.Text = "Grouping without LINQ";
        this.btnGroupingWithoutLinq.UseVisualStyleBackColor = true;
        this.btnGroupingWithoutLinq.Click += new System.EventHandler(this.btnGroupingWithoutLinq_Click);
        // 
        // FormMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(864, 459);
        this.Controls.Add(this.tabControl1);
        this.Name = "FormMain";
        this.Text = "LINQ in Action - Chapter 5";
        this.tabControl1.ResumeLayout(false);
        this.tabPage6.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
        this.tabPage1.ResumeLayout(false);
        this.tabPage1.PerformLayout();
        this.tabPage4.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        this.tabPage5.ResumeLayout(false);
        this.tabPage5.PerformLayout();
        this.tabPage2.ResumeLayout(false);
        this.tabPage2.PerformLayout();
        this.tabPage8.ResumeLayout(false);
        this.tabPage8.PerformLayout();
        this.tabPage7.ResumeLayout(false);
        this.tabPage7.PerformLayout();
        this.tabPage11.ResumeLayout(false);
        this.tabPage11.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.updMaxElementsRuns)).EndInit();
        this.tabPage3.ResumeLayout(false);
        this.tabPage3.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.updOverheadRuns)).EndInit();
        this.tabPage9.ResumeLayout(false);
        this.tabPage9.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.updGroupingRuns)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage5;
    private System.Windows.Forms.Button btnForEach;
    private System.Windows.Forms.Button btnChangingVariable;
    private System.Windows.Forms.Button btnParameterizedQuery;
    private System.Windows.Forms.Button btnCustomSort;
    private System.Windows.Forms.Button btnGrouping3;
    private System.Windows.Forms.Button btnGrouping2;
    private System.Windows.Forms.Button btnGrouping1;
    private System.Windows.Forms.TextBox txtGroupingResults;
    private System.Windows.Forms.Button btnPerformanceForeach;
    private System.Windows.Forms.Button btnPerformanceListFindAll;
    private System.Windows.Forms.Button btnPerformanceFor;
    private System.Windows.Forms.Button btnPerformanceListForEach;
    private System.Windows.Forms.TextBox txtPerformanceResults;
    private System.Windows.Forms.Button btnPerformanceToList;
    private System.Windows.Forms.Button btnPerformanceLinqPresized;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown updOverheadRuns;
    private System.Windows.Forms.Button btnCollect;
    private System.Windows.Forms.TextBox txtDesignPatternsResults;
    private System.Windows.Forms.ComboBox cbxSortOrder;
    private System.Windows.Forms.TabPage tabPage6;
    private System.Windows.Forms.Button btnQueryArrayListWithExplicitCast;
    private System.Windows.Forms.DataGridView dataGridView2;
    private System.Windows.Forms.Button btnQueryArrayListWithImplicitCast;
    private System.Windows.Forms.Button btnConditionalQuery;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.TextBox txtLinqToTextFilesResults;
    private System.Windows.Forms.TabPage tabPage7;
    private System.Windows.Forms.TabPage tabPage8;
    private System.Windows.Forms.Button btnPerformanceLinqToTextFilesBad;
    private System.Windows.Forms.Button btnPerformanceLinqToTextFilesGood;
    private System.Windows.Forms.Button btnLinqtoTextFiles;
    private System.Windows.Forms.Button btnFunctionalConstructionAnonymous;
    private System.Windows.Forms.Button btnFunctionalConstruction;
    private System.Windows.Forms.Button btnImmediateCompleteIteration;
    private System.Windows.Forms.RadioButton rdbFilterOnString;
    private System.Windows.Forms.RadioButton rdbFilterOnInt;
    private System.Windows.Forms.RadioButton rdbSort;
    private System.Windows.Forms.RadioButton rdbJoin;
    private System.Windows.Forms.TabPage tabPage9;
    private System.Windows.Forms.Button btnGroupingWithoutLinq;
    private System.Windows.Forms.Button btnGroupingWithLinq;
    private System.Windows.Forms.TextBox txtPerformanceGroupingResults;
    private System.Windows.Forms.Button btnGroupingWithLinqPerf;
    private System.Windows.Forms.Button btnGroupingWithoutLinqPerf;
    private System.Windows.Forms.TabPage tabPage11;
    private System.Windows.Forms.Button btnMaxElementOrderbyAndFirst;
    private System.Windows.Forms.Button btnMaxElementSubquery;
    private System.Windows.Forms.Button btnMaxElementWithoutLinq;
    private System.Windows.Forms.TextBox txtMaxElementResults;
    private System.Windows.Forms.Button btnMaxElementTwoQueries;
    private System.Windows.Forms.Button btnMaxElementCustomOperator;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown updMaxElementsRuns;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown updGroupingRuns;
    private System.Windows.Forms.Button btnDynamicQueryExpressionTree;
    private System.Windows.Forms.TextBox txtLinqToTextFilesPerformanceResults;
    private System.Windows.Forms.TextBox txtImmediateCompleteIterationResults;
  }
}