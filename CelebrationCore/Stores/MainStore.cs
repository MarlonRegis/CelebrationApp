using CelebrationCore.Models;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationCore.Stores
{
    public class MainStore
    {

        private readonly Main _main;
        private readonly List<Celebration> _celebrations;
        private Lazy<Task> _initializeLazy;
        public FrameworkElement MainRoot { get; set; }


        public IEnumerable<Celebration> CelebrationEnumerable => _celebrations;

        public IEnumerable<Celebration> Celebrations => _celebrations;

        public event Action<Celebration> CelebrationsMade;

        public int CelebrationLimit { get; set; } = 0;

        public MainStore(Main main)
        {
            if (main != null)
            {
                _main = main;
                _initializeLazy = new Lazy<Task>(Initialize);
                _celebrations = new List<Celebration>();
            }
        }

        public async Task Load()
        {
            try
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                await _initializeLazy.Value;
            }
            catch (Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }
        }

        public async Task SaveCelebration(Celebration celebration)
        {
            await _main.SaveCelebration(celebration);

            _celebrations.Add(celebration);

            OnCelebrationSave(celebration);
        }

        public async Task UpdateCelebration(Celebration celebration)
        {
            await _main.UpdateCelebration(celebration);
        }

        public async Task RemoveCelebration(object id)
        {
            await _main.DeleteCelebration(id);
        }

        private void OnCelebrationSave(Celebration celebration)
        {
            CelebrationsMade?.Invoke(celebration);
        }

        private Task Initialize()
        {
            IEnumerable<Celebration> celebration = _main.GetAllCelebrations(CelebrationLimit);

            _celebrations.Clear();
            _celebrations.AddRange(celebration);

            return Task.CompletedTask;
        }
    }
}
