using Microsoft.AspNetCore.Mvc;

namespace GarageInventory.Controllers
{
    public class MotorPartsInventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
