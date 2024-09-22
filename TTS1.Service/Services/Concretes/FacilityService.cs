using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.UretimIslemleri.Facilities;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.UretimIslemleri;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{
    public class FacilityService : IFacilityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public FacilityService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateFacilityAsync(FacilityAddDto facilityAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            Facility facility = new(facilityAddDto.Name, facilityAddDto.Location, userEmail);
            await unitOfWork.GetRepository<Facility>().AddAsync(facility);
            await unitOfWork.SaveAsync();
        }
        public async Task<List<FacilityDto>> GetAllFacilitesDeletedAsync()
        {
            var facilities = await unitOfWork.GetRepository<Facility>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<FacilityDto>>(facilities);

            return map;
        }

        public async Task<List<FacilityDto>> GetAllFacilitiesNonDeletedAsync()
        {
            var facilities = await unitOfWork.GetRepository<Facility>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<FacilityDto>>(facilities);

            return map;
        }

        public async Task<List<FacilityDto>> GetAllFacilitiesWithUserNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var facilities = await unitOfWork.GetRepository<Facility>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail);
            var map = mapper.Map<List<FacilityDto>>(facilities);

            return map;
        }

        public async Task<Facility> GetFacilityByGuid(Guid id)
        {
            var facility = await unitOfWork.GetRepository<Facility>().GetByGuidAsync(id);
            return facility;
        }

        public async Task<string> SafeDeleteFacilityAsync(Guid facilityId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var facility = await unitOfWork.GetRepository<Facility>().GetByGuidAsync(facilityId);

            facility.IsDeleted = true;
            facility.DeletedDate = DateTime.Now;
            facility.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Facility>().UpdateAsync(facility);
            await unitOfWork.SaveAsync();

            return facility.Name;
        }

        public async Task<string> UndoDeleteFacilityAsync(Guid facilityId)
        {
            var facility = await unitOfWork.GetRepository<Facility>().GetByGuidAsync(facilityId);

            facility.IsDeleted = false;
            facility.DeletedDate = null;
            facility.DeletedBy = null;

            await unitOfWork.GetRepository<Facility>().UpdateAsync(facility);
            await unitOfWork.SaveAsync();

            return facility.Name;
        }

        public async Task<string> UpdateFacilityAsync(FacilityUpdateDto facilityUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var facility = await unitOfWork.GetRepository<Facility>().GetAsync(x => !x.IsDeleted && x.Id == facilityUpdateDto.Id);

            facility.Name = facilityUpdateDto.Name;
            facility.Location = facilityUpdateDto.Location;
            facility.ModifiedBy = userEmail;
            facility.ModifiedDate = DateTime.Now;

            await unitOfWork.GetRepository<Facility>().UpdateAsync(facility);
            await unitOfWork.SaveAsync();

            return facility.Name;
        }
    }
}
