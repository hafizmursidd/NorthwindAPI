using Microsoft.AspNetCore.Mvc;
using Northwind.Contract.AuthenticationWebAPI;
using Northwind.Domain.Base;
using Northwind.Services.Abstraction;
using Northwind.WebAPI.Authentication;

namespace Northwind.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IAuthenticationManager _authManager;

        public UserController(IRepositoryManager repositoryManager, ILoggerManager logger, IAuthenticationManager authManager)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _authManager = authManager;
        }

        // GET: api/<UserController>
        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            if (!await _authManager.ValidateUser(userForAuthenticationDto))
            {
                _logger.LogWarning($"{nameof(Authentication)} : Authentication Failed. Wrong username of password");
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }
    }
}
