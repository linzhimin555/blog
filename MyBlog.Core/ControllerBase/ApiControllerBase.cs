using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core
{
    [ApiExceptionFilter]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// 返回ApiResult
        /// </summary>
        /// <param name="code">错误代码</param>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ApiResult ApiResult(StateCode code, object data = null, string message = null)
        {
            return new ApiResult(code, data, message);
        }

        /// <summary>
        /// 返回ApiResult
        /// </summary>
        /// <param name="code">自定义错误代码</param>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ApiResult ApiResult(int code, object data = null, string message = null)
        {
            return new ApiResult(code, data, message);
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        protected virtual ApiResult Success(object data, string message)
        {
            return new ApiResult(StateCode.Success, data, message);
        }


        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="code">自定义错误代码</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ApiResult Fail(int code, string message)
        {
            return ApiResult(code, message: message);
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        protected virtual ApiResult Fail(string message)
        {
            return ApiResult(StateCode.Fail, message: message);
        }
    }
}
