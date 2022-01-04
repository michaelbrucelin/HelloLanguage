using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temp_WebApplication_Core_MVC.Services;

namespace Temp_WebApplication_Core_MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IClock clock)  //由于在Startup中有注册，所以这里面的IClock会是一个ChinaClock类型
        {

        }
    }
}
