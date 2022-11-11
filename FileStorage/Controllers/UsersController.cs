using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using FileStorage.Entities.Models;
using FileStorage.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FileStorage.Controllers
{
    /// <summary>
    /// Users endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _repository.GetAll();
            return Ok(users);
        }


        /// <summary>
        /// Add user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            var response = _repository.Save(user);
            return Ok(response);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        [HttpDelete]
        public void DeleteUser(User user)
        {
            _repository.Delete(user);
        }

        // /// <summary>
        // /// Get user by id
        // /// </summary>
        // /// <returns></returns>
        // [HttpGet]
        // public IActionResult GetUserById(Guid id)
        // {
        //     var user = _repository.GetById(id);
        //     return Ok(user);
        // }


        //  /// <summary>
        // /// Update user
        // /// </summary>
        // /// <returns></returns>
        // [HttpPost]
        // public IActionResult UpdateUser(User user)
        // {
        //    var response = _repository.Save(user);
        //    return Ok(response);
        // }
    }
}