using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.Lojistik.Packages;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Lojistik;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{
    public class PackageService : IPackageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public PackageService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task CreatePackageAsync(PackageAddDto packageAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            packageAddDto.PackagingDate = DateTime.Now;

            Package package = new(packageAddDto.Type, packageAddDto.Number, packageAddDto.PackagingDate, userEmail);
            await unitOfWork.GetRepository<Package>().AddAsync(package);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<PackageDto>> GetAllPackagesDeletedAsync()
        {
            var packages = await unitOfWork.GetRepository<Package>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<PackageDto>>(packages);

            return map;
        }

        public async Task<List<PackageDto>> GetAllPackagesNonDeletedAsync()
        {
            var packages = await unitOfWork.GetRepository<Package>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<PackageDto>>(packages);
            return map;
        }

        public async Task<List<PackageDto>> GetAllPackagesWithUserNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var fields = await unitOfWork.GetRepository<Package>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail);
            var map = mapper.Map<List<PackageDto>>(fields);

            return map;
        }

        public async Task<Package> GetPackageNonDeletedAsync(Guid packageId)
        {
            var package = await unitOfWork.GetRepository<Package>().GetByGuidAsync(packageId);
            return package;
        }

        public async Task<string> SafeDeletePackageAsync(Guid packageId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var package = await unitOfWork.GetRepository<Package>().GetByGuidAsync(packageId);

            package.IsDeleted = true;
            package.DeletedDate = DateTime.Now;
            package.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Package>().UpdateAsync(package);
            await unitOfWork.SaveAsync();

            return package.Type;
        }

        public async Task<string> UndoDeletePackageAsync(Guid packageId)
        {
            var package = await unitOfWork.GetRepository<Package>().GetByGuidAsync(packageId);

            package.IsDeleted = false;
            package.DeletedDate = null;
            package.DeletedBy = null;

            await unitOfWork.GetRepository<Package>().UpdateAsync(package);
            await unitOfWork.SaveAsync();

            return package.Type;
        }

        public async Task<string> UpdatePackageAsync(PackageUpdateDto packageUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var package = await unitOfWork.GetRepository<Package>().GetAsync(x => !x.IsDeleted && x.Id == packageUpdateDto.Id);

            package.Type = packageUpdateDto.Type;
            package.Number = packageUpdateDto.Number;
            package.PackagingDate = packageUpdateDto.PackagingDate;
            package.ModifiedBy = userEmail;
            package.ModifiedDate = DateTime.Now;

            await unitOfWork.GetRepository<Package>().UpdateAsync(package);
            await unitOfWork.SaveAsync();

            return package.Type;
        }
    }
}
