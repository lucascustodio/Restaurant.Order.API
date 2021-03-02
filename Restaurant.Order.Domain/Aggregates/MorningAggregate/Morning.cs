using Restaurant.Order.Domain.Core;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Domain.Aggregates.MorningAggregate
{
    public class Morning : Entity
    {
        public DishType DishType { get; private set; }
        public string Description { get; private set; }

        public Morning()
        {

        }

        public Morning(DishType dishType, string description)
        {
            DishType = dishType;
            Description = description;
        }
    }
}
