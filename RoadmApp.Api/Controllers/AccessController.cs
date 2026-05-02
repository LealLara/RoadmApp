using Microsoft.AspNetCore.Mvc;
using RoadmApp.Api.PresentationModels.Results;
using RoadmApp.Application.IServices;
using RoadmApp.Application.Responses;
using RoadmApp.Application.UseCases.Access.CreateAccess;
using Swashbuckle.AspNetCore.Annotations;

namespace RoadmApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessController : ControllerBase
    {
        private readonly ICreateAccessUseCase _accessService;

        public AccessController(ICreateAccessUseCase accessService)
        {
            _accessService = accessService;
        }

        /// <summary>
        /// Endpoint para criar um novo acesso (registro de usuário).
        /// </summary>
        /// <param name="dto">Objeto contendo os dados de registro do usuário.</param>
        /// <returns>Retorna um objeto SuccessResults indicando o resultado da operação.</returns>
        [SwaggerOperation(Summary = "Cria um novo usuário no sistema", Description = "Endpoint para criar um novo acesso (registro de usuário).")]
        [SwaggerResponse(StatusCodes.Status200OK, "Acesso criado com sucesso", typeof(SuccessResults))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Falha ao criar acesso", typeof(SuccessResults))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(string))]
        [HttpPost("create-access")]
        public async Task<IActionResult> CreateAccess(RegisterDto dto)
        {
            try
            {
                SuccessModel data = await _accessService.CreateAccess(dto.Transform());

                if (!data.Success)
                    return BadRequest(new SuccessResults().Transform(data));

                return Ok(new SuccessResults().Transform(data));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}