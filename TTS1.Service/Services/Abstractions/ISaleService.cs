using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.DTOs.Lojistik.Transports;

namespace TTS.Service.Services.Abstractions
{
    public interface ISaleService
    {
        Task<List<TransportDto>> GetAllTransportsWithVehiclesFieldsFacilitiesProductsPackagesNonDeletedAsync();
        Task<List<TransportDto>> GetAllTransportsWithVehiclesFieldsFacilitiesProductsPackagesDeletedAsync();
        Task CreateTransportAsync(TransportAddDto TransportAddDto);
        Task<TransportDto> GetTransportWithVehicleFieldFacilityProductPackageNonDeletedAsync(Guid TransportId);
        Task<string> UpdateTransportAsync(TransportUpdateDto TransportUpdateDto);
        Task<string> SafeDeleteTransportAsync(Guid TransportId);
        Task<string> UndoDeleteTransportAsync(Guid TransportId);
    }
}
