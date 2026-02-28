using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Services.BookingServices;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class TravelinController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ICategoryService _categoryService;
        private readonly IBookingService _bookingService;

        public TravelinController(ITourService tourService, ICategoryService categoryService, IBookingService bookingService)
        {
            _tourService = tourService;
            _categoryService = categoryService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllTourAsync();
            var categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.Tours = tours;
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            await _bookingService.CreateBookingAsync(dto);
            TempData["BookingSuccess"] = "true";
            return RedirectToAction("Index");
        }
    }
}