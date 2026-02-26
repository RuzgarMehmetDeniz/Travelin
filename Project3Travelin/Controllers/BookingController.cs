using Microsoft.AspNetCore.Mvc;

namespace Project3Travelin.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
