using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core.Entity
{
    public interface IPager<TEntity> 
    {

        int Count { get; set; }

        int Size { get; set; }

        int Page { get; set; }

        int MaxPage { get; set; }

        int NextPage { get; }

        int PrevPage { get; }

        List<TEntity> Data { get; set; }
    }
}
