using academia_console.Data;
using academia_console.Models;

namespace ConsoleAcademia.Controllers
{
    public class AlunoController
    {
        private readonly AcademiaContext _context;

        public AlunoController(AcademiaContext context)
        {
            _context = context;
        }

        public void CriarAluno(string nome, string email)
        {
            var aluno = new Aluno { Nome = nome, Email = email };
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            Console.WriteLine("Aluno cadastrado com sucesso!");
        }

        public void ListarAlunos()
        {
            var alunos = _context.Alunos.ToList();
            Console.WriteLine("Lista de Alunos:");
            foreach (var aluno in alunos)
                Console.WriteLine($"{aluno.Id} - {aluno.Nome} ({aluno.Email})");
        }

        public void AtualizarAluno(int id, string novoNome, string novoEmail)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            aluno.Nome = novoNome;
            aluno.Email = novoEmail;
            _context.SaveChanges();
            Console.WriteLine("Aluno atualizado com sucesso!");
        }

        public void ExcluirAluno(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            Console.WriteLine("Aluno removido com sucesso!");
        }
    }
}
