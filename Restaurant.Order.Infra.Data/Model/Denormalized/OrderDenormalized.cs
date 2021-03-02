using Flunt.Validations;
using Restaurant.Order.Domain.Core;

namespace Restaurant.Order.Infra.Data.Model.Denormalized
{
    public class OrderDenormalized : Entity
    {
        public Domain.Aggregates.OrderAggregate.Order Order { get; private set; }
        public string Dishes { get; private set; }

        public OrderDenormalized()
        {

        }

        public OrderDenormalized(Domain.Aggregates.OrderAggregate.Order menu, string dishes)
        {
            SetMenuId(menu);
            SetDishes(dishes);
        }

        public void SetMenuId(Domain.Aggregates.OrderAggregate.Order order)
        {
            AddNotifications(new Contract().IsNotNull(order, "Order", "Order Id is required"));

            if (Invalid)
                return;

            Order = order;
        }

        public void SetDishes(string dishes)
        {
            AddNotifications(new Contract().IsNotNullOrEmpty(dishes, nameof(Dishes), "Dishes are required"));

            if (Invalid)
                return;

            Dishes = dishes;
        }

    }
}
