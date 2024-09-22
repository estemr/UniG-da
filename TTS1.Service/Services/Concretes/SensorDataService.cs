using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.CevreselIzleme.SensorDatas;
using TTS.Entity.DTOs.CevreselIzleme.Sensors;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{
    public class SensorDataService : ISensorDataService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public SensorDataService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task CreateSensorDataAsync(SensorDataAddDto sensorDataAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            
            var sensorData = new SensorData(sensorDataAddDto.SensorId, sensorDataAddDto.Value, sensorDataAddDto.Unit, sensorDataAddDto.Timestamp, userEmail);
            await unitOfWork.GetRepository<SensorData>().AddAsync(sensorData);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<SensorDataDto>> GetAllSensorDatasWithSensorUserNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var sensorDatas = await unitOfWork.GetRepository<SensorData>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail, x => x.Sensor);
            var map = mapper.Map<List<SensorDataDto>>(sensorDatas);

            return map;
        }

        public async Task<List<SensorDataDto>> GetAllSensorDatasWithSensorsDeletedAsync()
        {
            var sensorDatas = await unitOfWork.GetRepository<SensorData>().GetAllAsync(x => x.IsDeleted, x => x.Sensor);
            var map = mapper.Map<List<SensorDataDto>>(sensorDatas);

            return map;
        }

        public async Task<List<SensorDataDto>> GetAllSensorDatasWithSensorsNonDeletedAsync()
        {
            var sensorDatas = await unitOfWork.GetRepository<SensorData>().GetAllAsync(x => !x.IsDeleted, x => x.Sensor);
            var map = mapper.Map<List<SensorDataDto>>(sensorDatas);

            return map;
        }

        public async Task<SensorDataDto> GetSensorDataWithSensorNonDeletedAsync(Guid sensorDataId)
        {
            var sensorData = await unitOfWork.GetRepository<SensorData>().GetAsync(x => !x.IsDeleted && x.Id == sensorDataId, x => x.Sensor);
            var map = mapper.Map<SensorDataDto>(sensorData);

            return map;
        }

        public async Task<string> SafeDeleteSensorDataAsync(Guid sensorDataId)
        {
            var sensorData = await unitOfWork.GetRepository<SensorData>().GetByGuidAsync(sensorDataId);

            sensorData.IsDeleted = true;
            sensorData.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<SensorData>().UpdateAsync(sensorData);
            await unitOfWork.SaveAsync();

            return sensorData.Timestamp.ToLongDateString();
        }

        public async Task<string> UndoDeleteSensorDataAsync(Guid sensorDataId)
        {
            var sensorData = await unitOfWork.GetRepository<SensorData>().GetByGuidAsync(sensorDataId);

            sensorData.IsDeleted = false;
            sensorData.DeletedDate = null;
            sensorData.DeletedBy = null;

            await unitOfWork.GetRepository<SensorData>().UpdateAsync(sensorData);
            await unitOfWork.SaveAsync();

            return sensorData.Timestamp.ToLongDateString();
        }

        public async Task<string> UpdateSensorDataAsync(SensorDataUpdateDto sensorDataUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var sensorData = await unitOfWork.GetRepository<SensorData>().GetAsync(x => !x.IsDeleted && x.Id == sensorDataUpdateDto.Id, x => x.Sensor);


            sensorData.Value = sensorDataUpdateDto.Value;
            sensorData.Unit = sensorDataUpdateDto.Unit;
            sensorData.SensorId = sensorDataUpdateDto.SensorId;
            sensorData.Timestamp = sensorDataUpdateDto.Timestamp;
            sensorData.ModifiedDate = DateTime.Now;
            sensorData.ModifiedBy = userEmail;

            await unitOfWork.GetRepository<SensorData>().UpdateAsync(sensorData);
            await unitOfWork.SaveAsync();

            return sensorData.Timestamp.ToLongDateString();
        }
    }
}

