using CelebrationApp.Models;
using Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Services.Factory
{
    public class CelebrationFactory
    {
        public Celebration createCelebration(Guid id, string name, string description, DateTime recordDate, DateTime celebrationDate)
        {
            Celebration celebration = new Celebration(id, name, description, recordDate, celebrationDate);
            return celebration;
        }


        public Celebration ToCelebration(CelebrationDTO res)
        {
            return new Celebration(res.Id, res.Name, res.Description, res.RecordDate, res.CelebrationDate);
        }

        public CelebrationDTO ToCelebrationDTO(Celebration celebration)
        {
            return new CelebrationDTO()
            {
                Name = celebration.Name,
                Description = celebration.Description,
                CelebrationDate = celebration.CelebrationDate,
                RecordDate = celebration.RecordDate
            };
        }
    }
}
