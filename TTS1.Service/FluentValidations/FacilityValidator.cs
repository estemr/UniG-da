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
    public class FacilityValidator : AbstractValidator<Facility>
    {
        public FacilityValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .NotNull()
              .MinimumLength(2)
              .MaximumLength(50)
              .WithName("İsim");
            RuleFor(x => x.Location)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithName("Lokasyon");
        }
    
    }
}
