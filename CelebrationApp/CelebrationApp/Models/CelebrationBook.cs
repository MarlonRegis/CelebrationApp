using CelebrationApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelebrationApp.Models
{
    public class CelebrationBook
    {
        private readonly ICelebrationService _celebrationService;

        public CelebrationBook(ICelebrationService celebrationService)
        {
            _celebrationService = celebrationService;
        }

        public async Task<IEnumerable<Celebration>> GetAllReservations()
        {
            return await _celebrationService.GetAllReservations();
        }

        public async Task AddCelebration(Celebration reservation)
        {
            await _celebrationService.CreateCelebration(reservation);
        }
        
        public async Task UpdateCelebration(Celebration reservation)
        {
            await _celebrationService.UpdateCelebration(reservation);
        }
        
        public async Task DeleteCelebration(Celebration reservation)
        {
            await _celebrationService.DeleteCelebration(reservation);
        }



    }
}
