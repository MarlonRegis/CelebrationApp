using NLog;
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
        Logger _logger;

        public CelebrationRepository(CelebrationDbContext context) : base(context)
        {
            _logger = NLog.LogManager.GetLogger("logfile");
            _logger.Info("Constructor CelebrationsRepository");

        }

        public IEnumerable<CelebrationDTO> GetAll(int componentLimit)
        {
            _logger.Info("Started process to GetAll Celebrations");
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

            return new List<CelebrationDTO>();
        }

        public async Task Commit()
        {

            _logger.Info("Commit transaction");
            await _context.SaveChangesAsync();
        }

    }
}
