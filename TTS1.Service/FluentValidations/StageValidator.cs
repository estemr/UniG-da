using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.UretimIslemleri;

namespace TTS.Service.FluentValidations
{
    public class StageValidator : AbstractValidator<Stage>
    {
        public StageValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("İsim");
            RuleFor(x => x.Parameter)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithName("İsim");

        }
    }
}
