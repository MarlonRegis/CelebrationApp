using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.DTOs
{
    public class GenericDTO
    {
        [Key]
        public Guid Id { get; private set; }
    }
}
