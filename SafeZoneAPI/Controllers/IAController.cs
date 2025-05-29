using Microsoft.AspNetCore.Mvc;
using SafeZoneAPI.MLOperations;

namespace SafeZoneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IAController : ControllerBase
    {
        [HttpPost("prever-risco")]
        public ActionResult<RiscoOutput> PreverRisco([FromBody] RiscoInput input)
        {
            var predictor = new RiscoPredictor();
            var resultado = predictor.Prever(input);
            return Ok(resultado);
        }
    }
}
