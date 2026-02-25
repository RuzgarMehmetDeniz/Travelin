using Project3Travelin.Dtos.TourRotaDtos;
using Project3Travelin.Entities;

namespace Project3Travelin.Services.TourRotaService
{
    public interface ITourRotaServices
    {
        Task<List<ResultTourRotaDto>> GetAllTourRotaAsync();
        Task CreateTourRotaAsync(CreateTourRotaDto createTourRotaDto);
        Task UpdateTourRotaAsync(UpdateTourRotaDto createTourRotaDto);
        Task DeleteTourRotaAsync(string id);
        Task<GetTourRotaByIdDto> GetTourRotaByIdAsync(string id);
        Task<List<TourRota>> GetTourRotasByTourIdAsync(string tourId);

    }
}
