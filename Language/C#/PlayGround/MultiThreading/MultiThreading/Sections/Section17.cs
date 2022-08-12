using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Section17 : Form
    {
        public Section17()
        {
            InitializeComponent();
        }

        private readonly HttpClient httpClient = new HttpClient();

        private void Section17_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnUITrue_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            await DownloadWebsitesAsync().ConfigureAwait(true);   // 即使不设置，由于的UI项目，.NET也会自动配置为true

            txtShow.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnUIFalse_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            await DownloadWebsitesAsync().ConfigureAwait(false);  // 配置为false，意味着后面的代码从线程池随机一个线程执行，大概率（一定？）不会是UI线程，所以会抛异常

            try
            {
                txtShow.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLibTrue_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLibFalse_Click(object sender, EventArgs e)
        {

        }

        private async Task DownloadWebsitesAsync()
        {
            List<Task<string>> downloadWebsiteTasks = new List<Task<string>>();

            foreach (string site in Contents.WebSites)
            {
                downloadWebsiteTasks.Add(DownloadWebSiteAsync(site));
            }

            string[] results = await Task.WhenAll(downloadWebsiteTasks);
            foreach (string result in results)
                ReportResult(result);
        }

        private async Task<string> DownloadWebSiteAsync(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpResponseMessage response = await httpClient.GetAsync(url);
            byte[] responsePayloadBytes = await response.Content.ReadAsByteArrayAsync();

            return $"Finish downloding data from {url}. Total bytes returned {responsePayloadBytes.Length}. {Environment.NewLine}";
        }

        private void ReportResult(string result)
        {
            txtShow.Text += result;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
            txtShow.Text = string.Empty;
        }
    }
}
