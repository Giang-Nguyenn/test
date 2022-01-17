using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimsController : ControllerBase
    {
        private readonly DemoDBContext _context;

        public SimsController(DemoDBContext context)
        {
            _context = context;
        }

        // GET: api/Sims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sim>>> GetSims()
        {
            return await _context.Sims.ToListAsync();
        }

        // GET: api/Sims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sim>> GetSim(int id)
        {
            var sim = await _context.Sims.FindAsync(id);

            if (sim == null)
            {
                return NotFound();
            }

            return sim;
        }

        // PUT: api/Sims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSim(int id, Sim sim)
        {
            if (id != sim.Id)
            {
                return BadRequest();
            }

            _context.Entry(sim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimExists(id))
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

        // POST: api/Sims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sim>> PostSim(Sim sim)
        {
            _context.Sims.Add(sim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSim", new { id = sim.Id }, sim);
        }

        // DELETE: api/Sims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSim(int id)
        {
            var sim = await _context.Sims.FindAsync(id);
            if (sim == null)
            {
                return NotFound();
            }

            _context.Sims.Remove(sim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SimExists(int id)
        {
            return _context.Sims.Any(e => e.Id == id);
        }
    }
}
