using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.Lojistik.Vehicles;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Service.Services.Abstractions
{
    public interface IVehicleService
    {
        Task<List<VehicleDto>> GetAllVehiclesNonDeletedAsync();
        Task<List<VehicleDto>> GetAllVehiclesWithUserNonDeletedAsync();
        Task<List<VehicleDto>> GetAllVehiclesDeletedAsync();
        Task CreateVehicleAsync(VehicleAddDto vehicleAddDto);
        Task<Vehicle> GetVehicleByGuid(Guid id);
        Task<string> UpdateVehicleAsync(VehicleUpdateDto vehicleUpdateDto);
        Task<string> SafeDeleteVehicleAsync(Guid vehicleId);
        Task<string> UndoDeleteVehicleAsync(Guid vehicleId);
    }
}
