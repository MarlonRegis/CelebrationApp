using CelebrationCore.ViewModels;

namespace CelebrationCore.Interfaces
{
    public interface ICelebrationListingCommand
    {
        Task LoadCelebration();
        void OpenDetailsCelebration(CelebrationRecordViewModel celebration);
    }
}