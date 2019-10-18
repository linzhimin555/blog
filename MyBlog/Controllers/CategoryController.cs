using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Common.Jwt;
using MyBlog.Core;
using MyBlog.Core.Entity;
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
    public class CategoryController : ApiControllerBase
    {
        private readonly ILogger<CategoryController> _logger;

        private readonly ICategoryService _categoryService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jwtProvider"></param>
        /// <param name="categoryService"></param>
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        /// <summary>
        /// 这是个测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetCategoryList()
        {
            var list = await _categoryService.GetCategoryList();
            return new JsonResult(list);
        }
    }
}
