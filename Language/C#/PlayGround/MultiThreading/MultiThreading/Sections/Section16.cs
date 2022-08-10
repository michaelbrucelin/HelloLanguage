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

        private void btnSync_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            DownloadWebsitesSync();

            txtShow.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            await DownloadWebsitesAsync();

            txtShow.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
        }

        private void btnAsync2_Click(object sender, EventArgs e)
        {

        }

        private void btnAsync3_Click(object sender, EventArgs e)
        {

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
                string result = await Task.Run(() => DownloadWebSiteSync(site));
                ReportResult(result);
            }
        }

        private string DownloadWebSiteSync(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpResponseMessage response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            byte[] responsePayloadBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();

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
