using FYP.DTO_s;
using FYP.DTO_s.UserDTOs;

namespace FYP.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<bool> IsEmailExistsAsync(string email);
        Task<bool> IsNICExistsAsync(string nic);
        Task CreateNewUserAsync(CreateUserDTO createUserDTO);
        Task<bool> ValidateUserAsync(LoginUserDTO loginUserDTO);
    }
}
