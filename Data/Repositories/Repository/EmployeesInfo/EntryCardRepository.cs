using Core.Models.EmployeesInfo;
using Core.Models.General;
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
    public class EntryCardRepository : IEntryCardRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EntryCardRepository> _logger;

        public EntryCardRepository(AppDbContext dbContext, ILogger<EntryCardRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<EntryCard> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for EntryCard was Called");

                return await _dbContext.EntryCards.Include(x => x.Employee)
                                                  .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for EntryCard: {ex.Message}");
                return null;
            }
        }
        public async Task<EntryCard> GetByEmployeeId(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetByEmployeeId for EntryCard was Called");

                return await _dbContext.EntryCards.Include(x => x.Employee)
                                                  .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEmployeeId for EntryCard: {ex.Message}");
                return null;
            }
        }
        public async Task<EntryCard> GetBySecurityNumberAsync(string securityNumber)
        {
            try
            {
                _logger.LogInformation("GetBySecurityNumberAsync for EntryCard was Called");

                return await _dbContext.EntryCards.Include(x => x.Employee)
                                                  .FirstOrDefaultAsync(x => x.SecurityNumber == securityNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetBySecurityNumberAsync for EntryCard: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for EntryCard was Called");
                return await _dbContext.EntryCards.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for EntryCard: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistSecurityNumberAsync(string securityNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistSecurityNumberAsync for EntryCard was Called");
                return await _dbContext.EntryCards.AnyAsync(x => x.SecurityNumber.ToLower().Trim() == securityNumber.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistSecurityNumberAsync for EntryCard: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<EntryCard>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for EntryCard was Called");

                return await _dbContext.EntryCards.Include(x => x.Employee)
                                                  .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for EntryCard: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(EntryCard entryCard)
        {
            try
            {
                _logger.LogInformation("AddAsync for EntryCard was Called");

                if (entryCard != null)
                {
                    entryCard.CreatedBy = "Anonymous";
                    entryCard.CreatedDate = DateTime.Now;

                    await _dbContext.EntryCards.AddAsync(entryCard);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for EntryCard: {ex.Message}");
            }
        }
        public void Update(EntryCard entryCard)
        {
            try
            {
                _logger.LogInformation("Update for EntryCard was Called");
                if (entryCard != null)
                {
                    entryCard.ModifiedBy = "Anonymous";
                    entryCard.LastModified = DateTime.Now;

                    _dbContext.Entry(entryCard).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for EntryCard: {ex.Message}");
            }
        }
        public void Delete(EntryCard entryCard)
        {
            try
            {
                _logger.LogInformation("Delete for EntryCard was Called");

                if (entryCard != null)
                {
                    _dbContext.EntryCards.Remove(entryCard);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for EntryCard: {ex.Message}");
            }
        }
    }
}
