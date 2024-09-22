using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TTS.Data.UnitOfWorks;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;

namespace TTS.Web.Areas.Admin.Controllers.CevreselIzleme
{
    [Area("Admin")]
    public class FieldController : Controller
    {
        private readonly IFieldService fieldService;
        private readonly IMapper mapper;
        private readonly IValidator<Field> validator;
        private readonly IToastNotification toast;
        public FieldController(IUnitOfWork unitOfWork, IFieldService fieldService, IMapper mapper, IValidator<Field> validator, IToastNotification toast)
        {
            this.fieldService = fieldService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Index()
        {
            var fields = await fieldService.GetAllFieldsNonDeletedAsync();
            return View(fields);
        }
        public async Task<IActionResult> IndexForUser()
        {
            var fields = await fieldService.GetAllFieldsWithUserNonDeletedAsync();
            return View(fields);
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedField()
        {
            var fields = await fieldService.GetAllFieldsDeletedAsync();
            return View(fields);
        }


        [HttpGet]

        public async Task<IActionResult> Add()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Add(FieldAddDto fieldAddDto)
        {
            var map = mapper.Map<Field>(fieldAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await fieldService.CreateFieldAsync(fieldAddDto);
                toast.AddSuccessToastMessage(Messages.Fields.Add(fieldAddDto.Name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Field", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Field", new { Area = "Admin" });
                }
            }
            result.AddToModelState(ModelState);
            return View();
        }


        [HttpGet]


        public async Task<IActionResult> Update(Guid fieldId)
        {
            var field = await fieldService.GetFieldByGuid(fieldId);
            var map = mapper.Map<Field, FieldUpdateDto>(field);


            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FieldUpdateDto fieldUpdateDto)
        {
            var map = mapper.Map<Field>(fieldUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await fieldService.UpdateFieldAsync(fieldUpdateDto);
                toast.AddSuccessToastMessage(Messages.Fields.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Field", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Field", new { Area = "Admin" });
                }
            }
            result.AddToModelState(ModelState);
            return View();
        }

        public async Task<IActionResult> Delete(Guid fieldId)
        {
            var name = await fieldService.SafeDeleteFieldAsync(fieldId);
            toast.AddSuccessToastMessage(Messages.Fields.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Field", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Field", new { Area = "Admin" });
            }
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> UndoDelete(Guid fieldId)
        {
            var name = await fieldService.UndoDeleteFieldAsync(fieldId);
            toast.AddSuccessToastMessage(Messages.Fields.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Field", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Field", new { Area = "Admin" });
            }
        }
    }
}
