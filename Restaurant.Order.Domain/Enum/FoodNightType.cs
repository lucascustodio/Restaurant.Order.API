using System;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Order.Domain.Core;

namespace Restaurant.Order.Domain.Enum
{
    public class FoodNightType : Enumeration
    {
        public static readonly FoodNightType Steak = new FoodNightType(1, "Steak");
        public static readonly FoodNightType Potato = new FoodNightType(2, "Potato");
        public static readonly FoodNightType Wine = new FoodNightType(3, "Wine");
        public static readonly FoodNightType Cake = new FoodNightType(4, "Cake");

        protected FoodNightType(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<FoodNightType> List()
        {
            return new[] { Steak, Potato, Wine, Cake };
        }

        public static FoodNightType FromId(int id)
        {
            var types = List()
               .SingleOrDefault(s => s.Id == id);

            if (types == null)
                throw new ArgumentException($"Possible values: {String.Join(", ", List().Select(s => s.Id.ToString()))}");

            return types;
        }

        public static implicit operator FoodNightType(int id) => FromId(id);
    }
}
