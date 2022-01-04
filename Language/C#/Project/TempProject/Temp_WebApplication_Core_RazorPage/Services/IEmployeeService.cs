using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temp_WebApplication_Core_RazorPage.Models;

namespace Temp_WebApplication_Core_RazorPage.Services
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);
        Task<Employee> Fire(int id);
    }
}
