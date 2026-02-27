using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Dtos.TourDtos;

namespace Project3Travelin.Models
{
    public class DashboardViewModel
    {
        public int TotalTour { get; set; }
        public int TotalBooking { get; set; }
        public int TotalCategory { get; set; }
        public int TotalRota { get; set; }
        public List<ResultTourDto> RecentTours { get; set; }
        public List<ResultBookingDto> RecentBookings { get; set; }
        public Dictionary<string, int> ToursByCountry { get; set; }
        public List<(string TourTitle, int Count)> TopBookedTours { get; set; }
    }
}