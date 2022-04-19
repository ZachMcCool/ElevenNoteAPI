using System;
using System.Threading.Tasks;
using ElevenNote.Data.Entities;
using ElevenNote.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote.Services.User
{
    public interface UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            if (await GetUserByEmailAsync(model.Email) != null || await GetUserByEmailAsync(model.Username) != null)
                return false;
            var entity = new UserEntity
            {
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                DateCreated = DateTime.Now
            };

            var passwordHasher = new PasswordHasher<UserEntity>();

            entity.Password = passwordHasher.HashPassword(entity, model.Password);
            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesASync();

            return numberOfChanges == 1;

        }
        private async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.email.ToLower() == email.ToLower());
        }

        private async Task<UserEntity> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());
        }
    }
}