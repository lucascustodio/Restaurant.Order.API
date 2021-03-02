using System.Collections.Generic;
using System.Linq;
using Moq;
using Restaurant.Order.Application.Services;
using Restaurant.Order.Domain.Aggregates.MorningAggregate;
using Restaurant.Order.Domain.Aggregates.MorningAggregate.Interface;
using Restaurant.Order.Domain.Enum;
using Xunit;

namespace Restaurant.Order.Test.Application
{
    public class MorningServiceTest
    {

        private readonly Mock<IMorningRepository> _morningRepository;
        private readonly MorningService _morningService;

        public MorningServiceTest()
        {
            _morningRepository = new Mock<IMorningRepository>();

            _morningRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Morning>()
            {
                new Morning(DishType.Entree, "Eggs"),
                new Morning(DishType.Side, "Toast"),
                new Morning(DishType.Drink,"Coffee"),
                new Morning(DishType.Dessert,"Error"),
                new Morning(DishType.Error,"Error")
            });

            _morningService = new MorningService(_morningRepository.Object);
        }



        [Theory]
        [InlineData("1,2,3")]
        [InlineData("2,1,3")]

        public async void CreateMorningOrder_WithEggsToastCoffe(string dishTypeIds)
        {
            var result = await _morningService.Add(dishTypeIds.Split(",").Select(x => int.Parse(x)));
            Assert.Equal("Eggs,Toast,Coffee", result);
        }

        [Theory]
        [InlineData("1,2,3,4")]
        [InlineData("3,2,1,4")]

        public async void CreateMorningMenuOrder_WithError(string dishTypeIds)
        {
            var result = await _morningService.Add(dishTypeIds.Split(",").Select(x => int.Parse(x)));

            Assert.Equal("Eggs,Toast,Coffee,Error", result);
        }

        [Theory]
        [InlineData("1,2,3,3,3")]
        [InlineData("1,3,2,3,3")]

        public async void CreateMorningMenuOrder_ManyCoffee(string dishTypeIds)
        {
            var result = await _morningService.Add(dishTypeIds.Split(",").Select(x => int.Parse(x)));
            Assert.Equal("Eggs,Toast,Coffee(x3)", result);
        }
    }
}
