using Core.Models.Financial;
using Data.Context;
using Data.Repositories.IRepository.IFinancials;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.Financials
{
    public class LevelRepository : ILevelRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<LevelRepository> _logger;

        public LevelRepository(AppDbContext dbContext, ILogger<LevelRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Level> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Level was Called");

                return await _dbContext.Levels.Include(x => x.Grades)
                                              .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Level: {ex.Message}");
                return null;
            }
        }
        public async Task<Level> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for Level was Called");

                return await _dbContext.Levels.Include(x => x.Grades)
                                              .FirstOrDefaultAsync(x => x.Name == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Level: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Level was Called");
                return await _dbContext.Levels.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Level: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AlreadyExistNumberAsync(int levelNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistNumberAsync for Level was Called");
                return await _dbContext.Levels.AnyAsync(x => x.LevelNumber == levelNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistNumberAsync for Level: {ex.Message}");
                return true;
            }
        }
        public async Task<bool> AlreadyExistArabicAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Level was Called");
                return await _dbContext.Levels.AnyAsync(x => x.Name.ToLower().Trim() == arabicName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Level: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Level>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Level was Called");

                return await _dbContext.Levels.Include(x => x.Grades)
                                              .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Level: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Level level)
        {
            try
            {
                _logger.LogInformation("AddAsync for Level was Called");

                if (level != null)
                {
                    level.CreatedBy = "Anonymous";
                    level.CreatedDate = DateTime.Now;

                    await _dbContext.Levels.AddAsync(level);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Level: {ex.Message}");
            }
        }
        public void Update(Level level)
        {
            try
            {
                _logger.LogInformation("Update for Level was Called");
                if (level != null)
                {
                    level.ModifiedBy = "Anonymous";
                    level.LastModified = DateTime.Now;

                    _dbContext.Entry(level).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Level: {ex.Message}");
            }
        }
        public void Delete(Level level)
        {
            try
            {
                _logger.LogInformation("Delete for Level was Called");

                if (level != null)
                {
                    _dbContext.Levels.Remove(level);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Level: {ex.Message}");
            }
        }

        
    }
}
