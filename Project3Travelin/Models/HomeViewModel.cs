using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Dtos.TourDtos;

namespace Project3Travelin.Models
{
    public class HomeViewModel
    {
        public List<ResultTourDto> Tours { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
        public List<ResultCommentDto> Comments { get; set; }
    }
}