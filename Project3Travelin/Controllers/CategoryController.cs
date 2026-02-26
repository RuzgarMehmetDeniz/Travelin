using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Entities;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ITourService _tourService;

        public CategoryController(ICategoryService categoryService, ITourService tourService)
        {
            _categoryService = categoryService;
            _tourService = tourService;
        }
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
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
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.IsStatus = true;

            var tours = await _tourService.GetAllTourAsync();

            ViewBag.TourList = tours.Select(x => new SelectListItem
            {
                Value = x.TourId,
                Text = x.Title
            }).ToList();
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("CategoryList");
        }
    }
}
