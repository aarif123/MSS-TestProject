using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject_Aarif.CustomAttributes
{
    public class PositiveNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            long getal;
            if (long.TryParse(value.ToString(), out getal))
            {

                if (getal == 0 || getal > long.MaxValue)
                    return false;

                if (getal > 0)
                    return true;
            }
            return false;

        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("Please enter the value between {0} to {1}", 1, long.MaxValue.ToString());
        }
    }
}