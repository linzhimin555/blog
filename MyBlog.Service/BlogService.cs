using MyBlog.Core;
using MyBlog.Entity;
using System;
using System.Linq;

namespace MyBlog.Service
{
    public class BlogService : ServiceBase, IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
