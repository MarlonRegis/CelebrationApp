using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.DbContexts
{
    public class CelebrationDbContextFactory
    {
        private readonly string _connectionString;

        public CelebrationDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CelebrationDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new CelebrationDbContext(options);
        }
    }
}
