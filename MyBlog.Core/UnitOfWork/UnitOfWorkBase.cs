using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core
{
    public class UnitOfWorkBase : DbContext, IUnitOfWork
    {
        private readonly Dictionary<Type, IRepository> _repositories;

        public UnitOfWorkBase(DbContextOptions options) : base(options)
        {

        }

        public virtual int Commit()
        {
            return SaveChanges();
        }

        public virtual async Task<int> CommitAsync()
        {
            return await SaveChangesAsync();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                var repo = new Repository<TEntity>(this);
                _repositories[type] = repo;
                return repo;
            }
            return _repositories[type] as IRepository<TEntity>;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity.

            //builder.HasKey(o => o.Id);
            //builder.Property(o => o.DiscountAmount).HasColumnType("decimal(18, 0)");
            //builder.Property(o => o.ConditionAmount).HasColumnType("decimal(18, 0)");
            //builder.Property(o => o.Id).HasColumnName("ADItemID");
            //builder.HasOne(o => o.ActivitySeller).WithMany(o => o.AdItems).HasForeignKey(o => o.ASID);
            //builder.HasMany(o => o.ActivityDetailItemStorages).WithOne(o => o.ActivityDetailItem).HasForeignKey(o => o.ADItemID);
            //builder.HasMany(o => o.CouponProducts).WithOne().HasForeignKey(o => o.CouponId);
            //builder.HasMany(o => o.CouponCitys).WithOne().HasForeignKey(o => o.CouponId);
            //builder.ToTable("tblActivityDetailItem");
        }

    }
}
