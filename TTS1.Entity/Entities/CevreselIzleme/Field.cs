using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Core.Entities;
using TTS.Entity.Entities.Identity;
using TTS.Entity.Entities.Lojistik;
using TTS.Entity.Entities.Market;

namespace TTS.Entity.Entities.CevreselIzleme
{
    public class Field : EntityBase
    {
        public Field()
        {
        }

        public Field(string name, string location, double size, string soilType,string createdBy, Guid userId)
        {
            Name = name;
            Location = location;
            Size = size;
            CreatedBy = createdBy;
            SoilType = soilType;
            UserId = userId;
        }


        public string Name { get; set; }
        public string Location { get; set; }
        public double Size { get; set; }
        public string SoilType { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }
 
        public ICollection<Sensor> Sensors { get; set; }
        public ICollection<Transport> Transports { get; set; }
    }
}
