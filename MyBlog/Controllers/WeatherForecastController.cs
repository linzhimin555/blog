using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[Authorize]
        /// <summary>
        /// 这是个测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetName")]
        public ActionResult GetName()
        {
            var rng = new Random();
            return new JsonResult("");
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddName")]
        public ActionResult AddName()
        {
            return new JsonResult("asfds");
        }
    }
}
