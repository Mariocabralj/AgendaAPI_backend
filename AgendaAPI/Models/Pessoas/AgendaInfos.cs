using System.ComponentModel.DataAnnotations;

namespace AgendaAPI.Models.Pessoas;

public class AgendaInfos
{
    [Key]
    [Required]
    public Guid? PessoaId { get; set; } = Guid.NewGuid();
    public DateTime? DataCriacao { get; set; } = DateTime.Now;
    public bool? AtivoInativo { get; set; } = true;
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}