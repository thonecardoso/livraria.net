using livraria.net.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livraria.net.domain.Models
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public IEnumerable<Book> books { get; set; }
    }
}
