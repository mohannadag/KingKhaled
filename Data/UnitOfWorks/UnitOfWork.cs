using Data.Context;
using Data.Repositories.IRepository;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Repository;

namespace Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public INationalityRepository Nationalities => new NationalityRepository(
            _dbContext, new Logger<NationalityRepository>(new NullLoggerFactory()));
        public IIdentityRepository Identities => new IdentityRepository(
            _dbContext, new Logger<IdentityRepository>(new NullLoggerFactory()));
        public IEmployeeRepository Employees => new EmployeeRepository(
            _dbContext, new Logger<EmployeeRepository>(new NullLoggerFactory()));

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
