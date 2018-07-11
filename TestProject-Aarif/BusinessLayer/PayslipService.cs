using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject_Aarif.Models;

namespace TestProject_Aarif.BusinessLayer
{
    public class PayslipService : TaxSlab
    {
        public PayslipService(int finencialYear) : base(finencialYear) { }
        
        public override PayslipModel GetPayslip(EmployeeModel empModel)
        {
            double grossIncome = GetGrossIncome(empModel.AnnualSalary);
            double incomeTax = GetIncomeTax(empModel.AnnualSalary);

            return new PayslipModel()
            {
                Name = string.Format("{0} {1}", empModel.FirstName, empModel.LastName),
                Period = empModel.Period,
                GrossIncome = Math.Round(grossIncome),
                IncomeTax = Math.Round(incomeTax),
                NetIncome = Math.Round(grossIncome - incomeTax),
                SuperAmount = Math.Round(grossIncome * empModel.Rate / 100)
            };
        }

        private double GetGrossIncome(double annualSalary)
        {
            return (annualSalary / 12);
        }

        private double GetIncomeTax(double annualSalary)
        {
            var slab = SlabModel.Where(m => annualSalary >= m.From && annualSalary <= m.To).ToList().FirstOrDefault();
            var result = ((slab.MinTax) + ((annualSalary - (slab.From-1)) * slab.Rate / 100))/12;

            return result;
        }
    }
}