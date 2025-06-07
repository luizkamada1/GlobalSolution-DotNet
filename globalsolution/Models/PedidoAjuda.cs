using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace globalsolution.Models
{
    public class PedidoAjuda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [MaxLength(50)]
        public string? Latitude { get; set; }

        [MaxLength(50)]
        public string? Longitude { get; set; }

        public string? Endereco { get; set; }

        [MaxLength(100)]
        public string? Bairro { get; set; }

        [MaxLength(100)]
        public string? Cidade { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // 'pendente', 'em andamento', 'resolvido'

        // Relacionamento
        [ForeignKey("IdUsuario")]
        [ValidateNever] 
        public virtual Usuario? Usuario { get; set; }
    }
}
