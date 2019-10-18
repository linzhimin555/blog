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
using MyBlog.Core.Encrypt;
using MyBlog.Entity;
using MyBlog.Service;

namespace MyBlog.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class UserController : ApiControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IJwtProvider _jwtProvider;

        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jwtProvider"></param>
        /// <param name="userService"></param>
        public UserController(ILogger<UserController> logger, IJwtProvider jwtProvider, IUserService userService)
        {
            _logger = logger;
            _jwtProvider = jwtProvider;
            _userService = userService;
        }

        /// <summary>
        /// 登陆 获取token
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserLoginRequest userLogin)
        {
            var result =  await _userService.UserLoginAsync(userLogin.UserName, userLogin.Password);
            if (result.success)
            {
                var token = _jwtProvider.CreateJwtToken(new TokenModel { Uid = result.user.Id.ToString(), UserName = result.user.UserName });
                //return new JsonResult("");
            }
            return new JsonResult("");
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userRegister"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterRequest userRegister)
        {
            userRegister.Id = Guid.NewGuid();
            userRegister.Password = EncryptHelper.Md5_32(userRegister.Password);
            var success = await _userService.UserRegisterAsync(userRegister);
            return new JsonResult(success);
        }

        /// <summary>
        /// 这是个测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("SetToken")]
        public ActionResult GetToken()
        {
            //_categoryService.Test();
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
