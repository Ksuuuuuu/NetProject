using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using FileStorage.Entities.Models;
using FileStorage.Repository;
using Microsoft.AspNetCore.Mvc;
//using FileStorage.Entities.Models.File MyFile;

namespace FileStorage.Controllers
{
    /// <summary>
    /// Files endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private IRepository<Entities.Models.File> _repository;

        /// <summary>
        /// Files controller
        /// </summary>
        public FilesController(IRepository<Entities.Models.File> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get files
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var files = _repository.GetAll();
            return Ok(files);
        }


        /// <summary>
        /// Add file
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUser(Entities.Models.File file)
        {
            var response = _repository.Save(file);
            return Ok(response);
        }

        /// <summary>
        /// Delete file
        /// </summary>
        [HttpDelete]
        public void DeleteUser(Entities.Models.File file)
        {
            _repository.Delete(file);
        }

        // /// <summary>
        // /// Get file by id
        // /// </summary>
        // /// <returns></returns>
        // [HttpGet]
        // public IActionResult GetUserById(Guid id)
        // {
        //     var file = _repository.GetById(id);
        //     return Ok(file);
        // }


        // /// <summary>
        // /// Update file
        // /// </summary>
        // /// <returns></returns>
        // [HttpPost]
        // public IActionResult UpdateUser(Entities.Models.File file)
        // {
        //     var response = _repository.Save(file);
        //     return Ok(response);
        // }
    }
}