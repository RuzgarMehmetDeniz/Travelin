namespace Project3Travelin.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BookingDate { get; set; }

        public string TourId { get; set; }
    }
}
