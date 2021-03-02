using System;
using System.Threading.Tasks;
using Restaurant.Order.Domain.Aggregates.NightAggregate;
using Restaurant.Order.Domain.Aggregates.NightAggregate.Interface;
using Restaurant.Order.Infra.Data.Repositories.Base;

namespace Restaurant.Order.Infra.Data.Repositories
{
    public class NightRepository : Repository<Night>, INightRepository
    {
        public NightRepository(Context context) : base(context)
        {
        }
    }
}
