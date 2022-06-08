using Repository.DbContexts;
using Repository.DTOs;
using Repository.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CelebrationRepository : BaseRepository<CelebrationDTO>
    {
        public CelebrationRepository(CelebrationDbContext context) : base(context)
        {
        }

        public IEnumerable<CelebrationDTO> GetAll(int componentLimit)
        {
            var query = _context.Set<CelebrationDTO>();

            if (query.Any())
                if (componentLimit == 0)
                    return query.OrderBy(s => s.RecordDate).ToList();
                else
                    return query.Take(componentLimit).OrderByDescending(s => s.RecordDate).ToList();


            return new List<CelebrationDTO>();
        }

        public CelebrationDTO GetConflictingComponent(CelebrationDTO componentDTO)
        {

            CelebrationDTO component = _context.Celebrations
                .Where(c => c.Id == componentDTO.Id)
                .Where(c => c.Name == componentDTO.Name)
                .FirstOrDefault();

            if (component == null)
                return null;

            return component;
        }

    }
}
