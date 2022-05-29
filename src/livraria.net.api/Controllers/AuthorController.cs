using AutoMapper;
using livraria.net.api.Dto;
using livraria.net.core.Contracts;
using livraria.net.core.Controllers;
using livraria.net.domain.Helper;
using livraria.net.domain.Models;
using livraria.net.domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace livraria.net.api.Controllers
{
    [Authorize]
    [Route("api/v1/authors")]
    public class AuthorController : MainController
    {
        private readonly AuthorService _service;
        
        public AuthorController(IMapper mapper, INotificator notificator, AuthorService service, ILog log) : base(mapper, notificator, log)
        {
            _service = service;
        }

        /// <summary>
        /// Author creation operation
        /// </summary>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        /// <response code="201">Success author created</response>>
        /// <response code="401">Unauthorized</response>>
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> create(AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid) return ResponseModelError(ModelState);
            var createdAuthor = await _service.CreateAsync(_mapper.Map<Author>(authorDTO));
            await _log.Information(createdAuthor.Id, Med.GetTextFromApi(authorDTO, HttpContext), "POST.CREATE_AUTHOR");
            return ResponseCreated(_mapper.Map<AuthorDTO>(createdAuthor));
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
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindById(int id)
        {
            var foundAuthor = await _service.FindByIdAsync(id);
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            return ResponseOk(_mapper.Map<AuthorDTO>(foundAuthor));
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
        [AllowAnonymous]
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
        /// <response code="401">Unauthorized</response>>
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            await _log.Information(id, Med.GetTextFromApi(null, HttpContext), "DELETE.DELETE_AUTHOR");
            return ResponseNoContent();
        }

        /// <summary>
        /// Author update operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authorDTO"></param>
        /// <returns></returns>
        /// <response code="200">Success author updated</response>>
        /// <response code="400">Missing required fields, or an error on validation field rules</response>>   
        /// <response code="401">Unauthorized</response>>
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, AuthorDTO authorDTO)
        {
            if (!ModelState.IsValid) return ResponseModelError(ModelState);
            var foundAuthor = await _service.UpdateAsync(id, _mapper.Map<Author>(authorDTO));
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            await _log.Information(id, Med.GetTextFromApi(authorDTO, HttpContext), "PUT.UPDATE_AUTHOR");
            return ResponseOk(_mapper.Map<AuthorDTO>(foundAuthor));
        }
    }
}
