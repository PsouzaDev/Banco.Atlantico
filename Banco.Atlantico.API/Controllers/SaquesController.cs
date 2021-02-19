using Banco.Atlantico.Application;
using Banco.Atlantico.Application.Services;
using Banco.Atlantico.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Banco.Atlantico.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SaquesController : Controller
    {
        private readonly Stopwatch _stopWatch;
        private readonly ISaquesService _saquesService;
        private readonly int VALORMINIMO = int.Parse( Environment.GetEnvironmentVariable("VALOR_MINIMO"));
        private readonly int VALORMAXIMO = int.Parse( Environment.GetEnvironmentVariable("VALOR_MAXIMO"));

        private string _correlationId { get; set; }

        public SaquesController(ISaquesService saquesService)
        {
            _stopWatch = new Stopwatch();
            _saquesService = saquesService ?? throw  new ArgumentNullException(nameof(saquesService));
        }

        /// <summary>
        /// Realiza um Saque no caixa escolhido.
        /// </summary>
        /// <param name="saqueViewModel"></param>
        /// <returns></returns>
        [HttpPost()]
        [Consumes("application/json")]
        [SwaggerResponse(201, "sucesso!", typeof(SaqueViewModel))]
        [SwaggerResponse(204, "nada encontrado!")]
        [SwaggerResponse(400, "Parametros inválidos!")]
        [SwaggerResponse(500, "Erro interno!")]
        public async Task<IActionResult> SaquesAsync(SaqueViewModel saqueViewModel)
        {
            _stopWatch.Start();
            _correlationId = Guid.NewGuid().ToString();

            try
            {
                if (saqueViewModel.Valor <= VALORMINIMO &&  saqueViewModel.Valor > VALORMAXIMO)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, $"O valor minimo e maximo para  saques são {VALORMINIMO} e {VALORMAXIMO}");
                }

                var result = await _saquesService.SaqueAsync(saqueViewModel, _correlationId);

                return Created("NIE",result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
