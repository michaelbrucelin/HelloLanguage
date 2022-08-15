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

            await DownloadWebsitesAsync_UITrue().ConfigureAwait(true);   // 即使不设置，由于的UI项目，.NET也会自动配置为true

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

            await DownloadWebsitesAsync_UIFalse().ConfigureAwait(false);  // 配置为false，意味着后面的代码从线程池随机一个线程执行，大概率（一定？）不会是UI线程，所以会抛异常

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
        private async void btnLibTrue_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            await DownloadWebsitesAsync_LibraryTrue();

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
        private async void btnLibFalse_Click(object sender, EventArgs e)
        {
            txtShow.Text = "";

            Stopwatch stopwatch = Stopwatch.StartNew();

            await DownloadWebsitesAsync_LibraryFalse();

            try
            {
                txtShow.Text += $"Elapsed time: {stopwatch.Elapsed}{Environment.NewLine}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task DownloadWebsitesAsync_UITrue()
        {
            List<Task<string>> downloadWebsiteTasks = new List<Task<string>>();

            foreach (string site in Contents.WebSites)
            {
                downloadWebsiteTasks.Add(DownloadWebSiteAsync(site));
            }

            string[] results = await Task.WhenAll(downloadWebsiteTasks).ConfigureAwait(true);  // 即使不设置，由于的UI项目，.NET也会自动配置为true
            foreach (string result in results)
                ReportResult(result);
        }

        private async Task DownloadWebsitesAsync_UIFalse()
        {
            List<Task<string>> downloadWebsiteTasks = new List<Task<string>>();

            foreach (string site in Contents.WebSites)
            {
                downloadWebsiteTasks.Add(DownloadWebSiteAsync(site));
            }

            string[] results = await Task.WhenAll(downloadWebsiteTasks).ConfigureAwait(false);  // 配置为false，意味着后面的代码从线程池随机一个线程执行，大概率（一定？）不会是UI线程，所以会抛异常

            try
            {
                foreach (string result in results)
                    ReportResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task DownloadWebsitesAsync_LibraryTrue()
        {
            List<Task<string>> downloadWebsiteTasks = new List<Task<string>>();

            foreach (string site in Contents.WebSites)
            {
                downloadWebsiteTasks.Add(DownloadWebSiteAsync_LibraryTrue(site));
            }

            string[] results = Task.WhenAll(downloadWebsiteTasks).Result;  // .Result与.GetAwaiter().GetResult()效果一样
                                                                           // 这是一个非常不好的写法，通常不建议阻塞一个async的Thread，这里只是为了测试Library中的ConfigAwait(true)场景
                                                                           // 这里只是为了把Thread阻塞在这里，也就是说这里并没有释放UI Thread，UI Thread会等待所有的Task完成，并等待结果的返回
                                                                           // 这时如果Library中的方法设置了ConfigAwait(true)，就是与这里的代码形成死锁，互相等待对方释放UI Thread
            foreach (string result in results)
                ReportResult(result);
        }

        private async Task DownloadWebsitesAsync_LibraryFalse()
        {
            List<Task<string>> downloadWebsiteTasks = new List<Task<string>>();

            foreach (string site in Contents.WebSites)
            {
                downloadWebsiteTasks.Add(DownloadWebSiteAsync_LibraryFalse(site));
            }

            string[] results = Task.WhenAll(downloadWebsiteTasks).Result;  // .Result与.GetAwaiter().GetResult()效果一样
                                                                           // 这是一个非常不好的写法，通常不建议阻塞一个async的Thread，这里只是为了测试Library中的ConfigAwait(true)场景
                                                                           // 这里只是为了把Thread阻塞在这里，也就是说这里并没有释放UI Thread，UI Thread会等待所有的Task完成，并等待结果的返回
                                                                           // 这时如果Library中的方法设置了ConfigAwait(true)，就是与这里的代码形成死锁，互相等待对方释放UI Thread
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

        /// <summary>
        /// 假设此方法是来自某个Library，那么通常会设置ConfigAwait(false)，
        /// 因为通常Library中的方法并不在意await后面的代码是被一个新的线程执行，还是被原始线程执行，
        /// 而如果用的是ThreadPool中随机一个线程执行，通常可以获得更好的性能。
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> DownloadWebSiteAsync_LibraryTrue(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpResponseMessage response = await httpClient.GetAsync(url).ConfigureAwait(true);
            byte[] responsePayloadBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(true);

            return $"Finish downloding data from {url}. Total bytes returned {responsePayloadBytes.Length}. {Environment.NewLine}";
        }

        /// <summary>
        /// 假设此方法是来自某个Library，那么通常会设置ConfigAwait(false)，
        /// 因为通常Library中的方法并不在意await后面的代码是被一个新的线程执行，还是被原始线程执行，
        /// 而如果用的是ThreadPool中随机一个线程执行，通常可以获得更好的性能。
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> DownloadWebSiteAsync_LibraryFalse(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpResponseMessage response = await httpClient.GetAsync(url).ConfigureAwait(false);
            byte[] responsePayloadBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

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
