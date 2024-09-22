using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Security.Claims;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.CevreselIzleme.Sensors;
using TTS.Entity.DTOs.UretimIslemleri.Stages;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Market;
using TTS.Entity.Entities.UretimIslemleri;
using TTS.Entity.Enums;
using TTS.Service.Extensions;
using TTS.Service.Helpers.Images;
using TTS.Service.Services.Abstractions;

namespace TTS.Service.Services.Concretes
{
    public class StageService : IStageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public StageService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task CreateStageAsync(StageAddDto stageAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            stageAddDto.Timestamp = DateTime.Now;
            var stage = new Stage(stageAddDto.Name, stageAddDto.Parameter, stageAddDto.Timestamp, stageAddDto.ProductId, userEmail);
            await unitOfWork.GetRepository<Stage>().AddAsync(stage);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<StageDto>> GetAllStagesWithProductsDeletedAsync()
        {
            var stages = await unitOfWork.GetRepository<Stage>().GetAllAsync(x => x.IsDeleted, x => x.Product);
            var map = mapper.Map<List<StageDto>>(stages);

            return map;
        }

        public async Task<List<StageDto>> GetAllStagesWithProductsNonDeletedAsync()
        {
            var stages = await unitOfWork.GetRepository<Stage>().GetAllAsync(x => !x.IsDeleted, x => x.Product);
            var map = mapper.Map<List<StageDto>>(stages);

            return map;
        }

        public async Task<List<StageDto>> GetAllStagesWithProductsUserNonDeletedAsync()
        {
            var userEmail = _user.GetLoggedInEmail();
            var stages = await unitOfWork.GetRepository<Stage>().GetAllAsync(x => !x.IsDeleted && x.CreatedBy == userEmail, x => x.Product);
            var map = mapper.Map<List<StageDto>>(stages);

            return map;
        }

        public async Task<List<StageDto>> GetStageByProductIdAsync(Guid productId)
        {
            var stages = await unitOfWork.GetRepository<Stage>().GetAllAsync(x => !x.IsDeleted && x.ProductId == productId, x => x.Product);
            var map = mapper.Map<List<StageDto>>(stages);
            return map;
        }
        public async Task<List<StageDto>> GetStageByProductIdForUserAsync(Guid productId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var stages = await unitOfWork.GetRepository<Stage>().GetAllAsync(x => !x.IsDeleted && x.ProductId == productId && x.CreatedBy == userEmail, x => x.Product);
            var map = mapper.Map<List<StageDto>>(stages);
            return map;
        }

        public async Task<StageDto> GetStageWithProductNonDeletedAsync(Guid stageId)
        {
            var stage = await unitOfWork.GetRepository<Stage>().GetAsync(x => !x.IsDeleted && x.Id == stageId, x => x.Product);
            var map = mapper.Map<StageDto>(stage);

            return map;
        }

        public async Task<string> SafeDeleteStageAsync(Guid stageId)
        {
            var stage = await unitOfWork.GetRepository<Stage>().GetByGuidAsync(stageId);

            stage.IsDeleted = true;
            stage.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Stage>().UpdateAsync(stage);
            await unitOfWork.SaveAsync();

            return stage.Name;
        }

        public async Task<string> UndoDeleteStageAsync(Guid stageId)
        {
            var stage = await unitOfWork.GetRepository<Stage>().GetByGuidAsync(stageId);

            stage.IsDeleted = false;
            stage.DeletedDate = null;
            stage.DeletedBy = null;

            await unitOfWork.GetRepository<Stage>().UpdateAsync(stage);
            await unitOfWork.SaveAsync();

            return stage.Name;
        }

        public async Task<string> UpdateStageAsync(StageUpdateDto stageUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var stage = await unitOfWork.GetRepository<Stage>().GetAsync(x => !x.IsDeleted && x.Id == stageUpdateDto.Id, x => x.Product);

            stage.Name = stageUpdateDto.Name;
            stage.Parameter = stageUpdateDto.Parameter;
            stage.Timestamp = DateTime.Now;
            stage.ProductId = stageUpdateDto.ProductId;
            stage.ModifiedDate = DateTime.Now;
            stage.ModifiedBy = userEmail;

            await unitOfWork.GetRepository<Stage>().UpdateAsync(stage);
            await unitOfWork.SaveAsync();

            return stage.Name;
        }
    }
}
