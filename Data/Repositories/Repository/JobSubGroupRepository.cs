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
    public class JobSubGroupRepository : IJobSubGroupRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<JobSubGroupRepository> _logger;

        public JobSubGroupRepository(AppDbContext dbContext, ILogger<JobSubGroupRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<JobSubGroup> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for JobSubGroup was Called");

                return await _dbContext.JobSubGroups.Include(x => x.JobGroup)
                                                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for JobSubGroup: {ex.Message}");
                return null;
            }
        }
        public async Task<JobSubGroup> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByArabicNameAsync for JobSubGroup was Called");

                return await _dbContext.JobSubGroups.Include(x => x.JobGroup)
                                                    .FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByArabicNameAsync for JobSubGroup: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for JobSubGroup was Called");
                return await _dbContext.JobSubGroups.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for JobSubGroup: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AlreadyExistArabicAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for JobSubGroup was Called");
                return await _dbContext.JobSubGroups.AnyAsync(x => x.ArabicName.ToLower().Trim() == arabicName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for JobSubGroup: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<JobSubGroup>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for JobSubGroup was Called");

                return await _dbContext.JobSubGroups.Include(x => x.JobGroup)
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for JobSubGroup: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<JobSubGroup>> GetAllByJobGroupIdAsync(int jobGroupId)
        {
            try
            {
                _logger.LogInformation("GetAllByJobGroupIdAsync for JobSubGroup was Called");

                return await _dbContext.JobSubGroups.Include(x => x.JobGroup)
                                                    .Where(x => x.JobGroupId == jobGroupId)   
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByJobGroupIdAsync for JobSubGroup: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(JobSubGroup jobSubGroup)
        {
            try
            {
                _logger.LogInformation("AddAsync for JobSubGroup was Called");

                if (jobSubGroup != null)
                {
                    jobSubGroup.CreatedBy = "Anonymous";
                    jobSubGroup.CreatedDate = DateTime.Now;

                    await _dbContext.JobSubGroups.AddAsync(jobSubGroup);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for JobSubGroup: {ex.Message}");
            }
        }
        public void Update(JobSubGroup jobSubGroup)
        {
            try
            {
                _logger.LogInformation("Update for JobSubGroup was Called");
                if (jobSubGroup != null)
                {
                    jobSubGroup.ModifiedBy = "Anonymous";
                    jobSubGroup.LastModified = DateTime.Now;

                    _dbContext.Entry(jobSubGroup).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for JobSubGroup: {ex.Message}");
            }
        }
        public void Delete(JobSubGroup jobSubGroup)
        {
            try
            {
                _logger.LogInformation("Delete for JobSubGroup was Called");

                if (jobSubGroup != null)
                {
                    _dbContext.JobSubGroups.Remove(jobSubGroup);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for JobSubGroup: {ex.Message}");
            }
        }
    }
}
