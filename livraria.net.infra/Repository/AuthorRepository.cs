using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using livraria.net.infra.Data;

namespace livraria.net.infra.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        protected AuthorRepository(ApiDbContext db) : base(db)
        {
        }
    }
}
