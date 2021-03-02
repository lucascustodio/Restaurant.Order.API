using System.Threading.Tasks;
using Restaurant.Order.Domain.Interfaces;

namespace Restaurant.Order.Domain.Aggregates.MorningAggregate.Interface
{
    public interface IMorningRepository : IRepository<Morning>
    {
    }
}
