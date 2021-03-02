using Restaurant.Order.Domain.Core;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Domain.Aggregates.NightAggregate
{
    public class Night : Entity
    {
        public DishType DishType { get; private set; }
        public string Description { get; private set; }

        public Night()
        {

        }

        public Night(DishType dishType, string description)
        {
            DishType = dishType;
            Description = description;
        }
    }
}
