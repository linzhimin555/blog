using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common.Jwt;
using MyBlog.Core;

namespace MyBlog.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class WeatherForecastController : ApiControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IJwtProvider _jwtProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IJwtProvider jwtProvider)
        {
            _logger = logger;
            _jwtProvider = jwtProvider;
        }

        //[Authorize]
        /// <summary>
        /// 这是个测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("SetToken")]
        public ActionResult GetToken()
        {
            var uid = "admin";
            var token =  _jwtProvider.CreateJwtToken(new TokenModel { Uid = uid, UserName = "admin" });

            SerializeJwt(token);
            return new JsonResult(token);
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        private void SerializeJwt(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            object role;
            try
            {
                //jwtToken.Payload.TryGetValue(ClaimTypes.Role, out role);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //var tm = new TokenModelJwt
            //{
            //    Uid = (jwtToken.Id).ObjToInt(),
            //    Role = role != null ? role.ObjToString() : "",
            //};
            //return tm;
        }
        /// <summary>
        /// post请求
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetId")]
        [Authorize]
        public ActionResult GetId()
        {
            var id = _jwtProvider.GetUserId();
            return new JsonResult("asfds");
        }
    }
}
