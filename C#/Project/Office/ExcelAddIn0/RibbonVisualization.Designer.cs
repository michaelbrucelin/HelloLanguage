namespace ExcelAddIn0
{
    partial class RibbonVisualization : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonVisualization()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
            this.tab0 = this.Factory.CreateRibbonTab();
            this.group0 = this.Factory.CreateRibbonGroup();
            this.btn01 = this.Factory.CreateRibbonButton();
            this.btn02 = this.Factory.CreateRibbonButton();
            this.chkShowPane = this.Factory.CreateRibbonCheckBox();
            this.tab0.SuspendLayout();
            this.group0.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab0
            // 
            this.tab0.Groups.Add(this.group0);
            this.tab0.Label = "MyTabAddIns0";
            this.tab0.Name = "tab0";
            // 
            // group0
            // 
            this.group0.DialogLauncher = ribbonDialogLauncherImpl1;
            this.group0.Items.Add(this.btn01);
            this.group0.Items.Add(this.btn02);
            this.group0.Items.Add(this.chkShowPane);
            this.group0.Label = "MyGroup0";
            this.group0.Name = "group0";
            this.group0.DialogLauncherClick += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.group0_DialogLauncherClick);
            // 
            // btn01
            // 
            this.btn01.Label = "注册事件";
            this.btn01.Name = "btn01";
            this.btn01.ShowImage = true;
            this.btn01.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn01_Click);
            // 
            // btn02
            // 
            this.btn02.Label = "取消事件";
            this.btn02.Name = "btn02";
            this.btn02.ShowImage = true;
            this.btn02.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn02_Click);
            // 
            // chkShowPane
            // 
            this.chkShowPane.Label = "显示Pane";
            this.chkShowPane.Name = "chkShowPane";
            this.chkShowPane.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.chkShowPane_Click);
            // 
            // RibbonVisualization
            // 
            this.Name = "RibbonVisualization";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab0);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonVisualization_Load);
            this.tab0.ResumeLayout(false);
            this.tab0.PerformLayout();
            this.group0.ResumeLayout(false);
            this.group0.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab0;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group0;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn01;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn02;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox chkShowPane;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonVisualization RibbonVisualization
        {
            get { return this.GetRibbon<RibbonVisualization>(); }
        }
    }
}
