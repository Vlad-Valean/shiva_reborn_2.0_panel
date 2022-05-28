using ShivaReborn.Business.Interfaces;
using ShivaReborn.DataAccess.Models;
using ShivaReborn.DataAccess.Repositories;

namespace ShivaReborn.Business
{
    public class PlaceService : IService<Place>
    {
        private readonly IRepository<Place> _placeRepository;

        public PlaceService(IRepository<Place> placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<IEnumerable<Place>> GetAllAsync()
        {
            return await _placeRepository.GetAllAsync();
        }
        public async Task<Place> RemoveAsync(string id)
        {
            return await _placeRepository.RemoveAsync(id);
        }
        public async Task<Place> GetAsync(string id)
        {
            return await _placeRepository.GetAsync(id);
        }

        public async Task<Place> AddAsync(Place place)
        {
            return await _placeRepository.AddAsync(place);
        }
    }
}