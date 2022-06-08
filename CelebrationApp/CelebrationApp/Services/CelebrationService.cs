using CelebrationApp.Models;
using CelebrationApp.Services.Factory;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.DbContexts;
using Repository.DTOs;
using Repository.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Services
{
    public class CelebrationService : ICelebrationService
    {
        private readonly CelebrationDbContextFactory _dbContextFactory;
        private readonly CelebrationFactory _celebrationFactory;
        private readonly CelebrationDbContext _contextCelebration;

        public CelebrationService(CelebrationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _contextCelebration = _dbContextFactory.CreateDbContext();
            _celebrationFactory = new CelebrationFactory();
        }

        public async Task CreateCelebration(Celebration celebration)
        {
                CelebrationDTO celebrationDTO = _celebrationFactory.ToCelebrationDTO(celebration);

                _contextCelebration.Celebrations.Add(celebrationDTO);
                await _contextCelebration.SaveChangesAsync();
        }

        public async Task UpdateCelebration(Celebration celebration)
        {

                CelebrationDTO celebrationDTO = _celebrationFactory.ToCelebrationDTO(celebration);
                _contextCelebration.Celebrations.Update(celebrationDTO);
                await _contextCelebration.SaveChangesAsync();
        }

        public async Task DeleteCelebration(Celebration celebration)
        {

                CelebrationDTO celebrationDTO = _celebrationFactory.ToCelebrationDTO(celebration);
                _contextCelebration.Celebrations.Remove(celebrationDTO);
                await _contextCelebration.SaveChangesAsync();
        }

        public async Task<IEnumerable<Celebration>> GetAllReservations()
        {
                IEnumerable<CelebrationDTO> reservationDtos = await _contextCelebration.Celebrations.ToListAsync();
                return reservationDtos.Select(res => _celebrationFactory.ToCelebration(res));
        }

    }
}
