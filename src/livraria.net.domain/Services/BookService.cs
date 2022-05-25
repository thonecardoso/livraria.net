using livraria.net.core.Contracts;
using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace livraria.net.domain.Services
{
    public class BookService : BaseService
    {
        private readonly IBookRepository _repository;
        public BookService(INotificator notificator, IBookRepository repository) : base(notificator)
        {
            _repository = repository;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            return await _repository.Add(book);
        } 

        public async Task<List<Book>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Book> FindByIdAsync(int id)
        {
            var foundBook = await _repository.FindById(id);
            if (foundBook == null)
            {
                AddNotification("Book not found!");
                return null;
            }

            return foundBook;
        }

        public async Task<List<Book>> FindAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task DeleteAsync(int id)
        {
            var foundBook = await _repository.FindById(id);
            if (foundBook == null)
            {
                AddNotification("Book not found!");
                return;
            }
            await _repository.Delete(foundBook);
        }

        public async void UpdateAsync(int id, Book book)
        {
            var foundBook = await _repository.FindById(id);
            if (foundBook == null)
            {
                AddNotification("Book not found!");
                return;
            }

            foundBook.Name = book.Name; 
            foundBook.Isbn = book.Isbn;
            foundBook.Chapters = book.Chapters;
            foundBook.Pages = book.Pages;
            foundBook.AuthorId = book.AuthorId;
            foundBook.PublisherId = book.PublisherId;
            
            await _repository.Update(foundBook);
        }
    }
}
