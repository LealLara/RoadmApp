using Microsoft.AspNetCore.Mvc;
using RoadmApp.Api.DTOs;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Interfaces.IServices;
using RoadmApp.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

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

        /// <summary>
        /// Endpoint para criar um novo acesso (registro de usuário).
        /// </summary>
        /// <param name="dto">Objeto contendo os dados de registro do usuário.</param>
        /// <returns>Retorna um objeto SuccessModel indicando o resultado da operação.</returns>
        [SwaggerOperation(Summary = "Cria um novo acesso", Description = "Endpoint para criar um novo acesso (registro de usuário).")]
        [SwaggerResponse(StatusCodes.Status200OK, "Acesso criado com sucesso", typeof(SuccessModel))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Falha ao criar acesso", typeof(SuccessModel))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor", typeof(string))]
        [HttpPost("create-access")]
        public async Task<IActionResult> CreateAccess(RegisterDto dto)
        {
            try
            {
                SuccessModel data = await _accessService.CreateAccess(dto.Transform());
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}