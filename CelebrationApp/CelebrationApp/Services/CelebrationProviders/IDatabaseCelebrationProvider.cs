using CelebrationApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelebrationApp.Services.CelebrationProviders
{
    public interface IDatabaseCelebrationProvider
    {
        Task<IEnumerable<Celebration>> GetAllReservations();
    }
}