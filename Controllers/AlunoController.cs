using AvgApi.Data;
using AvgApi.Models;
using AvgApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace AvgApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AvgContext _context;
        private readonly IAlunoRepository _AlunoRepository;
        public AlunoController(AvgContext context, IAlunoRepository _AlunoRepo)
        {
            _context = context;
            _AlunoRepository = _AlunoRepo;
        }

        ////Get api/Aluno
        [HttpGet]
        public async Task<ActionResult> Get() 
        {
            //return (await _context.Alunos.OrderBy(x => x.Id).Include(x => x.).Include(x => x.Professors).ToListAsync());
            //return (await _context.Alunos.OrderBy(x => x.Id).Where(aluno => aluno.Disciplina.Any(ad => ad.ProfessorId == ProfessorId).ToListAsync();

             try
            {
                var result = await _AlunoRepository.GetAllAlunosAsync(true);
                 return Ok(result);
                }
              catch (Exception ex)
                {
                 return BadRequest($"Erro: {ex.Message}");
            }

        }

        //Get api/Professor/1
        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> GetByAlunoId(int AlunoId)
        {

            try
            {
                var result = await _AlunoRepository.GetAlunoAsyncById(AlunoId, true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpGet("ObterPorPalavraChave/{palavraChave}")]
        public ActionResult ObterPorPalavraChave(string palavraChave)
        {

            try
            {
                var result =  _AlunoRepository.ObterPorPalavraChave(palavraChave);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpGet("ObterPorPalavraChaveTESTE/{palavraChave}")]
        public ActionResult ObterPorPalavraChaveTESTE(string palavraChave)
        {

            try
            {
                var result = _AlunoRepository.ObterPorPalavraChaveIntStringData(palavraChave);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpGet("ByDisciplina/{disciplinaId}")]
        public async Task<IActionResult> GetByDisciplinaId(int disciplinaId)
        {
            try
            {
                var result = await _AlunoRepository.GetAlunosAsyncByDisciplinaId(disciplinaId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAluno(Aluno model)
        {
            try
            {
                _context.Add(model);
               await _context.SaveChangesAsync();
               return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{alunoId}")]
        public async Task<ActionResult> PutAluno(int alunoId, Aluno model)
        {

            try
            {
                IQueryable<Aluno> query = _context.Alunos;


                query = query.Include(a => a.AlunosDisciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(d => d.Professor);

                query = query.AsNoTracking()
                                .OrderBy(aluno => aluno.Id)
                                .Where(aluno => aluno.Id == alunoId);

                var result = query.FirstOrDefaultAsync();


                if (model == null)
                {
                    return NotFound();
                }

                _context.Update(model);
                await _context.SaveChangesAsync();
                  return Ok("Deletado") ;
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpDelete("{alunoId}")]
        public async Task<ActionResult> DeleteAluno(int alunoId)
        {
            try
            {
                var aluno = await _AlunoRepository.GetAlunoAsyncById(alunoId, false);
                if (aluno == null) return NotFound();

                _AlunoRepository.DeleteAluno(alunoId);

                if (await _AlunoRepository.SaveChangesAsync());
                {
                    return Ok("Deletado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }




    }

}
