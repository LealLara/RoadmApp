using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoadmApp.Domain.Interfaces.IServices;
using RoadmApp.Domain.Services;

namespace RoadmApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [Authorize]
        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromQuery] EmailDto emailDto)
        {
            try
            {
                await _emailService.SendAsync(emailDto.Transform());
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetEmailTyes()
        {
            try
            {
                return Ok(await _emailService.GetEmailTyes());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}