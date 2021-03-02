using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Restaurant.Order.Application.Commands;
using Restaurant.Order.Application.Services.Interfaces;
using Restaurant.Order.Application.Validators;
using Restaurant.Order.Application.ViewModels;
using Restaurant.Order.Domain.Aggregates.OrderAggregate.Interface;
using Restaurant.Order.Domain.Enum;
using Restaurant.Order.Infra.Data.Model.Denormalized.Interface;

namespace Restaurant.Order.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICreateOrderCommandValidator _commandValidator;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDenormalizedRepository _orderDenormalizedRepository;

        private readonly IMorningService _morningService;
        private readonly INightService _nightService;


        public OrderService(ICreateOrderCommandValidator commandValidator,
                            IOrderRepository orderRepository,
                            IOrderDenormalizedRepository orderDenormalizedRepository,
                            IMorningService morningService,
                            INightService nightService)
        {
            _commandValidator = commandValidator;
            _orderRepository = orderRepository;
            _orderDenormalizedRepository = orderDenormalizedRepository;
            _morningService = morningService;
            _nightService = nightService;
        }

        public async Task<CommandResponse> Add(CreateOrderCommand command)
        {
            var output = "";

            var validator = _commandValidator.Validate(command);
            PeriodType periodType;

            if (!validator.IsValid)
                return GenerateErrorValidatior(validator);

            periodType = GetPeriodType(command);
            var dishes = GetDishIds(command);

            if (periodType.IsMorning())
                output = await _morningService.Add(dishes);
            else
            if (periodType.IsNight())
                output = await _nightService.Add(dishes);

            var order = await AddOrderRepository(periodType, dishes);

            if (order.Invalid)
                return new CommandResponse(order.Notifications);

            var orderDenormalized = await AddDenormalizedOrderRepository(output, order);
            if (orderDenormalized.Invalid)
                return new CommandResponse(order.Notifications);

            await _orderRepository.SaveChanges();

            return new CommandResponse(order.Notifications);
        }

        private PeriodType GetPeriodType(CreateOrderCommand command)
        {
            PeriodType periodType;
            if (command.Input.ToLower().Split(",")[0].Contains(PeriodType.Morning.Name.ToLower()))
                periodType = PeriodType.Morning;
            else
                periodType = PeriodType.Night;
            return periodType;
        }

        private async Task<Infra.Data.Model.Denormalized.OrderDenormalized> AddDenormalizedOrderRepository(string output, Domain.Aggregates.OrderAggregate.Order order)
        {
            var orderDenormalized = new Infra.Data.Model.Denormalized.OrderDenormalized(order, output);
            await _orderDenormalizedRepository.AddAsync(orderDenormalized);
            return orderDenormalized;
        }

        private async Task<Domain.Aggregates.OrderAggregate.Order> AddOrderRepository(PeriodType periodType, IEnumerable<int> dishes)
        {
            var order = new Domain.Aggregates.OrderAggregate.Order(periodType, dishes.ToString());
            await _orderRepository.AddAsync(order);
            return order;
        }

        private static CommandResponse GenerateErrorValidatior(FluentValidation.Results.ValidationResult validator)
        {
            return new CommandResponse(validator.Errors.Select(x => new Notification(nameof(CreateOrderCommand), x.ErrorMessage)).ToList());
        }

        private static IEnumerable<int> GetDishIds(CreateOrderCommand command)
        {
            return command.Input.Split(",").Skip(1).Select(x => int.Parse(x));
        }

        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            var dishes = await _orderDenormalizedRepository.GetAll();
            return dishes?.Select(x => new OrderViewModel() { Dishes = x.Dishes });
        }
    }
}
