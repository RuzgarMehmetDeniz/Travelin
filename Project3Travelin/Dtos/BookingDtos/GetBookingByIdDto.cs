namespace Project3Travelin.Dtos.BookingDtos
{
    public class GetBookingByIdDto
    {
        public string BookingId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TourId { get; set; }
        public string TourTitle { get; set; }
        public DateTime BookingDate { get; set; }
    }
}