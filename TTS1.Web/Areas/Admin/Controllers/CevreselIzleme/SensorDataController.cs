using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TTS.Entity.DTOs.CevreselIzleme.SensorDatas;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Service.Services.Concretes;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;

namespace TTS.Web.Areas.Admin.Controllers.CevreselIzleme
{
    [Area("Admin")]
    public class SensorDataController : Controller
    {
        private readonly ISensorDataService sensorDataService;
        private readonly ISensorService sensorService;
        private readonly IMapper mapper;
        private readonly IValidator<SensorData> validator;
        private readonly IToastNotification toast;

        public SensorDataController(ISensorDataService sensorDataService, ISensorService sensorService, IMapper mapper, IValidator<SensorData> validator, IToastNotification toast)
        {
            this.sensorDataService = sensorDataService;
            this.sensorService = sensorService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Index()
        {
            var sensorData = await sensorDataService.GetAllSensorDatasWithSensorsNonDeletedAsync();
            return View(sensorData);
        }
        public async Task<IActionResult> IndexForUser()
        {
            var fields = await sensorDataService.GetAllSensorDatasWithSensorUserNonDeletedAsync();
            return View(fields);
        }


        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedSensorData()
        {
            var sensorDatas = await sensorDataService.GetAllSensorDatasWithSensorsDeletedAsync();
            return View(sensorDatas);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var sensors = await sensorService.GetAllSensorWithFieldUserNonDeletedAsync();
            return View(new SensorDataAddDto { Sensors = sensors });
        }

        [HttpPost]
        public async Task<IActionResult> Add(SensorDataAddDto sensorDataAddDto)
        {
            var map = mapper.Map<SensorData>(sensorDataAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await sensorDataService.CreateSensorDataAsync(sensorDataAddDto);
                toast.AddSuccessToastMessage(Messages.SensorDatas.Add(sensorDataAddDto.Timestamp.ToLongDateString()), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "SensorData", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "SensorData", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var sensors = await sensorService.GetAllSensorsWithFieldsNonDeletedAsync();
            return View(new SensorDataAddDto { Sensors = sensors });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid sensorDataId)
        {
            var sensorData = await sensorDataService.GetSensorDataWithSensorNonDeletedAsync(sensorDataId);
            var sensors = await sensorService.GetAllSensorWithFieldUserNonDeletedAsync();

            var sensorDataUpdateDto = mapper.Map<SensorDataUpdateDto>(sensorData);
            sensorDataUpdateDto.Sensors = sensors;

            return View(sensorDataUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SensorDataUpdateDto sensorDataUpdateDto)
        {
            var map = mapper.Map<SensorData>(sensorDataUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await sensorDataService.UpdateSensorDataAsync(sensorDataUpdateDto);
                toast.AddSuccessToastMessage(Messages.SensorDatas.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "SensorData", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "SensorData", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var sensors = await sensorService.GetAllSensorsWithFieldsNonDeletedAsync();
            sensorDataUpdateDto.Sensors = sensors;

            return View(sensorDataUpdateDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid sensorDataId)
        {
            var name = await sensorDataService.SafeDeleteSensorDataAsync(sensorDataId);
            toast.AddSuccessToastMessage(Messages.SensorDatas.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "SensorData", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "SensorData", new { Area = "Admin" });
            }
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> UndoDelete(Guid sensorDataId)
        {
            var name = await sensorDataService.UndoDeleteSensorDataAsync(sensorDataId);
            toast.AddSuccessToastMessage(Messages.SensorDatas.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "SensorData", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "SensorData", new { Area = "Admin" });
            }
        }
    }
}
