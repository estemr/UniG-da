using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.Lojistik.Transports;
using TTS.Entity.Entities.Lojistik;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{
    public class TransportService : ITransportService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public TransportService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<List<TransportDto>> GetTransportByProductIdAsync(Guid productId)
        {
            var transport = await unitOfWork.GetRepository<Transport>().GetAllAsync(x => !x.IsDeleted && x.ProductId == productId, x => x.Vehicle, x => x.Facility, x => x.Field, x => x.Package, x => x.Product);
            var map = mapper.Map<List<TransportDto>>(transport);
            return map;

        }

        public async Task<List<TransportDto>> GetTransportByProductIdForUserAsync(Guid productId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var transport = await unitOfWork.GetRepository<Transport>().GetAllAsync(x => !x.IsDeleted && x.ProductId == productId && x.CreatedBy == userEmail, x => x.Vehicle, x => x.Facility, x => x.Field, x => x.Package, x => x.Product);
            var map = mapper.Map<List<TransportDto>>(transport);
            return map;

        }

        public async Task CreateTransportAsync(TransportAddDto transportAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            transportAddDto.Timestamp = DateTime.Now;
            var transports = new Transport(transportAddDto.Name, transportAddDto.VehicleId, transportAddDto.FieldId, transportAddDto.FacilityId, transportAddDto.PackageId, transportAddDto.ProductId, transportAddDto.Timestamp, userEmail);
            await unitOfWork.GetRepository<Transport>().AddAsync(transports);
            await unitOfWork.SaveAsync();
        }



        public async Task<List<TransportDto>> GetAllTransportsWithVehiclesFieldsFacilitiesProductsPackagesDeletedAsync()
        {
            var transports = await unitOfWork.GetRepository<Transport>().GetAllAsync(x => x.IsDeleted, x => x.Vehicle, x => x.Facility, x => x.Field, x => x.Package, x => x.Product);
            var map = mapper.Map<List<TransportDto>>(transports);

            return map;
        }
        public async Task<List<TransportDto>> GetAllTransportsWithUserFieldsVehiclesFacilitiesProductsPackagesNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var transports = await unitOfWork.GetRepository<Transport>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail, x => x.Vehicle, x => x.Facility, x => x.Field, x => x.Package, x => x.Product);
            var map = mapper.Map<List<TransportDto>>(transports);

            return map;
        }

        public async Task<List<TransportDto>> GetAllTransportsWithVehiclesFieldsFacilitiesProductsPackagesNonDeletedAsync()
        {
            var transports = await unitOfWork.GetRepository<Transport>().GetAllAsync(x => !x.IsDeleted, x => x.Vehicle, x => x.Facility, x => x.Field, x => x.Package, x => x.Product);
            var map = mapper.Map<List<TransportDto>>(transports);

            return map;
        }

        public async Task<TransportDto> GetTransportWithVehicleFieldFacilityProductPackageNonDeletedAsync(Guid transportId)
        {
            var transport = await unitOfWork.GetRepository<Transport>().GetAsync(x => !x.IsDeleted && x.Id == transportId, x => x.Field, x => x.Facility, x => x.Vehicle, x => x.Package, x => x.Product);
            var map = mapper.Map<TransportDto>(transport);

            return map;
        }

        public async Task<string> SafeDeleteTransportAsync(Guid transportId)
        {
            var transport = await unitOfWork.GetRepository<Transport>().GetByGuidAsync(transportId);

            transport.IsDeleted = true;
            transport.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Transport>().UpdateAsync(transport);
            await unitOfWork.SaveAsync();

            return transport.Name;
        }

        public async Task<string> UndoDeleteTransportAsync(Guid transportId)
        {
            var transport = await unitOfWork.GetRepository<Transport>().GetByGuidAsync(transportId);

            transport.IsDeleted = false;
            transport.DeletedDate = null;
            transport.DeletedBy = null;

            await unitOfWork.GetRepository<Transport>().UpdateAsync(transport);
            await unitOfWork.SaveAsync();

            return transport.Name;
        }

        public async Task<string> UpdateTransportAsync(TransportUpdateDto transportUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var transport = await unitOfWork.GetRepository<Transport>().GetAsync(x => !x.IsDeleted && x.Id == transportUpdateDto.Id, x => x.Field, x => x.Facility, x => x.Vehicle, x => x.Package, x => x.Product);

            transport.Name = transportUpdateDto.Name;
            transport.VehicleId = transportUpdateDto.VehicleId;
            transport.FieldId = transportUpdateDto.FieldId;
            transport.FacilityId = transportUpdateDto.FacilityId;
            transport.PackageId = transportUpdateDto.PackageId;
            transport.ProductId = transportUpdateDto.ProductId;
            transport.Timestamp = DateTime.Now;
            transport.ModifiedDate = DateTime.Now;
            transport.ModifiedBy = userEmail;

            await unitOfWork.GetRepository<Transport>().UpdateAsync(transport);
            await unitOfWork.SaveAsync();

            return transport.Name;
        }
    }
}
