using TTS.Entity.DTOs.Lojistik.Packages;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Service.Services.Abstractions
{
    public interface IPackageService
    {
        Task<List<PackageDto>> GetAllPackagesNonDeletedAsync();
        Task<List<PackageDto>> GetAllPackagesWithUserNonDeletedAsync();
        Task<List<PackageDto>> GetAllPackagesDeletedAsync();
        Task CreatePackageAsync(PackageAddDto packageAddDto);
        Task<Package> GetPackageNonDeletedAsync(Guid packageId);
        Task<string> UpdatePackageAsync(PackageUpdateDto packageUpdateDto);
        Task<string> SafeDeletePackageAsync(Guid packageId);
        Task<string> UndoDeletePackageAsync(Guid packageId);
    }
}
