using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineAlisverisPlatformu.Data.Entities;


namespace OnlineAlisverisPlatformu.Data.Context
{
   public class OSPContext : DbContext
    {
        public OSPContext(DbContextOptions<OSPContext>options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
            modelBuilder.Entity<SettingEntity>().HasData(new SettingEntity
            {
                Id = 1,
                MaintenanceMode = false
            });




            base.OnModelCreating(modelBuilder);
        }


        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderProductEntity> OrderProducts { get; set; }
        public DbSet<SettingEntity> Settings { get; set; }

    }
}
