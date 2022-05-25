using AutoMapper;
using livraria.net.api.Dto;
using livraria.net.core.Contracts;
using livraria.net.core.Contracts.Logger;
using livraria.net.core.Controllers;
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
    [Route("api/v1/users")]
    public class UserController : MainController
    {
        private readonly UserService _service;
        public UserController(IMapper mapper, INotificator notificator, ILog log, UserService service) : base(mapper, notificator, log)
        {
            _service = service;
        }

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
        public async Task<IActionResult> create(UserDTO userDTO)
        {
            var createdUser = await _service.CreateAsync(_mapper.Map<User>(userDTO));
            await _log.Information(createdUser.Id, Med.GetTextFromApi(userDTO, HttpContext), "POST.CREATE_USER");
            return ResponseCreated(_mapper.Map<UserDTO>(createdUser));
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
        public async Task<IActionResult> FindById(int id)
        {
            var foundUser = await _service.FindByIdAsync(id);
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            return ResponseOk(_mapper.Map<UserDTO>(foundUser));
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
        public async Task<IActionResult> FindAll()
        {
            var users = await _service.GetAllAsync();
            return ResponseOk(users.Select(user => _mapper.Map<UserDTO>(user)).ToList());
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
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            await _log.Information(id, Med.GetTextFromApi(null, HttpContext), "DELETE.DELETE_USER");
            return ResponseNoContent();
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
        public async Task<IActionResult> Update(int id, UserDTO userDTO)
        {
            var foundUser = await _service.UpdateAsync(id, _mapper.Map<User>(userDTO));
            if (NotificatorHasNotifications())
            {
                return ResponseNotFound();
            }
            await _log.Information(id, Med.GetTextFromApi(userDTO, HttpContext), "PUT.UPDATE_USER");
            return ResponseOk(_mapper.Map<UserDTO>(foundUser));
        }
    }
}
