using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProject_Aarif.BusinessLayer;
using TestProject_Aarif.CustomAttributes;
using TestProject_Aarif.Models;

namespace TestProject_Aarif.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly PayslipService _payslip;

        private const int FINENCIAL_YEAR = 2018;

        public EmployeeController()
        {
            this._payslip = new PayslipService(FINENCIAL_YEAR);
        }

        [HttpPost]
        [ValidateModel]
        public HttpResponseMessage Post([FromBody] EmployeeModel empModel)
        {   
            try
            {
                if (ModelState.IsValid)
                {
                    var result = this._payslip.GetPayslip(empModel);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
