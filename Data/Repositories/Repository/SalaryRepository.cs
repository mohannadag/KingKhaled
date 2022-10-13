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
    public class SalaryRepository : ISalaryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<SalaryRepository> _logger;

        public SalaryRepository(AppDbContext dbContext, ILogger<SalaryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Salary> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Salary was Called");

                return await _dbContext.Salaries.Include(x => x.Grade)
                                                .Include(x => x.Level)
                                                .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Salary: {ex.Message}");
                return null;
            }
        }
        public async Task<Salary> GetByGradeIdAndLevelIdAsync(int gradeId, int levelId)
        {
            try
            {
                _logger.LogInformation("GetByGradeIdAndLevelIdAsync for Salary was Called");

                return await _dbContext.Salaries.Include(x => x.Grade)
                                                .Include(x => x.Level)
                                                .FirstOrDefaultAsync(x => x.GradeId == gradeId && x.LevelId == levelId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByGradeIdAndLevelIdAsync for Salary: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Salary was Called");
                return await _dbContext.Salaries.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Salary: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(int gradeId, int levelId)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Salary was Called");
                return await _dbContext.Salaries.AnyAsync(x => x.GradeId == gradeId && x.LevelId == levelId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Salary: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Salary>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Salary was Called");

                return await _dbContext.Salaries.Include(x => x.Grade)
                                                .Include(x => x.Level)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Salary: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Salary>> GetAllByGradeIdAsync(int gradeId)
        {
            try
            {
                _logger.LogInformation("GetAllByGradeIdAsync for Salary was Called");

                return await _dbContext.Salaries.Include(x => x.Grade)
                                                .Include(x => x.Level)
                                                .Where(x => x.GradeId == gradeId)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByGradeIdAsync for Salary: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Salary>> GetAllByLevelIdAsync(int levelId)
        {
            try
            {
                _logger.LogInformation("GetAllByLevelIdAsync for Salary was Called");

                return await _dbContext.Salaries.Include(x => x.Grade)
                                                .Include(x => x.Level)
                                                .Where(x => x.LevelId == levelId)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByLevelIdAsync for Salary: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Salary salary)
        {
            try
            {
                _logger.LogInformation("AddAsync for Salary was Called");

                if (salary != null)
                {
                    salary.CreatedBy = "Anonymous";
                    salary.CreatedDate = DateTime.Now;

                    await _dbContext.Salaries.AddAsync(salary);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Salary: {ex.Message}");
            }
        }
        public void Update(Salary salary)
        {
            try
            {
                _logger.LogInformation("Update for Salary was Called");
                if (salary != null)
                {
                    salary.ModifiedBy = "Anonymous";
                    salary.LastModified = DateTime.Now;

                    _dbContext.Entry(salary).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Salary: {ex.Message}");
            }
        }
        public void Delete(Salary salary)
        {
            try
            {
                _logger.LogInformation("Delete for Salary was Called");

                if (salary != null)
                {
                    _dbContext.Salaries.Remove(salary);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Salary: {ex.Message}");
            }
        }
    }
}
