using AutoMapper;
using livraria.net.api.Dto;
using livraria.net.core.Contracts;
using livraria.net.core.Controllers;
using livraria.net.domain.Models;
using livraria.net.domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livraria.net.api.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorController : MainController
    {
        private readonly AuthorService _service;
        public AuthorController(IMapper mapper, INotificator notificator, AuthorService service) : base(mapper, notificator)
        {
            _service = service;
        }

        /// <summary>
        /// Author creation operation
        /// </summary>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        /// <response code="201">Success author created</response>>
        /// <response code="400">Missing required fields, wrong field range value or author already registered</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     POST /api/v1/authors 
        ///     {
        ///         "id": 0,
        ///         "name": "Mario Carlos Andrade",
        ///         "age": 33
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> create(AuthorDTO authorDTO)
        {
            var createdAuthor = _service.CreateAsync(_mapper.Map<Author>(authorDTO));
            return ResponseCreated(createdAuthor);
        }

        /// <summary>
        /// Find author by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success author found</response>>
        /// <response code="404">Author not found error code</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     GET /api/v1/authors/123
        /// 
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public AuthorDTO FindById(int id)
        {
            return new AuthorDTO { Id = id };
        }

        /// <summary>
        /// Find all registered authors
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success all registered authors</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     GET /api/v1/authors
        /// 
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindAll()
        {
            var authors = await _service.GetAllAsync();
            return ResponseOk(authors.Select(author => _mapper.Map<AuthorDTO>(author)).ToList());
        }

        /// <summary>
        /// Delete author by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success author deleted</response>>
        /// <response code="404">Author not found error code</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     DELETE /api/v1/authors/123
        /// 
        /// </remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Delete(int id)
        {
            var authorDTO = new AuthorDTO { Id = id };
        }

        /// <summary>
        /// Author update operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        /// <response code="200">Success author updated</response>>
        /// <response code="400">Missing required fields, or an error on validation field rules</response>>        
        /// <response code="404">Author not found</response>> 
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     PUT /api/v1/authors/123 
        ///     {
        ///         "id": 123,
        ///         "name": "Mario Carlos Cortela",
        ///         "age": 31
        ///     }
        /// 
        /// </remarks> 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public AuthorDTO Update(int id, AuthorDTO authorDTO)
        {
            return authorDTO;
        }
    }
}
