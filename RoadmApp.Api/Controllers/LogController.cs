using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Interfaces.IServices;

namespace RoadmApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase 
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet("get-logs")]
        public async Task<IActionResult> GetLogs()
        {
            try
            {
                List<Log> logs = await _logService.GetLogs();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}