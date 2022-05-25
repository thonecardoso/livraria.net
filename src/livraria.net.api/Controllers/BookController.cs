using AutoMapper;
using livraria.net.api.Dto;
using livraria.net.core.Contracts;
using livraria.net.core.Contracts.Logger;
using livraria.net.core.Controllers;
using livraria.net.core.Query;
using livraria.net.domain.Helper;
using livraria.net.domain.Models;
using livraria.net.domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livraria.net.api.Controllers
{
    /// <summary>
    /// Books module management
    /// </summary>
    [Route("api/v1/books")]
    public class BookController : MainController
    {
        private readonly BookService _service;
        public BookController(IMapper mapper, INotificator notificator, ILog log, BookService service) : base(mapper, notificator, log)
        {
            _service = service;
        }

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
        public async Task<IActionResult> create(BookRequestDTO bookRequestDTO)
        {
            var createdAuthor = await _service.CreateAsync(_mapper.Map<Book>(bookRequestDTO));
            await _log.Information(createdAuthor.Id, Med.GetTextFromApi(bookRequestDTO, HttpContext), "POST.CREATE_BOOK");
            return ResponseCreated(_mapper.Map<BookResponseDTO>(createdAuthor));
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
        public async Task<IActionResult> FindById(int id)
        {
            var foundBook = await _service.FindByIdAsync(id);
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            return ResponseOk(_mapper.Map<BookResponseDTO>(foundBook));
        }

        /// <summary>
        /// List all registered books
        /// </summary>
        /// <param name="query"></param>
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
        public async Task<IActionResult> FindAll([FromQuery] BookQuery query)
        {
            var books = await _service.GetAllAsync(query);
            return ResponseOk(books.Select(book => _mapper.Map<BookResponseDTO>(book)).ToList());
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
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            await _log.Information(id, Med.GetTextFromApi(null, HttpContext), "DELETE.DELETE_BOOK");
            return ResponseNoContent();
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
        public async Task<IActionResult> Update(int id, BookRequestDTO bookRequestDTO)
        {
            var foundBook = await _service.UpdateAsync(id, _mapper.Map<Book>(bookRequestDTO));
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            await _log.Information(id, Med.GetTextFromApi(bookRequestDTO, HttpContext), "PUT.UPDATE_BOOK");
            return ResponseOk(_mapper.Map<AuthorDTO>(foundBook));
        }
    }
}
