using AutoMapper;
using FileStorage.Services.Abstract;
using FileStorage.Services.Models;
using FileStorage.Models;
using Microsoft.AspNetCore.Mvc;

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
        private readonly IFileService fileService;
        private readonly IMapper mapper;

        /// <summary>
        /// files controller
        /// </summary>
        public FilesController(IFileService fileService, IMapper mapper)
        {
            this.fileService = fileService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get files by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetFiles([FromQuery] Guid userId, [FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
             var pageModel = fileService.GetFiles(userId, limit, offset);
            return Ok(mapper.Map<PageResponse<FilePreviewModel>>(pageModel));
        }


        /// <summary>
        /// Delete file
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteFile([FromRoute] Guid id)
        {
            try
            {
                fileService.DeleteFile(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// Add file
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddFile([FromQuery] Guid userId,[FromForm] IFormFile file)
        {
            var response = fileService.AddFile(userId, file);
            return Ok(response);
        }

        /// <summary>
        /// Get file
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFile([FromRoute] Guid id)
        {
            try
            {
                var fileModel = fileService.GetFile(id);
                return Ok(mapper.Map<FileResponse>(fileModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}


    
