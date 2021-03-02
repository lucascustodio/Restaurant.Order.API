using Flunt.Notifications;
using Newtonsoft.Json;

namespace Restaurant.Order.Domain.Core
{
    public abstract class Enumeration : Notifiable
    {
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public int Id { get; private set; }

        protected Enumeration() { }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
