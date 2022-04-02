namespace LinqInAction.Chapter04.Win
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
      this.lnkFormStrings = new System.Windows.Forms.LinkLabel();
      this.lnkFormBooks = new System.Windows.Forms.LinkLabel();
      this.SuspendLayout();
      // 
      // lnkFormStrings
      // 
      this.lnkFormStrings.AutoSize = true;
      this.lnkFormStrings.Location = new System.Drawing.Point(12, 9);
      this.lnkFormStrings.Name = "lnkFormStrings";
      this.lnkFormStrings.Size = new System.Drawing.Size(62, 13);
      this.lnkFormStrings.TabIndex = 1;
      this.lnkFormStrings.TabStop = true;
      this.lnkFormStrings.Text = "FormStrings";
      this.lnkFormStrings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFormStrings_LinkClicked);
      // 
      // lnkFormBooks
      // 
      this.lnkFormBooks.AutoSize = true;
      this.lnkFormBooks.Location = new System.Drawing.Point(12, 27);
      this.lnkFormBooks.Name = "lnkFormBooks";
      this.lnkFormBooks.Size = new System.Drawing.Size(60, 13);
      this.lnkFormBooks.TabIndex = 2;
      this.lnkFormBooks.TabStop = true;
      this.lnkFormBooks.Text = "FormBooks";
      this.lnkFormBooks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFormBooks_LinkClicked);
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 271);
      this.Controls.Add(this.lnkFormBooks);
      this.Controls.Add(this.lnkFormStrings);
      this.Name = "FormMain";
      this.Text = "LINQ in Action - Chapter 4";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.LinkLabel lnkFormStrings;
    private System.Windows.Forms.LinkLabel lnkFormBooks;
  }
}

