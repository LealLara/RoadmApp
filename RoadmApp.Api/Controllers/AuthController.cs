using Microsoft.AspNetCore.Mvc;
using RoadmApp.Application.IServices;
using RoadmApp.Application.UseCases.Access.CreateAccess;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                Success token = await _authService.Login(dto.Nickname, dto.Password);
                // return Ok(new { token = new SuccessModel().Transform(token) });
                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.ToString());
            }
        }

        #region not implemented yet
        /*[HttpPost("logout")]
        public async Task<IActionResult> Logout(int userId)
        {
            try
            {
                var token = await _authService.Logout(userId);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.ToString());
            }
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(int userId, string newPassword)
        {
            try
            {
                var token = await _authService.ChangePassword(userId, newPassword);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.ToString());
            }
        }*/
        #endregion
    }
}