using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Services.BookingServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITourService _tourService;

        public BookingController(IBookingService bookingService, ITourService tourService)
        {
            _bookingService = bookingService;
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllTourAsync();

            ViewBag.TourList = tours.Select(x => new SelectListItem
            {
                Value = x.TourId,
                Text = x.Title
            }).ToList();

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            var tours = await _tourService.GetAllTourAsync();

            ViewBag.TourList = tours.Select(x => new SelectListItem
            {
                Value = x.TourId,
                Text = x.Title
            }).ToList();

            await _bookingService.CreateBookingAsync(createBookingDto);

            return RedirectToAction("TourList", "Tour");
        }
        public async Task<IActionResult> CreateBooking()
        {
            var tours = await _tourService.GetAllTourAsync();

            ViewBag.TourList = tours.Select(x => new SelectListItem
            {
                Value = x.TourId,
                Text = x.Title
            }).ToList();

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            var tours = await _tourService.GetAllTourAsync();

            ViewBag.TourList = tours.Select(x => new SelectListItem
            {
                Value = x.TourId,
                Text = x.Title
            }).ToList();

            await _bookingService.CreateBookingAsync(createBookingDto);

            return RedirectToAction("TourList", "Tour");
        }

    }
}