using livraria.net.api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace livraria.net.api.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// User creation operation
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        /// <response code="201">Success user created</response>>
        /// <response code="400">Missing required fields, wrong field range value or user already registered</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     POST /api/v1/users 
        ///     {
        ///         "Id":0,
        ///         "Name":"Isabela Batista",
        ///         "Age":46,
        ///         "Gender":1,
        ///         "Email":"IsabelaBatista35@yahoo.com",
        ///         "Username":"IsabelaBatista",
        ///         "Password":"42119ca2398640f1a0322652cd91876f",
        ///         "Birthdate":"1975-11-16T14:13:49.1963533-02:00"
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public UserDTO create(UserDTO userDTO)
        {
            return userDTO;
        }

        /// <summary>
        /// Find user by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success user found</response>>
        /// <response code="404">User not found error code</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     GET /api/v1/users/123
        /// 
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public UserDTO FindById(int id)
        {
            return new UserDTO { Id = id };
        }

        /// <summary>
        /// Find all registered users
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success all registered users</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     GET /api/v1/users
        /// 
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public List<UserDTO> FindAll()
        {
            return new List<UserDTO>();
        }

        /// <summary>
        /// Delete user by id operation
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success user deleted</response>>
        /// <response code="404">User not found error code</response>>
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     DELETE /api/v1/users/123
        /// 
        /// </remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Delete(int id)
        {
            var userDTO = new UserDTO { Id = id };
        }

        /// <summary>
        /// User update operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        /// <response code="200">Success user updated</response>>
        /// <response code="400">Missing required fields, or an error on validation field rules</response>>        
        /// <response code="404">User not found</response>> 
        /// <response code="500">Internal error on the API</response>>
        /// <remarks>
        /// Request Exemple:
        ///     
        ///     PUT /api/v1/users/123 
        ///     {
        ///         "Id":123,
        ///         "Name":"Isabela Batista",
        ///         "Age":46,
        ///         "Gender":1,
        ///         "Email":"IsabelaBatista35@yahoo.com",
        ///         "Username":"IsabelaBatista",
        ///         "Password":"42119ca2398640f1a0322652cd91876f",
        ///         "Birthdate":"1975-11-16T14:13:49.1963533-02:00"
        ///     }
        /// 
        /// </remarks> 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public UserDTO Update(int id, UserDTO userDTO)
        {
            return userDTO;
        }
    }
}
