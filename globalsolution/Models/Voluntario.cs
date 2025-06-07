using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace globalsolution.Models
{
    public class Voluntario
    {
        [Key]
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        [MaxLength(50)]
        public string? Especialidade { get; set; }

        [MaxLength(20)]
        public string? Disponibilidade { get; set; }

        [ForeignKey("IdUsuario")]
        [ValidateNever]
        public virtual Usuario? Usuario { get; set; }

        public virtual ICollection<Doacao>? Doacoes { get; set; }
    }
}
