using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeZoneAPI.Data;
using SafeZoneAPI.Models;
using SafeZoneAPI.Helpers;


namespace SafeZoneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlertaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> GetAll()
        {
            return await _context.Alertas.Include(a => a.RegiaoRisco).ToListAsync();
        }

        [HttpGet("{id}")]
public async Task<ActionResult<object>> GetById(int id)
{
    var regiao = await _context.RegioesRisco
        .Include(r => r.Alertas)
        .FirstOrDefaultAsync(r => r.Id == id);

    if (regiao == null)
        return NotFound();

    var response = new
    {
        regiao,
        links = new List<object>
        {
            new { rel = "self", href = Url.Action(nameof(GetById), new { id = regiao.Id }), method = "GET" },
            new { rel = "update", href = Url.Action(nameof(Update), new { id = regiao.Id }), method = "PUT" },
            new { rel = "delete", href = Url.Action(nameof(Delete), new { id = regiao.Id }), method = "DELETE" }
        }
    };

    return Ok(response);
}


        [HttpPost]
        public async Task<ActionResult<Alerta>> Create(Alerta alerta)
        {
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();

            var publisher = new RabbitMQPublisher();
            var mensagem = $"[ALERTA] - Risco: {alerta.Nivel} - Região ID: {alerta.RegiaoRiscoId}";
            publisher.PublicarMensagem(mensagem);

            return CreatedAtAction(nameof(GetById), new { id = alerta.Id }, alerta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Alerta alerta)
        {
            if (id != alerta.Id) return BadRequest();
            _context.Entry(alerta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var alerta = await _context.Alertas.FindAsync(id);
            if (alerta == null) return NotFound();
            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
