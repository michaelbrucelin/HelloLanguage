using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Temp_WebApplication_Core_SignalR.Services;

namespace Temp_WebApplication_Core_SignalR
{
    /// <summary>
    /// 在Hub中服务器可以调用客户端的JavaScript等客户端方法，客户端也可以调用服务端Hub中的方法
    /// </summary>
    //[Authorize]  身份认证
    public class CountHub : Hub
    {
        private readonly CountService _countService;

        public CountHub(CountService countService)
        {
            this._countService = countService;
        }

        public async Task GetLatestCount(string random)
        {
            //获取用户信息
            //var user = Context.User.Identity.Name;

            int count;
            do
            {
                count = _countService.GetLatestCount();
                Thread.Sleep(1000);
                //调用客户端的ReceiveUpdate方法
                await Clients.All.SendAsync("ReceiveUpdate", count);
            }
            while (count < 10);

            //调用客户端的Finished方法
            await Clients.All.SendAsync("Finished");
        }

        public override async Task OnConnectedAsync()
        {
            ////获取指定的客户端
            //var connectionId = Context.ConnectionId;
            //var client = Clients.Client(connectionId);
            ////调用指定的客户端的方法
            //await client.SendAsync("someFunc", new { });
            ////调用除了某个指定客户端外所有客户端的方法
            //await Clients.AllExcept(connectionId).SendAsync("someFunc");
            ////将指定的客户端加到指定的分组中
            //await Groups.AddToGroupAsync(connectionId, "MyGroup");
            ////将指定的客户端从指定的分组中移除
            //await Groups.RemoveFromGroupAsync(connectionId, "MyGroup");
            ////调用指定分组中所有客户端的方法
            //await Clients.Groups("MyGroup").SendAsync("someFun");
        }
    }
}
