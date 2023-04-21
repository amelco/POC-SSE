using Microsoft.AspNetCore.Mvc;
using POC_SSE.Models;

namespace POC_SSE.Controllers
{

    [ApiController]
    [Route("/casos")]
    public class CasoController : ControllerBase
    {

        private List<CasoModel> casos = new List<CasoModel>
        {
            new CasoModel
            {
                Id = Guid.NewGuid(),
                CodigoSS = "SS-0001",
                Placa = "ABC-1234"
            },
            new CasoModel
            {
                Id = Guid.NewGuid(),
                CodigoSS = "SS-0002",
                Placa = "DEF-5678"
            }
        };

        [HttpGet]
        public IActionResult ListarCasos(CancellationToken cancellationToken)
        {
            Task.Delay(500);
            return Ok(casos);
        }
    }
}
