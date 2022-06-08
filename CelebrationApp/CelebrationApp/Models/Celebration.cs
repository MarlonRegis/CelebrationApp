using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Models
{
    public class Celebration
    {
        public Celebration(Guid id, string name, string description, DateTime recordDate, DateTime celebrationDate)
        {
            this.id = id;
            Name = name;
            Description = description;
            RecordDate = recordDate;
            CelebrationDate = celebrationDate;
        }

        public Guid id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CelebrationDate { get; set; }


    }
}
