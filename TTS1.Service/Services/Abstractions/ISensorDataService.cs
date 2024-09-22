using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.CevreselIzleme.SensorDatas;
using TTS.Entity.DTOs.CevreselIzleme.Sensors;

namespace TTS.Service.Services.Abstractions
{
    public interface ISensorDataService
    {
        Task<List<SensorDataDto>> GetAllSensorDatasWithSensorsNonDeletedAsync();
        Task<List<SensorDataDto>> GetAllSensorDatasWithSensorUserNonDeletedAsync();
        Task<List<SensorDataDto>> GetAllSensorDatasWithSensorsDeletedAsync();
        Task CreateSensorDataAsync(SensorDataAddDto sensorDataAddDto);
        Task<SensorDataDto> GetSensorDataWithSensorNonDeletedAsync(Guid sensorDataId);
        Task<string> UpdateSensorDataAsync(SensorDataUpdateDto sensorDataUpdateDto);
        Task<string> SafeDeleteSensorDataAsync(Guid sensorDataId);
        Task<string> UndoDeleteSensorDataAsync(Guid sensorDataId);
    }
}
