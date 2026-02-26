using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Entities;

namespace Project3Travelin.Services.BookingServices
{
    public interface IBookingService
    {
        Task<List<ResultBookingDto>> GetAllBookingAsync();
        Task CreateBookingAsync(CreateBookingDto createBookingDto);
        Task UpdateBookingAsync(UpdateBookingDto updateBookingDto);
        Task DeleteBookingAsync(string id);
        Task<GetBookingByIdDto> GetBookingByIdAsync(string id);
    }
}
