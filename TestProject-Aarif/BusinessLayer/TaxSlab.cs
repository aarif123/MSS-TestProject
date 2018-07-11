using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject_Aarif.Models;

namespace TestProject_Aarif.BusinessLayer
{
    public abstract class TaxSlab
    {
        private int FinencialYear;
        public IList<SlabModel> SlabModel;

        public TaxSlab(int year)
        {
            this.FinencialYear = year;
            this.SlabModel = LoadSlabModel();
        }

        public abstract PayslipModel GetPayslip(EmployeeModel empModel);

        private IList<SlabModel> LoadSlabModel()
        {
            var slabs = AvailableSlab();
            return slabs.Where(m => m.Year == this.FinencialYear).FirstOrDefault().SlabModel;
        }

        private IList<SlabTable> AvailableSlab()
        {
            // Add slabs

            return new List<SlabTable>()
            {
                new SlabTable()
                {
                    Year = 2018,
                    SlabModel = new List<SlabModel>()
                    {
                        new SlabModel(){ From = 0, To = 18200, MinTax = 0, Rate = 0},
                        new SlabModel(){ From = 18201, To = 37000, MinTax = 0, Rate = 19},
                        new SlabModel(){ From = 37001, To = 87000, MinTax = 3572, Rate = 32.5},
                        new SlabModel(){ From = 87001, To = 180000, MinTax = 19822, Rate = 37},
                        new SlabModel(){ From = 180001, To = long.MaxValue, MinTax = 54232, Rate = 45}
                    }
                }
            };
        }
    }

    internal class SlabTable
    {
        public int Year { get; set; }
        public IList<SlabModel> SlabModel { get; set; }
    }
}