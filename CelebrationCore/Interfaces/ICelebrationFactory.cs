using CelebrationCore.Models;
using Repository.Repository.DTOs;

namespace CelebrationCore.Interfaces
{
    public interface ICelebrationFactory
    {
        Celebration createCelebration(string name, string description, DateTime recordDate, DateTime celebrationDate);
        Celebration ToCelebration(CelebrationDTO res);
        CelebrationDTO ToCelebrationDTO(Celebration celebration);
    }
}