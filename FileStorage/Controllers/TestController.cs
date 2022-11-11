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
    public class TestController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public TestController(IRepository<User> repository)
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
             User user = new User();
            // user.Email = "hbghesdbc";
            // user.Login = "hskjncfs";
            // user.PasswordHash = "erfh.ekjrnf";
            // user.CreatedTime = DateTime.Now;
            // user.UpdatedTime = DateTime.Now;

           // _repository.Save(user);

            user.Email = "jhk";

            _repository.Save(user);

            //var users =  _repository.GetAll();

            return Ok(user);
        }
    }
}