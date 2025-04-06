﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAlisverisPlatformu.Business.Operations.Orders;
using OnlineAlisverisPlatformu.Business.Operations.Orders.Dtos;
using OnlineAlisverisPlatformu.WebApi.Models;

namespace OnlineAlisverisPlatformu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

       
            public OrdersController(IOrderService orderService)
            {
                _orderService = orderService;
            }

            [HttpPost]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest data)
            {
                var addOrderDto = new AddOrderDto
                {
                    UserId = data.UserId,
                    Quantity = data.Quantity,
                    ProductIds = data.ProductIds
                };

                var result = await _orderService.AddOrder(addOrderDto);

                if (!result.IsSucceed)
                {
                    return BadRequest(result.Message);
                }
                else
                {
                    return Ok(result.Message);
                }
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetOrder(int id)
            {
                var order = await _orderService.GetOrder(id);

                if (order is null)
                {
                    return NotFound("Böyle bir sipariş bulunamadı");
                }
                else
                {
                    return Ok(order);
                }
            }

            [HttpGet]
            public async Task<IActionResult> GetOrders()
            {
                var orders = await _orderService.GetAllOrders();

                return Ok(orders);
            }

            [HttpDelete("{id}")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> DeleteOrder(int id)
            {
                var result = await _orderService.DeleteOrder(id);

                if (!result.IsSucceed)
                    return NotFound(result.Message);
                else
                    return Ok(result.Message);
            }

            [HttpPut("{id}")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderRequest data)
            {
                var updateOrderDto = new UpdateOrderDto
                {
                    Id = id,
                    CustomerId = data.UserId,
                    Quentity = data.Quantity,
                    ProductIds = data.ProductIds
                };

                var result = await _orderService.UpdateOrder(updateOrderDto);

                if (!result.IsSucceed)
                {
                    return NotFound(result.Message);
                }
                else
                {
                    return Ok(result.Message);
                }
            }

        }

}
   

