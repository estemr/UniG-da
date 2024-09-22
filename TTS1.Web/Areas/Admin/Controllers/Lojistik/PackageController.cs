using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.Lojistik.Packages;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Lojistik;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Service.Services.Concretes;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;

namespace TTS.Web.Areas.Admin.Controllers.Lojistik
{
    [Area("Admin")]
    public class PackageController : Controller
    {
        private readonly IPackageService packageService;
        private readonly IMapper mapper;
        private readonly IValidator<Package> validator;
        private readonly IToastNotification toast;

        public PackageController(IPackageService packageService, IMapper mapper, IValidator<Package> validator, IToastNotification toast)
        {
            this.packageService = packageService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Index()
        {
            var packages = await packageService.GetAllPackagesNonDeletedAsync();
            return View(packages);
        }
        public async Task<IActionResult> IndexForUser()
        {
            var packages = await packageService.GetAllPackagesWithUserNonDeletedAsync();
            return View(packages);
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedPackage()
        {
            var packages = await packageService.GetAllPackagesDeletedAsync();
            return View(packages);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(PackageAddDto packageAddDto)
        {
            var map = mapper.Map<Package>(packageAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await packageService.CreatePackageAsync(packageAddDto);
                toast.AddSuccessToastMessage(Messages.Packages.Add(packageAddDto.Type), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Package", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Package", new { Area = "Admin" });
                }
            }
            result.AddToModelState(ModelState);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid packageId)
        {
            var package = await packageService.GetPackageNonDeletedAsync(packageId);
            var map = mapper.Map<Package, PackageUpdateDto>(package);

            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PackageUpdateDto packageUpdateDto)
        {
            var map = mapper.Map<Package>(packageUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await packageService.UpdatePackageAsync(packageUpdateDto);
                toast.AddSuccessToastMessage(Messages.Fields.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Package", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Package", new { Area = "Admin" });
                }
            }
            result.AddToModelState(ModelState);
            return View();
        }

        public async Task<IActionResult> Delete(Guid packageId)
        {
            var name = await packageService.SafeDeletePackageAsync(packageId);
            toast.AddSuccessToastMessage(Messages.Packages.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Package", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Package", new { Area = "Admin" });
            }
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> UndoDelete(Guid fieldId)
        {
            var name = await packageService.UndoDeletePackageAsync(fieldId);
            toast.AddSuccessToastMessage(Messages.Packages.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Package", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Package", new { Area = "Admin" });
            }
        }
    }
}

