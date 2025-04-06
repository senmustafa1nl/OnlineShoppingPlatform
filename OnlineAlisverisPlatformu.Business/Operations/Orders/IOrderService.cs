using OnlineAlisverisPlatformu.Business.Operations.Orders.Dtos;
using OnlineAlisverisPlatformu.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineAlisverisPlatformu.Business.Types;

namespace OnlineAlisverisPlatformu.Business.Operations.Orders
{
    public interface IOrderService
    {
        Task<ServiceMessage> AddOrder(AddOrderDto order);
        Task<OrderDto> GetOrder(int id);
        Task<List<OrderDto>> GetAllOrders();
        Task<ServiceMessage> DeleteOrder(int id);
        Task<ServiceMessage> UpdateOrder(UpdateOrderDto order);
    }
}
