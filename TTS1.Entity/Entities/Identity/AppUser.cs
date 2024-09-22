using Microsoft.AspNetCore.Identity;
using TTS.Core.Entities;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Market;

namespace TTS.Entity.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("E5008BC7-140D-4DD9-A739-5EBF8EE01FA8");
        public Image Image { get; set; }

        public ICollection<Field> Fields { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
