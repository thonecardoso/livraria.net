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
    [Route("api/v1/books")]
    public class BookController : ControllerBase
    {
        [HttpPost]
        public BookResponseDTO create(BookRequestDTO bookRequestDTO)
        {
            return new BookResponseDTO
            {
                Id = bookRequestDTO.Id,
                AuthorId = bookRequestDTO.AuthorId,
                Chapters = bookRequestDTO.Chapters,
                Isbn = bookRequestDTO.Isbn,
                Name = bookRequestDTO.Name,
                Pages = bookRequestDTO.Pages,
                PublisherId = bookRequestDTO.PublisherId,
            };
        }

        [HttpGet("{id}")]
        public BookResponseDTO FindById(int id)
        {
            return new BookResponseDTO { Id = id };
        }

        [HttpGet]
        public List<BookResponseDTO> FindAll()
        {
            return new List<BookResponseDTO>();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bookDTO = new BookResponseDTO { Id = id };
        }

        [HttpPut("{id}")]
        public BookResponseDTO Update(int id, BookRequestDTO bookRequestDTO)
        {
            return new BookResponseDTO
            {
                Id = bookRequestDTO.Id,
                AuthorId = bookRequestDTO.AuthorId, 
                Chapters = bookRequestDTO.Chapters, 
                Isbn = bookRequestDTO.Isbn,
                Name = bookRequestDTO.Name,
                Pages = bookRequestDTO.Pages,
                PublisherId = bookRequestDTO.PublisherId,
            };
        }
    }
}
