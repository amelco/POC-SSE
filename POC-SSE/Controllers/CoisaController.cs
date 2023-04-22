using Microsoft.AspNetCore.Mvc;
using POC_SSE.Models;

namespace POC_SSE.Controllers
{

    [ApiController]
    [Route("/coisas")]
    public class CoisaController : ControllerBase
    {

        private List<CoisaModel> casos = new List<CoisaModel>
        {
            new CoisaModel
            {
                Id = Guid.NewGuid(),
                Codigo = "0001B",
                Nome = "Fulano de Tal"
            },
            new CoisaModel
            {
                Id = Guid.NewGuid(),
                Codigo = "0002A",
                Nome = "Beltrano de Tal"
            }
        };

        [HttpGet]
        public IActionResult ListarCoisas(CancellationToken cancellationToken)
        {
            Task.Delay(500);
            return Ok(casos);
        }
    }
}
