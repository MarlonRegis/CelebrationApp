using CelebrationApp.Services;
using System;
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

        public async Task AddCelebration(Celebration celebration)
        {
            await _celebrationService.CreateCelebration(celebration);
        }
        
        public async Task UpdateCelebration(Celebration celebration)
        {
            await _celebrationService.UpdateCelebration(celebration);
        }
        
        public async Task DeleteCelebration(object id)
        {
            await _celebrationService.DeleteCelebration(id);
        }



    }
}
