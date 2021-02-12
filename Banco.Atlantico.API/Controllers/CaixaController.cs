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
    public class CaixaController : Controller
    {
        private readonly Stopwatch _stopWatch;
        private readonly ISaqueService _saqueService;
        private readonly int VALORMINIMO = int.Parse( Environment.GetEnvironmentVariable("VALOR_MINIMO"));
        private readonly int VALORMAXIMO = int.Parse( Environment.GetEnvironmentVariable("VALOR_MAXIMO"));

        private string _correlationId { get; set; }

        public CaixaController(ISaqueService saqueService)
        {
            _stopWatch = new Stopwatch();
            _saqueService = saqueService ?? throw  new ArgumentNullException(nameof(saqueService));
        }


        [HttpPost()]
        [Consumes("application/json")]
        public async Task<IActionResult> SaqueAsync(SaqueViewModel saqueViewModel)
        {
            _stopWatch.Start();
            _correlationId = Guid.NewGuid().ToString();

            try
            {
                if (saqueViewModel.Valor <= VALORMINIMO ||  saqueViewModel.Valor > VALORMAXIMO)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed, $"O valor minimo e maximo para  saques são {VALORMINIMO} e {VALORMAXIMO}");
                }

                var result = await _saqueService.SaqueAsync(saqueViewModel, _correlationId);

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
