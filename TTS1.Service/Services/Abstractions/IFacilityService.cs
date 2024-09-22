using TTS.Entity.DTOs.UretimIslemleri.Facilities;
using TTS.Entity.Entities.UretimIslemleri;

namespace TTS.Service.Services.Abstractions
{
    public interface IFacilityService
    {
        Task<List<FacilityDto>> GetAllFacilitiesNonDeletedAsync();
        Task<List<FacilityDto>> GetAllFacilitiesWithUserNonDeletedAsync();
        Task<List<FacilityDto>> GetAllFacilitesDeletedAsync();
        Task CreateFacilityAsync(FacilityAddDto facilityAddDto);
        Task<Facility> GetFacilityByGuid(Guid id);
        Task<string> UpdateFacilityAsync(FacilityUpdateDto facilityUpdateDto);
        Task<string> SafeDeleteFacilityAsync(Guid facilityId);
        Task<string> UndoDeleteFacilityAsync(Guid facilityId);
    }
}
