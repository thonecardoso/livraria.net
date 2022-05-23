using livraria.net.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livraria.net.domain.Models
{
    public class Publisher : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime FundationDate { get; set; }
        public IEnumerable<Book> books { get; set; }
    }
}
