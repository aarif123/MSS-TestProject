using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryModel
{
    public class PayslipModel
    {
        public string Name { get; set; }
        public string Period { get; set; }
        public double GrossIncome { get; set; }
        public double IncomeTax { get; set; }
        public double NetIncome { get; set; }
        public double SuperAmount { get; set; }
    }
}