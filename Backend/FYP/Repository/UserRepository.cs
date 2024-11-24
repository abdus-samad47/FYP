using AutoMapper;
using FYP.Data;
using FYP.DTO_s.UserDTOs;
using FYP.Interface;
using FYP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FYP.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            // Fetch all users from the database
            var users = await _context.Users.ToListAsync();

            // Map the users to UserDTOs
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.email == email);
        }

        public async Task<bool> IsNICExistsAsync(string nic)
        {
            return await _context.Users.AnyAsync(u => u.nic == nic);
        }

        public async Task AddUserAsync(User user)
        {

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.email == email);
        }
    }
}
