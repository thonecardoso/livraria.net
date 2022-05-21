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
    [Route("api/v1/publishers")]
    public class PublisherController : ControllerBase
    {
        [HttpPost]
        public PublisherDTO create(PublisherDTO publisherDTO)
        {
            return publisherDTO;
        }

        [HttpGet("{id}")]
        public PublisherDTO FindById(int id)
        {
            return new PublisherDTO { Id = id };
        }

        [HttpGet]
        public List<PublisherDTO> FindAll()
        {
            return new List<PublisherDTO>();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var authorDTO = new PublisherDTO { Id = id };
        }

        [HttpPut("{id}")]
        public PublisherDTO Update(int id, PublisherDTO publisherDTO)
        {
            return publisherDTO;
        }
    }
}
