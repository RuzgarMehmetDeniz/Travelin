using AutoMapper;
using MongoDB.Driver;
using Project3Travelin.Dtos.TourRotaDtos;
using Project3Travelin.Entities;
using Project3Travelin.Services.TourRotaService;
using Project3Travelin.Settings;

namespace Project3Travelin.Services.TourRotaRota
{
    public class TourRotaService : ITourRotaServices
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<TourRota> _TourRotaCollection;
        public TourRotaService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _TourRotaCollection = database.GetCollection<TourRota>(_databaseSettings.TourRotaCollectionName);
            _mapper = mapper;
        }
        public async Task CreateTourRotaAsync(CreateTourRotaDto createTourRotaDto)
        {
            var values = _mapper.Map<TourRota>(createTourRotaDto);
            await _TourRotaCollection.InsertOneAsync(values);
        }

        public async Task DeleteTourRotaAsync(string id)
        {
            await _TourRotaCollection.DeleteOneAsync(x => x.TourRotaId == id);
        }

        public async Task<List<ResultTourRotaDto>> GetAllTourRotaAsync()
        {
            var values = await _TourRotaCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultTourRotaDto>>(values);
        }

        public async Task<GetTourRotaByIdDto> GetTourRotaByIdAsync(string id)
        {
            var value = await _TourRotaCollection.Find(x => x.TourRotaId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTourRotaByIdDto>(value);
        }

        public async Task<List<TourRota>> GetTourRotasByTourIdAsync(string tourId)
        {
            return await _TourRotaCollection
              .Find(c => c.TourId == tourId)
              .ToListAsync();
        }

        public async Task UpdateTourRotaAsync(UpdateTourRotaDto updateTourRotaDto)
        {
            var values = _mapper.Map<TourRota>(updateTourRotaDto);
            await _TourRotaCollection.FindOneAndReplaceAsync(x => x.TourRotaId == updateTourRotaDto.TourRotaId, values);
        }
    }
}
