using AutoMapper;
using TTS.Entity.DTOs.Lojistik.Transports;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Service.AutoMapper.Lojistik.Transports
{
    public class TransportProfile : Profile
    {
        public TransportProfile()
        {
            CreateMap<TransportDto, Transport>().ReverseMap();
            CreateMap<TransportUpdateDto, Transport>().ReverseMap();
            CreateMap<TransportUpdateDto, TransportDto>().ReverseMap();
            CreateMap<TransportAddDto, Transport>().ReverseMap();
        }
    }
}
