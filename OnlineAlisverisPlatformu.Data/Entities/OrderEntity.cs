using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisPlatformu.Data.Entities
{
   public class OrderEntity : BaseEntity
    {
        public DateTime OrderDate{ get; set; }
        public decimal TotalAmount { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        


        public UserEntity User { get; set; }
        public ICollection<OrderProductEntity> OrderProducts { get; set; }


    }
    public class  OrderConfiguration : BaseConfugiration<OrderEntity>
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
           builder.Property(x => x.OrderDate ).IsRequired();
            base.Configure(builder);
        }
    }
}
