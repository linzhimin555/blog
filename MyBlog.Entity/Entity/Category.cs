using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entity
{
    public class Category : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }
    }
}
