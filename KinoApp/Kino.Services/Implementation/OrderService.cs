﻿using Kino.Domain.DomainModels;
using Kino.Repository.Interface;
using Kino.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Services.Implementation
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }

        public  Order GetOrderDetails(BaseEntity model)
        {
            return  orderRepository.GetOrderDetails(model);
        }
    }
}
