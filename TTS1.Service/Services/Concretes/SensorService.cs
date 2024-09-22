using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.CevreselIzleme.Sensors;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Identity;
using TTS.Entity.Enums;
using TTS.Service.Extensions;
using TTS.Service.Helpers.Images;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{

    public class SensorService : ISensorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public SensorService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.imageHelper = imageHelper;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateSensorAsync(SensorAddDto sensorAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var createdDate = DateTime.Now;
            var sensor = new Sensor(sensorAddDto.Name, sensorAddDto.Type, sensorAddDto.FieldId, createdDate, userEmail);
            await unitOfWork.GetRepository<Sensor>().AddAsync(sensor);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<SensorDto>> GetAllSensorsWithFieldsNonDeletedAsync()
        {
            var sensors = await unitOfWork.GetRepository<Sensor>().GetAllAsync(x => !x.IsDeleted, x => x.Field, i => i.Image);
            var map = mapper.Map<List<SensorDto>>(sensors);

            return map;
        }

        public async Task<List<SensorDto>> GetAllSensorWithFieldUserNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var sensors = await unitOfWork.GetRepository<Sensor>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail, x=>x.Field, i => i.Image);
            var map = mapper.Map<List<SensorDto>>(sensors);

            return map;
        }

        public async Task<SensorDto> GetSensorWithFieldNonDeletedAsync(Guid sensorId)
        {
            var sensor = await unitOfWork.GetRepository<Sensor>().GetAsync(x => !x.IsDeleted && x.Id == sensorId, x => x.Field, i => i.Image);
            var map = mapper.Map<SensorDto>(sensor);

            return map;
        }


        public async Task<string> UpdateSensorAsync(SensorUpdateDto sensorUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var sensor = await unitOfWork.GetRepository<Sensor>().GetAsync(x => !x.IsDeleted && x.Id == sensorUpdateDto.Id, x => x.Field, i => i.Image);

           

            sensor.Name = sensorUpdateDto.Name;
            sensor.Type = sensorUpdateDto.Type;
            sensor.FieldId = sensorUpdateDto.FieldId;
            sensor.ModifiedDate = DateTime.Now;
            sensor.ModifiedBy = userEmail;

            await unitOfWork.GetRepository<Sensor>().UpdateAsync(sensor);
            await unitOfWork.SaveAsync();

            return sensor.Name;
        }

        public async Task<string> SafeDeleteSensorAsync(Guid sensorId)
        {
            var userEmail = _user.GetLoggedInEmail();

            var sensor = await unitOfWork.GetRepository<Sensor>().GetByGuidAsync(sensorId);

            sensor.IsDeleted = true;
            sensor.DeletedDate = DateTime.Now;
            sensor.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Sensor>().UpdateAsync(sensor);
            await unitOfWork.SaveAsync();

            return sensor.Name;
        }

        public async Task<List<SensorDto>> GetAllSensorsWithFiledsDeletedAsync()
        {
            var sensors = await unitOfWork.GetRepository<Sensor>().GetAllAsync(x => x.IsDeleted, x => x.Field);
            var map = mapper.Map<List<SensorDto>>(sensors);

            return map;
        }

        public async Task<string> UndoDeleteSensorAsync(Guid sensorId)
        {
            var sensor = await unitOfWork.GetRepository<Sensor>().GetByGuidAsync(sensorId);

            sensor.IsDeleted = false;
            sensor.DeletedDate = null;
            sensor.DeletedBy = null;

            await unitOfWork.GetRepository<Sensor>().UpdateAsync(sensor);
            await unitOfWork.SaveAsync();

            return sensor.Name;
        }
    }
}
