using GFT.Api.Model;
using GFT.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace GFT.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoService _investimentoService;

        public InvestimentoController(IInvestimentoService investimentoService)
        {
            _investimentoService = investimentoService;
        }

        [HttpGet("SaudeRequest")]
        public ActionResult<InvestimentoRequest> SaudeRequest()
        {
            var resultado = new InvestimentoRequest();
            return Ok(resultado);
        }

        [HttpGet("SaudeResponse")]
        public ActionResult<InvestimentoResponse> SaudeResponse()
        {
            var resultado = new InvestimentoResponse();
            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult<InvestimentoResponse> CalcularInvestimento([FromBody] InvestimentoRequest request)
        {
            var resultado = _investimentoService.CalcularInvestimento(request);
            return Ok(resultado);
        }
    }
}