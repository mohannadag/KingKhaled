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
    public class ContractTransactionRepository : IContractTransactionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ContractTransactionRepository> _logger;

        public ContractTransactionRepository(AppDbContext dbContext, ILogger<ContractTransactionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<ContractTransaction> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for ContractTransaction was Called");

                return await _dbContext.ContractTransactions.Include(x => x.Contract)
                                                            .ThenInclude(x => x.Employee)
                                                            .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for ContractTransaction: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for ContractTransaction was Called");
                return await _dbContext.ContractTransactions.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for ContractTransaction: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExtendedAsync()
        {
            try
            {
                _logger.LogInformation("AlreadyExtendedAsync for ContractTransaction was Called");
                return await _dbContext.ContractTransactions.AnyAsync(x => x.EndDate > DateTime.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExtendedAsync for ContractTransaction: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<ContractTransaction>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for ContractTransaction was Called");

                return await _dbContext.ContractTransactions.Include(x => x.Contract)
                                                            .ThenInclude(x => x.Employee)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for ContractTransaction: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<ContractTransaction>> GetAllByContractIdAsync(int contractId)
        {
            try
            {
                _logger.LogInformation("GetAllByContractIdAsync for ContractTransaction was Called");

                return await _dbContext.ContractTransactions.Include(x => x.Contract)
                                                            .ThenInclude(x => x.Employee)
                                                            .Where(x => x.ContractId == contractId)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByContractIdAsync for ContractTransaction: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<ContractTransaction>> GetAllByContractNumberAsync(string contractNumber)
        {
            try
            {
                _logger.LogInformation("GetAllByContractNumberAsync for ContractTransaction was Called");

                return await _dbContext.ContractTransactions.Include(x => x.Contract)
                                                            .ThenInclude(x => x.Employee)
                                                            .Where(x => x.Contract.ContractNumber == contractNumber)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByContractNumberAsync for ContractTransaction: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<ContractTransaction>> GetAllByEmployeeIdAsync(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetAllByEmployeeIdAsync for ContractTransaction was Called");

                return await _dbContext.ContractTransactions.Include(x => x.Contract)
                                                            .ThenInclude(x => x.Employee)
                                                            .Where(x => x.Contract.EmployeeId == employeeId)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByEmployeeIdAsync for ContractTransaction: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(ContractTransaction contractTransaction)
        {
            try
            {
                _logger.LogInformation("AddAsync for ContractTransaction was Called");

                if (contractTransaction != null)
                {
                    contractTransaction.CreatedBy = "Anonymous";
                    contractTransaction.CreatedDate = DateTime.Now;

                    await _dbContext.ContractTransactions.AddAsync(contractTransaction);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for ContractTransaction: {ex.Message}");
            }
        }
        public void Update(ContractTransaction contractTransaction)
        {
            try
            {
                _logger.LogInformation("Update for ContractTransaction was Called");
                if (contractTransaction != null)
                {
                    contractTransaction.ModifiedBy = "Anonymous";
                    contractTransaction.LastModified = DateTime.Now;

                    _dbContext.Entry(contractTransaction).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for ContractTransaction: {ex.Message}");
            }
        }
        public void Delete(ContractTransaction contractTransaction)
        {
            try
            {
                _logger.LogInformation("Delete for ContractTransaction was Called");

                if (contractTransaction != null)
                {
                    _dbContext.ContractTransactions.Remove(contractTransaction);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for ContractTransaction: {ex.Message}");
            }
        }
    }
}
