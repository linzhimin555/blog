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
using MyBlog.Service;

namespace MyBlog.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class BlogController : ApiControllerBase
    {
        private readonly ILogger<BlogController> _logger;

        private readonly IJwtProvider _jwtProvider;

        private readonly ICategoryService _categoryService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jwtProvider"></param>
        /// <param name="categoryService"></param>
        public BlogController(ILogger<BlogController> logger, IJwtProvider jwtProvider, ICategoryService categoryService)
        {
            _logger = logger;
            _jwtProvider = jwtProvider;
            _categoryService = categoryService;
        }

        /// <summary>
        /// 这是个测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("SetToken")]
        public ActionResult GetToken()
        {
            _categoryService.Test();
            var uid = "admin";
            var token = _jwtProvider.CreateJwtToken(new TokenModel { Uid = uid, UserName = "admin" });

            SerializeJwt(token);
            return new JsonResult(token);
        }

        [Authorize]
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
            return new JsonResult(id);
        }
    }
}
