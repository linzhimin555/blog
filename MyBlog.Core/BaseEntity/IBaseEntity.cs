using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core
{
    public interface IBaseEntity<Tkey> : IBaseEntity
    {
        Tkey Id { get; set; }
    }

    public interface IBaseEntity
    {

    }
}
