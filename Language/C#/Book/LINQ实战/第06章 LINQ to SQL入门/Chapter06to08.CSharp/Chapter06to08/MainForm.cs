using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinqInAction.Chapter06to08.Common;
using LinqInAction.Chapter06to08.Common.CodeSamples;
using LinqInAction.Chapter06to08.Common.SampleHarness;

namespace Samples.CSharp
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private List<SampleClass> GetSamples()
        {
            List<SampleClass> sampleList = new List<SampleClass>();
            sampleList.Add(new Ch6Samples());
            sampleList.Add(new Ch7Samples());
            sampleList.Add(new Ch8Samples());
            return sampleList;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            List<SampleClass> sampleList = GetSamples();
            foreach (SampleClass sampleClass in sampleList)
            {
                TreeNode classNode = this.SampleTreeview.Nodes.Add(sampleClass.Title);
                classNode.Tag = sampleClass;
                foreach (SampleItem item in sampleClass)
                {
                    TreeNode itemNode = classNode.Nodes.Add(item.Description);
                    itemNode.Tag = item;
                }
            }
        }

        SampleItem currentSample;
        SampleClass currentClass;

        private void SampleTreeview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = SampleTreeview.SelectedNode;
            if (selectedNode.Parent != null)
            {
                currentSample = (SampleItem)selectedNode.Tag;
                if (currentSample != null)
                {
                    currentClass = (SampleClass)selectedNode.Parent.Tag;
                    this.ChapterLabel.Text = currentSample.Chapter.ToString();
                    this.ListingLabel.Text = currentSample.ListingNumber.ToString();
                    this.DescriptionLabel.Text = currentSample.Description;
                    this.btnRun.Enabled = true;
                }
                else
                {
                    this.ChapterLabel.Text = "";
                    this.ListingLabel.Text = "";
                    this.DescriptionLabel.Text = "";
                    this.btnRun.Enabled = false;
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            OutputTextBos.Text = "";
            if (currentSample != null)
                RunSample(currentClass, currentSample);
        }

        private void btnRunAll_Click(object sender, EventArgs e)
        {
            this.OutputTextBos.Text = "";
            List<SampleClass> sampleList = GetSamples();
            foreach (SampleClass sampleClass in sampleList)
                foreach (SampleItem item in sampleClass)
                    RunSample(sampleClass, item);

        }

        private void RunSample(SampleClass currentClass, SampleItem currentSample)
        {
            if (currentSample != null)
            {
                base.UseWaitCursor = true;
                StreamWriter newOut = currentClass.OutputStreamWriter;
                TextWriter output = Console.Out;
                Console.SetOut(newOut);
                MemoryStream baseStream = (MemoryStream)newOut.BaseStream;
                baseStream.SetLength(0);
                try
                {
                    currentSample.Method.Invoke(currentClass, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.ToString());
                }
                newOut.Flush();
                Console.SetOut(output);
                OutputTextBos.Text = OutputTextBos.Text + newOut.Encoding.GetString(baseStream.ToArray());
                base.UseWaitCursor = false;
            }
        }
    }
}