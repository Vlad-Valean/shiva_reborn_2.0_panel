using ShivaReborn.Business.Interfaces;
using ShivaReborn.DataAccess.Models;
using ShivaReborn.DataAccess.Repositories;

namespace ShivaReborn.Business
{
    public class BuildingService : IService<Building>
    {
        private readonly IRepository<Building> _buildingRepository;

        public BuildingService(IRepository<Building> buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public async Task<IEnumerable<Building>> GetAllAsync()
        {
            return await _buildingRepository.GetAllAsync();
        }

        public async Task<Building> RemoveAsync(string id)
        {
            return await _buildingRepository.RemoveAsync(id);
        }
        public async Task<Building> GetAsync(string id)
        {
            return await _buildingRepository.GetAsync(id);
        }

        public async Task<Building> AddAsync(Building building)
        {
            return await _buildingRepository.AddAsync(building);
        }
    }
}