using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisPlatformu.Data.Entities
{
   public class OrderProductEntity : BaseEntity
    {
        public int OrderId { get; set; }
        
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }

        public OrderEntity  Order { get; set; }
        public ProductEntity Product { get; set; }

       

    }
    public class OrderProductConfiguration : BaseConfugiration<OrderProductEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.Ignore(x=> x.Id);
            builder.HasKey("OrderId","ProductId");
            base.Configure(builder);
        }
    }
}
