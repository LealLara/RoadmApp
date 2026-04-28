using Microsoft.AspNetCore.Mvc;
using RoadmApp.Api.DTOs;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Interfaces.IServices;

namespace RoadmApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessController : ControllerBase
    {
        private readonly IAccessService _accessService;

        public AccessController(IAccessService accessService)
        {
            _accessService = accessService;
        }

        [HttpPost("create-access")]
        public async Task<IActionResult> CreateAccess(RegisterDto dto)
        {
            try
            {
                User data = await _accessService.CreateAccess(dto.Transform());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}