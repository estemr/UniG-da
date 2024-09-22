using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TTS.Entity.DTOs.CevreselIzleme.Sensors;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;
using static TTS.Web.ResultMessages.Messages;

namespace TTS.Web.Areas.Admin.Controllers.CevreselIzleme
{
    [Area("Admin")]
    public class SensorController : Controller
    {
        private readonly ISensorService sensorService;
        private readonly IFieldService fieldService;
        private readonly IMapper mapper;
        private readonly IValidator<Sensor> validator;
        private readonly IToastNotification toast;

        public SensorController(ISensorService sensorService, IFieldService fieldService, IMapper mapper, IValidator<Sensor> validator, IToastNotification toast)
        {
            this.sensorService = sensorService;
            this.fieldService = fieldService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Index()
        {
            var sensors = await sensorService.GetAllSensorsWithFieldsNonDeletedAsync();
            return View(sensors);
        }
        public async Task<IActionResult> IndexForUser()
        {
            var sensors = await sensorService.GetAllSensorWithFieldUserNonDeletedAsync();
            return View(sensors);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedSensor()
        {
            var sensors = await sensorService.GetAllSensorsWithFiledsDeletedAsync();
            return View(sensors);
        }

        [HttpGet]
   
        public async Task<IActionResult> Add()
        {
            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                var fields = await fieldService.GetAllFieldsNonDeletedAsync();
                return View(new SensorAddDto { Fields = fields });
            }
            else
            {
                var fields = await fieldService.GetAllFieldsWithUserNonDeletedAsync();
                return View(new SensorAddDto { Fields = fields });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(SensorAddDto sensorAddDto)
        {
            var map = mapper.Map<Sensor>(sensorAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await sensorService.CreateSensorAsync(sensorAddDto);
                toast.AddSuccessToastMessage(Messages.Sensors.Add(sensorAddDto.Name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Sensor", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Sensor", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var fields = await fieldService.GetAllFieldsWithUserNonDeletedAsync();
            return View(new SensorAddDto { Fields = fields });
        }


        [HttpGet]
       
        public async Task<IActionResult> Update(Guid sensorId)
        {
            var sensor = await sensorService.GetSensorWithFieldNonDeletedAsync(sensorId);
            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                var fields = await fieldService.GetAllFieldsNonDeletedAsync();
                var sensorUpdateDto = mapper.Map<SensorUpdateDto>(sensor);
                sensorUpdateDto.Fields = fields;
                return View(sensorUpdateDto);
            }
            else
            {
                var fields = await fieldService.GetAllFieldsWithUserNonDeletedAsync();
                var sensorUpdateDto = mapper.Map<SensorUpdateDto>(sensor);
                sensorUpdateDto.Fields = fields;
                return View(sensorUpdateDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(SensorUpdateDto sensorUpdateDto)
        {
            var map = mapper.Map<Sensor>(sensorUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await sensorService.UpdateSensorAsync(sensorUpdateDto);
                toast.AddSuccessToastMessage(Messages.Sensors.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Sensor", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Sensor", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var fields = await fieldService.GetAllFieldsNonDeletedAsync();
            sensorUpdateDto.Fields = fields;

            return View(sensorUpdateDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid sensorId)
        {
            var name = await sensorService.SafeDeleteSensorAsync(sensorId);
            toast.AddSuccessToastMessage(Messages.Sensors.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Sensor", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Sensor", new { Area = "Admin" });
            }
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> UndoDelete(Guid sensorId)
        {
            var name = await sensorService.UndoDeleteSensorAsync(sensorId);
            toast.AddSuccessToastMessage(Messages.Sensors.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Sensor", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Sensor", new { Area = "Admin" });
            }
        }
    }
}
