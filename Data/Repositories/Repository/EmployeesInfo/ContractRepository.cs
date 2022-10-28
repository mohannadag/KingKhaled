using Core.Models.EmployeesInfo;
using Data.Context;
using Data.Repositories.IRepository.IEmployeesInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.EmployeesInfo
{
    public class ContractRepository : IContractRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ContractRepository> _logger;

        public ContractRepository(AppDbContext dbContext, ILogger<ContractRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Contract> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Contract was Called");

                return await _dbContext.Contracts.Include(x => x.Employee)
                                                 .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Contract: {ex.Message}");
                return null;
            }
        }
        public async Task<Contract> GetByContractNumberAsync(string contractNumber)
        {
            try
            {
                _logger.LogInformation("GetByContractNumberAsync for Contract was Called");

                return await _dbContext.Contracts.Include(x => x.Employee)
                                                 .FirstOrDefaultAsync(x => x.ContractNumber == contractNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByContractNumberAsync for Contract: {ex.Message}");
                return null;
            }
        }
        public async Task<Contract> GetByEmployeeId(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetByEmployeeId for Contract was Called");

                return await _dbContext.Contracts.Include(x => x.Employee)
                                                 .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEmployeeId for Contract: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Contract was Called");
                return await _dbContext.Contracts.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Contract: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> IsValidToExtendAsync(int contractId, DateTime startDate)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Contract was Called");
                return await _dbContext.Contracts.Where(x => x.EndDate < DateTime.Now && x.EndDate < startDate)
                                                 .AnyAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Contract: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistForEmployeeAsync(int employeeId)
        {
            try
            {
                _logger.LogInformation("AlreadyExistForEmployeeAsync for Contract was Called");
                return await _dbContext.Contracts.AnyAsync(x => x.EmployeeId == employeeId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistForEmployeeAsync for Contract: {ex.Message}");
                return true;
            }
        }
        public async Task<bool> AlreadyExistContractNumberAsync(string contractNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistContractNumberAsync for Contract was Called");
                return await _dbContext.Contracts.AnyAsync(x => x.ContractNumber == contractNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistContractNumberAsync for Contract: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Contract>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Contract was Called");

                return await _dbContext.Contracts.Include(x => x.Employee)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for EntryCard: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Contract>> GetAllExpiredAsync()
        {
            try
            {
                _logger.LogInformation("GetAllExpiredAsync for Contract was Called");

                return await _dbContext.Contracts.Include(x => x.Employee)
                                                 .Include(x => x.ContractTransactions)
                                                 .Where(x => x.EndDate < DateTime.Now)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllExpiredAsync for EntryCard: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Contract contract)
        {
            try
            {
                _logger.LogInformation("AddAsync for Contract was Called");

                if (contract != null)
                {
                    contract.CreatedBy = "Anonymous";
                    contract.CreatedDate = DateTime.Now;

                    await _dbContext.Contracts.AddAsync(contract);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Contract: {ex.Message}");
            }
        }
        public void Update(Contract contract)
        {
            try
            {
                _logger.LogInformation("Update for Contract was Called");
                if (contract != null)
                {
                    contract.ModifiedBy = "Anonymous";
                    contract.LastModified = DateTime.Now;

                    _dbContext.Entry(contract).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Contract: {ex.Message}");
            }
        }
        public void Delete(Contract contract)
        {
            try
            {
                _logger.LogInformation("Delete for Contract was Called");

                if (contract != null)
                {
                    _dbContext.Contracts.Remove(contract);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Contract: {ex.Message}");
            }
        }

        
    }
}
