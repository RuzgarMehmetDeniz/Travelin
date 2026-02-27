namespace Project3Travelin.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public string CommentId { get; set; }
        public string Name { get; set; }
        public string TourId { get; set; }
        public string HeadLine { get; set; }
        public string CommentDetail { get; set; }
        public int Score { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsStatus { get; set; }
        public string TourTitle { get; set; }
    }
}