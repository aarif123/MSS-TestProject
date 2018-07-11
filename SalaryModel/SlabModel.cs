using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryModel
{
    public class SlabModel
    {
        public int From { get; set; }
        public int To { get; set; }
        public int MinTax { get; set; }
        public double Rate { get; set; }
    }
}