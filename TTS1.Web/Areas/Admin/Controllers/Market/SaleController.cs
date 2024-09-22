using Microsoft.AspNetCore.Mvc;

namespace TTS.Web.Areas.Admin.Controllers.Market
{
    [Area("Admin")]
    public class SaleController : Controller
    {
        public SaleController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
