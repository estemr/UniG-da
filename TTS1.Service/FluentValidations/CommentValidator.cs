using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.Entities;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Service.FluentValidations
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(100)
                .WithName("Başlık");
            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(1)
                .MaximumLength(5000)
                .WithName("Yorum");
        }
    }
}
