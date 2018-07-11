using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryModel
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AnnualSalary { get; set; }
        public int Rate { get; set; }
        public string Period { get; set; }
    }
}