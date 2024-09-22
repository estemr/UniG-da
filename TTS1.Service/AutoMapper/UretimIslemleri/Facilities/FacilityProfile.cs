using AutoMapper;
using TTS.Entity.DTOs.UretimIslemleri.Facilities;
using TTS.Entity.Entities.UretimIslemleri;

namespace TTS.Service.AutoMapper.UretimIslemleri.Facilities
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
            CreateMap<FacilityDto, Facility>().ReverseMap();
            CreateMap<FacilityUpdateDto, Facility>().ReverseMap();
            CreateMap<FacilityUpdateDto, FacilityDto>().ReverseMap();
            CreateMap<FacilityAddDto, Facility>().ReverseMap();
        }
    }
}
