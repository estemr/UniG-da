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
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator() 
        {
            RuleFor(x => x.Plate)
              .NotEmpty()
              .NotNull()
              .MinimumLength(7)
              .MaximumLength(10)
              .WithName("Plaka");
            RuleFor(x => x.Model)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithName("Model");
            RuleFor(x => x.DriverName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithName("Sürücü İsmi");
        }
    }
}
