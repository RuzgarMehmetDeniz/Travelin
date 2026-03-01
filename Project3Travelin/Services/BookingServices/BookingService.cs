using AutoMapper;
using MongoDB.Driver;
using Project3Travelin.Dtos.BookingDtos;
using Project3Travelin.Entities;
using Project3Travelin.Settings;

namespace Project3Travelin.Services.BookingServices
{
    public class BookingService: IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Booking> _BookingCollection;
        public BookingService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _BookingCollection = database.GetCollection<Booking>(_databaseSettings.BookingCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var values = _mapper.Map<Booking>(createBookingDto);
            await _BookingCollection.InsertOneAsync(values);

        }

        public async Task DeleteBookingAsync(string id)
        {
            await _BookingCollection.DeleteOneAsync(x => x.BookingId == id);
        }

        public async Task<List<ResultBookingDto>> GetAllBookingAsync()
        {
            var values = await _BookingCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBookingDto>>(values);
        }

        public async Task<GetBookingByIdDto> GetBookingByIdAsync(string id)
        {
            var value = await _BookingCollection.Find(x => x.BookingId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBookingByIdDto>(value);
        }

        public async Task UpdateBookingAsync(UpdateBookingDto updateBookingDto)
        {
            var values = _mapper.Map<Booking>(updateBookingDto);
            await _BookingCollection.FindOneAndReplaceAsync(x => x.BookingId == updateBookingDto.BookingId, values);
        }
        public async Task<List<GetBookingByIdDto>> GetBookingsByTourIdAsync(string tourId)
        {
            var values = await _BookingCollection.Find(x => x.TourId == tourId).ToListAsync();
            return _mapper.Map<List<GetBookingByIdDto>>(values);
        }
        public async Task ApproveBookingAsync(string id, bool isStatus)
        {
            var filter = Builders<Booking>.Filter.Eq(x => x.BookingId, id);
            var update = Builders<Booking>.Update.Set(x => x.IsStatus, isStatus);
            await _BookingCollection.UpdateOneAsync(filter, update);
        }
    }
}
