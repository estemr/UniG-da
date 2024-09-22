using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TTS.Entity.DTOs.Lojistik.Vehicles;
using TTS.Entity.Entities.Lojistik;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Service.Services.Concretes;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;

namespace TTS.Web.Areas.Admin.Controllers.Lojistik
{
    [Area("Admin")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IMapper mapper;
        private readonly IValidator<Vehicle> validator;
        private readonly IToastNotification toast;

        public VehicleController(IVehicleService vehicleService, IMapper mapper, IValidator<Vehicle> validator, IToastNotification toast)
        {
            this.vehicleService = vehicleService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var vehicles = await vehicleService.GetAllVehiclesNonDeletedAsync();
            return View(vehicles);
        }

        public async Task<IActionResult> IndexForUser()
        {
            var fields = await vehicleService.GetAllVehiclesWithUserNonDeletedAsync();
            return View(fields);
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedVehicle()
        {
            var vehicles = await vehicleService.GetAllVehiclesDeletedAsync();
            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleAddDto vehicleAddDto)
        {
            var map = mapper.Map<Vehicle>(vehicleAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await vehicleService.CreateVehicleAsync(vehicleAddDto);
                toast.AddSuccessToastMessage(Messages.Vehicles.Add(vehicleAddDto.Plate), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Vehicle", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Vehicle", new { Area = "Admin" });
                }
            }
            result.AddToModelState(ModelState);
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid vehicleId)
        {
            var vehicle = await vehicleService.GetVehicleByGuid(vehicleId);
            var map = mapper.Map<Vehicle, VehicleUpdateDto>(vehicle);


            return View(map);
        }

        [HttpPost]

        public async Task<IActionResult> Update(VehicleUpdateDto vehicleUpdateDto)
        {
            var map = mapper.Map<Vehicle>(vehicleUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await vehicleService.UpdateVehicleAsync(vehicleUpdateDto);
                toast.AddSuccessToastMessage(Messages.Vehicles.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Vehicle", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Vehicle", new { Area = "Admin" });
                }
            }
            result.AddToModelState(ModelState);
            return View();
        }

        public async Task<IActionResult> Delete(Guid vehicleId)
        {
            var name = await vehicleService.SafeDeleteVehicleAsync(vehicleId);
            toast.AddSuccessToastMessage(Messages.Vehicles.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Vehicle", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Vehicle", new { Area = "Admin" });
            }
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid vehicleId)
        {
            var name = await vehicleService.UndoDeleteVehicleAsync(vehicleId);
            toast.AddSuccessToastMessage(Messages.Vehicles.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Vehicle", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Vehicle", new { Area = "Admin" });
            }
        }
    }
}
