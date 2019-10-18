using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyBlog.Core;
using System;

namespace MyBlog.UnitOfWork
{
    public class MyUnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        public MyUnitOfWork(DbContextOptions<MyUnitOfWork> options, IHttpContextAccessor accessor) : base(options, accessor)
        {
        }


        protected override bool MapTypeFilter(Type type)
        {
            return type.FullName.StartsWith("MyBlog.UnitOfWork.MyMapping");
        }

    }
}
