using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.CommentServices;

namespace Project3Travelin.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentServices _commentServices;

        public CommentController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }
        [HttpGet]
        public IActionResult CreateComment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.IsStatus= false;
            createCommentDto.CommentDate = DateTime.Now;
            await _commentServices.CreateCommentAsync(createCommentDto);
            return RedirectToAction("CommentList");
        }
    }
}