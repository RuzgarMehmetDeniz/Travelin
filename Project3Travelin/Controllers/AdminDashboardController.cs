using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Models;
using Project3Travelin.Services.BookingServices;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.CommentServices;
using Project3Travelin.Services.TourRotaRota;
using Project3Travelin.Services.TourRotaService;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IBookingService _bookingService;
        private readonly ICategoryService _categoryService;
        private readonly ITourRotaServices _tourRotaService;

        public AdminDashboardController(ITourService tourService, IBookingService bookingService,
            ICategoryService categoryService, ITourRotaServices tourRotaService)
        {
            _tourService = tourService;
            _bookingService = bookingService;
            _categoryService = categoryService;
            _tourRotaService = tourRotaService;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllTourAsync();
            var bookings = await _bookingService.GetAllBookingAsync();
            var categories = await _categoryService.GetAllCategoryAsync();
            var rotas = await _tourRotaService.GetAllTourRotaAsync();
            var tourDict = tours.ToDictionary(t => t.TourId, t => t.Title);

            var vm = new DashboardViewModel
            {
                TotalTour = tours.Count,
                TotalBooking = bookings.Count,
                TotalCategory = categories.Count,
                TotalRota = rotas.Count,
                RecentTours = tours.TakeLast(5).ToList(),
                RecentBookings = bookings.TakeLast(5).ToList(),
                ToursByCountry = tours
                    .GroupBy(t => t.Country)
                    .ToDictionary(g => g.Key, g => g.Count()),
                TopBookedTours = bookings
                    .GroupBy(b => b.TourId)
                    .Select(g => (
                        TourTitle: tourDict.TryGetValue(g.Key, out var title) ? title : "Belirtilmemiş",
                        Count: g.Count()
                    ))
                    .OrderByDescending(x => x.Count)
                    .Take(5)
                    .ToList()
            };

            return View(vm);
        }
    }
}