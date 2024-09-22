using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.CevreselIzleme.Sensors;

namespace TTS.Service.Services.Abstractions
{
    public interface ISensorService
    {
        Task<List<SensorDto>> GetAllSensorsWithFieldsNonDeletedAsync();
        Task<List<SensorDto>> GetAllSensorWithFieldUserNonDeletedAsync();
        Task<List<SensorDto>> GetAllSensorsWithFiledsDeletedAsync();
        Task CreateSensorAsync(SensorAddDto sensorAddDto);
        Task<SensorDto> GetSensorWithFieldNonDeletedAsync(Guid sensorId);
        Task<string> UpdateSensorAsync(SensorUpdateDto sensorUpdateDto);
        Task<string> SafeDeleteSensorAsync(Guid sensorId);
        Task<string> UndoDeleteSensorAsync(Guid sensorId);
    }
}
