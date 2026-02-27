using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Models;
using Project3Travelin.Services.BookingServices;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.CommentServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class TravelinController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentServices _commentService;
        private readonly IBookingService _bookingService;

        public TravelinController(ITourService tourService, ICategoryService categoryService,
            ICommentServices commentService, IBookingService bookingService)
        {
            _tourService = tourService;
            _categoryService = categoryService;
            _commentService = commentService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> Index()
        {
            var tours = await _tourService.GetAllTourAsync();
            var tourDict = tours.ToDictionary(t => t.TourId, t => t.Title);
            var comments = await _commentService.GetAllCommentAsync();

            foreach (var comment in comments)
                comment.TourTitle = tourDict.TryGetValue(comment.TourId, out var t) ? t : "Belirtilmemiş";

            var vm = new HomeViewModel
            {
                Tours = tours,
                Categories = await _categoryService.GetAllCategoryAsync(),
                Comments = comments.Where(c => c.IsStatus).ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            await _bookingService.CreateBookingAsync(dto);
            TempData["Success"] = "Rezervasyonunuz başarıyla alındı!";
            return RedirectToAction("Index");
        }
    }
}