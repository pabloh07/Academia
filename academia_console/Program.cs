using ConsoleAcademia.Controllers;
using Microsoft.Extensions.Configuration;
using academia_console.Data;

// Carrega config
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = config.GetConnectionString("DefaultConnection");

// Cria contexto e garante banco criado
using var context = new AcademiaContext(connectionString);
context.Database.EnsureCreated();

var controller = new AlunoController(context);

while (true)
{
    Console.WriteLine("\n[1] Criar | [2] Listar | [3] Atualizar | [4] Excluir | [0] Sair");
    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            controller.CriarAluno(nome, email);
            break;

        case "2":
            controller.ListarAlunos();
            break;

        case "3":
            Console.Write("ID do aluno: ");
            int idAtt = int.Parse(Console.ReadLine());
            Console.Write("Novo nome: ");
            string nomeAtt = Console.ReadLine();
            Console.Write("Novo email: ");
            string emailAtt = Console.ReadLine();
            controller.AtualizarAluno(idAtt, nomeAtt, emailAtt);
            break;

        case "4":
            Console.Write("ID do aluno para excluir: ");
            int idDel = int.Parse(Console.ReadLine());
            controller.ExcluirAluno(idDel);
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}
