using Microsoft.EntityFrameworkCore;
using Repository.Repository.DTOs;

namespace Repository.Repository.DbContexts

{
    public class CelebrationDbContext : DbContext
    {
        public DbContextOptions _options { get; set; }
        public CelebrationDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<CelebrationDTO> Celebrations { get; set; }

    }
}
