using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject_Aarif.Controllers;
using TestProject_Aarif.Models;
using Newtonsoft.Json;

namespace TestCases.Tests
{
    [TestClass]
    public class EmployeesTest
    {
        EmployeeController empController;

        //private BadRequestFilter _badRequestFilter;
        //private ActionExecutingContext _context;
        //private HttpContext _httpContext;
        //private RouteData _routeData;

        [TestInitialize]
        public void InitializeTest()
        {
            this.empController = new EmployeeController();

            //_badRequestFilter = new BadRequestFilter();

            //_httpContext = new DefaultHttpContext();
            //_routeData = new RouteData();
            //_actionDescriptor = new ControllerActionDescriptor();
            //var modelState = new ModelStateDictionary();

            //var actionContext = new ActionContext(
            //    _httpContext,
            //    _routeData,
            //    _actionDescriptor,
            //    modelState
            //);

            //_context = new ActionExecutingContext(actionContext, new List<IFilterMetadata>(),
            //    new Dictionary<string, object>(), new object());
        }
        
        #region TaxSlab Tests

        [TestMethod]
        public void PositiveTest_Should_Return_PayslipDetails_For_60050_AnnualSalary()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = 60050,
                Period = "Mar-2018",
                Rate = 9
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();

            var result = this.empController.Post(model);
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            var payslipModel = JsonConvert.DeserializeObject<PayslipModel>(jsonResult);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(922, payslipModel.IncomeTax);
            Assert.AreEqual(5004, payslipModel.GrossIncome);
            Assert.AreEqual(4082, payslipModel.NetIncome);
            Assert.AreEqual(450, payslipModel.SuperAmount);
        }

        [TestMethod]
        public void PositiveTest_Should_Return_PayslipDetails_For_120000_AnnualSalary()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = 120000,
                Period = "Mar-2018",
                Rate = 10
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();

            var result = this.empController.Post(model);
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            var payslipModel = JsonConvert.DeserializeObject<PayslipModel>(jsonResult);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(2669, payslipModel.IncomeTax);
            Assert.AreEqual(10000, payslipModel.GrossIncome);
            Assert.AreEqual(7331, payslipModel.NetIncome);
            Assert.AreEqual(1000, payslipModel.SuperAmount);
        }

        [TestMethod]
        public void PositiveTest_Should_Return_PayslipDetails_For_15000_AnnualSalary()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = 15000,
                Period = "Mar-2018",
                Rate = 10
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();

            var result = this.empController.Post(model);
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            var payslipModel = JsonConvert.DeserializeObject<PayslipModel>(jsonResult);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(0, payslipModel.IncomeTax);
            Assert.AreEqual(1250, payslipModel.GrossIncome);
            Assert.AreEqual(1250, payslipModel.NetIncome);
            Assert.AreEqual(125, payslipModel.SuperAmount);
        }

        [TestMethod]
        public void PositiveTest_Should_Return_PayslipDetails_For_35000_AnnualSalary()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = 35000,
                Period = "Mar-2018",
                Rate = 10
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();

            var result = this.empController.Post(model);
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            var payslipModel = JsonConvert.DeserializeObject<PayslipModel>(jsonResult);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(266, payslipModel.IncomeTax);
            Assert.AreEqual(2917, payslipModel.GrossIncome);
            Assert.AreEqual(2651, payslipModel.NetIncome);
            Assert.AreEqual(292, payslipModel.SuperAmount);
        }

        [TestMethod]
        public void PositiveTest_Should_Return_PayslipDetails_For_200000_AnnualSalary()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = 200000,
                Period = "Mar-2018",
                Rate = 10
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();

            var result = this.empController.Post(model);
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            var payslipModel = JsonConvert.DeserializeObject<PayslipModel>(jsonResult);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(5269, payslipModel.IncomeTax);
            Assert.AreEqual(16667, payslipModel.GrossIncome);
            Assert.AreEqual(11397, payslipModel.NetIncome);
            Assert.AreEqual(1667, payslipModel.SuperAmount);
        }
        
        #endregion

        #region Other Tests
        
        [TestMethod]
        public void Negative_Should_Return_ModelError_For_0_AnnualSalary()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = 0,
                Period = "Mar-2018",
                Rate = 9
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();
            this.empController.Validate(model);

            var result = this.empController.Post(model);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void Negative_Should_Return_ModelError_For_Negative_AnnualSalary()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = -1,
                Period = "Mar-2018",
                Rate = 9
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();
            this.empController.Validate(model);

            var result = this.empController.Post(model);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void Negative_Should_Return_ModelError_For_Negative_SuperRate()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = 500,
                Period = "Mar-2018",
                Rate = -1
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();
            this.empController.Validate(model);

            var result = this.empController.Post(model);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void Negative_Should_Return_ModelError_For_More_Than_Highest_AnnualSalary()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = double.MaxValue,
                Period = "Mar-2018",
                Rate = 9    
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();
            this.empController.Validate(model);

            var result = this.empController.Post(model);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void Negative_Should_Return_ModelError_For_More_Than_Highest_SuperRate()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = 2000,
                Period = "Mar-2018",
                Rate = 13
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();
            this.empController.Validate(model);

            var result = this.empController.Post(model);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }
        
        #endregion
        
        #region CommonValidationCheck Tests

        [TestMethod]
        public void Should_Return_200OK_OnSuccess()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel()
            {
                FirstName = "James",
                LastName = "Michel",
                AnnualSalary = 60050,
                Period = "Mar-2018",
                Rate = 9
            };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();

            var result = this.empController.Post(model);


            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
        }
        
        [TestMethod]
        public void Should_Return_400BadRequest_OnModelInvalid()
        {
            //ExpectedResult
            EmployeeModel model = new EmployeeModel() { };

            // Assign
            this.empController.Request = new System.Net.Http.HttpRequestMessage();
            this.empController.Configuration = new System.Web.Http.HttpConfiguration();
            this.empController.Validate(model);

            var result = this.empController.Post(model);

            // verify
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }
        
        #endregion
        
        [TestCleanup]
        public void ClearTest()
        {
            this.empController = null;
        }
    }
}
