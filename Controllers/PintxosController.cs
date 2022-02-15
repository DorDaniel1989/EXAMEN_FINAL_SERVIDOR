using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiExamen.Modelos;

namespace Final1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PintxosController : ControllerBase
    {
        private readonly ApiContext _context;

        public PintxosController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Pintxos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pintxo>>> GetPintxos()
        {
            return await _context.Pintxos.ToListAsync();
        }

        // GET: api/Pintxos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pintxo>> GetPintxo(int id)
        {
            var pintxo = await _context.Pintxos.FindAsync(id);

            if (pintxo == null)
            {
                return NotFound();
            }

            return pintxo;
        }

        // PUT: api/Pintxos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPintxo(int id, Pintxo pintxo)
        {
            if (id != pintxo.PintxoId)
            {
                return BadRequest();
            }

            _context.Entry(pintxo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PintxoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pintxos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pintxo>> PostPintxo(Pintxo pintxo)
        {
            _context.Pintxos.Add(pintxo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PintxoExists(pintxo.PintxoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPintxo", new { id = pintxo.PintxoId }, pintxo);
        }

        // DELETE: api/Pintxos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePintxo(int id)
        {
            var pintxo = await _context.Pintxos.FindAsync(id);
            if (pintxo == null)
            {
                return NotFound();
            }

            _context.Pintxos.Remove(pintxo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PintxoExists(int id)
        {
            return _context.Pintxos.Any(e => e.PintxoId == id);
        }
    }
}
