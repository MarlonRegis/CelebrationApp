using CelebrationApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelebrationApp.Services
{
    public interface ICelebrationService
    {
        Task CreateCelebration(Celebration celebration);
        Task DeleteCelebration(Celebration celebration);
        IEnumerable<Celebration> GetAllCelebrations(int celebrationLimit);
        Task UpdateCelebration(Celebration celebration);
    }
}