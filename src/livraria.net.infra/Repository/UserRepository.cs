using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using livraria.net.infra.Data;

namespace livraria.net.infra.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApiDbContext db) : base(db)
        {
        }
    }
}
