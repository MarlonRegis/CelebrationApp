using CelebrationApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelebrationApp.Models
{
    public class CelebrationBook
    {
        private readonly ICelebrationService _celebrationService;

        public CelebrationBook(CelebrationService celebrationService)
        {
            _celebrationService = celebrationService;
        }

        public IEnumerable<Celebration> GetAllCelebrations(int limitSource)
        {
            return  _celebrationService.GetAllCelebrations(limitSource);
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
