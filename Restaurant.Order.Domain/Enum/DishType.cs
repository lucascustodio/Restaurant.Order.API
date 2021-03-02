using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Order.Domain.Core;

namespace Restaurant.Order.Domain.Enum
{
    public class DishType : Enumeration
    {
        public static readonly DishType Entree = new DishType(1, "Entrée");
        public static readonly DishType Side = new DishType(2, "Side");
        public static readonly DishType Drink = new DishType(3, "Drink");
        public static readonly DishType Dessert = new DishType(4, "Dessert");
        public static readonly DishType Error = new DishType(5, "Error");

        protected DishType(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<DishType> List()
        {
            return new[] { Entree, Side, Drink, Dessert, Error };
        }

        public static DishType FromId(int id)
        {
            var types = List()
               .SingleOrDefault(s => s.Id == id);

            if (types == null)
                throw new ArgumentException($"Possible values: {String.Join(", ", List().Select(s => s.Id.ToString()))}");

            return types;
        }

        public static DishType FromName(string name)
        {
            var types = List()
               .SingleOrDefault(s => s.Name == name);

            if (types == null)
                throw new ArgumentException($"Possible values: {String.Join(", ", List().Select(s => s.Id.ToString()))}");

            return types;
        }


        public static implicit operator DishType(int id) => FromId(id);

    }
}
