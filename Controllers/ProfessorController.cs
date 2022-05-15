
using AvgApi.Data;
using AvgApi.Models;
using AvgApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvgApi.Controllers
{   [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly AvgContext _context;

        public ProfessorController(AvgContext context)
        {
            _context=context;
        }

        //Get api/Professor 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> Index()
        {
        //return  (await _professorRepository.Professores);
        //https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/async/task-asynchronous-programming-model
            return (await _context.Professores.ToListAsync());
        }

        //Get api/Professor/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            return await _context.Professores.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> PostProfessor(Professor professor)
        {
            _context.Professores.Add(professor);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessor", new Professor { Id = professor.Id}, professor); 
        }

        [HttpPut]
        public async Task<ActionResult> PutProfessor(int id,Professor professor)
        {
            try
            {
                if (id != professor.Id) return BadRequest();

                _context.Entry(professor).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception)
            {
                if (!ExistsProfessor(id)) return NotFound(); else throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProfessor(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if(professor == null) return NotFound();

            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ExistsProfessor(int id)
        {
          return _context.Professores.Any(p => p.Id == id);
        }
    }
}
