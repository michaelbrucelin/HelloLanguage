using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Temp_WebApplication_Core_RazorPage.Services;

namespace Temp_WebApplication_Core_RazorPage.Pages.Department
{
    public class AddDepartmentModel : PageModel
    {
        private readonly IDepartmentService _departmentService;

        [BindProperty]
        public Temp_WebApplication_Core_RazorPage.Models.Department Department { get; set; }

        public AddDepartmentModel(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _departmentService.Add(Department);
            return RedirectToPage("/Index");
        }
    }
}
