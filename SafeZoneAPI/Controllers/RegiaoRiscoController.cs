using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeZoneAPI.Data;
using SafeZoneAPI.Models;

namespace SafeZoneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegiaoRiscoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegiaoRiscoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegiaoRisco>>> GetAll()
        {
            return await _context.RegioesRisco.Include(r => r.Alertas).ToListAsync();
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
        public async Task<ActionResult<RegiaoRisco>> Create(RegiaoRisco regiao)
        {
            _context.RegioesRisco.Add(regiao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = regiao.Id }, regiao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RegiaoRisco regiao)
        {
            if (id != regiao.Id) return BadRequest();
            _context.Entry(regiao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var regiao = await _context.RegioesRisco.FindAsync(id);
            if (regiao == null) return NotFound();
            _context.RegioesRisco.Remove(regiao);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
