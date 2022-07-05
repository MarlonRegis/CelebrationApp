using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.DTOs
{
    public class CelebrationDTO : GenericDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime CelebrationDate { get; set; }
    }
}
