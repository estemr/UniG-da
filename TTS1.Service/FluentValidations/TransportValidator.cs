using FluentValidation;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Service.FluentValidations
{
    public class TransportValidator : AbstractValidator<Transport>
    {
        public TransportValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .NotNull()
              .MinimumLength(1)
              .MaximumLength(100)
              .WithName("İsim");
        }
    }
}
