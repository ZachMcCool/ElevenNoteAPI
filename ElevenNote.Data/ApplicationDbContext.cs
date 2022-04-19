using ElevenNote.Data.Entities;
using Microsoft.EntityFrameworkCore;
using ElevenNote.Data;

namespace ElevenNote.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<UserEntity> Users { get; set; }


    }
}