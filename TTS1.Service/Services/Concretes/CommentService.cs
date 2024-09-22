using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.Yorum;
using TTS.Entity.Entities;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateCommentAsync(CommentAddDto commentAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var comments = new Comment(commentAddDto.Title, commentAddDto.Content, commentAddDto.ProductId, userEmail);
            await unitOfWork.GetRepository<Comment>().AddAsync(comments);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<CommentDto>> GetAllCommentsDeletedAsync()
        {
            var comments = await unitOfWork.GetRepository<Comment>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<CommentDto>>(comments);

            return map;
        }


        public async Task<List<CommentDto>> GetAllCommentsWithProductNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var comments = await unitOfWork.GetRepository<Comment>().GetAllAsync(x => !x.IsDeleted, x => x.Product);
            var map = mapper.Map<List<CommentDto>>(comments);

            return map;
        }

        public async Task<List<CommentDto>> GetAllCommentsWithProductUserNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var comments = await unitOfWork.GetRepository<Comment>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail);
            var map = mapper.Map<List<CommentDto>>(comments);

            return map;
        }

        public async Task<Comment> GetCommentByGuid(Guid id)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(id);
            return comment;
        }

        public async Task<string> SafeDeleteCommentAsync(Guid commentId)
        {
            var userEmail = _user.GetLoggedInEmail();

            var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(commentId);

            comment.IsDeleted = true;
            comment.DeletedDate = DateTime.Now;
            comment.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

            return comment.Title;
        }

        public async Task<string> UndoDeleteCommentAsync(Guid commentId)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetByGuidAsync(commentId);

            comment.IsDeleted = false;
            comment.DeletedDate = null;
            comment.DeletedBy = null;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

            return comment.Title;
        }

        public async Task<string> UpdateCommentAsync(CommentUpdateDto commentUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(x => !x.IsDeleted && x.Id == commentUpdateDto.Id, x => x.Product);

            comment.Title = commentUpdateDto.Title;
            comment.Content = commentUpdateDto.Content;
            comment.ProductId = commentUpdateDto.ProductId;
            comment.ModifiedDate = DateTime.Now;
            comment.ModifiedBy = userEmail;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

            return comment.Title;
        }
    }
}
