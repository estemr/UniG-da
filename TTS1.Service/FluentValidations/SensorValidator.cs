using FluentValidation;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Service.FluentValidations
{
    public class SensorValidator : AbstractValidator<Sensor>
    {
        public SensorValidator()
        {
            RuleFor(x=> x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("İsim");
            RuleFor(x=>x.Type)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("Tip");
        }
    }
}
