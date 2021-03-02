using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Order.Domain.Core;

namespace Restaurant.Order.Domain.Enum
{
    public class FoodMorningType : Enumeration
    {
        public static readonly FoodMorningType Eggs = new FoodMorningType(1, "Eggs");
        public static readonly FoodMorningType Toast = new FoodMorningType(2, "Toast");
        public static readonly FoodMorningType Coffee = new FoodMorningType(3, "Coffee");
        public static readonly FoodMorningType Error = new FoodMorningType(4, "Error");

        protected FoodMorningType(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<FoodMorningType> List()
        {
            return new[] { Eggs, Toast, Coffee, Error };
        }

        public static FoodMorningType FromId(int id)
        {
            var types = List()
               .SingleOrDefault(s => s.Id == id);

            if (types == null)
                throw new ArgumentException($"Possible values: {String.Join(", ", List().Select(s => s.Id.ToString()))}");

            return types;
        }

        public static implicit operator FoodMorningType(int id) => FromId(id);
    }
}
