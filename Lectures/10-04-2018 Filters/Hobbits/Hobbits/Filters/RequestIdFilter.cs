using Hobbits.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hobbits.Filters
{
    public class RequestIdFilter : IActionFilter
    {
        private IRequestIdGenerator requestIdGenerator;

        public RequestIdFilter(IRequestIdGenerator requestIdGenerator)
        {
            this.requestIdGenerator = requestIdGenerator;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("request-id", this.requestIdGenerator.RequestId);
        }
    }
}
