using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Models
{
    public class Celebration
    {
        public Celebration( string name, string description, DateTime recordDate, DateTime celebrationDate, object id = null)
        {
            this.id = id;
            Name = name;
            Description = description;
            RecordDate = recordDate;
            CelebrationDate = celebrationDate;
        }

        public object id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CelebrationDate { get; set; }


    }
}
