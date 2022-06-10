using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Models
{
    public class Main
    {
        private readonly CelebrationBook _celebrationBook;

        public string Name { get; }

        public Main(string name, CelebrationBook celebrationBook)
        {
            Name = name;
            _celebrationBook = celebrationBook;
        }

        public IEnumerable<Celebration> GetAllCelebrations(int componenetLimit = 0)
        {
            return _celebrationBook.GetAllCelebrations(componenetLimit);
        }

        public async Task SaveCelebration(Celebration celebration)
        {
            await _celebrationBook.AddCelebration(celebration);
        }

        public async Task UpdateCelebration(Celebration celebration)
        {
            await _celebrationBook.UpdateCelebration(celebration);
        }

        public async Task DeleteCelebration(Celebration celebration)
        {
            await _celebrationBook.DeleteCelebration(celebration);
        }
    }
}
