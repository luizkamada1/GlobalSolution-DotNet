using System.ComponentModel.DataAnnotations;

namespace globalsolution.Models
{
    public class Abrigo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public int CapacidadeTotal { get; set; }

        [Required]
        public int CapacidadeAtual { get; set; }

        public string? Recursos { get; set; }

        // Relacionamentos
        public virtual ICollection<UsuarioAbrigado>? UsuariosAbrigados { get; set; }
    }
}
