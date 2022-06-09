using CelebrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Stores
{
    public class MainStore
    {

        private readonly Main _main;
        private readonly List<Celebration> _celebrations;
        private Lazy<Task> _initializeLazy;

        public IEnumerable<Celebration> CelebrationEnumerable => _celebrations;

        public IEnumerable<Celebration> Components => _celebrations;

        public event Action<Celebration> ComponentMade;

        private int _celebrationLimit = 0;
        public int CelebrationLimit
        {
            get { return _celebrationLimit; }
            set { _celebrationLimit = value; }
        }

        public MainStore(Main main)
        {
            _main = main;
            _initializeLazy = new Lazy<Task>(Initialize);

            _celebrations = new List<Celebration>();
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

            OnComponentSave(celebration);
        }

        public async Task UpdateComponent(Celebration celebration)
        {
            await _main.UpdateCelebration(celebration);
        }

        public async Task RemoveComponent(Celebration celebration)
        {
            await _main.DeleteCelebration(celebration);
        }

        private void OnComponentSave(Celebration component)
        {
            ComponentMade?.Invoke(component);
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
