using globalsolution.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Relato
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int IdUsuario { get; set; }

    [Required]
    [MaxLength(50)]
    public string? TipoRelato { get; set; }

    [Required]
    public string? Descricao { get; set; }

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

    [MaxLength(255)]
    public string? MidiaUrl { get; set; }

    [ForeignKey("IdUsuario")]
    [ValidateNever]
    public virtual Usuario? Usuario { get; set; }
}
