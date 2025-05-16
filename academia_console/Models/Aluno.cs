using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace academia_console.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
