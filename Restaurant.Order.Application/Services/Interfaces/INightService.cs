using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Order.Application.Services.Interfaces
{
    public interface INightService
    {
        Task<string> Add(IEnumerable<int> dishes);
    }
}
