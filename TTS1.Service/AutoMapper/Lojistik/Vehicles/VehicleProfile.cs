using AutoMapper;
using TTS.Entity.DTOs.Lojistik.Vehicles;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Service.AutoMapper.Lojistik.Vehicles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<VehicleUpdateDto, Vehicle>().ReverseMap();
            CreateMap<VehicleUpdateDto, VehicleDto>().ReverseMap();
            CreateMap<VehicleAddDto, Vehicle>().ReverseMap();
        }
    }
}
