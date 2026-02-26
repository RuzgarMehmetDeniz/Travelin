using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Entities;
using Project3Travelin.Models;
using Project3Travelin.Services.CommentServices;
using Project3Travelin.Services.TourRotaService;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ICommentServices _commentServices;
        private readonly ITourRotaServices _tourRotaServices;

        public TourController(ITourService tourService, ICommentServices commentServices, ITourRotaServices tourRotaServices)
        {
            _tourService = tourService;
            _commentServices = commentServices;
            _tourRotaServices = tourRotaServices;
        }

        public IActionResult CreateTour()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTour(CreateTourDto createTourDto)
        {
            await _tourService.CreateTourAsync(createTourDto);
            return RedirectToAction("TourList");
        }
        public async Task<IActionResult> TourList()
        {
            ViewBag.rnd = new Random().Next(600, 1500);
            var values = await _tourService.GetAllTourAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> TourDetail(string id)
        {
            ViewBag.rnd = new Random().Next(600, 1500);

            var tour = await _tourService.GetTourByIdAsync(id);

            var comments = await _commentServices.GetCommentsByTourIdAsync(id);
            var tourrotas = await _tourRotaServices.GetTourRotasByTourIdAsync(id);

            var vm = new TourDetailViewModel
            {
                Tour = tour,
                Comments = comments,
                TourRotas = tourrotas,
                CreateCommentDto = new CreateCommentDto
                {
                    TourId = id  
                }
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.CommentDate = DateTime.Now;
            await _commentServices.CreateCommentAsync(createCommentDto);

            return RedirectToAction("TourDetail", new { id = createCommentDto.TourId });
        }
    }
}
