using livraria.net.core.Models;
using System.Collections.Generic;

namespace livraria.net.domain.Models
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Book> Books { get; set; }
    }
}
