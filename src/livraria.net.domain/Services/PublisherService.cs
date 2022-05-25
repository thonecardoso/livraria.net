using livraria.net.core.Contracts;
using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace livraria.net.domain.Services
{
    public class PublisherService : BaseService
    {
        private readonly IPublisherRepository _repository;
        public PublisherService(INotificator notificator, IPublisherRepository repository) : base(notificator)
        {
            _repository = repository;
        }

        public async Task<Publisher> CreateAsync(Publisher publisher)
        {
            return await _repository.Add(publisher);
        } 

        public async Task<List<Publisher>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Publisher> FindByIdAsync(int id)
        {
            var foundPublisher = await _repository.FindById(id);
            if (foundPublisher == null)
            {
                AddNotification("Author not found!");
                return null;
            }

            return foundPublisher;
        }

        public async Task<List<Publisher>> FindAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task DeleteAsync(int id)
        {
            var foundPublisher = await _repository.FindById(id);
            if (foundPublisher == null)
            {
                AddNotification("Publisher not found!");
                return;
            }
            await _repository.Delete(foundPublisher);
        }

        public async void UpdateAsync(int id, Publisher publisher)
        {
            var foundPublisher = await _repository.FindById(id);
            if (foundPublisher == null)
            {
                AddNotification("Publisher not found!");
                return;
            }

            foundPublisher.Name = publisher.Name; 
            foundPublisher.Code = publisher.Code;
            foundPublisher.FundationDate = publisher.FundationDate;

            await _repository.Update(foundPublisher);
        }
    }
}
