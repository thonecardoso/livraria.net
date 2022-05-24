using System;

namespace livraria.net.core.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; }


        public Entity()
        {
            CreatedAt = DateTime.Now;
        }

        public Entity(int id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }
    }
}
