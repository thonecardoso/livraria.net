using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using livraria.net.infra.Data;

namespace livraria.net.infra.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApiDbContext db) : base(db)
        {
        }
    }
}
