using livraria.net.core.Contracts;
using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace livraria.net.domain.Services
{
    public class AuthorService : BaseService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(INotificator notificator, IAuthorRepository repository) : base(notificator)
        {
            _repository = repository;
        }

        public async Task<Author> CreateAsync(Author author)
        {
            return await _repository.Add(author);
        } 

        public async Task<List<Author>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Author> FindByIdAsync(int id)
        {
            var foundAuthor = await _repository.FindById(id);
            if (foundAuthor == null)
            {
                AddNotification("Author not found!");
                return null;
            }

            return foundAuthor;
        }

        public async Task<List<Author>> FindAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task DeleteAsync(int id)
        {
            var foundAuthor = await _repository.FindById(id);
            if (foundAuthor == null)
            {
                AddNotification("Author not found!");
                return;
            }
            await _repository.Delete(foundAuthor);
        }

        public async Task<Author> UpdateAsync(int id, Author author)
        {
            var foundAuthor = await _repository.FindById(id);
            if (foundAuthor == null)
            {
                AddNotification("Author not found!");
                return null;
            }

            foundAuthor.Name = author.Name; 
            foundAuthor.Age = author.Age;

            await _repository.Update(foundAuthor);
            return foundAuthor;
        }
    }
}
