using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using TTS.Entity.DTOs.CevreselIzleme.Sensors;
using TTS.Entity.DTOs.Yorum;
using TTS.Entity.Entities;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Service.Extensions;
using TTS.Service.Services.Abstractions;
using TTS.Service.Services.Concretes;
using TTS.Web.Consts;
using TTS.Web.ResultMessages;
using static TTS.Web.ResultMessages.Messages;

namespace TTS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IProductService productService;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;
        private readonly IValidator<Comment> validator;

        public CommentController(ICommentService commentService, IProductService productService, IMapper mapper, IToastNotification toast, IValidator<Comment> validator)
        {
            this.commentService = commentService;
            this.productService = productService;
            this.mapper = mapper;
            this.toast = toast;
            this.validator = validator;
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Index()
        {
            var comments = await commentService.GetAllCommentsWithProductNonDeletedAsync();
            return View(comments);
        }
        public async Task<IActionResult> IndexForUser()
        {
            var comments = await commentService.GetAllCommentsWithProductUserNonDeletedAsync();
            return View(comments);
        }
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedComment()
        {
            var comments = await commentService.GetAllCommentsDeletedAsync();
            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var products = await productService.GetAllProductsNonDeletedAsync();
            return View(new CommentAddDto { Products = products });
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentAddDto commentAddDto)
        {
            var map = mapper.Map<Comment>(commentAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await commentService.CreateCommentAsync(commentAddDto);
                toast.AddSuccessToastMessage(Messages.Comments.Add(commentAddDto.Title), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Comment", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Comment", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var products = await productService.GetAllProductsNonDeletedAsync();
            return View(new CommentAddDto { Products = products });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid commentId)
        {
            var comment = await commentService.GetCommentByGuid(commentId);
            var products = await productService.GetAllProductsNonDeletedAsync();
            var commentUpdateDto = mapper.Map<CommentUpdateDto>(comment);
            commentUpdateDto.Products = products;
            return View(commentUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CommentUpdateDto commentUpdateDto)
        {
            var map = mapper.Map<Comment>(commentUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await commentService.UpdateCommentAsync(commentUpdateDto);
                toast.AddSuccessToastMessage(Messages.Sensors.Update(name), new ToastrOptions() { Title = "İşlem başarılı" });
                if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Comment", new { Area = "Admin" });
                }
                else
                {
                    return RedirectToAction("IndexForUser", "Comment", new { Area = "Admin" });
                }
            }
            else
            {
                result.AddToModelState(ModelState);
            }

            var products = await productService.GetAllProductsNonDeletedAsync();
            commentUpdateDto.Products = products;

            return View(commentUpdateDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid commentId)
        {
            var name = await commentService.SafeDeleteCommentAsync(commentId);
            toast.AddSuccessToastMessage(Messages.Comments.Delete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Comment", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Comment", new { Area = "Admin" });
            }
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> UndoDelete(Guid commentId)
        {
            var name = await commentService.UndoDeleteCommentAsync(commentId);
            toast.AddSuccessToastMessage(Messages.Comments.UndoDelete(name), new ToastrOptions() { Title = "İşlem başarılı" });

            if (User.IsInRole("Superadmin") || User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Comment", new { Area = "Admin" });
            }
            else
            {
                return RedirectToAction("IndexForUser", "Comment", new { Area = "Admin" });
            }
        }

    }
}
