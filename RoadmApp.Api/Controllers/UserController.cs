using Microsoft.AspNetCore.Mvc;
using RoadmApp.Application.IServices;

namespace RoadmApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICreateAccessUseCase _accessService;

        public UserController(ICreateAccessUseCase accessService)
        {
            _accessService = accessService;
        }
    }
}
