namespace LinqInAction.Chapter14
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPageLoading = new System.Windows.Forms.TabPage();
      this.btnTestLoading = new System.Windows.Forms.Button();
      this.tabPageWithoutLinq = new System.Windows.Forms.TabPage();
      this.btnDataTableSelect = new System.Windows.Forms.Button();
      this.btnDataViewsRelationships = new System.Windows.Forms.Button();
      this.btnDataViews = new System.Windows.Forms.Button();
      this.tabPageUntypedDataSet = new System.Windows.Forms.TabPage();
      this.btnUntypedDataView = new System.Windows.Forms.Button();
      this.btnUntypedRelationship = new System.Windows.Forms.Button();
      this.btnUntypedJoin = new System.Windows.Forms.Button();
      this.btnUntypedSimple = new System.Windows.Forms.Button();
      this.tabPageTypedDataSet = new System.Windows.Forms.TabPage();
      this.btnTypedDataView = new System.Windows.Forms.Button();
      this.btnTypedRelationship = new System.Windows.Forms.Button();
      this.btnTypedJoin = new System.Windows.Forms.Button();
      this.btnTypedSimple = new System.Windows.Forms.Button();
      this.tabPageCopyToDataTable = new System.Windows.Forms.TabPage();
      this.btnShowChanges = new System.Windows.Forms.Button();
      this.btnCopyToDataTable = new System.Windows.Forms.Button();
      this.tabPageDataRowComparer = new System.Windows.Forms.TabPage();
      this.btnIntersect = new System.Windows.Forms.Button();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.label2 = new System.Windows.Forms.Label();
      this.dataGridView2 = new System.Windows.Forms.DataGridView();
      this.label1 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPageLoading.SuspendLayout();
      this.tabPageWithoutLinq.SuspendLayout();
      this.tabPageUntypedDataSet.SuspendLayout();
      this.tabPageTypedDataSet.SuspendLayout();
      this.tabPageCopyToDataTable.SuspendLayout();
      this.tabPageDataRowComparer.SuspendLayout();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.tabControl1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(590, 64);
      this.panel1.TabIndex = 0;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPageLoading);
      this.tabControl1.Controls.Add(this.tabPageWithoutLinq);
      this.tabControl1.Controls.Add(this.tabPageUntypedDataSet);
      this.tabControl1.Controls.Add(this.tabPageTypedDataSet);
      this.tabControl1.Controls.Add(this.tabPageCopyToDataTable);
      this.tabControl1.Controls.Add(this.tabPageDataRowComparer);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(590, 64);
      this.tabControl1.TabIndex = 23;
      // 
      // tabPageLoading
      // 
      this.tabPageLoading.Controls.Add(this.btnTestLoading);
      this.tabPageLoading.Location = new System.Drawing.Point(4, 22);
      this.tabPageLoading.Name = "tabPageLoading";
      this.tabPageLoading.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageLoading.Size = new System.Drawing.Size(582, 38);
      this.tabPageLoading.TabIndex = 1;
      this.tabPageLoading.Text = "Loading";
      this.tabPageLoading.UseVisualStyleBackColor = true;
      // 
      // btnTestLoading
      // 
      this.btnTestLoading.Location = new System.Drawing.Point(8, 6);
      this.btnTestLoading.Name = "btnTestLoading";
      this.btnTestLoading.Size = new System.Drawing.Size(101, 23);
      this.btnTestLoading.TabIndex = 22;
      this.btnTestLoading.Text = "Test loading";
      this.btnTestLoading.UseVisualStyleBackColor = true;
      this.btnTestLoading.Click += new System.EventHandler(this.btnTestLoading_Click);
      // 
      // tabPageWithoutLinq
      // 
      this.tabPageWithoutLinq.Controls.Add(this.btnDataTableSelect);
      this.tabPageWithoutLinq.Controls.Add(this.btnDataViewsRelationships);
      this.tabPageWithoutLinq.Controls.Add(this.btnDataViews);
      this.tabPageWithoutLinq.Location = new System.Drawing.Point(4, 22);
      this.tabPageWithoutLinq.Name = "tabPageWithoutLinq";
      this.tabPageWithoutLinq.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageWithoutLinq.Size = new System.Drawing.Size(582, 38);
      this.tabPageWithoutLinq.TabIndex = 0;
      this.tabPageWithoutLinq.Text = "Without LINQ";
      this.tabPageWithoutLinq.UseVisualStyleBackColor = true;
      // 
      // btnDataTableSelect
      // 
      this.btnDataTableSelect.Location = new System.Drawing.Point(8, 6);
      this.btnDataTableSelect.Name = "btnDataTableSelect";
      this.btnDataTableSelect.Size = new System.Drawing.Size(109, 23);
      this.btnDataTableSelect.TabIndex = 22;
      this.btnDataTableSelect.Text = "DataTable.Select";
      this.btnDataTableSelect.UseVisualStyleBackColor = true;
      this.btnDataTableSelect.Click += new System.EventHandler(this.btnDataTableSelect_Click);
      // 
      // btnDataViewsRelationships
      // 
      this.btnDataViewsRelationships.Location = new System.Drawing.Point(238, 6);
      this.btnDataViewsRelationships.Name = "btnDataViewsRelationships";
      this.btnDataViewsRelationships.Size = new System.Drawing.Size(158, 23);
      this.btnDataViewsRelationships.TabIndex = 22;
      this.btnDataViewsRelationships.Text = "DataViews and Relationships";
      this.btnDataViewsRelationships.UseVisualStyleBackColor = true;
      this.btnDataViewsRelationships.Click += new System.EventHandler(this.btnDataViewsRelationships_Click);
      // 
      // btnDataViews
      // 
      this.btnDataViews.Location = new System.Drawing.Point(123, 6);
      this.btnDataViews.Name = "btnDataViews";
      this.btnDataViews.Size = new System.Drawing.Size(109, 23);
      this.btnDataViews.TabIndex = 22;
      this.btnDataViews.Text = "DataViews";
      this.btnDataViews.UseVisualStyleBackColor = true;
      this.btnDataViews.Click += new System.EventHandler(this.btnDataViews_Click);
      // 
      // tabPageUntypedDataSet
      // 
      this.tabPageUntypedDataSet.Controls.Add(this.btnUntypedDataView);
      this.tabPageUntypedDataSet.Controls.Add(this.btnUntypedRelationship);
      this.tabPageUntypedDataSet.Controls.Add(this.btnUntypedJoin);
      this.tabPageUntypedDataSet.Controls.Add(this.btnUntypedSimple);
      this.tabPageUntypedDataSet.Location = new System.Drawing.Point(4, 22);
      this.tabPageUntypedDataSet.Name = "tabPageUntypedDataSet";
      this.tabPageUntypedDataSet.Size = new System.Drawing.Size(582, 38);
      this.tabPageUntypedDataSet.TabIndex = 2;
      this.tabPageUntypedDataSet.Text = "Untyped DataSet";
      this.tabPageUntypedDataSet.UseVisualStyleBackColor = true;
      // 
      // btnUntypedDataView
      // 
      this.btnUntypedDataView.Location = new System.Drawing.Point(334, 6);
      this.btnUntypedDataView.Name = "btnUntypedDataView";
      this.btnUntypedDataView.Size = new System.Drawing.Size(75, 23);
      this.btnUntypedDataView.TabIndex = 25;
      this.btnUntypedDataView.Text = "DataView";
      this.btnUntypedDataView.UseVisualStyleBackColor = true;
      this.btnUntypedDataView.Click += new System.EventHandler(this.btnUntypedDataView_Click);
      // 
      // btnUntypedRelationship
      // 
      this.btnUntypedRelationship.Location = new System.Drawing.Point(219, 6);
      this.btnUntypedRelationship.Name = "btnUntypedRelationship";
      this.btnUntypedRelationship.Size = new System.Drawing.Size(109, 23);
      this.btnUntypedRelationship.TabIndex = 24;
      this.btnUntypedRelationship.Text = "With relationship";
      this.btnUntypedRelationship.UseVisualStyleBackColor = true;
      this.btnUntypedRelationship.Click += new System.EventHandler(this.btnUntypedRelationship_Click);
      // 
      // btnUntypedJoin
      // 
      this.btnUntypedJoin.Location = new System.Drawing.Point(112, 6);
      this.btnUntypedJoin.Name = "btnUntypedJoin";
      this.btnUntypedJoin.Size = new System.Drawing.Size(101, 23);
      this.btnUntypedJoin.TabIndex = 23;
      this.btnUntypedJoin.Text = "With join";
      this.btnUntypedJoin.UseVisualStyleBackColor = true;
      this.btnUntypedJoin.Click += new System.EventHandler(this.btnUntypedJoin_Click);
      // 
      // btnUntypedSimple
      // 
      this.btnUntypedSimple.Location = new System.Drawing.Point(5, 6);
      this.btnUntypedSimple.Name = "btnUntypedSimple";
      this.btnUntypedSimple.Size = new System.Drawing.Size(101, 23);
      this.btnUntypedSimple.TabIndex = 22;
      this.btnUntypedSimple.Text = "Simple query";
      this.btnUntypedSimple.UseVisualStyleBackColor = true;
      this.btnUntypedSimple.Click += new System.EventHandler(this.btnUntypedSimple_Click);
      // 
      // tabPageTypedDataSet
      // 
      this.tabPageTypedDataSet.Controls.Add(this.btnTypedDataView);
      this.tabPageTypedDataSet.Controls.Add(this.btnTypedRelationship);
      this.tabPageTypedDataSet.Controls.Add(this.btnTypedJoin);
      this.tabPageTypedDataSet.Controls.Add(this.btnTypedSimple);
      this.tabPageTypedDataSet.Location = new System.Drawing.Point(4, 22);
      this.tabPageTypedDataSet.Name = "tabPageTypedDataSet";
      this.tabPageTypedDataSet.Size = new System.Drawing.Size(582, 38);
      this.tabPageTypedDataSet.TabIndex = 3;
      this.tabPageTypedDataSet.Text = "Typed DataSet";
      this.tabPageTypedDataSet.UseVisualStyleBackColor = true;
      // 
      // btnTypedDataView
      // 
      this.btnTypedDataView.Location = new System.Drawing.Point(334, 6);
      this.btnTypedDataView.Name = "btnTypedDataView";
      this.btnTypedDataView.Size = new System.Drawing.Size(75, 23);
      this.btnTypedDataView.TabIndex = 26;
      this.btnTypedDataView.Text = "DataView";
      this.btnTypedDataView.UseVisualStyleBackColor = true;
      this.btnTypedDataView.Click += new System.EventHandler(this.btnTypedDataView_Click);
      // 
      // btnTypedRelationship
      // 
      this.btnTypedRelationship.Location = new System.Drawing.Point(219, 6);
      this.btnTypedRelationship.Name = "btnTypedRelationship";
      this.btnTypedRelationship.Size = new System.Drawing.Size(109, 23);
      this.btnTypedRelationship.TabIndex = 24;
      this.btnTypedRelationship.Text = "With relationship";
      this.btnTypedRelationship.UseVisualStyleBackColor = true;
      this.btnTypedRelationship.Click += new System.EventHandler(this.btnTypedRelationship_Click);
      // 
      // btnTypedJoin
      // 
      this.btnTypedJoin.Location = new System.Drawing.Point(112, 6);
      this.btnTypedJoin.Name = "btnTypedJoin";
      this.btnTypedJoin.Size = new System.Drawing.Size(101, 23);
      this.btnTypedJoin.TabIndex = 23;
      this.btnTypedJoin.Text = "With join";
      this.btnTypedJoin.UseVisualStyleBackColor = true;
      this.btnTypedJoin.Click += new System.EventHandler(this.btnTypedJoin_Click);
      // 
      // btnTypedSimple
      // 
      this.btnTypedSimple.Location = new System.Drawing.Point(5, 6);
      this.btnTypedSimple.Name = "btnTypedSimple";
      this.btnTypedSimple.Size = new System.Drawing.Size(101, 23);
      this.btnTypedSimple.TabIndex = 22;
      this.btnTypedSimple.Text = "Simple query";
      this.btnTypedSimple.UseVisualStyleBackColor = true;
      this.btnTypedSimple.Click += new System.EventHandler(this.btnTypedSimple_Click);
      // 
      // tabPageCopyToDataTable
      // 
      this.tabPageCopyToDataTable.Controls.Add(this.btnShowChanges);
      this.tabPageCopyToDataTable.Controls.Add(this.btnCopyToDataTable);
      this.tabPageCopyToDataTable.Location = new System.Drawing.Point(4, 22);
      this.tabPageCopyToDataTable.Name = "tabPageCopyToDataTable";
      this.tabPageCopyToDataTable.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageCopyToDataTable.Size = new System.Drawing.Size(582, 38);
      this.tabPageCopyToDataTable.TabIndex = 5;
      this.tabPageCopyToDataTable.Text = "CopyToDataTable";
      this.tabPageCopyToDataTable.UseVisualStyleBackColor = true;
      // 
      // btnShowChanges
      // 
      this.btnShowChanges.Enabled = false;
      this.btnShowChanges.Location = new System.Drawing.Point(129, 7);
      this.btnShowChanges.Name = "btnShowChanges";
      this.btnShowChanges.Size = new System.Drawing.Size(108, 23);
      this.btnShowChanges.TabIndex = 1;
      this.btnShowChanges.Text = "Show changes";
      this.btnShowChanges.UseVisualStyleBackColor = true;
      this.btnShowChanges.Click += new System.EventHandler(this.btnShowChanges_Click);
      // 
      // btnCopyToDataTable
      // 
      this.btnCopyToDataTable.Location = new System.Drawing.Point(9, 7);
      this.btnCopyToDataTable.Name = "btnCopyToDataTable";
      this.btnCopyToDataTable.Size = new System.Drawing.Size(113, 23);
      this.btnCopyToDataTable.TabIndex = 0;
      this.btnCopyToDataTable.Text = "CopyToDataTable";
      this.btnCopyToDataTable.UseVisualStyleBackColor = true;
      this.btnCopyToDataTable.Click += new System.EventHandler(this.btnCopyToDataTable_Click);
      // 
      // tabPageDataRowComparer
      // 
      this.tabPageDataRowComparer.Controls.Add(this.btnIntersect);
      this.tabPageDataRowComparer.Location = new System.Drawing.Point(4, 22);
      this.tabPageDataRowComparer.Name = "tabPageDataRowComparer";
      this.tabPageDataRowComparer.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageDataRowComparer.Size = new System.Drawing.Size(582, 38);
      this.tabPageDataRowComparer.TabIndex = 4;
      this.tabPageDataRowComparer.Text = "DataRowComparer";
      this.tabPageDataRowComparer.UseVisualStyleBackColor = true;
      // 
      // btnIntersect
      // 
      this.btnIntersect.Location = new System.Drawing.Point(9, 7);
      this.btnIntersect.Name = "btnIntersect";
      this.btnIntersect.Size = new System.Drawing.Size(75, 23);
      this.btnIntersect.TabIndex = 0;
      this.btnIntersect.Text = "Intersect";
      this.btnIntersect.UseVisualStyleBackColor = true;
      this.btnIntersect.Click += new System.EventHandler(this.btnIntersect_Click);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 64);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
      this.splitContainer1.Panel1.Controls.Add(this.label2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
      this.splitContainer1.Panel2.Controls.Add(this.label1);
      this.splitContainer1.Size = new System.Drawing.Size(590, 257);
      this.splitContainer1.SplitterDistance = 92;
      this.splitContainer1.TabIndex = 1;
      // 
      // dataGridView1
      // 
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 13);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(590, 79);
      this.dataGridView1.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Top;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(65, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Publishers";
      // 
      // dataGridView2
      // 
      this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView2.Location = new System.Drawing.Point(0, 13);
      this.dataGridView2.Name = "dataGridView2";
      this.dataGridView2.Size = new System.Drawing.Size(590, 148);
      this.dataGridView2.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Top;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(42, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Books";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(590, 321);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.panel1);
      this.Name = "FormMain";
      this.Text = "LINQ to DataSet";
      this.panel1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabPageLoading.ResumeLayout(false);
      this.tabPageWithoutLinq.ResumeLayout(false);
      this.tabPageUntypedDataSet.ResumeLayout(false);
      this.tabPageTypedDataSet.ResumeLayout(false);
      this.tabPageCopyToDataTable.ResumeLayout(false);
      this.tabPageDataRowComparer.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DataGridView dataGridView2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPageWithoutLinq;
    private System.Windows.Forms.Button btnDataViews;
    private System.Windows.Forms.TabPage tabPageLoading;
    private System.Windows.Forms.Button btnTestLoading;
    private System.Windows.Forms.TabPage tabPageUntypedDataSet;
    private System.Windows.Forms.Button btnUntypedRelationship;
    private System.Windows.Forms.Button btnUntypedJoin;
    private System.Windows.Forms.Button btnUntypedSimple;
    private System.Windows.Forms.TabPage tabPageTypedDataSet;
    private System.Windows.Forms.Button btnTypedRelationship;
    private System.Windows.Forms.Button btnTypedJoin;
    private System.Windows.Forms.Button btnTypedSimple;
    private System.Windows.Forms.Button btnDataTableSelect;
    private System.Windows.Forms.Button btnDataViewsRelationships;
    private System.Windows.Forms.Button btnUntypedDataView;
    private System.Windows.Forms.Button btnTypedDataView;
    private System.Windows.Forms.TabPage tabPageDataRowComparer;
    private System.Windows.Forms.Button btnIntersect;
    private System.Windows.Forms.TabPage tabPageCopyToDataTable;
    private System.Windows.Forms.Button btnCopyToDataTable;
    private System.Windows.Forms.Button btnShowChanges;
  }
}

