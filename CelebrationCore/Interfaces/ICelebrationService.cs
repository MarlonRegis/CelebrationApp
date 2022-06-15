using CelebrationCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelebrationCore.Interfaces
{
    public interface ICelebrationService
    {
        Task CreateCelebration(Celebration celebration);
        Task DeleteCelebration(object id);
        IEnumerable<Celebration> GetAllCelebrations(int celebrationLimit);
        Task UpdateCelebration(Celebration celebration);
    }
}