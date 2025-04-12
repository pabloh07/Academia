using academia_console.Models;
using Microsoft.EntityFrameworkCore;

namespace academia_console.Data
{
    public class AcademiaContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        private readonly string _connectionString;

        public AcademiaContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }
}
