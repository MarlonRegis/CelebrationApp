using CelebrationCore.Models;
using Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationCore.Services.Factory
{
    public class CelebrationFactory
    {
        public Celebration createCelebration(string name, string description, DateTime recordDate, DateTime celebrationDate)
        {
            Celebration celebration = new Celebration( name, description, recordDate, celebrationDate);
            return celebration;
        }


        public Celebration ToCelebration(CelebrationDTO res)
        {
            return new Celebration( res.Name, res.Description, res.RecordDate, res.CelebrationDate, res.Id);
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
