using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.ViewModels
{
    public class CelebrationRecordViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CelebrationDate { get; set; } 

        /*
                public CelebrationRecordViewModel(Entidade model)
                {
                    Id = model.id;
                    Name = model.name;
                    Description = model.description;
                    RecordDate = model.recordDate;
                    CelebrationDate = model.celebrationDate;
                }

        */
    }
}
