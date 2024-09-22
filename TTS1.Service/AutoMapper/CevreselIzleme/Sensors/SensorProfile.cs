using AutoMapper;
using TTS.Entity.DTOs.CevreselIzleme.Sensors;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Service.AutoMapper.CevreselIzleme.Sensors
{
    public class SensorProfile : Profile
    {
        public SensorProfile()
        {
            CreateMap<SensorDto, Sensor>().ReverseMap();
            CreateMap<SensorUpdateDto, Sensor>().ReverseMap();
            CreateMap<SensorUpdateDto, SensorDto>().ReverseMap();
            CreateMap<SensorAddDto, Sensor>().ReverseMap();
        }
    }
}
