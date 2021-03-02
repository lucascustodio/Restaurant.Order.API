using System.Collections.Generic;
using System.Linq;
using Restaurant.Order.Domain.Aggregates.MorningAggregate;
using Restaurant.Order.Domain.Aggregates.NightAggregate;
using Restaurant.Order.Domain.Enum;

namespace Restaurant.Order.Infra.Data
{
    public class Seeder
    {
        Context _context;

        public Seeder(Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            SeedMorning();
            SeedNight();
        }

        private void SeedMorning()
        {
            List<Morning> mornings = new List<Morning>()
            {
                new Morning(DishType.Entree, "Eggs"),
                new Morning(DishType.Side, "Toast"),
                new Morning(DishType.Drink,"Coffee"),
                new Morning(DishType.Dessert,"Error"),
                new Morning(DishType.Error,"Error")
            };

            var hasFoods = _context.Mornings.Any();

            if (!hasFoods)
                _context.Mornings.AddRange(mornings);
        }

        private void SeedNight()
        {
            List<Night> nights = new List<Night>()
            {
                new Night(DishType.Entree, "Steak"),
                new Night(DishType.Side,"Potato"),
                new Night(DishType.Drink, "Wine"),
                new Night(DishType.Dessert, "Cake"),
                new Night(DishType.Dessert, "Error")
            };

            var hasFoods = _context.Nights.Any();

            if (!hasFoods)
                _context.Nights.AddRange(nights);
        }
    }
}
