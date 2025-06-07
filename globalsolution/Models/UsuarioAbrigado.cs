using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace globalsolution.Models
{
    public class UsuarioAbrigado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public int IdAbrigo { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; }

        public DateTime? DataSaida { get; set; }

        // Relacionamentos
        [ForeignKey("IdUsuario")]
        [ValidateNever]
        public virtual Usuario? Usuario { get; set; }

        [ForeignKey("IdAbrigo")]
        [ValidateNever]
        public virtual Abrigo? Abrigo { get; set; }
    }
}