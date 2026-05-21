using Microsoft.AspNetCore.Mvc;

namespace GarageInventory.Controllers
{
    public class ToolsInventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
