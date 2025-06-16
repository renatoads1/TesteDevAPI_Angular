using Microsoft.AspNetCore.Mvc;
using TesteDev.Models;
using TesteDev.Services;

namespace TesteDev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CdbController : Controller
    {
        private readonly ICdbCalculatorService _cdbCalculatorService;

        public CdbController(ICdbCalculatorService cdbCalculatorService)
        {
            _cdbCalculatorService = cdbCalculatorService;
        }

        [HttpPost("calcular")]
        public ActionResult<CdbResult> Calcular([FromBody] CdbRequest request)
        {
            try
            {
                var resultado = _cdbCalculatorService.Calcular(request);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
