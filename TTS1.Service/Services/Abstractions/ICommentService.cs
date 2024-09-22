using TTS.Entity.DTOs.Yorum;
using TTS.Entity.Entities;

namespace TTS.Service.Services.Abstractions
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentsWithProductUserNonDeletedAsync();
        Task<List<CommentDto>> GetAllCommentsWithProductNonDeletedAsync();
        Task<List<CommentDto>> GetAllCommentsDeletedAsync();
        Task CreateCommentAsync(CommentAddDto commentAddDto);
        Task<Comment> GetCommentByGuid(Guid id);
        Task<string> UpdateCommentAsync(CommentUpdateDto commentUpdateDto);
        Task<string> SafeDeleteCommentAsync(Guid commentId);
        Task<string> UndoDeleteCommentAsync(Guid commentId);
    }
}
