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
        protected readonly CelebrationDbContext _context;

        public BaseRepository(CelebrationDbContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>();

            if (query.Any())
                return query.ToList();

            return new List<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            var query = _context.Set<TEntity>().Where(e => e.Id == (Guid)id);

            if (query.Any())
                return query.FirstOrDefault();

            return null;
        }

        public virtual async Task Save(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

        }

        public virtual void Update(TEntity entity)
        {

            _context.Set<TEntity>().Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
