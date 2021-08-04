using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temp_WebApplication_Core_MVC.Models;

namespace Temp_WebApplication_Core_MVC.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task<CompanySummary> GetCompanySummary();
        Task Add(Department department);
    }
}
