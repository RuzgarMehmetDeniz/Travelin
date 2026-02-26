using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ITourService _tourService;

        public AdminCategoryController(ICategoryService categoryService, ITourService tourService)
        {
            _categoryService = categoryService;
            _tourService = tourService;
        }

        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            var tours = await _tourService.GetAllTourAsync();

            var result = categories.Select(c => new ResultCategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                IconUrl = c.IconUrl,
                IsStatus = c.IsStatus,
                TourId = c.TourId,
                TourTitle = tours.FirstOrDefault(t => t.TourId == c.TourId).Title
            }).ToList();

            return View(result);
        }
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> CreateCategory()
        {
            var tours = await _tourService.GetAllTourAsync();
            ViewBag.Tours = tours;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            var tours = await _tourService.GetAllTourAsync();
            ViewBag.Tours = tours;
            return View(new UpdateCategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                IconUrl = category.IconUrl,
                IsStatus = category.IsStatus,
                TourId = category.TourId,
                TourTitle = category.TourTitle
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto)
        {
            await _categoryService.UpdateCategoryAsync(dto);
            return RedirectToAction("CategoryList");
        }
    }
}
