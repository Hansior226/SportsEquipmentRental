using Microsoft.AspNetCore.Mvc;

namespace RentEquipment.Controllers
{
    public class SprzetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}