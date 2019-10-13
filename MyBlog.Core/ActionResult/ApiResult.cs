using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core
{
    public class ApiResult : JsonResult
    {

        public ApiResult(StateCode code, object data = null, string message = null) : base(null)
        {
            Value = new
            {
                Code = (int)code,
                Data = data,
                Message = message
            };
        }

        public ApiResult(int code, object data = null, string message = null) : base(null)
        {
            Value = new 
            {
                Code = code,
                Data = data,
                Message = message
            };
        }
    }
}
