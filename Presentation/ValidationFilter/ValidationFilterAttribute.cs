using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ValidationFilter
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var Action = context.RouteData.Values["action"];
            var Controller =context.RouteData.Values["controller"];
            var Parm = context.ActionArguments.SingleOrDefault(A => A.Value.ToString().Contains("Dto")).Value;

            if(Parm is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null in Action {Action} inside Controller {Controller}");
                return;
            }

            if(!context.ModelState.IsValid) 
                context.Result=new UnprocessableEntityObjectResult(context.ModelState);
        }
    }
}
