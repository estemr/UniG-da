using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.UretimIslemleri.Facilities;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.UretimIslemleri;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Service.Services.Concretes;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;

namespace TTS.Web.Areas.Admin.Controllers.UretimIslemleri
{
    [Area("Admin")]
    public class FacilityController : Controller
    {
        private readonly IFacilityService facilityService;
        private readonly IMapper mapper;
        private readonly IValidator<Facility> validator;
        private readonly IToastNotification toast;

        public FacilityController(IFacilityService facilityService, IMapper mapper, IValidator<Facility> validator, IToastNotification toast)
        {
            this.facilityService = facilityService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Index()
        {
            var facilities = await facilityService.GetAllFacilitiesNonDeletedAsync();
            return View(facilities);
        }

        public async Task<IActionResult> IndexForUser()
        {
            var facility = await facilityService.GetAllFacilitiesWithUserNonDeletedAsync();
            return View(facility);
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedFacility()
        {
            var facilities = await facilityService.GetAllFacilitesDeletedAsync();
            return View(facilities);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FacilityAddDto facilityAddDto)
        {
            var map = mapper.Map<Facility>(facilityAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await facilityService.CreateFacilityAsync(facilityAddDto);
                toast.AddSuccessToastMessage(Messages.Facilities.Add(facilityAddDto.Name), new ToastrOptions() { Title = "İşlem başarılı" });
                return RedirectToAction("Index", "Facility", new { Area = "Admin" });
            }
            result.AddToModelState(ModelState);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid facilityId)
        {
            var facility = await facilityService.GetFacilityByGuid(facilityId);
            var map = mapper.Map<Facility, FacilityUpdateDto>(facility);


            return View(map);
        }

        [HttpPost]

        public async Task<IActionResult> Update(FacilityUpdateDto facilityUpdateDto)
        {
            var map = mapper.Map<Facility>(facilityUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await facilityService.UpdateFacilityAsync(facilityUpdateDto);
                toast.AddSuccessToastMessage(Messages.Facilities.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                return RedirectToAction("Index", "Facility", new { Area = "Admin" });
            }
            result.AddToModelState(ModelState);
            return View();
        }

        public async Task<IActionResult> Delete(Guid facilityId)
        {
            var name = await facilityService.SafeDeleteFacilityAsync(facilityId);
            toast.AddSuccessToastMessage(Messages.Facilities.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            return RedirectToAction("Index", "Facility", new { Area = "Admin" });
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid facilityId)
        {
            var name = await facilityService.UndoDeleteFacilityAsync(facilityId);
            toast.AddSuccessToastMessage(Messages.Facilities.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            return RedirectToAction("Index", "Facility", new { Area = "Admin" });
        }
    }
}
