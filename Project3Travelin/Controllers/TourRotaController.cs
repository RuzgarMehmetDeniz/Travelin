using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.TourRotaDtos;
using Project3Travelin.Services.TourRotaService;

namespace Project3Travelin.Controllers
{
    public class TourRotaController : Controller
    {
        private readonly ITourRotaServices _tourRotaServices;

        public TourRotaController(ITourRotaServices tourRotaServices)
        {
            _tourRotaServices = tourRotaServices;
        }
        [HttpGet]
        public IActionResult CreateTourRota()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTourRota(CreateTourRotaDto createTourRotaDto)
        {
            await _tourRotaServices.CreateTourRotaAsync(createTourRotaDto);
            return RedirectToAction("TourRota");
        }
    }
}
