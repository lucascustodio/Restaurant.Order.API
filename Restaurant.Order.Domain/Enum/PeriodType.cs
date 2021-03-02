using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurant.Order.Domain.Core;

namespace Restaurant.Order.Domain.Enum
{
    public class PeriodType : Enumeration
    {
        public static readonly PeriodType Morning = new PeriodType(1, "Morning");
        public static readonly PeriodType Night = new PeriodType(2, "Night");

        protected PeriodType(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<PeriodType> List()
        {
            return new[] { Morning, Night };
        }

        public static PeriodType FromId(int id)
        {
            var types = List()
               .SingleOrDefault(s => s.Id == id);

            if (types == null)
                throw new ArgumentException($"Possible values: {String.Join(", ", List().Select(s => s.Id.ToString()))}");

            return types;
        }

        public static PeriodType FromName(string name)
        {
            var types = List()
               .SingleOrDefault(s => s.Name.ToLower() == name.ToLower());

            if (types == null)
                throw new ArgumentException($"Possible values: {String.Join(", ", List().Select(s => s.Id.ToString()))}");

            return types;
        }

        public static bool IsValidByName(string name)
        {
            var types = List()
               .SingleOrDefault(s => s.Name.ToLower() == name.ToLower());

            if (types == null)
                return false;

            return true;
        }


        public bool IsMorning() => Id == PeriodType.Morning.Id;
        public bool IsNight() => Id == PeriodType.Night.Id;
    }
}
