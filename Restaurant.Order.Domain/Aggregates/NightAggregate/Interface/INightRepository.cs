using System.Threading.Tasks;
using Restaurant.Order.Domain.Interfaces;

namespace Restaurant.Order.Domain.Aggregates.NightAggregate.Interface
{
    public interface INightRepository : IRepository<Night>
    {
        Task<Night> GetError();
    }
}
