using livraria.net.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livraria.net.domain.Models
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string Isbn { get; set; }
        public int Pages { get; set; }
        public int Chapters { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
