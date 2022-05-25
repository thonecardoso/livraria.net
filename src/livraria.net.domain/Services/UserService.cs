using livraria.net.core.Contracts;
using livraria.net.domain.Contracts.Repository;
using livraria.net.domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace livraria.net.domain.Services
{
    public class UserService : BaseService
    {
        private readonly IUserRepository _repository;
        public UserService(INotificator notificator, IUserRepository repository) : base(notificator)
        {
            _repository = repository;
        }

        public async Task<User> CreateAsync(User user)
        {
            return await _repository.Add(user);
        } 

        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            var foundUser = await _repository.FindById(id);
            if (foundUser == null)
            {
                AddNotification("User not found!");
                return null;
            }

            return foundUser;
        }

        public async Task<List<User>> FindAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task DeleteAsync(int id)
        {
            var foundUser = await _repository.FindById(id);
            if (foundUser == null)
            {
                AddNotification("User not found!");
                return;
            }
            await _repository.Delete(foundUser);
        }

        public async Task<User> UpdateAsync(int id, User book)
        {
            var foundUser = await _repository.FindById(id);
            if (foundUser == null)
            {
                AddNotification("User not found!");
                return null;
            }

            foundUser.Name = book.Name; 
            foundUser.Age = book.Age;
            foundUser.Gender = book.Gender;
            foundUser.Email = book.Email;
            foundUser.Username = book.Username;
            foundUser.Password = book.Password;
            foundUser.Birthdate = book.Birthdate;

            await _repository.Update(foundUser);
            return foundUser;
        }
    }
}
