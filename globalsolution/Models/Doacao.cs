using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace globalsolution.Models
{
    public class Doacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdVoluntario { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; } // alimento, água, roupa, colchão, outro

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime Data { get; set; }

        // Relacionamento
        [ForeignKey("IdVoluntario")]
        [ValidateNever]
        public virtual Voluntario? Voluntario { get; set; }
    }
}
