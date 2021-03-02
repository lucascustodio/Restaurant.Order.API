using System.Collections.Generic;
using System.Linq;
using Moq;
using Restaurant.Order.Application.Services;
using Restaurant.Order.Domain.Aggregates.NightAggregate;
using Restaurant.Order.Domain.Aggregates.NightAggregate.Interface;
using Restaurant.Order.Domain.Enum;
using Xunit;

namespace Restaurant.Order.Test.Application
{

    public class NightServiceTest
    {
        private readonly Mock<INightRepository> _nightRepository;
        private readonly NightService _nightService;

        public NightServiceTest()
        {
            _nightRepository = new Mock<INightRepository>();

            _nightRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Night>()
            {
                new Night(DishType.Entree, "Steak"),
                new Night(DishType.Side,"Potato"),
                new Night(DishType.Drink, "Wine"),
                new Night(DishType.Dessert, "Cake"),
                new Night(DishType.Dessert, "Error")
            });

            _nightService = new NightService(_nightRepository.Object);
        }


        [Theory]
        [InlineData("1, 2, 3, 4")]
        [InlineData("4, 2, 3, 1")]
        public async void CreateNightOrder_WithSteakPotatoWineCake(string dishTypeIds)
        {            
            var result = await _nightService.Add(dishTypeIds.Split(",").Select(x => int.Parse(x)));
            Assert.Equal("Steak,Potato,Wine,Cake", result);
        }

        [Theory]
        [InlineData("1,2,2,4")]
        [InlineData("2,2,4,1")]

        public async void CreateNightMenuOrder_WithManyPotato(string dishTypeIds)
        {
            var result = await _nightService.Add(dishTypeIds.Split(",").Select(x => int.Parse(x)));
            Assert.Equal("Steak,Potato(x2),Cake", result);
        }

        [Theory]
        [InlineData("1,2,3,5")]
        [InlineData("3,2,1,5")]

        public async void CreateNightMenuOrder_WithError(string dishTypeIds)
        {
            var result = await _nightService.Add(dishTypeIds.Split(",").Select(x => int.Parse(x)));
            Assert.Equal("Steak,Potato,Wine,Error", result);
        }

        [Theory]
        [InlineData("1,1,2,3,4")]
        public async void CreateNightMenuOrder_WithErrorManyOtherFoods(string dishTypeIds)
        {
            var result = await _nightService.Add(dishTypeIds.Split(",").Select(x => int.Parse(x)));
            Assert.Equal("Steak,Error", result);
        }
    }
}
