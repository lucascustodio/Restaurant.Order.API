using Restaurant.Order.Infra.Data.Model.Denormalized;
using Restaurant.Order.Infra.Data.Model.Denormalized.Interface;
using Restaurant.Order.Infra.Data.Repositories.Base;

namespace Restaurant.Order.Infra.Data.Repositories
{
    public class MenuDenormalizedRepository : Repository<OrderDenormalized>, IOrderDenormalizedRepository
    {
        public MenuDenormalizedRepository(Context context) : base(context)
        {
        }
    }
}
