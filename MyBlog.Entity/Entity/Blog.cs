using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entity
{
    public class Blog : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }

        public DateTime AddTime { get; set; }

        public string CategoryId { get; set; }
    }
}
