using Flunt.Notifications;

namespace Restaurant.Order.Domain.Core
{
    public abstract class Entity : Notifiable
    {
        public virtual int Id { get; protected set; }
        public Entity()
        {
        }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
