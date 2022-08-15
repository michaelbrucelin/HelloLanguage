using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Section18 : Form
    {
        public Section18()
        {
            InitializeComponent();
        }

        private void Section18_Load(object sender, EventArgs e)
        {

        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            Summary summary = BenchmarkRunner.Run<BenchMarkService>();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }

    [MemoryDiagnoser]
    public class BenchMarkService
    {
        private readonly IEnumerable<string> webSites = new string[] {
            "https://www.zhihu.com",
            "https://www.baidu.com",
            "https://www.weibo.com"
        };

        private readonly int testimes = 100000;  // 100000

        [Benchmark]
        public async Task LoadDataTask()
        {
            DownloadService downloadService = new DownloadService();

            for (int i = 0; i < testimes; i++)
            {
                foreach (string webSite in webSites)
                {
                    await downloadService.DownloadDataTask(webSite);
                }
            }
        }

        [Benchmark]
        public async ValueTask LoadDataValueTask()
        {
            DownloadService downloadService = new DownloadService();

            for (int i = 0; i < testimes; i++)
            {
                foreach (string webSite in webSites)
                {
                    await downloadService.DownloadDataValueTask(webSite);
                }
            }
        }
    }

    public class DownloadService
    {
        private readonly MemoryCache cache;
        private readonly HttpClient httpClient;
        private readonly CacheItemPolicy cacheItemPolicy;

        public DownloadService()
        {
            this.cache = MemoryCache.Default;
            this.httpClient = new HttpClient();
            this.cacheItemPolicy = new CacheItemPolicy()
            {
                SlidingExpiration = TimeSpan.FromDays(1)
            };
        }

        public async Task<object> DownloadDataTask(string website)
        {
            if (cache.Contains(website))
            {
                return cache.Get(website);
            }

            HttpResponseMessage response = await httpClient.GetAsync(website);
            cache.Set(website, response, cacheItemPolicy);

            return response;
        }

        public async ValueTask<object> DownloadDataValueTask(string website)
        {
            if (cache.Contains(website))
            {
                return cache.Get(website);
            }

            HttpResponseMessage response = await httpClient.GetAsync(website);
            cache.Set(website, response, cacheItemPolicy);

            return response;
        }
    }
}
