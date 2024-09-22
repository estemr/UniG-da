using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Service.FluentValidations
{
    public class PackageValidator : AbstractValidator<Package>
    {
        public PackageValidator()
        {
            RuleFor(x => x.Type)
              .NotEmpty()
              .NotNull()
              .MinimumLength(2)
              .MaximumLength(50)
              .WithName("Tür");
        }
    }
}
