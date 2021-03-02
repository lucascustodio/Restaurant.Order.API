using Restaurant.Order.Infra.Validator;

namespace Restaurant.Order.Application.Commands
{
    public class CreateOrderCommand : Command
    {
        public string Input { get; set; }
    }
}
