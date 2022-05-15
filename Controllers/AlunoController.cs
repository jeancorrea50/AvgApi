using AvgApi.Data;
using AvgApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AvgContext _context;

        public AlunoController(AvgContext context)
        {
            _context=context;
        }

        ////Get api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> Index()
        {
            return (await _context.Alunos.ToListAsync());
        }


        //Get api/Professor/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            return (await _context.Alunos.FindAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAluno", new Aluno { Id = aluno.Id }, aluno);
        }

        [HttpPut]
        public async Task<ActionResult> PutAluno(int id, Aluno aluno)
        {
            try
            {
                if (id != aluno.Id) return BadRequest();

                _context.Entry(aluno).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception)
            {
                if (!ExitsAluno(id)) return NotFound(); else throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();

            _context.Remove(aluno);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ExitsAluno(int id)
        {
            return _context.Alunos.Any(p => p.Id == id);
        }


    }

}
