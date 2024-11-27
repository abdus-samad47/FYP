using AutoMapper;
using FYP.Data;
using FYP.DTO_s;
using FYP.DTO_s.UserDTOs;
using FYP.Interface;
using FYP.Models;
using FYP.Repository;
using FYP.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FYP.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(ApplicationDbContext context, IMapper mapper, IUserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _userRepository.IsEmailExistsAsync(email);
        }

        public async Task<bool> IsNICExistsAsync(string nic)
        {
            return await _userRepository.IsNICExistsAsync(nic);
        }
        public async Task CreateNewUserAsync(CreateUserDTO createUserDTO)
        {

            var salt = Hashing.Salt();
            var password = createUserDTO.password;
            var hashingPassword = Hashing.hashPassword(password, salt);
            createUserDTO.password = hashingPassword;
            var user = _mapper.Map<User>(createUserDTO);
            user.salt = salt;

            await _userRepository.AddUserAsync(user);
        }
        public async Task<bool> ValidateUserAsync(LoginUserDTO loginDTO)
        {
            // Check if user exists
            var user = await _userRepository.GetByEmailAsync(loginDTO.email);
            if (user == null)
            {
                return false;
            }

            // Verify password
            return Hashing.VerifyPassword(loginDTO.password, user.password, user.salt);
        }
    }
}
