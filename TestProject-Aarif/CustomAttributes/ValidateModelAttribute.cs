using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using Newtonsoft.Json;

namespace TestProject_Aarif.CustomAttributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly Func<Dictionary<string, object>, bool> _validate;

        public ValidateModelAttribute() : this(arguments => arguments.ContainsValue(null)) { }

        public ValidateModelAttribute(Func<Dictionary<string, object>, bool> checkCondition)
        {
            _validate = checkCondition;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (_validate(actionContext.ActionArguments))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The argument cannot be null");
            }

            if (!actionContext.ModelState.IsValid)
            {
                var errors = new OutputErrors();

                foreach (var modelStateKey in actionContext.ModelState.Keys)
                {
                    var message = new Dictionary<string, string>();
                    var value = actionContext.ModelState[modelStateKey];
                    foreach (var error in value.Errors)
                    {
                        message.Add("field", GetFieldName(modelStateKey));
                        message.Add("message", string.IsNullOrEmpty(error.ErrorMessage) ? error.Exception.Message : error.ErrorMessage);
                    }

                    errors.Details.Add(message);
                }

                errors.Type = "Field Validation";

                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(errors));
            }
        }

        private string GetFieldName(string value)
        {
            if (value.IndexOf(".") > 0)
                return value.Split('.')[1];
            else
                return value;
        }
    }

    internal class OutputErrors
    {
        public OutputErrors()
        {
            Details = new List<Dictionary<string, string>>();
        }
        public String Type { get; set; }
        public List<Dictionary<string, string>> Details { get; set; }
    }
}