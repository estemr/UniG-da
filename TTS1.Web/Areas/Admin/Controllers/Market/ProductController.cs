using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TTS.Entity.DTOs.Market.Products;
using TTS.Entity.Entities.Market;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;

namespace TTS.Web.Areas.Admin.Controllers.Market
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ITransportService transportService;
        private readonly IStageService stageService;
        private readonly IMapper mapper;
        private readonly IValidator<Product> validator;
        private readonly IToastNotification toast;

        public ProductController(IProductService productService, ITransportService transportService, IStageService stageService, IMapper mapper, IValidator<Product> validator, IToastNotification toast)
        {
            this.productService = productService;
            this.transportService = transportService;
            this.stageService = stageService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAllProductsNonDeletedAsync();

            return View(products);
        }

        public async Task<IActionResult> IndexForUser()
        {
            var products = await productService.GetAllProductsWithUserNonDeletedAsync();
            return View(products);
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedProduct()
        {
            var products = await productService.GetAllProductsDeletedAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            var map = mapper.Map<Product>(productAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await productService.CreateProductAsync(productAddDto);
                toast.AddSuccessToastMessage(Messages.Products.Add(productAddDto.Name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Product", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Product", new { Area = "Admin" });
                }
            }
            result.AddToModelState(ModelState);
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid productId)
        {
            var product = await productService.GetProductByGuidAsync(productId);
            var map = mapper.Map<Product, ProductUpdateDto>(product);


            return View(map);
        }

        [HttpPost]

        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var map = mapper.Map<Product>(productUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await productService.UpdateProductAsync(productUpdateDto);
                toast.AddSuccessToastMessage(Messages.Products.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Product", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Product", new { Area = "Admin" });
                }
            }
            result.AddToModelState(ModelState);
            return View();
        }

        public async Task<IActionResult> Delete(Guid productId)
        {
            var name = await productService.SafeDeleteProductAsync(productId);
            toast.AddSuccessToastMessage(Messages.Products.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Product", new { Area = "Admin" });
            }
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid productId)
        {
            var name = await productService.UndoDeleteProductAsync(productId);
            toast.AddSuccessToastMessage(Messages.Products.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Product", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Product", new { Area = "Admin" });
            }
        }
    }
}
