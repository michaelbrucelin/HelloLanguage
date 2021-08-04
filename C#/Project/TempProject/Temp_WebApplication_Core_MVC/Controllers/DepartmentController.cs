using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temp_WebApplication_Core_MVC.Models;
using Temp_WebApplication_Core_MVC.Services;

namespace Temp_WebApplication_Core_MVC.Controllers
{
    public class DepartmentController:Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IOptions<ThisOptions> _thisOptions;

        public DepartmentController(IDepartmentService departmentService,IOptions<ThisOptions> thisOptions)
        {
            _departmentService = departmentService;
            this._thisOptions = thisOptions;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Department Index";
            var departments = await _departmentService.GetAll();
            return View(departments);
        }

        //[HttpGet]  不写的话，默认就是GET方法
        public IActionResult Add()
        {
            ViewBag.Title = "Add Department";
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department model)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
