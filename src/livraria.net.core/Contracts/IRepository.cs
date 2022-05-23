using livraria.net.core.Models;
using livraria.net.core.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace livraria.net.core.Contracts
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindById(int id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(IQueryBase query);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<int> SaveChanges();
    }
}
