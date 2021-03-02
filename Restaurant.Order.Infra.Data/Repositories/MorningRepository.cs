using System;
using System.Threading.Tasks;
using Restaurant.Order.Domain.Aggregates.MorningAggregate;
using Restaurant.Order.Domain.Aggregates.MorningAggregate.Interface;
using Restaurant.Order.Domain.Aggregates.NightAggregate;
using Restaurant.Order.Domain.Aggregates.NightAggregate.Interface;
using Restaurant.Order.Infra.Data.Repositories.Base;

namespace Restaurant.Order.Infra.Data.Repositories
{
    public class MorningRepository : Repository<Morning>, IMorningRepository
    {
        public MorningRepository(Context context) : base(context)
        {
        }
    }
}
