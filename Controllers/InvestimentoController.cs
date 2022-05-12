using AvgApi.Data;
using AvgApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {

        private readonly AvgContext _context;

        public InvestimentoController(AvgContext context)
        {
            _context = context;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investimento>>> GetInvestimentos()
        {
            return (await _context.Investimentos.OrderBy(x => x.Id).AsNoTracking().ToListAsync());
        }


        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Investimento>> GetInvestimentos(int id)
        {
            var investimento = await _context.Investimentos.FindAsync(id);

            if (investimento == null)
            {
                return NotFound();
            }

            return investimento;
        }

        // PUT: api/Categoria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestimentos(int id, Investimento investimento)
        {
            if (id != investimento.Id)
            {
                return BadRequest();
            }

            _context.Entry(investimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestimentosExists(id))
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

        // POST: api/Categoria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Investimento>> PostInvestimentos(Investimento investimento)
        {
            _context.Investimentos.Add(investimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvestimentos", new { id = investimento.Id }, investimento);
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestimentos(int id)
        {
            var investimento = await _context.Investimentos.FindAsync(id);
            if (investimento == null)
            {
                return NotFound();
            }

            _context.Investimentos.Remove(investimento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvestimentosExists(int id)
        {
            return _context.Investimentos.Any(e => e.Id == id);
        }
    }
}
