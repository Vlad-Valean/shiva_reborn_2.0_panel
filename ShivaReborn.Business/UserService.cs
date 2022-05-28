using ShivaReborn.Business.Interfaces;
using ShivaReborn.DataAccess.Models;
using ShivaReborn.DataAccess.Repositories;

namespace ShivaReborn.Business
{
    public class UserService : IService<User>
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task<User> RemoveAsync(int id)
        {
            return await _userRepository.RemoveAsync(id);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<User> AddAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }
    }
}