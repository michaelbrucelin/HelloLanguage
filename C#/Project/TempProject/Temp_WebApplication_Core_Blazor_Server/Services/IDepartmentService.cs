using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temp_WebApplication_Core_Blazor_Server.Models;

namespace Temp_WebApplication_Core_Blazor_Server.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task<CompanySummary> GetCompanySummary();
        Task Add(Department department);
    }
}
