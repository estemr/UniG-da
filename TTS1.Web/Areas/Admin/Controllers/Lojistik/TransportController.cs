using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TTS.Entity.DTOs.Lojistik.Transports;
using TTS.Entity.Entities.Lojistik;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;
using static TTS.Web.ResultMessages.Messages;

namespace TTS.Web.Areas.Admin.Controllers.Lojistik
{
    [Area("Admin")]
    public class TransportController : Controller
    {
        private readonly ITransportService transportService;
        private readonly IProductService productService;
        private readonly IPackageService packageService;
        private readonly IVehicleService vehicleService;
        private readonly IFieldService fieldService;
        private readonly IFacilityService facilityService;
        private readonly IMapper mapper;
        private readonly IValidator<Transport> validator;
        private readonly IToastNotification toast;

        public TransportController(ITransportService transportService, IProductService productService, IPackageService packageService, IVehicleService vehicleService, IFieldService fieldService, IFacilityService facilityService, IMapper mapper, IValidator<Transport> validator, IToastNotification toast)
        {
            this.transportService = transportService;
            this.productService = productService;
            this.packageService = packageService;
            this.vehicleService = vehicleService;
            this.fieldService = fieldService;
            this.facilityService = facilityService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Index()
        {
            var transports = await transportService.GetAllTransportsWithVehiclesFieldsFacilitiesProductsPackagesNonDeletedAsync();
            return View(transports);
        }
        public async Task<IActionResult> IndexForUser()
        {
            var transports = await transportService.GetAllTransportsWithUserFieldsVehiclesFacilitiesProductsPackagesNonDeletedAsync();
            return View(transports);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedTransport()
        {
            var transports = await transportService.GetAllTransportsWithVehiclesFieldsFacilitiesProductsPackagesDeletedAsync();
            return View(transports);
        }

        [HttpGet]

        public async Task<IActionResult> Add()
        {
            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                var vehicles = await vehicleService.GetAllVehiclesNonDeletedAsync();
                var fields = await fieldService.GetAllFieldsNonDeletedAsync();
                var facilities = await facilityService.GetAllFacilitiesNonDeletedAsync();
                var packages = await packageService.GetAllPackagesNonDeletedAsync();
                var products = await productService.GetAllProductsNonDeletedAsync();
                return View(new TransportAddDto { Vehicles = vehicles, Fields = fields, Facilities = facilities, Packages = packages, Products = products });
            }
            else
            {
                var vehicles = await vehicleService.GetAllVehiclesWithUserNonDeletedAsync();
                var fields = await fieldService.GetAllFieldsWithUserNonDeletedAsync();
                var facilities = await facilityService.GetAllFacilitiesWithUserNonDeletedAsync();
                var packages = await packageService.GetAllPackagesWithUserNonDeletedAsync();
                var products = await productService.GetAllProductsWithUserNonDeletedAsync();
                return View(new TransportAddDto { Vehicles = vehicles, Fields = fields, Facilities = facilities, Packages = packages, Products = products });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(TransportAddDto transportAddDto)
        {
            var map = mapper.Map<Transport>(transportAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await transportService.CreateTransportAsync(transportAddDto);
                toast.AddSuccessToastMessage(Messages.Transports.Add(transportAddDto.Name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Transport", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Transport", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var vehicles = await vehicleService.GetAllVehiclesNonDeletedAsync();
            var fields = await fieldService.GetAllFieldsNonDeletedAsync();
            var facilities = await facilityService.GetAllFacilitiesNonDeletedAsync();
            var packages = await packageService.GetAllPackagesNonDeletedAsync();
            var products = await productService.GetAllProductsNonDeletedAsync();
            return View(new TransportAddDto { Vehicles = vehicles, Fields = fields, Facilities = facilities, Packages = packages, Products = products });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid transportId)
        {

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                var transport = await transportService.GetTransportWithVehicleFieldFacilityProductPackageNonDeletedAsync(transportId);
                var fields = await fieldService.GetAllFieldsNonDeletedAsync();
                var facilities = await facilityService.GetAllFacilitiesNonDeletedAsync();
                var vehicles = await vehicleService.GetAllVehiclesNonDeletedAsync();
                var packages = await packageService.GetAllPackagesNonDeletedAsync();
                var products = await productService.GetAllProductsNonDeletedAsync();

                var transportUpdateDto = mapper.Map<TransportUpdateDto>(transport);
                transportUpdateDto.Fields = fields;
                transportUpdateDto.Vehicles = vehicles;
                transportUpdateDto.Facilities = facilities;
                transportUpdateDto.Packages = packages;
                transportUpdateDto.Products = products;

                return View(transportUpdateDto);
            }
            else
            {
                var transport = await transportService.GetTransportWithVehicleFieldFacilityProductPackageNonDeletedAsync(transportId);
                var fields = await fieldService.GetAllFieldsWithUserNonDeletedAsync();
                var facilities = await facilityService.GetAllFacilitiesWithUserNonDeletedAsync();
                var vehicles = await vehicleService.GetAllVehiclesWithUserNonDeletedAsync();
                var packages = await packageService.GetAllPackagesWithUserNonDeletedAsync();
                var products = await productService.GetAllProductsWithUserNonDeletedAsync();

                var transportUpdateDto = mapper.Map<TransportUpdateDto>(transport);
                transportUpdateDto.Fields = fields;
                transportUpdateDto.Vehicles = vehicles;
                transportUpdateDto.Facilities = facilities;
                transportUpdateDto.Packages = packages;
                transportUpdateDto.Products = products;

                return View(transportUpdateDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(TransportUpdateDto transportUpdateDto)
        {
            var map = mapper.Map<Transport>(transportUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await transportService.UpdateTransportAsync(transportUpdateDto);
                toast.AddSuccessToastMessage(Messages.Transports.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Transport", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Transport", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var fields = await fieldService.GetAllFieldsWithUserNonDeletedAsync();
            var facilities = await facilityService.GetAllFacilitiesNonDeletedAsync();
            var vehicles = await vehicleService.GetAllVehiclesNonDeletedAsync();
            var packages = await packageService.GetAllPackagesNonDeletedAsync();
            var products = await productService.GetAllProductsNonDeletedAsync();

            transportUpdateDto.Fields = fields;
            transportUpdateDto.Vehicles = vehicles;
            transportUpdateDto.Facilities = facilities;
            transportUpdateDto.Packages = packages;
            transportUpdateDto.Products = products;

            return View(transportUpdateDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid transportId)
        {
            var name = await transportService.SafeDeleteTransportAsync(transportId);
            toast.AddSuccessToastMessage(Messages.Transports.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Transport", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Transport", new { Area = "Admin" });
            }
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid transportId)
        {
            var name = await transportService.UndoDeleteTransportAsync(transportId);
            toast.AddSuccessToastMessage(Messages.Transports.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Transport", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Transport", new { Area = "Admin" });
            }
        }
        public async Task<IActionResult> IndexByProduct(Guid productId)
        {
            var transports = await transportService.GetTransportByProductIdAsync(productId);
            return View(transports);

        }
    }
}
