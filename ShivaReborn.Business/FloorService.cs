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
    }
}