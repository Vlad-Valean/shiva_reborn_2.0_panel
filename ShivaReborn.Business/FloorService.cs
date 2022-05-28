using ShivaReborn.Business.Interfaces;
using ShivaReborn.DataAccess.Models;
using ShivaReborn.DataAccess.Repositories;

namespace ShivaReborn.Business
{
    public class FloorService : IService<Floor>
    {
        private readonly IRepository<Floor> _floorRepository;

        public FloorService(IRepository<Floor> floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public async Task<IEnumerable<Floor>> GetAllAsync()
        {
            return await _floorRepository.GetAllAsync();
        }
        public async Task<Floor> RemoveAsync(int id)
        {
            return await _floorRepository.RemoveAsync(id);
        }
        public async Task<Floor> GetAsync(int id)
        {
            return await _floorRepository.GetAsync(id);
        }

        public async Task<Floor> AddAsync(Floor floor)
        {
            return await _floorRepository.AddAsync(floor);
        }
    }
}