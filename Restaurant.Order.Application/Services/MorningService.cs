using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant.Order.Application.Services.Interfaces;
using Restaurant.Order.Domain.Aggregates.MorningAggregate;
using Restaurant.Order.Domain.Aggregates.MorningAggregate.Interface;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Application.Services
{
    public class MorningService : IMorningService
    {
        private readonly IMorningRepository _morningRepository;

        protected MorningService()
        {

        }

        public MorningService(IMorningRepository morningRepository)
        {
            _morningRepository = morningRepository;
        }

        public async Task<string> Add(IEnumerable<int> dishes)
        {
            var mornings = await BuildListMorning(dishes);

            mornings.Select(x => _morningRepository.AddAsync(x));

            await _morningRepository.SaveChanges();

            return BuildString(mornings);
        }

        private static string BuildString(List<Morning> nights)
        {
            var result = string.Join(",", nights.OrderBy(x => x.DishType.Id).Distinct().Select(x => x.Description));
            return ReplaceCountOrder(nights, result);
        }

        private static string ReplaceCountOrder(List<Morning> nights, string result)
        {
            var count = nights.Count(x => x.DishType == DishType.Drink);
            if (count > 1)
            {
                var description = nights.FirstOrDefault(x => x.DishType == DishType.Drink).Description;
                return result.Replace(description, $"{description}(x{count})");
            }
            return result;
        }

        private async Task<List<Morning>> BuildListMorning(IEnumerable<int> dishes)
        {
            var stringb = string.Empty;
            var result = new List<Morning>();
            var foods = await _morningRepository.GetAll();
            var error = foods.FirstOrDefault(x => x.Description == "Error");

            foreach (var dish in dishes)
            {
                var choose = foods.FirstOrDefault(x => x.DishType.Id == dish);
                if (choose is null)
                {
                    result.Add(error);
                    break;
                }

                if (choose.DishType == DishType.Dessert)
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
            return DishType.Drink == dishType;
        }

    }
}
