using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temp_WebApplication_Core_SignalR.Controllers
{
    [Route("api/count")]
    public class CountController : Controller
    {
        private readonly IHubContext<CountHub> _countHub;

        public CountController(IHubContext<CountHub> countHub)
        {
            this._countHub = countHub;
        }

        [HttpPost]
        public async Task<IActionResult> Post()  //这个地方的方法签名必须是Post，测试写成MyPost，调用时就是405错误了，暂时不清楚是为什么
        {
            //调用所有客户端的someFunc方法，并传一个参数：random="abcd"
            await _countHub.Clients.All.SendAsync("someFunc", new { random = "Hello SignalR" });

            //Accepted的状态码是202，表示请求被响应但是还没有被处理或者已经被响应并处理了但是还没有处理完的意思
            return Accepted(1);
        }
    }
}
