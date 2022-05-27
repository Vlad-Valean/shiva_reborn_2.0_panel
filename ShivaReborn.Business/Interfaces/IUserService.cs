using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.Business.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
}