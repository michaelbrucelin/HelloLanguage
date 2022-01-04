using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Temp_WebApplication_Core_Blazor_Server.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "性别")]
        public Gender Gender { get; set; }
        public bool Fired { get; set; }
    }

    public enum Gender
    {
        女 = 0,
        男 = 1
    }
}
