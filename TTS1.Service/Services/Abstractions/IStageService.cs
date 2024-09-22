using TTS.Entity.DTOs.UretimIslemleri.Stages;

namespace TTS.Service.Services.Abstractions
{
    public interface IStageService
    {
        Task<List<StageDto>> GetStageByProductIdForUserAsync(Guid productId);
        Task<List<StageDto>> GetStageByProductIdAsync(Guid productId);
        Task<List<StageDto>> GetAllStagesWithProductsNonDeletedAsync();
        Task<List<StageDto>> GetAllStagesWithProductsUserNonDeletedAsync();
        Task<List<StageDto>> GetAllStagesWithProductsDeletedAsync();
        Task CreateStageAsync(StageAddDto stageAddDto);
        Task<StageDto> GetStageWithProductNonDeletedAsync(Guid stageId);
        Task<string> UpdateStageAsync(StageUpdateDto stageUpdateDto);
        Task<string> SafeDeleteStageAsync(Guid stageId);
        Task<string> UndoDeleteStageAsync(Guid stageId);
    }
}
