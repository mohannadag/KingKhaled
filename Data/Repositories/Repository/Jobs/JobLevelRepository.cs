using Core.Models.Jobs;
using Data.Context;
using Data.Repositories.IRepository.IJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.Jobs
{
    public class JobLevelRepository : IJobLevelRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<JobLevelRepository> _logger;

        public JobLevelRepository(AppDbContext dbContext, ILogger<JobLevelRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<JobLevel> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for JobLevel was Called");

                return await _dbContext.JobLevels.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for JobLevel: {ex.Message}");
                return null;
            }
        }
        public async Task<JobLevel> GetByNameAsync(string name)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for JobLevel was Called");

                return await _dbContext.JobLevels.FirstOrDefaultAsync(x => x.Name == name);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for JobLevel: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for JobLevel was Called");
                return await _dbContext.JobLevels.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for JobLevel: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string name)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for JobLevel was Called");
                return await _dbContext.JobLevels.AnyAsync(x => x.Name.Trim() == name.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for JobLevel: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<JobLevel>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for JobLevel was Called");

                return await _dbContext.JobLevels.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for JobLevel: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(JobLevel jobLevel)
        {
            try
            {
                _logger.LogInformation("AddAsync for JobLevel was Called");

                if (jobLevel != null)
                {
                    jobLevel.CreatedBy = "Anonymous";
                    jobLevel.CreatedDate = DateTime.Now;

                    await _dbContext.JobLevels.AddAsync(jobLevel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for JobLevel: {ex.Message}");
            }
        }
        public void Update(JobLevel jobLevel)
        {
            try
            {
                _logger.LogInformation("Update for JobLevel was Called");
                if (jobLevel != null)
                {
                    jobLevel.ModifiedBy = "Anonymous";
                    jobLevel.LastModified = DateTime.Now;

                    _dbContext.Entry(jobLevel).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for JobLevel: {ex.Message}");
            }
        }
        public void Delete(JobLevel jobLevel)
        {
            try
            {
                _logger.LogInformation("Delete for JobLevel was Called");

                if (jobLevel != null)
                {
                    _dbContext.JobLevels.Remove(jobLevel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for JobLevel: {ex.Message}");
            }
        }
    }
}
