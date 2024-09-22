using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.Entities;
using TTS.Entity.Entities.UretimIslemleri;

namespace TTS.Data.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(new Comment
            {
                Id = Guid.Parse("37BBD36A-3643-4168-8476-14D7945D25E1"),
                Title = "Her bilgiye ulaşmamız çok iyi",
                Content = "Her bilgiye ulaşmamız çok iyi",
                ProductId = Guid.Parse("971F7086-05E6-4C7A-92A8-216C924AFFDB"),
            },
            new Comment
            {
                Id = Guid.Parse("2DE2B4A1-43DC-4D67-9699-621C79F39F02"),
                Title = "Bu siteyi yapana çok teşekkürlerimi sunarım",
                Content = "Bu siteyi yapana çok teşekkürlerimi sunarım",
                ProductId = Guid.Parse("64EF8E12-5802-4295-B902-AB9E3F9F03BD"),
            });
        }
    }
}
