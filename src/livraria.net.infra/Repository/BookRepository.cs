using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using livraria.net.infra.Data;

namespace livraria.net.infra.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApiDbContext db) : base(db)
        {
        }
    }
}
