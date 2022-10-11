using Core.Models;
using Data.Context;
using Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BankRepository> _logger;

        public BankRepository(AppDbContext dbContext, ILogger<BankRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Bank> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Bank was Called");

                return await _dbContext.Banks.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Bank: {ex.Message}");
                return null;
            }
        }
        public async Task<Bank> GetByCodeAsync(string code)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Bank was Called");

                return await _dbContext.Banks.FirstOrDefaultAsync(x => x.Code == code);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Bank: {ex.Message}");
                return null;
            }
        }

        public async Task<Bank> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for Bank was Called");

                return await _dbContext.Banks.FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Bank: {ex.Message}");
                return null;
            }
        }
        public async Task<Bank> GetByEnglishNameAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for Bank was Called");

                return await _dbContext.Banks.FirstOrDefaultAsync(x => x.EnglishName.ToLower() == englishName.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Bank: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Bank was Called");
                return await _dbContext.Banks.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Bank: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistArabicAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Bank was Called");
                return await _dbContext.Banks.AnyAsync(x => x.ArabicName.ToLower().Trim() == arabicName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Bank: {ex.Message}");
                return true;
            }
        }

        public async Task<bool> AlreadyExistEnglishAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Bank was Called");
                return await _dbContext.Banks.AnyAsync(x => x.EnglishName.ToLower().Trim() == englishName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Bank: {ex.Message}");
                return true;
            }
        }

        public async Task<bool> AlreadyExistCodeAsync(string code)
        {
            try
            {
                _logger.LogInformation("AlreadyExistCodeAsync for Bank was Called");
                return await _dbContext.Banks.AnyAsync(x => x.Code.ToLower().Trim() == code.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistCodeAsync for Bank: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Bank>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Bank was Called");

                return await _dbContext.Banks.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Bank: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Bank bank)
        {
            try
            {
                _logger.LogInformation("AddAsync for Bank was Called");

                if (bank != null)
                {
                    bank.CreatedBy = "Anonymous";
                    bank.CreatedDate = DateTime.Now;

                    await _dbContext.Banks.AddAsync(bank);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Bank: {ex.Message}");
            }
        }
        public void Update(Bank bank)
        {
            try
            {
                _logger.LogInformation("Update for Bank was Called");
                if (bank != null)
                {
                    bank.ModifiedBy = "Anonymous";
                    bank.LastModified = DateTime.Now;

                    _dbContext.Entry(bank).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Bank: {ex.Message}");
            }
        }
        public void Delete(Bank bank)
        {
            try
            {
                _logger.LogInformation("Delete for Bank was Called");

                if (bank != null)
                {
                    _dbContext.Banks.Remove(bank);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Bank: {ex.Message}");
            }
        }
    }
}
