using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Core.Mapping
{
    public interface IEntityDbTypeMap<TEntity> : IDbTypeMap where TEntity : class, IBaseEntity
    {
        void EntityDbTypeMapping(EntityTypeBuilder<TEntity> builder);
    }
}
