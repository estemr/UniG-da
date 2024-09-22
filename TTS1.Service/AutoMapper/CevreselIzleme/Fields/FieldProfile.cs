using AutoMapper;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.CevreselIzleme.Sensors;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Service.AutoMapper.CevreselIzleme.Fields
{
    public class FieldProfile : Profile
    {
        public FieldProfile()
        {
            CreateMap<FieldDto, Field>().ReverseMap();
            CreateMap<FieldUpdateDto, Field>().ReverseMap();
            CreateMap<FieldUpdateDto, FieldDto>().ReverseMap();
            CreateMap<FieldAddDto, Field>().ReverseMap();
        }
    }
}
