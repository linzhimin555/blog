using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entity
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }
    }
}
