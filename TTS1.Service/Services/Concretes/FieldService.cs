using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Service.Extensions;
using TTS.Service.Helpers.Images;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{
    public class FieldService : IFieldService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public FieldService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task CreateFieldAsync(FieldAddDto fieldAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            Field field = new(fieldAddDto.Name, fieldAddDto.Location, fieldAddDto.Size, fieldAddDto.SoilType, userEmail, userId);
            await unitOfWork.GetRepository<Field>().AddAsync(field);
            await unitOfWork.SaveAsync();
        }
        public async Task<List<FieldDto>> GetAllFieldsNonDeletedAsync()
        {
            var fields = await unitOfWork.GetRepository<Field>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<FieldDto>>(fields);

            return map;
        }

        public async Task<List<FieldDto>> GetAllFieldsWithUserNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var fields = await unitOfWork.GetRepository<Field>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail);
            var map = mapper.Map<List<FieldDto>>(fields);

            return map;
        }

        public async Task<Field> GetFieldByGuid(Guid id)
        {
            var field = await unitOfWork.GetRepository<Field>().GetByGuidAsync(id);
            return field;
        }

        public async Task<string> UpdateFieldAsync(FieldUpdateDto fieldUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var field = await unitOfWork.GetRepository<Field>().GetAsync(x => !x.IsDeleted && x.Id == fieldUpdateDto.Id);

            field.Name = fieldUpdateDto.Name;
            field.Location = fieldUpdateDto.Location;
            field.Size = fieldUpdateDto.Size;
            field.SoilType = fieldUpdateDto.SoilType;
            field.ModifiedBy = userEmail;
            field.ModifiedDate = DateTime.Now;

            await unitOfWork.GetRepository<Field>().UpdateAsync(field);
            await unitOfWork.SaveAsync();

            return field.Name;
        }

        public async Task<string> SafeDeleteFieldAsync(Guid fieldId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var field = await unitOfWork.GetRepository<Field>().GetByGuidAsync(fieldId);

            field.IsDeleted = true;
            field.DeletedDate = DateTime.Now;
            field.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Field>().UpdateAsync(field);
            await unitOfWork.SaveAsync();

            return field.Name;
        }

        public async Task<List<FieldDto>> GetAllFieldsDeletedAsync()
        {
            var fields = await unitOfWork.GetRepository<Field>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<FieldDto>>(fields);

            return map;
        }

        public async Task<string> UndoDeleteFieldAsync(Guid fieldId)
        {
            var field = await unitOfWork.GetRepository<Field>().GetByGuidAsync(fieldId);

            field.IsDeleted = false;
            field.DeletedDate = null;
            field.DeletedBy = null;

            await unitOfWork.GetRepository<Field>().UpdateAsync(field);
            await unitOfWork.SaveAsync();

            return field.Name;
        }
    }
}
