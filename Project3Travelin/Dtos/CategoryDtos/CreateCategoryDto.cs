namespace Project3Travelin.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public string IconUrl { get; set; }
        public bool IsStatus { get; set; }
        public string TourId { get; set; }
        public string TourTitle { get; set; }
    }
}