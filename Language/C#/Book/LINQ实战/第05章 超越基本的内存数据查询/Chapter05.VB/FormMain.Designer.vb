<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.TabPage1 = New System.Windows.Forms.TabPage
    Me.btnQueryArrayListWithImplicitCast = New System.Windows.Forms.Button
    Me.btnQueryArrayListWithExplicitCast = New System.Windows.Forms.Button
    Me.dataGridView2 = New System.Windows.Forms.DataGridView
    Me.TabPage2 = New System.Windows.Forms.TabPage
    Me.btnGrouping3 = New System.Windows.Forms.Button
    Me.btnGrouping2 = New System.Windows.Forms.Button
    Me.btnGrouping1 = New System.Windows.Forms.Button
    Me.txtGroupingResults = New System.Windows.Forms.TextBox
    Me.TabPage3 = New System.Windows.Forms.TabPage
    Me.btnDynamicQueryExpressionTree = New System.Windows.Forms.Button
    Me.btnConditionalQuery = New System.Windows.Forms.Button
    Me.cbxSortOrder = New System.Windows.Forms.ComboBox
    Me.btnCustomSort = New System.Windows.Forms.Button
    Me.btnChangingVariable = New System.Windows.Forms.Button
    Me.btnParameterizedQuery = New System.Windows.Forms.Button
    Me.dataGridView1 = New System.Windows.Forms.DataGridView
    Me.TabPage4 = New System.Windows.Forms.TabPage
    Me.btnLinqtoTextFiles = New System.Windows.Forms.Button
    Me.txtLinqToTextFilesResults = New System.Windows.Forms.TextBox
    Me.TabPage5 = New System.Windows.Forms.TabPage
    Me.btnFunctionalConstruction = New System.Windows.Forms.Button
    Me.btnFunctionalConstructionAnonymous = New System.Windows.Forms.Button
    Me.btnForEach = New System.Windows.Forms.Button
    Me.txtDesignPatternsResults = New System.Windows.Forms.TextBox
    Me.TabPage6 = New System.Windows.Forms.TabPage
    Me.txtLinqToTextFilesPerformanceResults = New System.Windows.Forms.TextBox
    Me.btnPerformanceLinqToTextFilesBad = New System.Windows.Forms.Button
    Me.btnPerformanceLinqToTextFilesGood = New System.Windows.Forms.Button
    Me.TabPage7 = New System.Windows.Forms.TabPage
    Me.txtImmediateCompleteIterationResults = New System.Windows.Forms.TextBox
    Me.btnImmediateCompleteIteration = New System.Windows.Forms.Button
    Me.TabPage8 = New System.Windows.Forms.TabPage
    Me.label1 = New System.Windows.Forms.Label
    Me.updMaxElementsRuns = New System.Windows.Forms.NumericUpDown
    Me.btnMaxElementOrderbyAndFirst = New System.Windows.Forms.Button
    Me.btnMaxElementCustomOperator = New System.Windows.Forms.Button
    Me.btnMaxElementTwoQueries = New System.Windows.Forms.Button
    Me.btnMaxElementSubquery = New System.Windows.Forms.Button
    Me.btnMaxElementWithoutLinq = New System.Windows.Forms.Button
    Me.txtMaxElementResults = New System.Windows.Forms.TextBox
    Me.TabPage9 = New System.Windows.Forms.TabPage
    Me.txtPerformanceResults = New System.Windows.Forms.TextBox
    Me.rdbJoin = New System.Windows.Forms.RadioButton
    Me.rdbSort = New System.Windows.Forms.RadioButton
    Me.rdbFilterOnString = New System.Windows.Forms.RadioButton
    Me.rdbFilterOnInt = New System.Windows.Forms.RadioButton
    Me.btnCollect = New System.Windows.Forms.Button
    Me.label3 = New System.Windows.Forms.Label
    Me.updOverheadRuns = New System.Windows.Forms.NumericUpDown
    Me.btnPerformanceLinqPresized = New System.Windows.Forms.Button
    Me.btnPerformanceToList = New System.Windows.Forms.Button
    Me.btnPerformanceListForEach = New System.Windows.Forms.Button
    Me.btnPerformanceListFindAll = New System.Windows.Forms.Button
    Me.btnPerformanceFor = New System.Windows.Forms.Button
    Me.btnPerformanceForeach = New System.Windows.Forms.Button
    Me.TabPage10 = New System.Windows.Forms.TabPage
    Me.label2 = New System.Windows.Forms.Label
    Me.updGroupingRuns = New System.Windows.Forms.NumericUpDown
    Me.btnGroupingWithLinqPerf = New System.Windows.Forms.Button
    Me.btnGroupingWithLinq = New System.Windows.Forms.Button
    Me.btnGroupingWithoutLinqPerf = New System.Windows.Forms.Button
    Me.btnGroupingWithoutLinq = New System.Windows.Forms.Button
    Me.txtPerformanceGroupingResults = New System.Windows.Forms.TextBox
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    CType(Me.dataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage2.SuspendLayout()
    Me.TabPage3.SuspendLayout()
    CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage4.SuspendLayout()
    Me.TabPage5.SuspendLayout()
    Me.TabPage6.SuspendLayout()
    Me.TabPage7.SuspendLayout()
    Me.TabPage8.SuspendLayout()
    CType(Me.updMaxElementsRuns, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage9.SuspendLayout()
    CType(Me.updOverheadRuns, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage10.SuspendLayout()
    CType(Me.updGroupingRuns, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Controls.Add(Me.TabPage3)
    Me.TabControl1.Controls.Add(Me.TabPage4)
    Me.TabControl1.Controls.Add(Me.TabPage5)
    Me.TabControl1.Controls.Add(Me.TabPage6)
    Me.TabControl1.Controls.Add(Me.TabPage7)
    Me.TabControl1.Controls.Add(Me.TabPage8)
    Me.TabControl1.Controls.Add(Me.TabPage9)
    Me.TabControl1.Controls.Add(Me.TabPage10)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(864, 459)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.btnQueryArrayListWithImplicitCast)
    Me.TabPage1.Controls.Add(Me.btnQueryArrayListWithExplicitCast)
    Me.TabPage1.Controls.Add(Me.dataGridView2)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(856, 433)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "5.1.1 Non-generic collections"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'btnQueryArrayListWithImplicitCast
    '
    Me.btnQueryArrayListWithImplicitCast.Location = New System.Drawing.Point(215, 11)
    Me.btnQueryArrayListWithImplicitCast.Name = "btnQueryArrayListWithImplicitCast"
    Me.btnQueryArrayListWithImplicitCast.Size = New System.Drawing.Size(193, 23)
    Me.btnQueryArrayListWithImplicitCast.TabIndex = 1
    Me.btnQueryArrayListWithImplicitCast.Text = "Query ArrayList with implicit Cast"
    Me.btnQueryArrayListWithImplicitCast.UseVisualStyleBackColor = True
    '
    'btnQueryArrayListWithExplicitCast
    '
    Me.btnQueryArrayListWithExplicitCast.Location = New System.Drawing.Point(8, 11)
    Me.btnQueryArrayListWithExplicitCast.Name = "btnQueryArrayListWithExplicitCast"
    Me.btnQueryArrayListWithExplicitCast.Size = New System.Drawing.Size(201, 23)
    Me.btnQueryArrayListWithExplicitCast.TabIndex = 0
    Me.btnQueryArrayListWithExplicitCast.Text = "Query ArrayList with explicit Cast"
    Me.btnQueryArrayListWithExplicitCast.UseVisualStyleBackColor = True
    '
    'dataGridView2
    '
    Me.dataGridView2.AllowUserToAddRows = False
    Me.dataGridView2.AllowUserToDeleteRows = False
    Me.dataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dataGridView2.Location = New System.Drawing.Point(3, 40)
    Me.dataGridView2.Name = "dataGridView2"
    Me.dataGridView2.ReadOnly = True
    Me.dataGridView2.Size = New System.Drawing.Size(850, 390)
    Me.dataGridView2.TabIndex = 2
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.btnGrouping3)
    Me.TabPage2.Controls.Add(Me.btnGrouping2)
    Me.TabPage2.Controls.Add(Me.btnGrouping1)
    Me.TabPage2.Controls.Add(Me.txtGroupingResults)
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(856, 433)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "5.1.2 Grouping"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'btnGrouping3
    '
    Me.btnGrouping3.Location = New System.Drawing.Point(8, 35)
    Me.btnGrouping3.Name = "btnGrouping3"
    Me.btnGrouping3.Size = New System.Drawing.Size(461, 23)
    Me.btnGrouping3.TabIndex = 2
    Me.btnGrouping3.Text = "Groups books by subject and returns the title and publisher of each book"
    Me.btnGrouping3.UseVisualStyleBackColor = True
    '
    'btnGrouping2
    '
    Me.btnGrouping2.Location = New System.Drawing.Point(238, 6)
    Me.btnGrouping2.Name = "btnGrouping2"
    Me.btnGrouping2.Size = New System.Drawing.Size(231, 23)
    Me.btnGrouping2.TabIndex = 1
    Me.btnGrouping2.Text = "Groups book titles by publisher and subject"
    Me.btnGrouping2.UseVisualStyleBackColor = True
    '
    'btnGrouping1
    '
    Me.btnGrouping1.Location = New System.Drawing.Point(8, 6)
    Me.btnGrouping1.Name = "btnGrouping1"
    Me.btnGrouping1.Size = New System.Drawing.Size(224, 23)
    Me.btnGrouping1.TabIndex = 0
    Me.btnGrouping1.Text = "Groups books by publisher and subject"
    Me.btnGrouping1.UseVisualStyleBackColor = True
    '
    'txtGroupingResults
    '
    Me.txtGroupingResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtGroupingResults.Location = New System.Drawing.Point(8, 64)
    Me.txtGroupingResults.Multiline = True
    Me.txtGroupingResults.Name = "txtGroupingResults"
    Me.txtGroupingResults.Size = New System.Drawing.Size(840, 366)
    Me.txtGroupingResults.TabIndex = 3
    '
    'TabPage3
    '
    Me.TabPage3.Controls.Add(Me.btnDynamicQueryExpressionTree)
    Me.TabPage3.Controls.Add(Me.btnConditionalQuery)
    Me.TabPage3.Controls.Add(Me.cbxSortOrder)
    Me.TabPage3.Controls.Add(Me.btnCustomSort)
    Me.TabPage3.Controls.Add(Me.btnChangingVariable)
    Me.TabPage3.Controls.Add(Me.btnParameterizedQuery)
    Me.TabPage3.Controls.Add(Me.dataGridView1)
    Me.TabPage3.Location = New System.Drawing.Point(4, 22)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage3.Size = New System.Drawing.Size(856, 433)
    Me.TabPage3.TabIndex = 2
    Me.TabPage3.Text = "5.1.3 Dynamic queries"
    Me.TabPage3.UseVisualStyleBackColor = True
    '
    'btnDynamicQueryExpressionTree
    '
    Me.btnDynamicQueryExpressionTree.Location = New System.Drawing.Point(151, 94)
    Me.btnDynamicQueryExpressionTree.Name = "btnDynamicQueryExpressionTree"
    Me.btnDynamicQueryExpressionTree.Size = New System.Drawing.Size(121, 23)
    Me.btnDynamicQueryExpressionTree.TabIndex = 5
    Me.btnDynamicQueryExpressionTree.Text = "Expression tree"
    Me.btnDynamicQueryExpressionTree.UseVisualStyleBackColor = True
    '
    'btnConditionalQuery
    '
    Me.btnConditionalQuery.Location = New System.Drawing.Point(9, 94)
    Me.btnConditionalQuery.Name = "btnConditionalQuery"
    Me.btnConditionalQuery.Size = New System.Drawing.Size(135, 23)
    Me.btnConditionalQuery.TabIndex = 4
    Me.btnConditionalQuery.Text = "Conditional query"
    Me.btnConditionalQuery.UseVisualStyleBackColor = True
    '
    'cbxSortOrder
    '
    Me.cbxSortOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbxSortOrder.FormattingEnabled = True
    Me.cbxSortOrder.Items.AddRange(New Object() {"Title ascending", "Title descending", "Publisher ascending", "Page count ascending"})
    Me.cbxSortOrder.Location = New System.Drawing.Point(151, 64)
    Me.cbxSortOrder.Name = "cbxSortOrder"
    Me.cbxSortOrder.Size = New System.Drawing.Size(121, 21)
    Me.cbxSortOrder.TabIndex = 3
    '
    'btnCustomSort
    '
    Me.btnCustomSort.Location = New System.Drawing.Point(8, 64)
    Me.btnCustomSort.Name = "btnCustomSort"
    Me.btnCustomSort.Size = New System.Drawing.Size(136, 23)
    Me.btnCustomSort.TabIndex = 2
    Me.btnCustomSort.Text = "Custom sort"
    Me.btnCustomSort.UseVisualStyleBackColor = True
    '
    'btnChangingVariable
    '
    Me.btnChangingVariable.Location = New System.Drawing.Point(8, 6)
    Me.btnChangingVariable.Name = "btnChangingVariable"
    Me.btnChangingVariable.Size = New System.Drawing.Size(134, 23)
    Me.btnChangingVariable.TabIndex = 0
    Me.btnChangingVariable.Text = "Changing variable"
    Me.btnChangingVariable.UseVisualStyleBackColor = True
    '
    'btnParameterizedQuery
    '
    Me.btnParameterizedQuery.Location = New System.Drawing.Point(8, 35)
    Me.btnParameterizedQuery.Name = "btnParameterizedQuery"
    Me.btnParameterizedQuery.Size = New System.Drawing.Size(136, 23)
    Me.btnParameterizedQuery.TabIndex = 1
    Me.btnParameterizedQuery.Text = "Parameterized query"
    Me.btnParameterizedQuery.UseVisualStyleBackColor = True
    '
    'dataGridView1
    '
    Me.dataGridView1.AllowUserToAddRows = False
    Me.dataGridView1.AllowUserToDeleteRows = False
    Me.dataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dataGridView1.Location = New System.Drawing.Point(3, 123)
    Me.dataGridView1.Name = "dataGridView1"
    Me.dataGridView1.ReadOnly = True
    Me.dataGridView1.Size = New System.Drawing.Size(850, 307)
    Me.dataGridView1.TabIndex = 6
    '
    'TabPage4
    '
    Me.TabPage4.Controls.Add(Me.btnLinqtoTextFiles)
    Me.TabPage4.Controls.Add(Me.txtLinqToTextFilesResults)
    Me.TabPage4.Location = New System.Drawing.Point(4, 22)
    Me.TabPage4.Name = "TabPage4"
    Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage4.Size = New System.Drawing.Size(856, 433)
    Me.TabPage4.TabIndex = 3
    Me.TabPage4.Text = "5.1.4 LINQ to Text Files"
    Me.TabPage4.UseVisualStyleBackColor = True
    '
    'btnLinqtoTextFiles
    '
    Me.btnLinqtoTextFiles.Location = New System.Drawing.Point(8, 6)
    Me.btnLinqtoTextFiles.Name = "btnLinqtoTextFiles"
    Me.btnLinqtoTextFiles.Size = New System.Drawing.Size(75, 23)
    Me.btnLinqtoTextFiles.TabIndex = 0
    Me.btnLinqtoTextFiles.Text = "Run"
    Me.btnLinqtoTextFiles.UseVisualStyleBackColor = True
    '
    'txtLinqToTextFilesResults
    '
    Me.txtLinqToTextFilesResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtLinqToTextFilesResults.Location = New System.Drawing.Point(6, 35)
    Me.txtLinqToTextFilesResults.Multiline = True
    Me.txtLinqToTextFilesResults.Name = "txtLinqToTextFilesResults"
    Me.txtLinqToTextFilesResults.Size = New System.Drawing.Size(840, 408)
    Me.txtLinqToTextFilesResults.TabIndex = 1
    '
    'TabPage5
    '
    Me.TabPage5.Controls.Add(Me.btnFunctionalConstruction)
    Me.TabPage5.Controls.Add(Me.btnFunctionalConstructionAnonymous)
    Me.TabPage5.Controls.Add(Me.btnForEach)
    Me.TabPage5.Controls.Add(Me.txtDesignPatternsResults)
    Me.TabPage5.Location = New System.Drawing.Point(4, 22)
    Me.TabPage5.Name = "TabPage5"
    Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage5.Size = New System.Drawing.Size(856, 433)
    Me.TabPage5.TabIndex = 4
    Me.TabPage5.Text = "5.2 Design Patterns"
    Me.TabPage5.UseVisualStyleBackColor = True
    '
    'btnFunctionalConstruction
    '
    Me.btnFunctionalConstruction.Location = New System.Drawing.Point(269, 6)
    Me.btnFunctionalConstruction.Name = "btnFunctionalConstruction"
    Me.btnFunctionalConstruction.Size = New System.Drawing.Size(226, 23)
    Me.btnFunctionalConstruction.TabIndex = 1
    Me.btnFunctionalConstruction.Text = "Functional Construction with existing types"
    Me.btnFunctionalConstruction.UseVisualStyleBackColor = True
    '
    'btnFunctionalConstructionAnonymous
    '
    Me.btnFunctionalConstructionAnonymous.Location = New System.Drawing.Point(8, 6)
    Me.btnFunctionalConstructionAnonymous.Name = "btnFunctionalConstructionAnonymous"
    Me.btnFunctionalConstructionAnonymous.Size = New System.Drawing.Size(255, 23)
    Me.btnFunctionalConstructionAnonymous.TabIndex = 0
    Me.btnFunctionalConstructionAnonymous.Text = "Functional Construction with anonymous types"
    Me.btnFunctionalConstructionAnonymous.UseVisualStyleBackColor = True
    '
    'btnForEach
    '
    Me.btnForEach.Location = New System.Drawing.Point(8, 37)
    Me.btnForEach.Name = "btnForEach"
    Me.btnForEach.Size = New System.Drawing.Size(75, 23)
    Me.btnForEach.TabIndex = 2
    Me.btnForEach.Text = "ForEach"
    Me.btnForEach.UseVisualStyleBackColor = True
    '
    'txtDesignPatternsResults
    '
    Me.txtDesignPatternsResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtDesignPatternsResults.Location = New System.Drawing.Point(6, 71)
    Me.txtDesignPatternsResults.Multiline = True
    Me.txtDesignPatternsResults.Name = "txtDesignPatternsResults"
    Me.txtDesignPatternsResults.Size = New System.Drawing.Size(840, 377)
    Me.txtDesignPatternsResults.TabIndex = 3
    '
    'TabPage6
    '
    Me.TabPage6.Controls.Add(Me.txtLinqToTextFilesPerformanceResults)
    Me.TabPage6.Controls.Add(Me.btnPerformanceLinqToTextFilesBad)
    Me.TabPage6.Controls.Add(Me.btnPerformanceLinqToTextFilesGood)
    Me.TabPage6.Location = New System.Drawing.Point(4, 22)
    Me.TabPage6.Name = "TabPage6"
    Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage6.Size = New System.Drawing.Size(856, 433)
    Me.TabPage6.TabIndex = 5
    Me.TabPage6.Text = "5.3.1 Performance (LINQ to Text Files)"
    Me.TabPage6.UseVisualStyleBackColor = True
    '
    'txtLinqToTextFilesPerformanceResults
    '
    Me.txtLinqToTextFilesPerformanceResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtLinqToTextFilesPerformanceResults.Location = New System.Drawing.Point(8, 64)
    Me.txtLinqToTextFilesPerformanceResults.Multiline = True
    Me.txtLinqToTextFilesPerformanceResults.Name = "txtLinqToTextFilesPerformanceResults"
    Me.txtLinqToTextFilesPerformanceResults.Size = New System.Drawing.Size(840, 363)
    Me.txtLinqToTextFilesPerformanceResults.TabIndex = 2
    '
    'btnPerformanceLinqToTextFilesBad
    '
    Me.btnPerformanceLinqToTextFilesBad.Location = New System.Drawing.Point(8, 6)
    Me.btnPerformanceLinqToTextFilesBad.Name = "btnPerformanceLinqToTextFilesBad"
    Me.btnPerformanceLinqToTextFilesBad.Size = New System.Drawing.Size(75, 23)
    Me.btnPerformanceLinqToTextFilesBad.TabIndex = 0
    Me.btnPerformanceLinqToTextFilesBad.Text = "Bad"
    Me.btnPerformanceLinqToTextFilesBad.UseVisualStyleBackColor = True
    '
    'btnPerformanceLinqToTextFilesGood
    '
    Me.btnPerformanceLinqToTextFilesGood.Location = New System.Drawing.Point(8, 35)
    Me.btnPerformanceLinqToTextFilesGood.Name = "btnPerformanceLinqToTextFilesGood"
    Me.btnPerformanceLinqToTextFilesGood.Size = New System.Drawing.Size(75, 23)
    Me.btnPerformanceLinqToTextFilesGood.TabIndex = 1
    Me.btnPerformanceLinqToTextFilesGood.Text = "Good"
    Me.btnPerformanceLinqToTextFilesGood.UseVisualStyleBackColor = True
    '
    'TabPage7
    '
    Me.TabPage7.Controls.Add(Me.txtImmediateCompleteIterationResults)
    Me.TabPage7.Controls.Add(Me.btnImmediateCompleteIteration)
    Me.TabPage7.Location = New System.Drawing.Point(4, 22)
    Me.TabPage7.Name = "TabPage7"
    Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage7.Size = New System.Drawing.Size(856, 433)
    Me.TabPage7.TabIndex = 6
    Me.TabPage7.Text = "5.3.2 Performance (immediate complete iteration)"
    Me.TabPage7.UseVisualStyleBackColor = True
    '
    'txtImmediateCompleteIterationResults
    '
    Me.txtImmediateCompleteIterationResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtImmediateCompleteIterationResults.Location = New System.Drawing.Point(6, 35)
    Me.txtImmediateCompleteIterationResults.Multiline = True
    Me.txtImmediateCompleteIterationResults.Name = "txtImmediateCompleteIterationResults"
    Me.txtImmediateCompleteIterationResults.Size = New System.Drawing.Size(840, 392)
    Me.txtImmediateCompleteIterationResults.TabIndex = 2
    '
    'btnImmediateCompleteIteration
    '
    Me.btnImmediateCompleteIteration.Location = New System.Drawing.Point(8, 6)
    Me.btnImmediateCompleteIteration.Name = "btnImmediateCompleteIteration"
    Me.btnImmediateCompleteIteration.Size = New System.Drawing.Size(75, 23)
    Me.btnImmediateCompleteIteration.TabIndex = 0
    Me.btnImmediateCompleteIteration.Text = "Run"
    Me.btnImmediateCompleteIteration.UseVisualStyleBackColor = True
    '
    'TabPage8
    '
    Me.TabPage8.Controls.Add(Me.label1)
    Me.TabPage8.Controls.Add(Me.updMaxElementsRuns)
    Me.TabPage8.Controls.Add(Me.btnMaxElementOrderbyAndFirst)
    Me.TabPage8.Controls.Add(Me.btnMaxElementCustomOperator)
    Me.TabPage8.Controls.Add(Me.btnMaxElementTwoQueries)
    Me.TabPage8.Controls.Add(Me.btnMaxElementSubquery)
    Me.TabPage8.Controls.Add(Me.btnMaxElementWithoutLinq)
    Me.TabPage8.Controls.Add(Me.txtMaxElementResults)
    Me.TabPage8.Location = New System.Drawing.Point(4, 22)
    Me.TabPage8.Name = "TabPage8"
    Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage8.Size = New System.Drawing.Size(856, 433)
    Me.TabPage8.TabIndex = 7
    Me.TabPage8.Text = "5.3.3 Performance (MaxElement)"
    Me.TabPage8.UseVisualStyleBackColor = True
    '
    'label1
    '
    Me.label1.AutoSize = True
    Me.label1.Location = New System.Drawing.Point(8, 37)
    Me.label1.Name = "label1"
    Me.label1.Size = New System.Drawing.Size(35, 13)
    Me.label1.TabIndex = 5
    Me.label1.Text = "Runs:"
    Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'updMaxElementsRuns
    '
    Me.updMaxElementsRuns.Location = New System.Drawing.Point(49, 35)
    Me.updMaxElementsRuns.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
    Me.updMaxElementsRuns.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.updMaxElementsRuns.Name = "updMaxElementsRuns"
    Me.updMaxElementsRuns.Size = New System.Drawing.Size(73, 20)
    Me.updMaxElementsRuns.TabIndex = 6
    Me.updMaxElementsRuns.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'btnMaxElementOrderbyAndFirst
    '
    Me.btnMaxElementOrderbyAndFirst.Location = New System.Drawing.Point(119, 6)
    Me.btnMaxElementOrderbyAndFirst.Name = "btnMaxElementOrderbyAndFirst"
    Me.btnMaxElementOrderbyAndFirst.Size = New System.Drawing.Size(110, 23)
    Me.btnMaxElementOrderbyAndFirst.TabIndex = 1
    Me.btnMaxElementOrderbyAndFirst.Text = "OrderBy and First"
    Me.btnMaxElementOrderbyAndFirst.UseVisualStyleBackColor = True
    '
    'btnMaxElementCustomOperator
    '
    Me.btnMaxElementCustomOperator.Location = New System.Drawing.Point(397, 6)
    Me.btnMaxElementCustomOperator.Name = "btnMaxElementCustomOperator"
    Me.btnMaxElementCustomOperator.Size = New System.Drawing.Size(115, 23)
    Me.btnMaxElementCustomOperator.TabIndex = 4
    Me.btnMaxElementCustomOperator.Text = "Custom operator"
    Me.btnMaxElementCustomOperator.UseVisualStyleBackColor = True
    '
    'btnMaxElementTwoQueries
    '
    Me.btnMaxElementTwoQueries.Location = New System.Drawing.Point(316, 6)
    Me.btnMaxElementTwoQueries.Name = "btnMaxElementTwoQueries"
    Me.btnMaxElementTwoQueries.Size = New System.Drawing.Size(75, 23)
    Me.btnMaxElementTwoQueries.TabIndex = 3
    Me.btnMaxElementTwoQueries.Text = "Two queries"
    Me.btnMaxElementTwoQueries.UseVisualStyleBackColor = True
    '
    'btnMaxElementSubquery
    '
    Me.btnMaxElementSubquery.Location = New System.Drawing.Point(235, 6)
    Me.btnMaxElementSubquery.Name = "btnMaxElementSubquery"
    Me.btnMaxElementSubquery.Size = New System.Drawing.Size(75, 23)
    Me.btnMaxElementSubquery.TabIndex = 2
    Me.btnMaxElementSubquery.Text = "Sub-query"
    Me.btnMaxElementSubquery.UseVisualStyleBackColor = True
    '
    'btnMaxElementWithoutLinq
    '
    Me.btnMaxElementWithoutLinq.Location = New System.Drawing.Point(8, 6)
    Me.btnMaxElementWithoutLinq.Name = "btnMaxElementWithoutLinq"
    Me.btnMaxElementWithoutLinq.Size = New System.Drawing.Size(105, 23)
    Me.btnMaxElementWithoutLinq.TabIndex = 0
    Me.btnMaxElementWithoutLinq.Text = "Without LINQ"
    Me.btnMaxElementWithoutLinq.UseVisualStyleBackColor = True
    '
    'txtMaxElementResults
    '
    Me.txtMaxElementResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtMaxElementResults.Location = New System.Drawing.Point(6, 61)
    Me.txtMaxElementResults.Multiline = True
    Me.txtMaxElementResults.Name = "txtMaxElementResults"
    Me.txtMaxElementResults.Size = New System.Drawing.Size(840, 366)
    Me.txtMaxElementResults.TabIndex = 7
    '
    'TabPage9
    '
    Me.TabPage9.Controls.Add(Me.txtPerformanceResults)
    Me.TabPage9.Controls.Add(Me.rdbJoin)
    Me.TabPage9.Controls.Add(Me.rdbSort)
    Me.TabPage9.Controls.Add(Me.rdbFilterOnString)
    Me.TabPage9.Controls.Add(Me.rdbFilterOnInt)
    Me.TabPage9.Controls.Add(Me.btnCollect)
    Me.TabPage9.Controls.Add(Me.label3)
    Me.TabPage9.Controls.Add(Me.updOverheadRuns)
    Me.TabPage9.Controls.Add(Me.btnPerformanceLinqPresized)
    Me.TabPage9.Controls.Add(Me.btnPerformanceToList)
    Me.TabPage9.Controls.Add(Me.btnPerformanceListForEach)
    Me.TabPage9.Controls.Add(Me.btnPerformanceListFindAll)
    Me.TabPage9.Controls.Add(Me.btnPerformanceFor)
    Me.TabPage9.Controls.Add(Me.btnPerformanceForeach)
    Me.TabPage9.Location = New System.Drawing.Point(4, 22)
    Me.TabPage9.Name = "TabPage9"
    Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage9.Size = New System.Drawing.Size(856, 433)
    Me.TabPage9.TabIndex = 8
    Me.TabPage9.Text = "5.3.4 Performance (LINQ's overhead)"
    Me.TabPage9.UseVisualStyleBackColor = True
    '
    'txtPerformanceResults
    '
    Me.txtPerformanceResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtPerformanceResults.Location = New System.Drawing.Point(7, 62)
    Me.txtPerformanceResults.Multiline = True
    Me.txtPerformanceResults.Name = "txtPerformanceResults"
    Me.txtPerformanceResults.Size = New System.Drawing.Size(840, 368)
    Me.txtPerformanceResults.TabIndex = 13
    '
    'rdbJoin
    '
    Me.rdbJoin.AutoSize = True
    Me.rdbJoin.Location = New System.Drawing.Point(316, 34)
    Me.rdbJoin.Name = "rdbJoin"
    Me.rdbJoin.Size = New System.Drawing.Size(45, 17)
    Me.rdbJoin.TabIndex = 11
    Me.rdbJoin.Text = "Join"
    Me.rdbJoin.UseVisualStyleBackColor = True
    '
    'rdbSort
    '
    Me.rdbSort.AutoSize = True
    Me.rdbSort.Location = New System.Drawing.Point(366, 34)
    Me.rdbSort.Name = "rdbSort"
    Me.rdbSort.Size = New System.Drawing.Size(45, 17)
    Me.rdbSort.TabIndex = 12
    Me.rdbSort.Text = "Sort"
    Me.rdbSort.UseVisualStyleBackColor = True
    '
    'rdbFilterOnString
    '
    Me.rdbFilterOnString.AutoSize = True
    Me.rdbFilterOnString.Location = New System.Drawing.Point(220, 34)
    Me.rdbFilterOnString.Name = "rdbFilterOnString"
    Me.rdbFilterOnString.Size = New System.Drawing.Size(91, 17)
    Me.rdbFilterOnString.TabIndex = 10
    Me.rdbFilterOnString.Text = "Filter on string"
    Me.rdbFilterOnString.UseVisualStyleBackColor = True
    '
    'rdbFilterOnInt
    '
    Me.rdbFilterOnInt.AutoSize = True
    Me.rdbFilterOnInt.Checked = True
    Me.rdbFilterOnInt.Location = New System.Drawing.Point(138, 34)
    Me.rdbFilterOnInt.Name = "rdbFilterOnInt"
    Me.rdbFilterOnInt.Size = New System.Drawing.Size(77, 17)
    Me.rdbFilterOnInt.TabIndex = 9
    Me.rdbFilterOnInt.TabStop = True
    Me.rdbFilterOnInt.Text = "Filter on int"
    Me.rdbFilterOnInt.UseVisualStyleBackColor = True
    '
    'btnCollect
    '
    Me.btnCollect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnCollect.Location = New System.Drawing.Point(774, 7)
    Me.btnCollect.Name = "btnCollect"
    Me.btnCollect.Size = New System.Drawing.Size(75, 23)
    Me.btnCollect.TabIndex = 6
    Me.btnCollect.Text = "GC.Collect"
    Me.btnCollect.UseVisualStyleBackColor = True
    '
    'label3
    '
    Me.label3.AutoSize = True
    Me.label3.Location = New System.Drawing.Point(7, 36)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(35, 13)
    Me.label3.TabIndex = 7
    Me.label3.Text = "Runs:"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'updOverheadRuns
    '
    Me.updOverheadRuns.Location = New System.Drawing.Point(48, 34)
    Me.updOverheadRuns.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
    Me.updOverheadRuns.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.updOverheadRuns.Name = "updOverheadRuns"
    Me.updOverheadRuns.Size = New System.Drawing.Size(73, 20)
    Me.updOverheadRuns.TabIndex = 8
    Me.updOverheadRuns.Value = New Decimal(New Integer() {50, 0, 0, 0})
    '
    'btnPerformanceLinqPresized
    '
    Me.btnPerformanceLinqPresized.Location = New System.Drawing.Point(533, 7)
    Me.btnPerformanceLinqPresized.Name = "btnPerformanceLinqPresized"
    Me.btnPerformanceLinqPresized.Size = New System.Drawing.Size(136, 23)
    Me.btnPerformanceLinqPresized.TabIndex = 5
    Me.btnPerformanceLinqPresized.Text = "LINQ with presized list"
    Me.btnPerformanceLinqPresized.UseVisualStyleBackColor = True
    '
    'btnPerformanceToList
    '
    Me.btnPerformanceToList.Location = New System.Drawing.Point(404, 7)
    Me.btnPerformanceToList.Name = "btnPerformanceToList"
    Me.btnPerformanceToList.Size = New System.Drawing.Size(123, 23)
    Me.btnPerformanceToList.TabIndex = 4
    Me.btnPerformanceToList.Text = "LINQ with ToList"
    Me.btnPerformanceToList.UseVisualStyleBackColor = True
    '
    'btnPerformanceListForEach
    '
    Me.btnPerformanceListForEach.Location = New System.Drawing.Point(285, 6)
    Me.btnPerformanceListForEach.Name = "btnPerformanceListForEach"
    Me.btnPerformanceListForEach.Size = New System.Drawing.Size(113, 23)
    Me.btnPerformanceListForEach.TabIndex = 3
    Me.btnPerformanceListForEach.Text = "List(Of T).ForEach"
    Me.btnPerformanceListForEach.UseVisualStyleBackColor = True
    '
    'btnPerformanceListFindAll
    '
    Me.btnPerformanceListFindAll.Location = New System.Drawing.Point(169, 6)
    Me.btnPerformanceListFindAll.Name = "btnPerformanceListFindAll"
    Me.btnPerformanceListFindAll.Size = New System.Drawing.Size(110, 23)
    Me.btnPerformanceListFindAll.TabIndex = 2
    Me.btnPerformanceListFindAll.Text = "List(Of T).FindAll"
    Me.btnPerformanceListFindAll.UseVisualStyleBackColor = True
    '
    'btnPerformanceFor
    '
    Me.btnPerformanceFor.Location = New System.Drawing.Point(88, 6)
    Me.btnPerformanceFor.Name = "btnPerformanceFor"
    Me.btnPerformanceFor.Size = New System.Drawing.Size(75, 23)
    Me.btnPerformanceFor.TabIndex = 1
    Me.btnPerformanceFor.Text = "for"
    Me.btnPerformanceFor.UseVisualStyleBackColor = True
    '
    'btnPerformanceForeach
    '
    Me.btnPerformanceForeach.Location = New System.Drawing.Point(7, 6)
    Me.btnPerformanceForeach.Name = "btnPerformanceForeach"
    Me.btnPerformanceForeach.Size = New System.Drawing.Size(75, 23)
    Me.btnPerformanceForeach.TabIndex = 0
    Me.btnPerformanceForeach.Text = "foreach"
    Me.btnPerformanceForeach.UseVisualStyleBackColor = True
    '
    'TabPage10
    '
    Me.TabPage10.Controls.Add(Me.label2)
    Me.TabPage10.Controls.Add(Me.updGroupingRuns)
    Me.TabPage10.Controls.Add(Me.btnGroupingWithLinqPerf)
    Me.TabPage10.Controls.Add(Me.btnGroupingWithLinq)
    Me.TabPage10.Controls.Add(Me.btnGroupingWithoutLinqPerf)
    Me.TabPage10.Controls.Add(Me.btnGroupingWithoutLinq)
    Me.TabPage10.Controls.Add(Me.txtPerformanceGroupingResults)
    Me.TabPage10.Location = New System.Drawing.Point(4, 22)
    Me.TabPage10.Name = "TabPage10"
    Me.TabPage10.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage10.Size = New System.Drawing.Size(856, 433)
    Me.TabPage10.TabIndex = 9
    Me.TabPage10.Text = "5.3.5 Performance (grouping)"
    Me.TabPage10.UseVisualStyleBackColor = True
    '
    'label2
    '
    Me.label2.AutoSize = True
    Me.label2.Location = New System.Drawing.Point(8, 67)
    Me.label2.Name = "label2"
    Me.label2.Size = New System.Drawing.Size(35, 13)
    Me.label2.TabIndex = 4
    Me.label2.Text = "Runs:"
    Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'updGroupingRuns
    '
    Me.updGroupingRuns.Location = New System.Drawing.Point(49, 65)
    Me.updGroupingRuns.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
    Me.updGroupingRuns.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.updGroupingRuns.Name = "updGroupingRuns"
    Me.updGroupingRuns.Size = New System.Drawing.Size(73, 20)
    Me.updGroupingRuns.TabIndex = 5
    Me.updGroupingRuns.Value = New Decimal(New Integer() {10, 0, 0, 0})
    '
    'btnGroupingWithLinqPerf
    '
    Me.btnGroupingWithLinqPerf.Location = New System.Drawing.Point(190, 35)
    Me.btnGroupingWithLinqPerf.Name = "btnGroupingWithLinqPerf"
    Me.btnGroupingWithLinqPerf.Size = New System.Drawing.Size(166, 23)
    Me.btnGroupingWithLinqPerf.TabIndex = 3
    Me.btnGroupingWithLinqPerf.Text = "Grouping with LINQ (perf)"
    Me.btnGroupingWithLinqPerf.UseVisualStyleBackColor = True
    '
    'btnGroupingWithLinq
    '
    Me.btnGroupingWithLinq.Location = New System.Drawing.Point(190, 6)
    Me.btnGroupingWithLinq.Name = "btnGroupingWithLinq"
    Me.btnGroupingWithLinq.Size = New System.Drawing.Size(166, 23)
    Me.btnGroupingWithLinq.TabIndex = 1
    Me.btnGroupingWithLinq.Text = "Grouping with LINQ"
    Me.btnGroupingWithLinq.UseVisualStyleBackColor = True
    '
    'btnGroupingWithoutLinqPerf
    '
    Me.btnGroupingWithoutLinqPerf.Location = New System.Drawing.Point(8, 35)
    Me.btnGroupingWithoutLinqPerf.Name = "btnGroupingWithoutLinqPerf"
    Me.btnGroupingWithoutLinqPerf.Size = New System.Drawing.Size(176, 23)
    Me.btnGroupingWithoutLinqPerf.TabIndex = 2
    Me.btnGroupingWithoutLinqPerf.Text = "Grouping without LINQ (perf)"
    Me.btnGroupingWithoutLinqPerf.UseVisualStyleBackColor = True
    '
    'btnGroupingWithoutLinq
    '
    Me.btnGroupingWithoutLinq.Location = New System.Drawing.Point(8, 6)
    Me.btnGroupingWithoutLinq.Name = "btnGroupingWithoutLinq"
    Me.btnGroupingWithoutLinq.Size = New System.Drawing.Size(176, 23)
    Me.btnGroupingWithoutLinq.TabIndex = 0
    Me.btnGroupingWithoutLinq.Text = "Grouping without LINQ"
    Me.btnGroupingWithoutLinq.UseVisualStyleBackColor = True
    '
    'txtPerformanceGroupingResults
    '
    Me.txtPerformanceGroupingResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtPerformanceGroupingResults.Location = New System.Drawing.Point(6, 94)
    Me.txtPerformanceGroupingResults.Multiline = True
    Me.txtPerformanceGroupingResults.Name = "txtPerformanceGroupingResults"
    Me.txtPerformanceGroupingResults.Size = New System.Drawing.Size(840, 336)
    Me.txtPerformanceGroupingResults.TabIndex = 6
    '
    'FormMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(864, 459)
    Me.Controls.Add(Me.TabControl1)
    Me.Name = "FormMain"
    Me.Text = "LINQ in Action - Chapter 5"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    CType(Me.dataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage2.PerformLayout()
    Me.TabPage3.ResumeLayout(False)
    CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage4.ResumeLayout(False)
    Me.TabPage4.PerformLayout()
    Me.TabPage5.ResumeLayout(False)
    Me.TabPage5.PerformLayout()
    Me.TabPage6.ResumeLayout(False)
    Me.TabPage6.PerformLayout()
    Me.TabPage7.ResumeLayout(False)
    Me.TabPage7.PerformLayout()
    Me.TabPage8.ResumeLayout(False)
    Me.TabPage8.PerformLayout()
    CType(Me.updMaxElementsRuns, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage9.ResumeLayout(False)
    Me.TabPage9.PerformLayout()
    CType(Me.updOverheadRuns, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage10.ResumeLayout(False)
    Me.TabPage10.PerformLayout()
    CType(Me.updGroupingRuns, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
  Private WithEvents btnQueryArrayListWithImplicitCast As System.Windows.Forms.Button
  Private WithEvents btnQueryArrayListWithExplicitCast As System.Windows.Forms.Button
  Private WithEvents dataGridView2 As System.Windows.Forms.DataGridView
  Private WithEvents btnGrouping3 As System.Windows.Forms.Button
  Private WithEvents btnGrouping2 As System.Windows.Forms.Button
  Private WithEvents btnGrouping1 As System.Windows.Forms.Button
  Private WithEvents txtGroupingResults As System.Windows.Forms.TextBox
  Private WithEvents btnDynamicQueryExpressionTree As System.Windows.Forms.Button
  Private WithEvents btnConditionalQuery As System.Windows.Forms.Button
  Private WithEvents cbxSortOrder As System.Windows.Forms.ComboBox
  Private WithEvents btnCustomSort As System.Windows.Forms.Button
  Private WithEvents btnChangingVariable As System.Windows.Forms.Button
  Private WithEvents btnParameterizedQuery As System.Windows.Forms.Button
  Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
  Private WithEvents btnLinqtoTextFiles As System.Windows.Forms.Button
  Private WithEvents txtLinqToTextFilesResults As System.Windows.Forms.TextBox
  Private WithEvents btnFunctionalConstruction As System.Windows.Forms.Button
  Private WithEvents btnFunctionalConstructionAnonymous As System.Windows.Forms.Button
  Private WithEvents btnForEach As System.Windows.Forms.Button
  Private WithEvents txtDesignPatternsResults As System.Windows.Forms.TextBox
  Private WithEvents btnPerformanceLinqToTextFilesBad As System.Windows.Forms.Button
  Private WithEvents btnPerformanceLinqToTextFilesGood As System.Windows.Forms.Button
  Private WithEvents btnImmediateCompleteIteration As System.Windows.Forms.Button
  Private WithEvents label1 As System.Windows.Forms.Label
  Private WithEvents updMaxElementsRuns As System.Windows.Forms.NumericUpDown
  Private WithEvents btnMaxElementOrderbyAndFirst As System.Windows.Forms.Button
  Private WithEvents btnMaxElementCustomOperator As System.Windows.Forms.Button
  Private WithEvents btnMaxElementTwoQueries As System.Windows.Forms.Button
  Private WithEvents btnMaxElementSubquery As System.Windows.Forms.Button
  Private WithEvents btnMaxElementWithoutLinq As System.Windows.Forms.Button
  Private WithEvents txtMaxElementResults As System.Windows.Forms.TextBox
  Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
  Private WithEvents txtPerformanceResults As System.Windows.Forms.TextBox
  Private WithEvents rdbJoin As System.Windows.Forms.RadioButton
  Private WithEvents rdbSort As System.Windows.Forms.RadioButton
  Private WithEvents rdbFilterOnString As System.Windows.Forms.RadioButton
  Private WithEvents rdbFilterOnInt As System.Windows.Forms.RadioButton
  Private WithEvents btnCollect As System.Windows.Forms.Button
  Private WithEvents label3 As System.Windows.Forms.Label
  Private WithEvents updOverheadRuns As System.Windows.Forms.NumericUpDown
  Private WithEvents btnPerformanceLinqPresized As System.Windows.Forms.Button
  Private WithEvents btnPerformanceToList As System.Windows.Forms.Button
  Private WithEvents btnPerformanceListForEach As System.Windows.Forms.Button
  Private WithEvents btnPerformanceListFindAll As System.Windows.Forms.Button
  Private WithEvents btnPerformanceFor As System.Windows.Forms.Button
  Private WithEvents btnPerformanceForeach As System.Windows.Forms.Button
  Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
  Private WithEvents label2 As System.Windows.Forms.Label
  Private WithEvents updGroupingRuns As System.Windows.Forms.NumericUpDown
  Private WithEvents btnGroupingWithLinqPerf As System.Windows.Forms.Button
  Private WithEvents btnGroupingWithLinq As System.Windows.Forms.Button
  Private WithEvents btnGroupingWithoutLinqPerf As System.Windows.Forms.Button
  Private WithEvents btnGroupingWithoutLinq As System.Windows.Forms.Button
  Private WithEvents txtPerformanceGroupingResults As System.Windows.Forms.TextBox
  Private WithEvents txtLinqToTextFilesPerformanceResults As System.Windows.Forms.TextBox
  Private WithEvents txtImmediateCompleteIterationResults As System.Windows.Forms.TextBox
End Class
