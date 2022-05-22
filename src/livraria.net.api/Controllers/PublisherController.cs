using livraria.net.api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace livraria.net.api.Controllers
{
    [ApiController]
    [Route("api/v1/publishers")]
    public class PublisherController : ControllerBase
    {
        /// <summary>
        /// Publisher creation operation
        /// </summary>
        /// <param name="PublisherDTO"></param>
        /// <returns></returns>
        /// <response code="201">Success publisher created</response>>
        /// <response code="400">Missing required fields, wrong field range value or publisher already registered</response>>
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public PublisherDTO create(PublisherDTO publisherDTO)
        {
            return publisherDTO;
        }

        /// <summary>
        /// Find publisher by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success publisher found</response>>
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public PublisherDTO FindById(int id)
        {
            return new PublisherDTO { Id = id };
        }

        /// <summary>
        /// Find all registered publishers
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success all registered publishers</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     GET /api/v1/publishers
        /// 
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public List<PublisherDTO> FindAll()
        {
            return new List<PublisherDTO>();
        }

        /// <summary>
        /// Delete publisher by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success publisher deleted</response>>
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Delete(int id)
        {
            var authorDTO = new PublisherDTO { Id = id };
        }

        /// <summary>
        /// Publisher update operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="publisherDTO"></param>
        /// <returns></returns>
        /// <response code="200">Success publisher updated</response>>
        /// <response code="400">Missing required fields, or an error on validation field rules</response>>        
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public PublisherDTO Update(int id, PublisherDTO publisherDTO)
        {
            return publisherDTO;
        }
    }
}
