using Kino.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Services.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderDetails(BaseEntity entity);
    }
}
