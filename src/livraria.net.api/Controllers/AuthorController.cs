using livraria.net.api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livraria.net.api.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorController : ControllerBase
    {
        [HttpPost]
        public AuthorDTO create(AuthorDTO authorDTO)
        {
            return authorDTO;
        }

        [HttpGet("{id}")]
        public AuthorDTO FindById(int id)
        {
            return new AuthorDTO { Id = id };
        }

        [HttpGet]
        public List<AuthorDTO> FindAll()
        {
            return new List<AuthorDTO>();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var authorDTO = new AuthorDTO { Id = id };
        }

        [HttpPut("{id}")]
        public AuthorDTO Update(int id, AuthorDTO authorDTO)
        {
            return authorDTO;
        }
    }
}
