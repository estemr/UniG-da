using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Market;

namespace TTS.Service.FluentValidations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .NotNull()
              .MinimumLength(2)
              .MaximumLength(50)
              .WithName("İsim");
            RuleFor(x => x.Price)
              .NotEmpty()
              .NotNull()
              .WithName("Fiyat");
            RuleFor(x => x.Unit)
              .NotEmpty()
              .NotNull()
              .MinimumLength(2)
              .MaximumLength(50)
              .WithName("Birim");

        }
    }
}
