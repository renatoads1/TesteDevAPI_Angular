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
        public IActionResult Calcular([FromBody] CdbRequest? request)
        {
            if (request == null)
                return BadRequest("Request inválido.");

            try
            {
                var result = _cdbCalculatorService.Calcular(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Retorne uma mensagem genérica para exceções inesperadas
                return BadRequest("Erro inesperado: " + ex.Message);
            }
        }
    }
}
