using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TTS.Entity.DTOs.UretimIslemleri.Stages;
using TTS.Entity.Entities.UretimIslemleri;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Service.Services.Concretes;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;

namespace TTS.Web.Areas.Admin.Controllers.UretimIslemleri
{
    [Area("Admin")]
    public class StageController : Controller
    {
        private readonly IStageService stageService;
        private readonly IProductService productService;
        private readonly IMapper mapper;
        private readonly IValidator<Stage> validator;
        private readonly IToastNotification toast;

        public StageController(IStageService stageService, IProductService productService, IMapper mapper, IValidator<Stage> validator, IToastNotification toast)
        {
            this.stageService = stageService;
            this.productService = productService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var stages = await stageService.GetAllStagesWithProductsNonDeletedAsync();
            return View(stages);
        }

        public async Task<IActionResult> IndexForUser()
        {
            var stages = await stageService.GetAllStagesWithProductsUserNonDeletedAsync();
            return View(stages);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedStage()
        {
            var stages = await stageService.GetAllStagesWithProductsDeletedAsync();
            return View(stages);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                var products = await productService.GetAllProductsNonDeletedAsync();
                return View(new StageAddDto { Products = products });
            }
            else
            {
                var products = await productService.GetAllProductsWithUserNonDeletedAsync();
                return View(new StageAddDto { Products = products });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(StageAddDto stageAddDto)
        {
            var map = mapper.Map<Stage>(stageAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await stageService.CreateStageAsync(stageAddDto);
                toast.AddSuccessToastMessage(Messages.Stages.Add(stageAddDto.Name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Stage", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Stage", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var products = await productService.GetAllProductsNonDeletedAsync();
            return View(new StageAddDto { Products = products });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid stageId)
        {
            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                var stage = await stageService.GetStageWithProductNonDeletedAsync(stageId);
                var products = await productService.GetAllProductsNonDeletedAsync();

                var stageUpdateDto = mapper.Map<StageUpdateDto>(stage);
                stageUpdateDto.Products = products;

                return View(stageUpdateDto);
            }
            else
            {
                var stage = await stageService.GetStageWithProductNonDeletedAsync(stageId);
                var products = await productService.GetAllProductsWithUserNonDeletedAsync();

                var stageUpdateDto = mapper.Map<StageUpdateDto>(stage);
                stageUpdateDto.Products = products;

                return View(stageUpdateDto);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(StageUpdateDto stageUpdateDto)
        {
            var map = mapper.Map<Stage>(stageUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await stageService.UpdateStageAsync(stageUpdateDto);
                toast.AddSuccessToastMessage(Messages.Stages.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Stage", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Stage", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var products = await productService.GetAllProductsNonDeletedAsync();
            stageUpdateDto.Products = products;

            return View(stageUpdateDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid stageId)
        {
            var name = await stageService.SafeDeleteStageAsync(stageId);
            toast.AddSuccessToastMessage(Messages.Stages.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Stage", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Stage", new { Area = "Admin" });
            }
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid stageId)
        {
            var name = await stageService.UndoDeleteStageAsync(stageId);
            toast.AddSuccessToastMessage(Messages.Stages.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Stage", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Stage", new { Area = "Admin" });
            }
        }
        public async Task<IActionResult> IndexByProduct(Guid productId)
        {
            //if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            //{
            //    var stages = await stageService.GetStageByProductIdAsync(productId);
            //    return View(stages);
            //}
            //else
            //{
            //    var stages = await stageService.GetStageByProductIdForUserAsync(productId);
            //    return View(stages);
            //}

            var stages = await stageService.GetStageByProductIdAsync(productId);
            return View(stages);
        }

    }
}
