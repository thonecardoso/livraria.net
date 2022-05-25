using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using livraria.net.infra.Data;

namespace livraria.net.infra.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApiDbContext db) : base(db)
        {
        }
    }
}
