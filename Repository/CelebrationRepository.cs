using Commons.MyLogger;
using Microsoft.Extensions.Logging;
using Repository.Repository.Base;
using Repository.Repository.DbContexts;
using Repository.Repository.DTOs;
using System.Collections.Generic;
using System.Linq;
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
            _context = new CelebrationDbContext(_context._options);

            var query = _context.Set<CelebrationDTO>();

            if (query.Any())
                if (componentLimit == 0)
                {
                    return query.OrderBy(s => s.RecordDate).ToList();
                }
                else
                {
                    return query.Take(componentLimit).OrderByDescending(s => s.RecordDate).ToList();
                }

            MyLogger.GetLog().LogDebug("GetAll celebration return");
            return new List<CelebrationDTO>();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();

            MyLogger.GetLog().LogDebug("Commited transaction");
        }

    }
}
