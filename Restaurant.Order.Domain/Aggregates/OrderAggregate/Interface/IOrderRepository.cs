using Restaurant.Order.Domain.Interfaces;

namespace Restaurant.Order.Domain.Aggregates.OrderAggregate.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
