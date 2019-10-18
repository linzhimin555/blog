using MyBlog.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public interface ICategoryService
    {
        void Test();

        Task<List<CategoryDto>> GetCategoryList();
    }
}
