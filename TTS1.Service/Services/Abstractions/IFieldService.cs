using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Service.Services.Abstractions
{
    public interface IFieldService
    {
        Task<List<FieldDto>> GetAllFieldsWithUserNonDeletedAsync();
        Task<List<FieldDto>> GetAllFieldsNonDeletedAsync();
        Task<List<FieldDto>> GetAllFieldsDeletedAsync();
        Task CreateFieldAsync(FieldAddDto fieldAddDto);
        Task<Field> GetFieldByGuid(Guid id);
        Task<string> UpdateFieldAsync(FieldUpdateDto fieldUpdateDto);
        Task<string> SafeDeleteFieldAsync(Guid fieldId);
        Task<string> UndoDeleteFieldAsync(Guid fieldId);
    }
}
