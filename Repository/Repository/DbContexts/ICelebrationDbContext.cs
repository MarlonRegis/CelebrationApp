using Microsoft.EntityFrameworkCore;
using Repository.DTOs;

namespace Repository.DbContexts
{
    public interface ICelebrationDbContext
    {
        DbSet<CelebrationDTO> Reservations { get; set; }

        void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
    }
}