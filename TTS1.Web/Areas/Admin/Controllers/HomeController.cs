using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TTS.Service.Services.Abstractions;
using TTS.Service.Services.Concretes;

namespace TTS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICommentService commentService;

        public HomeController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public async Task<IActionResult> Index()
        {
            var comments = await commentService.GetAllCommentsWithProductNonDeletedAsync();
            return View(comments);
        }


    }
}
