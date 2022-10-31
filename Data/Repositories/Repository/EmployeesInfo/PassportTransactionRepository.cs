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
    public class PassportTransactionRepository : IPassportTransactionRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<PassportTransactionRepository> _logger;

        public PassportTransactionRepository(AppDbContext dbContext, ILogger<PassportTransactionRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<PassportTransaction> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for PassportTransaction was Called");

                return await _dbContext.PassportTransactions.Include(x => x.Passport)
                                                            .ThenInclude(x => x.Employee)
                                                            .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for PassportTransaction: {ex.Message}");
                return null;
            }
        }
        
        public async Task<IEnumerable<PassportTransaction>> GetAllByEmployeeIdAsync(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetAllByEmployeeIdAsync for PassportTransaction was Called");

                return await _dbContext.PassportTransactions.Include(x => x.Passport)
                                                            .ThenInclude(x => x.Employee)
                                                            .Where(x => x.Passport.EmployeeId == employeeId)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByEmployeeIdAsync for PassportTransaction: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<PassportTransaction>> GetAllByPassportIdAsync(int passportId)
        {
            try
            {
                _logger.LogInformation("GetAllByPassportIdAsync for PassportTransaction was Called");

                return await _dbContext.PassportTransactions.Include(x => x.Passport)
                                                            .ThenInclude(x => x.Employee)
                                                            .Where(x => x.PassportId == passportId)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByPassportIdAsync for PassportTransaction: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<PassportTransaction>> GetAllByPassportNumberAsync(string passportNumber)
        {
            try
            {
                _logger.LogInformation("GetAllByPassportNumberAsync for PassportTransaction was Called");

                return await _dbContext.PassportTransactions.Include(x => x.Passport)
                                                            .ThenInclude(x => x.Employee)
                                                            .Where(x => x.Passport.PassportNumber == passportNumber)
                                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByPassportNumberAsync for PassportTransaction: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(PassportTransaction passportTransaction)
        {
            try
            {
                _logger.LogInformation("AddAsync for PassportTransaction was Called");

                if (passportTransaction != null)
                {
                    passportTransaction.CreatedBy = "Anonymous";
                    passportTransaction.CreatedDate = DateTime.Now;

                    await _dbContext.PassportTransactions.AddAsync(passportTransaction);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for PassportTransaction: {ex.Message}");
            }
        }
    }
}
