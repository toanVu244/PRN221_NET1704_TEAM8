using JPOS.Model.Entities;
using JPOS.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPOS.Model.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly JPOSDbContext _context;
        public UserRepository(JPOSDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
        public async Task<User?> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
        public async Task<User> GetLastUserAsync()
        {
            var lastUser = await _context.Users
                .OrderByDescending(u => u.UserID)
                .FirstOrDefaultAsync();

            return lastUser;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
           return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
