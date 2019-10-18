using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core.Entity
{
    public class Pager<TEntity> : IPager<TEntity>
    {
        public int Count { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public int MaxPage { get; set; }

        public int NextPage
        {
            get
            {
                int next = Page + 1;
                if (next > MaxPage)
                    next = 0;
                return next;
            }
        }

        public int PrevPage
        {
            get
            {
                int prev = Page - 1;
                if (Page < 1)
                    prev = 0;
                return prev;
            }
        }

        public List<TEntity> Data { get; set; }
    }
}
