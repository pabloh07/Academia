using academia_console.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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

    public class AcademiaContextFactory : IDesignTimeDbContextFactory<AcademiaContext>
    {
        public AcademiaContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Database=academia_console;User=root;Password=12345678;";
            return new AcademiaContext(connectionString);
        }
    }

}
