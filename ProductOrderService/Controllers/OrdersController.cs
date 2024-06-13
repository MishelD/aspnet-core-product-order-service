using Microsoft.AspNetCore.Mvc;
using ProductOrderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductOrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static List<Order> orders = new List<Order>();

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(orders);
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.Id = orders.Count > 0 ? orders.Max(o => o.Id) + 1 : 1;
            order.OrderDate = DateTime.Now;
            orders.Add(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            orders.Remove(order);
            return NoContent();
        }
    }
}