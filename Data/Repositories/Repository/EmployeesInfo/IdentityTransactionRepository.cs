using Core.Models.EmployeesInfo;
using Data.Context;
using Data.Repositories.IRepository.IEmployeesInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.EmployeesInfo
{
    public class IdentityTransactionRepository : IIdentityTransactionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<IdentityTransactionRepository> _logger;

        public IdentityTransactionRepository(AppDbContext dbContext, ILogger<IdentityTransactionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IdentityTransaction> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for IdentityTransaction was Called");

                return await _dbContext.IdentityTransactions.Include(x => x.Identity)
                                                            .ThenInclude(x => x.Employee)
                                                            .Include(x => x.JobVisa)
                                                            .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for IdentityTransaction: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<IdentityTransaction>> GetAllByEmployeeIdAsync(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetAllByEmployeeIdAsync for IdentityTransaction was Called");

                return await _dbContext.IdentityTransactions.Include(x => x.Identity)
                                                            .ThenInclude(x => x.Employee)
                                                            .Include(x => x.JobVisa)
                                                            .Where(x => x.Identity.EmployeeId == employeeId)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByEmployeeIdAsync for IdentityTransaction: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<IdentityTransaction>> GetAllByIdentityIdAsync(int identityId)
        {
            try
            {
                _logger.LogInformation("GetAllByIdentityIdAsync for IdentityTransaction was Called");

                return await _dbContext.IdentityTransactions.Include(x => x.Identity)
                                                            .ThenInclude(x => x.Employee)
                                                            .Include(x => x.JobVisa)
                                                            .Where(x => x.IdentityId == identityId)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByContractIdAsync for ContractTransaction: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<IdentityTransaction>> GetAllByIdentityNumberAsync(string identityNumber)
        {
            try
            {
                _logger.LogInformation("GetAllByIdentityNumberAsync for IdentityTransaction was Called");

                return await _dbContext.IdentityTransactions.Include(x => x.Identity)
                                                            .ThenInclude(x => x.Employee)
                                                            .Include(x => x.JobVisa)
                                                            .Where(x => x.Identity.IdentityNumber == identityNumber)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByIdentityNumberAsync for IdentityTransaction: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(IdentityTransaction identityTransaction)
        {
            try
            {
                _logger.LogInformation("AddAsync for IdentityTransaction was Called");

                if (identityTransaction != null)
                {
                    identityTransaction.CreatedBy = "Anonymous";
                    identityTransaction.CreatedDate = DateTime.Now;

                    await _dbContext.IdentityTransactions.AddAsync(identityTransaction);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for IdentityTransaction: {ex.Message}");
            }
        }
    }
}
