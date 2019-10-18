using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core;
using MyBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRepository<Category> _repository;

        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Category>();
            _mapper = mapper;
        }

        public void Test()
        {
            var ss = _unitOfWork.GetRepository<Category>().AsQueryable().ToList();
        }

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryDto>> GetCategoryList()
        {
            var categorys = await _repository.AsQueryable().AsNoTracking().ToListAsync();
            return _mapper.Map<List<CategoryDto>>(categorys);
        }
    }
}
