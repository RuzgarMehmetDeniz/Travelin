using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.TourRotaDtos;
using Project3Travelin.Services.TourRotaRota;
using Project3Travelin.Services.TourRotaService;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class AdminTourRotaController : Controller
    {
        private readonly ITourRotaServices _tourRotaService;
        private readonly ITourService _tourService;

        public AdminTourRotaController(ITourRotaServices tourRotaService, ITourService tourService)
        {
            _tourRotaService = tourRotaService;
            _tourService = tourService;
        }

        public async Task<IActionResult> TourRotaList()
        {
            var rotas = await _tourRotaService.GetAllTourRotaAsync();
            var tours = await _tourService.GetAllTourAsync();
            var tourDict = tours.ToDictionary(t => t.TourId, t => t.Title);
            ViewBag.TourDict = tourDict;
            return View(rotas);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTourRota()
        {
            ViewBag.Tours = await _tourService.GetAllTourAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTourRota(CreateTourRotaDto dto)
        {
            await _tourRotaService.CreateTourRotaAsync(dto);
            return RedirectToAction("TourRotaList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTourRota(string id)
        {
            var rota = await _tourRotaService.GetTourRotaByIdAsync(id);
            ViewBag.Tours = await _tourService.GetAllTourAsync();
            return View(new UpdateTourRotaDto
            {
                TourRotaId = rota.TourRotaId,
                TourId = rota.TourId,
                Name = rota.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTourRota(UpdateTourRotaDto dto)
        {
            await _tourRotaService.UpdateTourRotaAsync(dto);
            return RedirectToAction("TourRotaList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTourRota(string id)
        {
            await _tourRotaService.DeleteTourRotaAsync(id);
            return RedirectToAction("TourRotaList");
        }
    }
}