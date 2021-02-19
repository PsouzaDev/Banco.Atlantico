using Banco.Atlantico.Application.Interfaces;
using Banco.Atlantico.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Atlantico.API.Controllers
{
    [Route("BancoAtlantico/[controller]")]
    [ApiController]
    public class CaixasController : Controller
    {
        private readonly Stopwatch _stopWatch;
        private readonly ICaixasService _caixaService;

        private string _correlationId { get; set; }

        public CaixasController(ICaixasService caixaService)
        {
            _stopWatch = new Stopwatch();
            _caixaService = caixaService ?? throw new ArgumentNullException(nameof(caixaService));
        }

        [HttpGet()]
        [Consumes("application/json")]
        [SwaggerResponse(200, "sucesso!", typeof(CaixaViewModel))]
        [SwaggerResponse(204, "nada encontrado!")]
        [SwaggerResponse(400, "Parametros inválidos!")]
        [SwaggerResponse(500, "Erro interno!")]
        public async Task<IActionResult> CaixasAsync()
        {
            _stopWatch.Start();
            _correlationId = Guid.NewGuid().ToString();

            try
            {
                var result = await _caixaService.CaixasAsync(_correlationId);

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("/{idFicha}")]
        [Consumes("application/json")]
        [SwaggerResponse(200, "sucesso!", typeof(CaixaViewModel))]
        [SwaggerResponse(204, "nada encontrado!")]
        [SwaggerResponse(400, "Parametros inválidos!")]
        [SwaggerResponse(500, "Erro interno!")]
        public async Task<IActionResult> CaixasAsync([FromRoute]string Id)
        {
            throw new NotImplementedException();
        }
    }
}
