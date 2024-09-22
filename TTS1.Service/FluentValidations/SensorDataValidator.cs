using FluentValidation;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Service.FluentValidations
{
    public class SensorDataValidator : AbstractValidator<SensorData>
    {
        public SensorDataValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(100)
                .WithName("Değer");
            RuleFor(x => x.Unit)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(10)
                .WithName("Birim");
        }
    }
}
