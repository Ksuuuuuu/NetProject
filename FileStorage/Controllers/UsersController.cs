using AutoMapper;
using FileStorage.Services.Abstract;
using FileStorage.Services.Models;
using FileStorage.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get users by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = userService.GetUsers(limit, offset);

            var response = mapper.Map<PageResponse<UserPreviewResponse>>(pageModel);

            return Ok(response); // code 200 + body
        }


        /// <summary>
        /// Update user
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = userService.UpdateUser(id, mapper.Map<UpdateUserModel>(model));

                return Ok(mapper.Map<UserResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get user
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute] Guid id)
        {
            try
            {
                var userModel = userService.GetUser(id);
                return Ok(mapper.Map<UserResponse>(userModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}