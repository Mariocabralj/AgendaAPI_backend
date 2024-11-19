using FluentValidation;
namespace AgendaAPI.Models.Pessoas;

public class PessoasValidacao : AbstractValidator <AgendaInfos>
{
    public PessoasValidacao(AgendaInfos agendaInfos) 
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome não pode ser vazio.")
            .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O email não pode ser vazio.")
            .MaximumLength(150).WithMessage("O email deve ter no máximo 150 caracteres");
        RuleFor(x => x.Telefone)
            .NotEmpty().WithMessage("O telefone não pode ser vazio.")
            .MinimumLength(8).MaximumLength(50).WithMessage("O telefone deve conter entre 8 a 50 dígitos. Digite um número válido");
    }
}