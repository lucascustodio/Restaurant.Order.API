using Restaurant.Order.Domain.Aggregates.OrderAggregate.Interface;
using Restaurant.Order.Infra.Data.Repositories.Base;

namespace Restaurant.Order.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Domain.Aggregates.OrderAggregate.Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context)
        {
        }
    }
}
