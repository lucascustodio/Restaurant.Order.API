using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Order.Application.Commands;
using Restaurant.Order.Application.ViewModels;

namespace Restaurant.Order.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<CommandResponse> Add(CreateOrderCommand command);

        Task<IEnumerable<OrderViewModel>> GetAll();
    }
}
