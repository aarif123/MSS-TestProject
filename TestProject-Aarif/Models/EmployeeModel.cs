using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestProject_Aarif.CustomAttributes;

namespace TestProject_Aarif.Models
{
    public class EmployeeModel
    {
        [Required]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [PositiveNumber]
        public double AnnualSalary { get; set; }

        [Range(0, 12)]
        public int Rate { get; set; }

        public string Period { get; set; }
    }
}