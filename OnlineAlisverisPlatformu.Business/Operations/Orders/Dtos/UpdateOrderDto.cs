using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAlisverisPlatformu.Business.Operations.Orders.Dtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Quentity { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
