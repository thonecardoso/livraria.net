using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livraria.net.core.Models
{
    public abstract class Entity
    {
        public int Id { get; private set; }
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
