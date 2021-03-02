using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Order.Domain.Interfaces;

namespace Restaurant.Order.Infra.Data.Model.Denormalized.Interface
{
    public interface IOrderDenormalizedRepository : IRepository<OrderDenormalized>
    {
    }
}
