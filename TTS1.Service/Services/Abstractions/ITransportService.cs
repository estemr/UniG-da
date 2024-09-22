using TTS.Entity.DTOs.Lojistik.Transports;

namespace TTS.Service.Services.Abstractions
{
    public interface ITransportService
    {
        Task<List<TransportDto>> GetTransportByProductIdForUserAsync(Guid productId);
        Task<List<TransportDto>> GetTransportByProductIdAsync(Guid productId);
        Task<List<TransportDto>> GetAllTransportsWithVehiclesFieldsFacilitiesProductsPackagesNonDeletedAsync();
        Task<List<TransportDto>> GetAllTransportsWithUserFieldsVehiclesFacilitiesProductsPackagesNonDeletedAsync();
        Task<List<TransportDto>> GetAllTransportsWithVehiclesFieldsFacilitiesProductsPackagesDeletedAsync();
        Task CreateTransportAsync(TransportAddDto TransportAddDto);
        Task<TransportDto> GetTransportWithVehicleFieldFacilityProductPackageNonDeletedAsync(Guid TransportId);
        Task<string> UpdateTransportAsync(TransportUpdateDto TransportUpdateDto);
        Task<string> SafeDeleteTransportAsync(Guid TransportId);
        Task<string> UndoDeleteTransportAsync(Guid TransportId);
    }
}
