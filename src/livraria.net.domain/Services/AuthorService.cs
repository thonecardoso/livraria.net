using AutoMapper;
using livraria.net.core.Contracts;
using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        
    }
}
