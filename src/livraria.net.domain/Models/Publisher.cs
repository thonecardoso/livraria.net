using livraria.net.core.Models;
using System;
using System.Collections.Generic;

namespace livraria.net.domain.Models
{
    public class Publisher : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime FundationDate { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
