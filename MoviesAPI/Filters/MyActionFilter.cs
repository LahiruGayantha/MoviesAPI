using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Filters
{
    public class MyActionFilter:IActionFilter
    {
        private readonly ILogger<MyActionFilter> Logger;

        public MyActionFilter(ILogger<MyActionFilter> logger)
        {
            this.Logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogWarning("On Action executing");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogWarning("On Action executed");
        }
    }
}
