using Bazingo_Core.Domain_Logic.Interfaces;
using Bazingo_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateOrder(string userId , CreateOrderDto dto)
        {
            var order = new Order
            {
                BuyerID = userId ,
                TotalAmount = dto.Items.Sum(i => i.Quantity * i.Quantity) ,
                Status = "Pending" ,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Orders.AddAsync(order);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<OrderDto> GetOrderById(int orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null) return null;

            return new OrderDto
            {
                OrderId = order.OrderID ,
                BuyerName = order.Buyer.UserName ,
                TotalAmount = order.TotalAmount ,
                Status = order.Status
            };
        }

        public async Task<bool> CancelOrder(int orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null) return false;

            order.Status = "Canceled";
            _unitOfWork.Orders.Update(order);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}
