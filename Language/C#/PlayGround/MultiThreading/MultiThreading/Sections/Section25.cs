using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Section25 : Form
    {
        public Section25()
        {
            InitializeComponent();
        }

        private void Section25_Load(object sender, EventArgs e)
        {

        }

        private async void btnSample01_Click(object sender, EventArgs e)
        {
            // await IssueClientRequestAsync("127.0.0.1", "hello");  // 连接会失败
            Console.WriteLine("done");
        }

        private async Task<string> IssueClientRequestAsync(string serverName, string message)
        {
            using (NamedPipeClientStream pipe = new NamedPipeClientStream(serverName, "PipeName", PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough))
            {
                pipe.Connect();  // 必须在设置ReadMode之前连接
                pipe.ReadMode = PipeTransmissionMode.Message;

                // 将数据异步发送给服务器
                byte[] request = Encoding.UTF8.GetBytes(message);
                await pipe.WriteAsync(request, 0, request.Length);

                // 异步读取服务器的响应
                byte[] response = new byte[1000];
                int bytesRead = await pipe.ReadAsync(response, 0, response.Length);

                return Encoding.UTF8.GetString(response, 0, bytesRead);
            }  // 关闭管道
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
