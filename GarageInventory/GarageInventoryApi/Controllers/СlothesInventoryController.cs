using Microsoft.AspNetCore.Mvc;

namespace GarageInventory.Controllers
{
    public class СlothesInventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
