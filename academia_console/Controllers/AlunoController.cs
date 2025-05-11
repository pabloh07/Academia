using academia_console.Data;
using academia_console.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace academia_console.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AcademiaContext _context;

        public AlunoController(AcademiaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();
            return aluno;
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id) return BadRequest();

            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound();

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
