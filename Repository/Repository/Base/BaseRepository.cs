using NLog;
using Repository.DbContexts;
using Repository.Interfaces;
using Repository.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : GenericDTO
    {

        private readonly Logger _logger;

        protected readonly CelebrationDbContext _context;

        public BaseRepository(CelebrationDbContext context)
        {
            _context = context;
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();

            if (query.Any())
                return query.ToList();

            _logger.Info("Method GetAll in BaseRepository");
            return new List<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            var query = _context.Set<TEntity>().Where(e => e.Id == (Guid)id);

            if (query.Any())
                return query.FirstOrDefault();
            _logger.Info("Method GetById in BaseRepository");
            return null;
        }

        public virtual async Task Save(TEntity entity)
        {
            _logger.Info("Method Save in BaseRepository");
            await _context.Set<TEntity>().AddAsync(entity);

        }

        public virtual void Update(TEntity entity)
        {
            _logger.Info("Method Update in BaseRepository");
            _context.Set<TEntity>().Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {

            _logger.Info("Method Remove in BaseRepository");
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
