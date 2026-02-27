using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Services.CommentServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class AdminCommentController : Controller
    {
        private readonly ICommentServices _commentService;
        private readonly ITourService _tourService;

        public AdminCommentController(ICommentServices commentService, ITourService tourService)
        {
            _commentService = commentService;
            _tourService = tourService;
        }

        public async Task<IActionResult> CommentList()
        {
            var comments = await _commentService.GetAllCommentAsync();
            var tours = await _tourService.GetAllTourAsync();
            var tourDict = tours.ToDictionary(t => t.TourId, t => t.Title);

            foreach (var comment in comments)
                comment.TourTitle = tourDict.TryGetValue(comment.TourId, out var t) ? t : "Belirtilmemiş";

            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> CreateComment()
        {
            ViewBag.Tours = await _tourService.GetAllTourAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto dto)
        {
            dto.CommentDate = DateTime.Now;
            dto.IsStatus = false;
            await _commentService.CreateCommentAsync(dto);
            return RedirectToAction("CommentList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            ViewBag.Tours = await _tourService.GetAllTourAsync();
            return View(new UpdateCommentDto
            {
                CommentId = comment.CommentId,
                Name = comment.Name,
                TourId = comment.TourId,
                HeadLine = comment.HeadLine,
                CommentDetail = comment.CommentDetail,
                Score = comment.Score,
                CommentDate = comment.CommentDate,
                IsStatus = comment.IsStatus
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto dto)
        {
            await _commentService.UpdateCommentAsync(dto);
            return RedirectToAction("CommentList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("CommentList");
        }

        [HttpPost]
        public async Task<IActionResult> ApproveComment(string id)
        {
            await _commentService.ApproveCommentAsync(id);
            TempData["Success"] = "Yorum başarıyla onaylandı.";
            return RedirectToAction("CommentList");
        }
    }
}