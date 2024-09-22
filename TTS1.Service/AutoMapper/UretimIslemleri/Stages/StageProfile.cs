using AutoMapper;
using TTS.Entity.DTOs.UretimIslemleri.Stages;
using TTS.Entity.Entities.UretimIslemleri;

namespace TTS.Service.AutoMapper.UretimIslemleri.Stages
{
    public class StageProfile : Profile
    {
        public StageProfile()
        {
            CreateMap<StageDto, Stage>().ReverseMap();
            CreateMap<StageUpdateDto, Stage>().ReverseMap();
            CreateMap<StageUpdateDto, StageDto>().ReverseMap();
            CreateMap<StageAddDto, Stage>().ReverseMap();
        }
    }
}
