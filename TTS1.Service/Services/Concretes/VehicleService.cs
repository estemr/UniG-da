using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.Lojistik.Vehicles;
using TTS.Entity.Entities.Lojistik;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task CreateVehicleAsync(VehicleAddDto vehicleAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            Vehicle vehicle = new(vehicleAddDto.Plate, vehicleAddDto.Model, vehicleAddDto.DriverName, userEmail);
            await unitOfWork.GetRepository<Vehicle>().AddAsync(vehicle);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<VehicleDto>> GetAllVehiclesWithUserNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var vehicles = await unitOfWork.GetRepository<Vehicle>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail);
            var map = mapper.Map<List<VehicleDto>>(vehicles);

            return map;
        }

        public async Task<List<VehicleDto>> GetAllVehiclesDeletedAsync()
        {
            var vehicles = await unitOfWork.GetRepository<Vehicle>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<VehicleDto>>(vehicles);

            return map;
        }

        public async Task<List<VehicleDto>> GetAllVehiclesNonDeletedAsync()
        {
            var vehicles = await unitOfWork.GetRepository<Vehicle>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<VehicleDto>>(vehicles);

            return map;
        }

        public async Task<Vehicle> GetVehicleByGuid(Guid id)
        {
            var vehicle = await unitOfWork.GetRepository<Vehicle>().GetByGuidAsync(id);
            return vehicle;
        }

        public async Task<string> SafeDeleteVehicleAsync(Guid vehicleId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var vehicle = await unitOfWork.GetRepository<Vehicle>().GetByGuidAsync(vehicleId);

            vehicle.IsDeleted = true;
            vehicle.DeletedDate = DateTime.Now;
            vehicle.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Vehicle>().UpdateAsync(vehicle);
            await unitOfWork.SaveAsync();

            return vehicle.Plate;
        }

        public async Task<string> UndoDeleteVehicleAsync(Guid vehicleId)
        {
            var vehicle = await unitOfWork.GetRepository<Vehicle>().GetByGuidAsync(vehicleId);

            vehicle.IsDeleted = false;
            vehicle.DeletedDate = null;
            vehicle.DeletedBy = null;

            await unitOfWork.GetRepository<Vehicle>().UpdateAsync(vehicle);
            await unitOfWork.SaveAsync();

            return vehicle.Plate;
        }

        public async Task<string> UpdateVehicleAsync(VehicleUpdateDto vehicleUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var vehicle = await unitOfWork.GetRepository<Vehicle>().GetAsync(x => !x.IsDeleted && x.Id == vehicleUpdateDto.Id);

            

            vehicle.Plate = vehicleUpdateDto.Plate;
            vehicle.Model = vehicleUpdateDto.Model;
            vehicle.DriverName = vehicleUpdateDto.DriverName;
            vehicle.ModifiedBy = userEmail;
            vehicle.ModifiedDate = DateTime.Now;

            await unitOfWork.GetRepository<Vehicle>().UpdateAsync(vehicle);
            await unitOfWork.SaveAsync();

            return vehicle.Plate;
        }
    }
}
