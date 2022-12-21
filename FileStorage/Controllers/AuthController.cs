using AutoMapper;
using FileStorage.Services.Abstract;
using FileStorage.Services.Models;
using FileStorage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;

namespace FileStorage.Controllers
{
    /// <summary>
    /// Users endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        /// <summary>
        /// Authcontroller
        /// </summary>
        public AuthController(IAuthService  authService, IMapper mapper)
        {
            this.authService = authService;
            this.mapper = mapper;
        }
        /// <summary>
        /// register
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("registerUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequest request)
        {
            try
            {
                RegisterUserModel registerModel = mapper.Map<RegisterUserModel>(request);
                UserModel result = await authService.RegisterUser(registerModel);
                UserResponse response = mapper.Map<UserResponse>(result);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        /// <summary>
        /// login
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("loginUser")]
        public async Task<IActionResult> LogInUserAsync([FromBody] LoginUserRequest request)
        {
           try
            {
                LoginUserModel loginModel = mapper.Map<LoginUserModel>(request);
                TokenResponse response = await authService.LoginUser(loginModel);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
