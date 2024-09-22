using AutoMapper;
using TTS.Entity.DTOs.CevreselIzleme.SensorDatas;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Service.AutoMapper.CevreselIzleme.SensorDatas
{
    public class SensorDataProfile : Profile
    {
        public SensorDataProfile()
        {
            CreateMap<SensorDataDto, SensorData>().ReverseMap();
            CreateMap<SensorDataUpdateDto, SensorData>().ReverseMap();
            CreateMap<SensorDataUpdateDto, SensorDataDto>().ReverseMap();
            CreateMap<SensorDataAddDto, SensorData>().ReverseMap();
        }
    }
}
