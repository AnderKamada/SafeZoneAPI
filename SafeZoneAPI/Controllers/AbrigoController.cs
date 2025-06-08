using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeZoneAPI.Data;
using SafeZoneAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeZoneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbrigoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AbrigoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abrigo>>> GetAll()
        {
            return await _context.Abrigos.ToListAsync();
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
       public async Task<ActionResult<Abrigo>> Create(Abrigo abrigo)
       {
           _context.Abrigos.Add(abrigo);
           await _context.SaveChangesAsync();
           return CreatedAtAction(nameof(GetById), new { id = abrigo.Id }, abrigo);
       }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Abrigo abrigo)
        {
            if (id != abrigo.Id) return BadRequest();
            _context.Entry(abrigo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var abrigo = await _context.Abrigos.FindAsync(id);
            if (abrigo == null) return NotFound();
            _context.Abrigos.Remove(abrigo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
