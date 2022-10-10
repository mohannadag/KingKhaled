using Core.Models;
using Data.Context;
using Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository
{
    public class EmployeeAccountRepository : IEmployeeAccountRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EmployeeAccountRepository> _logger;

        public EmployeeAccountRepository(AppDbContext dbContext, ILogger<EmployeeAccountRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<EmployeeAccount> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for EmployeeAccount was Called");

                return await _dbContext.EmployeeAccounts.Include(x => x.Employee)
                                                        .Include(x => x.Bank)
                                                        .LastOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for EmployeeAccount: {ex.Message}");
                return null;
            }
        }
        public async Task<EmployeeAccount> GetByNumberAsync(string accountNumber)
        {
            try
            {
                _logger.LogInformation("GetByNumberAsync for EmployeeAccount was Called");

                return await _dbContext.EmployeeAccounts.Include(x => x.Employee)
                                                        .Include(x => x.Bank)
                                                        .LastOrDefaultAsync(x => x.AccountNumber == accountNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNumberAsync for EmployeeAccount: {ex.Message}");
                return null;
            }
        }
        public async Task<EmployeeAccount> GetByIBANAsync(string iban)
        {
            try
            {
                _logger.LogInformation("GetByIBANAsync for EmployeeAccount was Called");

                return await _dbContext.EmployeeAccounts.Include(x => x.Employee)
                                                        .Include(x => x.Bank)
                                                        .LastOrDefaultAsync(x => x.IBAN.ToUpper() == iban.ToUpper());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIBANAsync for EmployeeAccount: {ex.Message}");
                return null;
            }
        }


        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for EmployeeAccount was Called");
                return await _dbContext.EmployeeAccounts.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for EmployeeAccount: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AlreadyExistAsync(int employeeId, int bankId)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for EmployeeAccount was Called");
                return await _dbContext.EmployeeAccounts.AnyAsync(x => x.EmployeeId == employeeId && x.BankId == bankId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for EmployeeAccount: {ex.Message}");
                return true;
            }
        }

        public async Task<bool> AlreadyExistIBANAsync(string iban)
        {
            try
            {
                _logger.LogInformation("AlreadyExistIBANAsync for EmployeeAccount was Called");
                return await _dbContext.EmployeeAccounts.AnyAsync(x => x.IBAN.Trim().ToUpper() == iban.Trim().ToUpper());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistIBANAsync for EmployeeAccount: {ex.Message}");
                return true;
            }
        }

        public async Task<bool> AlreadyExistNumberAsync(string accountNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistNumberAsync for EmployeeAccount was Called");
                return await _dbContext.EmployeeAccounts.AnyAsync(x => x.AccountNumber.Trim().ToUpper() == accountNumber.Trim().ToUpper());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistNumberAsync for EmployeeAccount: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<EmployeeAccount>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for EmployeeAccount was Called");

                return await _dbContext.EmployeeAccounts.Include(x => x.Employee)
                                                        .Include(x => x.Bank)
                                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for EmployeeAccount: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<EmployeeAccount>> GetAllByBankIdAsync(int bankId)
        {
            try
            {
                _logger.LogInformation("GetAllByBankIdAsync for EmployeeAccount was Called");

                return await _dbContext.EmployeeAccounts.Include(x => x.Employee)
                                                        .Include(x => x.Bank)
                                                        .Where(x => x.BankId == bankId)
                                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByBankIdAsync for EmployeeAccount: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<EmployeeAccount>> GetAllByEmployeeIdAsync(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetAllByEmployeeIdAsync for EmployeeAccount was Called");

                return await _dbContext.EmployeeAccounts.Include(x => x.Employee)
                                                        .Include(x => x.Bank)
                                                        .Where(x => x.EmployeeId == employeeId)
                                                        .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByEmployeeIdAsync for EmployeeAccount: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(EmployeeAccount employeeAccount)
        {
            try
            {
                _logger.LogInformation("AddAsync for EmployeeAccount was Called");

                if (employeeAccount != null)
                {
                    employeeAccount.CreatedDate = DateTime.Now;
                    employeeAccount.LastModified = DateTime.Now;

                    await _dbContext.EmployeeAccounts.AddAsync(employeeAccount);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for EmployeeAccount: {ex.Message}");
            }
        }
        public void Update(EmployeeAccount employeeAccount)
        {
            try
            {
                _logger.LogInformation("Update for EmployeeAccount was Called");
                if (employeeAccount != null)
                {
                    employeeAccount.LastModified = DateTime.Now;
                    _dbContext.Entry(employeeAccount).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for EmployeeAccount: {ex.Message}");
            }
        }
        public void Delete(EmployeeAccount employeeAccount)
        {
            try
            {
                _logger.LogInformation("Delete for EmployeeAccount was Called");

                if (employeeAccount != null)
                {
                    _dbContext.EmployeeAccounts.Remove(employeeAccount);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for EmployeeAccount: {ex.Message}");
            }
        }
    }
}
