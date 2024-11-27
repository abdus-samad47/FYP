using FYP.DTO_s.UserDTOs;
using FYP.Models;

namespace FYP.Interface
{
    public interface IUserRepository
    {
        Task<bool> IsEmailExistsAsync(string email);
        Task<bool> IsNICExistsAsync(string nic);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task<User> GetByEmailAsync(string email);
    }
}
