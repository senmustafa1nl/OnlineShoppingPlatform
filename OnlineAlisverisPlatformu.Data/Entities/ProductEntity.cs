using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisPlatformu.Data.Entities
{
  public  class ProductEntity : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        

        public ICollection<OrderProductEntity> OrderProducts { get; set; }
    }
    public class ProductConfiguration : BaseConfugiration<ProductEntity>
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.StockQuantity).IsRequired();
            base.Configure(builder);
        }
    }
}
