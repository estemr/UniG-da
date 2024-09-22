using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using TTS.Entity.DTOs.Users;
using TTS.Entity.Entities.Identity;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Service.Services.Concretes;
using TTS.Web.ResultMessages;

namespace TTS.Web.Areas.Admin.Controllers.User
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IUserService userService;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;
        private readonly IValidator<AppUser> validator;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService, IToastNotification toast, IMapper mapper, IValidator<AppUser> validator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.toast = toast;
            this.mapper = mapper;
            this.validator = validator;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz hatalı olabilir.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz hatalı olabilir.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var roles = await userService.GetAllRolesAsync();
            return View(new UserAddDto { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var map = mapper.Map<AppUser>(userRegisterDto);
            var validation = await validator.ValidateAsync(map);
            var roles = await userService.GetAllRolesAsync();
            if (ModelState.IsValid)
            {
                var result = await userService.RegisterUserAsync(userRegisterDto);
                if (result.Succeeded)
                {
                    toast.AddSuccessToastMessage(Messages.Users.Add(userRegisterDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Login", "Auth", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles });

                }
            }
            return View(new UserAddDto { Roles = roles });
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
