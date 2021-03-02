using Restaurant.Order.Domain.Core;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Domain.Aggregates.OrderAggregate
{
    public class Order : Entity
    {
        public PeriodType PeriodType { get; private set; }

        public string DishTypes { get; private set; }

        public Order()
        {
        }

        public Order(PeriodType periodType, string dishTypes)
        {
            PeriodType = periodType;
            SetDishTypes(dishTypes);
        }

        public void SetDishTypes(string dishTypes)
        {
            DishTypes = dishTypes;
        }
    }
}
