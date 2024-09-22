using AutoMapper;
using TTS.Entity.DTOs.Yorum;
using TTS.Entity.Entities;

namespace TTS.Service.AutoMapper.Yorum
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<CommentUpdateDto, Comment>().ReverseMap();
            CreateMap<CommentUpdateDto, CommentDto>().ReverseMap();
            CreateMap<CommentAddDto, Comment>().ReverseMap();
        }
    }
}
