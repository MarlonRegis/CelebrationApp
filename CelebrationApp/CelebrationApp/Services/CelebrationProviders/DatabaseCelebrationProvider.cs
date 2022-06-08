using CelebrationApp.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;
using Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Services.CelebrationProviders
{
    public class DatabaseCelebrationProvider : IDatabaseCelebrationProvider
    {
        private readonly CelebrationDbContextFactory _dbContextFactory;

        public DatabaseCelebrationProvider(CelebrationDbContextFactory celebrationDbContextFactory)
        {
            _dbContextFactory = celebrationDbContextFactory;
        }

        public async Task<IEnumerable<Celebration>> GetAllReservations()
        {
            using (CelebrationDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<CelebrationDTO> reservationDtos = await context.Reservations.ToListAsync();

                return reservationDtos.Select(res => ToReservation(res));
            }
        }

        private static Celebration ToReservation(CelebrationDTO res)
        {
            return new Celebration(res.Id, res.Name, res.Description, res.RecordDate, res.CelebrationDate);
        }

    }
}
