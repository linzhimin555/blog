using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Core.Mapping;
using MyBlog.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.UnitOfWork.MyMapping
{
    public class UserMapping : IEntityDbTypeMap<User>
    {
        public void EntityDbTypeMapping(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(o => o.Id);
            builder.ToTable("User");
        }
    }
}
