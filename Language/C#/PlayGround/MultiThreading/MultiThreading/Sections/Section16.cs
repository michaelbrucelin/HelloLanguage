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
    public partial class Section16 : Form
    {
        public Section16()
        {
            InitializeComponent();
        }

        private readonly HttpClient httpClient = new HttpClient();

        private void Section16_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 同步执行，卡UI界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            DownloadWebsitesSync();

            txtShow.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
        }

        /// <summary>
        /// 异步执行，不卡UI界面
        /// 但是效率与同步执行基本一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAsync_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            await DownloadWebsitesAsync();

            txtShow.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
        }

        /// <summary>
        /// 异步执行，不卡UI界面
        /// 而且每个下载任务在一个单独的线程（Task.Run()）中执行，即多个任务并发，提高了效率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAsync2_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            await DownloadWebsitesAsync2();

            txtShow.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
        }

        /// <summary>
        /// 异步执行，不卡UI界面
        /// 这里使用HttpClient内置的异步机制，不在将下载任务放在Task.Run()中，从而减少了Task的数量，从而减少了冷启动时clr的工作量，进一步的提升了效率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAsync3_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            await DownloadWebsitesAsync3();

            txtShow.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
        }

        private void DownloadWebsitesSync()
        {
            foreach (string site in Contents.WebSites)
            {
                string result = DownloadWebSiteSync(site);
                ReportResult(result);
            }
        }

        private async Task DownloadWebsitesAsync()
        {
            foreach (string site in Contents.WebSites)
            {
                string result = await Task.Run(() => DownloadWebSiteSync(site));      // 每次下载虽然是异步，但是彼此同步，即下载完当前的任务才能下载下一个任务
                ReportResult(result);
            }
        }

        private async Task DownloadWebsitesAsync2()
        {
            List<Task<string>> downloadWebsiteTasks = new List<Task<string>>();

            foreach (string site in Contents.WebSites)
            {
                downloadWebsiteTasks.Add(Task.Run(() => DownloadWebSiteSync(site)));  // 每个下载任务在Task.Run()新申请的一个独立线程中运行，即所有下载任务并发执行
            }

            string[] results = await Task.WhenAll(downloadWebsiteTasks);              // 异步等待所有任务的执行完毕
            foreach (string result in results)
                ReportResult(result);
        }

        private async Task DownloadWebsitesAsync3()
        {
            List<Task<string>> downloadWebsiteTasks = new List<Task<string>>();

            foreach (string site in Contents.WebSites)
            {
                downloadWebsiteTasks.Add(DownloadWebSiteAsync(site));                 // DownloadWebSiteAsync中使用了HttpClient的异步下载方法，返回的本身就是一个Task
            }

            string[] results = await Task.WhenAll(downloadWebsiteTasks);
            foreach (string result in results)
                ReportResult(result);
        }

        private string DownloadWebSiteSync(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpResponseMessage response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            byte[] responsePayloadBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();

            return $"Finish downloding data from {url}. Total bytes returned {responsePayloadBytes.Length}. {Environment.NewLine}";
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
