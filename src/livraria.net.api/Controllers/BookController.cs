using livraria.net.api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace livraria.net.api.Controllers
{
    /// <summary>
    /// Books module management
    /// </summary>
    [ApiController]
    [Route("api/v1/books")]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// Book creation operation
        /// </summary>
        /// <param name="bookRequestDTO"></param>
        /// <returns></returns>
        /// <response code="201">Success book creation</response>>
        /// <response code="400">Missing required fields, wrong field range value or book already registered</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     POST /api/v1/books 
        ///     {
        ///         "id": 0,
        ///         "name": "O Pequeno Principe",
        ///         "pages": 90,
        ///         "chapters": 16,
        ///         "isbn": 9788854172388,
        ///         "publisherId": 97,
        ///         "authorId": 34
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Find book by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success book found</response>>
        /// <response code="404">Book not found error code</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     GET /api/v1/books/123
        /// 
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public BookResponseDTO FindById(int id)
        {
            return new BookResponseDTO { Id = id };
        }

        /// <summary>
        /// List all registered books
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success all registered books</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     GET /api/v1/books
        /// 
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public List<BookResponseDTO> FindAll()
        {
            return new List<BookResponseDTO>();
        }

        /// <summary>
        /// Delete book by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success book deleted</response>>
        /// <response code="404">Book not found error code</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     DELETE /api/v1/books/123
        /// 
        /// </remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Delete(int id)
        {
            var bookDTO = new BookResponseDTO { Id = id };
        }

        /// <summary>
        /// Book update operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookRequestDTO"></param>
        /// <returns></returns>
        /// <response code="200">Success book updated</response>>
        /// <response code="400">Missing required fields, or an error on validation field rules</response>>        
        /// <response code="404">Book not found</response>> 
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     PUT /api/v1/books/123 
        ///     {
        ///         "id": 0,
        ///         "name": "O Pequeno Principe",
        ///         "pages": 90,
        ///         "chapters": 16,
        ///         "isbn": 9788854172388,
        ///         "publisherId": 97,
        ///         "authorId": 34
        ///     }
        /// 
        /// </remarks> 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
