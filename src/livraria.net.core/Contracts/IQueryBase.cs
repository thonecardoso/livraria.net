using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;

namespace livraria.net.core.Query
{
    public interface IQueryBase : ICustomQueryable, IQueryPaging, IQuerySort
    {
    }
}
