using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Service.FluentValidations
{
    public class FieldValidator : AbstractValidator<Field>
    {
        public FieldValidator()
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
            RuleFor(x => x.Size)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0).WithMessage("Dönüm değeri 0' dan büyük olmalı.")
                .WithName("Dönüm");
            RuleFor(x => x.SoilType)
              .NotEmpty()
              .NotNull()
              .MinimumLength(2)
              .MaximumLength(50)
              .WithName("Toprak Türü");
        }
    }
}
