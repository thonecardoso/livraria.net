using livraria.net.api.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace livraria.net.api.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public UserDTO create(UserDTO userDTO)
        {
            return userDTO;
        }

        [HttpGet("{id}")]
        public UserDTO FindById(int id)
        {
            return new UserDTO { Id = id };
        }

        [HttpGet]
        public List<UserDTO> FindAll()
        {
            return new List<UserDTO>();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var userDTO = new UserDTO { Id = id };
        }

        [HttpPut("{id}")]
        public UserDTO Update(int id, UserDTO userDTO)
        {
            return userDTO;
        }
    }
}
