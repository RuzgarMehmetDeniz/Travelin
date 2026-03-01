using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Dtos.CommentDtos;
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
        private readonly ICommentServices _commentServices;
        private readonly IBookingService _bookingService;
        private readonly IStringLocalizer<Project3Travelin.Resources.SharedResource> _localizer;

        public TravelinController(
            ITourService tourService,
            ICategoryService categoryService,
            IBookingService bookingService,
            IStringLocalizer<Project3Travelin.Resources.SharedResource> localizer,
            ICommentServices commentServices)
        {
            _tourService = tourService;
            _categoryService = categoryService;
            _bookingService = bookingService;
            _localizer = localizer;
            _commentServices = commentServices;
        }

        public async Task<IActionResult> Index()
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            var heroTitle = _localizer["HeroTitle"];
            Console.WriteLine($"=== Culture: {culture} | HeroTitle: {heroTitle} ===");

            var model = new HomeViewModel
            {
                Tours = await _tourService.GetAllTourAsync(),
                Categories = await _categoryService.GetAllCategoryAsync(),
                Comments = await _commentServices.GetAllCommentAsync() // <--- burası
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            await _bookingService.CreateBookingAsync(dto);
            TempData["BookingSuccess"] = "true";
            return RedirectToAction("Index");
        }

        public IActionResult SetLanguage(string culture, string returnUrl = "/Travelin/Index")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
    }
}