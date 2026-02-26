using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Entities;

namespace Project3Travelin.Models
{
    public class TourDetailViewModel
    {
        public CreateCommentDto CreateCommentDto { get; set; }
        public GetTourByIdDto Tour { get; set; }
        public List<Comment> Comments { get; set; }
        public List<TourRota> TourRotas { get; set; }
        public List<Category> Categories { get; set; }
    }
}
