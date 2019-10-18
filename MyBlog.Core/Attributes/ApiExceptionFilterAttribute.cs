using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core
{
    internal class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.ExceptionHandled = true;
                context.Result = new ApiResult(StateCode.Fail, message: "系统繁忙");
            }
        }
    }
}
