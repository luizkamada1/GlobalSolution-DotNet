using System.ComponentModel.DataAnnotations;

namespace globalsolution.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }

        [MaxLength(20)]
        public string? Telefone { get; set; }

        [Required]
        [MaxLength(20)]
        public string TipoUsuario { get; set; } // 'morador', 'voluntario', 'autoridade'

        [MaxLength(100)]
        public string? Bairro { get; set; }

        [MaxLength(100)]
        public string? Cidade { get; set; }

        [MaxLength(10)]
        public string? Cep { get; set; }

        // Relacionamentos
        public virtual ICollection<PedidoAjuda>? PedidosAjuda { get; set; }
        public virtual ICollection<Relato>? Relatos { get; set; }
        public virtual Voluntario? Voluntario { get; set; }
        public virtual ICollection<UsuarioAbrigado>? UsuariosAbrigados { get; set; }
    }
}
