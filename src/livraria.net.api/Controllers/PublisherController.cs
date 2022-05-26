using AutoMapper;
using livraria.net.api.Dto;
using livraria.net.core.Contracts;
using livraria.net.core.Contracts.Logger;
using livraria.net.core.Controllers;
using livraria.net.domain.Helper;
using livraria.net.domain.Models;
using livraria.net.domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livraria.net.api.Controllers
{
    [Authorize]
    [Route("api/v1/publishers")]
    public class PublisherController : MainController
    {
        private readonly PublisherService _service;
        public PublisherController(IMapper mapper, INotificator notificator, ILog log, PublisherService service) : base(mapper, notificator, log)
        {
            _service = service;
        }

        /// <summary>
        /// Publisher creation operation
        /// </summary>
        /// <param name="PublisherDTO"></param>
        /// <returns></returns>
        /// <response code="201">Success publisher created</response>>
        /// <response code="400">Missing required fields, wrong field range value or publisher already registered</response>>
        /// <response code="401">Unauthorized</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     POST /api/v1/publishers 
        ///     {
        ///         "id": 0,
        ///         "name": "Mario Carlos Andrade",
        ///         "code": asdfget24,
        ///         "fundationDate": "2022-05-22"
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> create(PublisherDTO publisherDTO)
        {
            if (!ModelState.IsValid) return ResponseModelError(ModelState);
            var createdPubliser = await _service.CreateAsync(_mapper.Map<Publisher>(publisherDTO));
            await _log.Information(createdPubliser.Id, Med.GetTextFromApi(publisherDTO, HttpContext), "POST.CREATE_PUBLISHER");
            return ResponseCreated(_mapper.Map<PublisherDTO>(createdPubliser));
        }

        /// <summary>
        /// Find publisher by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success publisher found</response>>
        /// <response code="401">Unauthorized</response>>
        /// <response code="404">Publisher not found error code</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     GET /api/v1/publishers/123
        /// 
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindById(int id)
        {
            var foundPublisher = await _service.FindByIdAsync(id);
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            return ResponseOk(_mapper.Map<PublisherDTO>(foundPublisher));
        }

        /// <summary>
        /// Find all registered publishers
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success all registered publishers</response>>
        /// <response code="401">Unauthorized</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     GET /api/v1/publishers
        /// 
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindAll()
        {
            var publishers = await _service.GetAllAsync();
            return ResponseOk(publishers.Select(publisher => _mapper.Map<PublisherDTO>(publisher)).ToList());
        }

        /// <summary>
        /// Delete publisher by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success publisher deleted</response>>
        /// <response code="401">Unauthorized</response>>
        /// <response code="404">Publisher not found error code</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     DELETE /api/v1/publishers/123
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
            await _log.Information(id, Med.GetTextFromApi(null, HttpContext), "DELETE.DELETE_PUBLISHER");
            return ResponseNoContent();
        }

        /// <summary>
        /// Publisher update operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="publisherDTO"></param>
        /// <returns></returns>
        /// <response code="200">Success publisher updated</response>>
        /// <response code="400">Missing required fields, or an error on validation field rules</response>> 
        /// <response code="401">Unauthorized</response>>
        /// <response code="404">Publisher not found</response>> 
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     PUT /api/v1/publishers/123 
        ///     {
        ///         "id": 123,
        ///         "name": "Mario Carlos Andrade",
        ///         "code": asdfget24,
        ///         "fundationDate": "2022-05-22"
        ///     }
        /// 
        /// </remarks> 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, PublisherDTO publisherDTO)
        {
            if (!ModelState.IsValid) return ResponseModelError(ModelState);
            var foundPublisher = await _service.UpdateAsync(id, _mapper.Map<Publisher>(publisherDTO));
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            await _log.Information(id, Med.GetTextFromApi(publisherDTO, HttpContext), "PUT.UPDATE_PUBLISHER");
            return ResponseOk(_mapper.Map<PublisherDTO>(foundPublisher));
        }
    }
}
