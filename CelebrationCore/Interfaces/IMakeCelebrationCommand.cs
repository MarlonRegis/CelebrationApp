namespace CelebrationCore.Interfaces
{
    public interface IMakeCelebrationCommand
    {
        bool CanExecute();
        bool CanExecuteCommand();
        Task RemoveCelebration();
        Task SaveCelebration();
        Task UpdateCelebration();
    }
}