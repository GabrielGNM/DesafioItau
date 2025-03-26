using FluentValidation;

namespace DesafioItaú.Dto.Validators
{
    public class TrasacaoDtoValidator : AbstractValidator<TrasacaoDto>
    {
        public TrasacaoDtoValidator()
        {
            RuleFor(transacao => transacao.Valor)
                .Must(c => c >= 0)
                .WithMessage("Valor deve ser maior ou igual a 0.");

            RuleFor(transacao => transacao.DataHora)
                .Must(c => c < DateTime.Now)
                .WithMessage("Data não pode ser futura ou igual a atual");
        }
    }
}
