using App1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LAB7.Filters
{
    public class CustomFilter : IActionFilter, IExceptionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Disable client-side validation
            context.HttpContext.Response.Headers.Add("X-ClientSide-Validation", "disabled");

            if (context.ActionArguments.TryGetValue("employee", out var employeeObject))
            {
                if (employeeObject is Employee employee)
                {
                    var validationContext = new ValidationContext(employee, serviceProvider: null, items: null);
                    var validationResults = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(employee, validationContext, validationResults, validateAllProperties: true))
                    {
                        foreach (var validationResult in validationResults)
                        {
                            context.ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? string.Empty, validationResult.ErrorMessage);
                        }

                        // Notify the user about validation errors
                        //context.Result = new BadRequestObjectResult(context.ModelState);
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnException(ExceptionContext context)
        {
            // Redirect to a dedicated error page
            context.Result = new ViewResult
            {
                ViewName = "_ErrorPage",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }

}
