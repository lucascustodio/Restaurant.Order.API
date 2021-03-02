using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Order.Application.Services.Interfaces;
using Restaurant.Order.Domain.Aggregates.NightAggregate;
using Restaurant.Order.Domain.Aggregates.NightAggregate.Interface;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Application.Services
{
    public class NightService : INightService
    {
        private readonly INightRepository _nightRepository;

        protected NightService()
        {

        }

        public NightService(INightRepository nightRepository)
        {
            _nightRepository = nightRepository;
        }

        public async Task<string> Add(IEnumerable<int> dishes)
        {
            var nights = await BuildListNight(dishes);

            nights.Select(x => _nightRepository.AddAsync(x));

            await _nightRepository.SaveChanges();

            return BuildString(nights);
        }

        private static string BuildString(List<Night> nights)
        {
            var result = string.Join(",", nights.OrderBy(x => x.DishType.Id).Distinct().Select(x => x.Description));
            return ReplaceCountOrder(nights, result);
        }

        private static string ReplaceCountOrder(List<Night> nights, string result)
        {
            var count = nights.Count(x => x.DishType == DishType.Side);
            if (count > 1)
            {
                var description = nights.FirstOrDefault(x => x.DishType == DishType.Side).Description;
                return result.Replace(description, $"{description}(x{count})");
            }
            return result;
        }

        private async Task<List<Night>> BuildListNight(IEnumerable<int> dishes)
        {
            var stringb = string.Empty;

            var result = new List<Night>();

            var foods = await _nightRepository.GetAll();
            var error = foods.FirstOrDefault(x => x.Description == "Error");

            foreach (var dish in dishes)
            {
                var choose = foods.FirstOrDefault(x => x.DishType.Id == dish);
                if (choose is null)
                {
                    result.Add(error);
                    break;
                }

                if (result.Any(x => x.DishType.Id == dish))
                {
                    if (!CanRepeate(dish))
                    {
                        result.Add(error);
                        break;
                    }
                }
                result.Add(choose);
            }
            return result;
        }

        private static bool CanRepeate(DishType dishType)
        {
            return DishType.Side == dishType;
        }

    }
}
