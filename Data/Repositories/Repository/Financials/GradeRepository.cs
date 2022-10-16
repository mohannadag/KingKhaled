using Core.Models.Financial;
using Data.Context;
using Data.Repositories.IRepository.IFinancials;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.Financials
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<GradeRepository> _logger;

        public GradeRepository(AppDbContext dbContext, ILogger<GradeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Grade was Called");

                return await _dbContext.Grades.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Grade: {ex.Message}");
                return null;
            }
        }
        public async Task<Grade> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for Grade was Called");

                return await _dbContext.Grades.FirstOrDefaultAsync(x => x.Name == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Grade: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Grade was Called");
                return await _dbContext.Grades.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Grade: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> IsValidLevelIdForGradeAsync(int gradeId, int levelId)
        {
            try
            {
                _logger.LogInformation("IsValidLevelIdForGradeAsync for Grade was Called");
                return await _dbContext.Grades.AnyAsync(x => x.Id == gradeId && x.Levels.Any(x => x.Id == levelId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidLevelIdForGradeAsync for Grade: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AlreadyExistArabicAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Grade was Called");
                return await _dbContext.Grades.AnyAsync(x => x.Name.ToLower().Trim() == arabicName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Grade: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Grade was Called");

                return await _dbContext.Grades.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Grade: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Grade grade)
        {
            try
            {
                _logger.LogInformation("AddAsync for Grade was Called");

                if (grade != null)
                {
                    grade.CreatedBy = "Anonymous";
                    grade.CreatedDate = DateTime.Now;

                    await _dbContext.Grades.AddAsync(grade);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Grade: {ex.Message}");
            }
        }
        public void Update(Grade grade)
        {
            try
            {
                _logger.LogInformation("Update for Grade was Called");
                if (grade != null)
                {
                    grade.ModifiedBy = "Anonymous";
                    grade.LastModified = DateTime.Now;

                    _dbContext.Entry(grade).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Grade: {ex.Message}");
            }
        }
        public void Delete(Grade grade)
        {
            try
            {
                _logger.LogInformation("Delete for Grade was Called");

                if (grade != null)
                {
                    _dbContext.Grades.Remove(grade);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Grade: {ex.Message}");
            }
        }


    }
}
