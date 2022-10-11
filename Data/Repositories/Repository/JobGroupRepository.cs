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
    public class JobGroupRepository : IJobGroupRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<JobGroupRepository> _logger;

        public JobGroupRepository(AppDbContext dbContext, ILogger<JobGroupRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<JobGroup> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for JobGroup was Called");

                return await _dbContext.JobGroups.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for JobGroup: {ex.Message}");
                return null;
            }
        }
        public async Task<JobGroup> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for JobGroup was Called");

                return await _dbContext.JobGroups.FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for JobGroup: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for JobGroup was Called");
                return await _dbContext.JobGroups.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for JobGroup: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistArabicAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for JobGroup was Called");
                return await _dbContext.JobGroups.AnyAsync(x => x.ArabicName.ToLower().Trim() == arabicName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for JobGroup: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<JobGroup>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for JobGroup was Called");

                return await _dbContext.JobGroups.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for JobGroup: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(JobGroup jobGroup)
        {
            try
            {
                _logger.LogInformation("AddAsync for JobGroup was Called");

                if (jobGroup != null)
                {
                    jobGroup.CreatedBy = "Anonymous";
                    jobGroup.CreatedDate = DateTime.Now;

                    await _dbContext.JobGroups.AddAsync(jobGroup);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for JobGroup: {ex.Message}");
            }
        }
        public void Update(JobGroup jobGroup)
        {
            try
            {
                _logger.LogInformation("Update for JobGroup was Called");
                if (jobGroup != null)
                {
                    jobGroup.ModifiedBy = "Anonymous";
                    jobGroup.LastModified = DateTime.Now;

                    _dbContext.Entry(jobGroup).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for JobGroup: {ex.Message}");
            }
        }
        public void Delete(JobGroup jobGroup)
        {
            try
            {
                _logger.LogInformation("Delete for JobGroup was Called");

                if (jobGroup != null)
                {
                    _dbContext.JobGroups.Remove(jobGroup);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for JobGroup: {ex.Message}");
            }
        }
    }
}
