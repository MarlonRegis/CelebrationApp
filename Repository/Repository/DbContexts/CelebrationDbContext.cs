using Microsoft.EntityFrameworkCore;
using Repository.DTOs;

namespace Repository.DbContexts

{
    public class CelebrationDbContext : DbContext
    {

        public DbSet<CelebrationDTO> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=c:/Sidi/study/FinalProject/CelebrationApp/Repository/celebration.db");
    }
}
