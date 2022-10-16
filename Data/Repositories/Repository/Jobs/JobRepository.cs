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
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<JobRepository> _logger;

        public JobRepository(AppDbContext dbContext, ILogger<JobRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Job was Called");

                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Job: {ex.Message}");
                return null;
            }
        }
        public async Task<Job> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for Job was Called");

                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Job: {ex.Message}");
                return null;
            }
        }
        public async Task<Job> GetByCodeAsync(string code)
        {
            try
            {
                _logger.LogInformation("GetByCodeAsync for Job was Called");

                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .FirstOrDefaultAsync(x => x.Code.ToLower() == code.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByCodeAsync for Job: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Job was Called");
                return await _dbContext.Jobs.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Job: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AlreadyExistCodeAsync(string code)
        {
            try
            {
                _logger.LogInformation("AlreadyExistCodeAsync for Job was Called");
                return await _dbContext.Jobs.AnyAsync(x => x.Code == code);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistCodeAsync for Job: {ex.Message}");
                return true;
            }
        }
        public async Task<bool> AlreadyExistArabicAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Job was Called");
                return await _dbContext.Jobs.AnyAsync(x => x.ArabicName.ToLower().Trim() == arabicName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Job: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Job was Called");

                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Job: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Job>> GetAllByAllowanceStatusAsync(bool haveWorkNatureAllowance)
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Job was Called");

                if (haveWorkNatureAllowance)
                {
                    return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                                .ThenInclude(x => x.JobGroup)
                                                .Include(x => x.MaxGrade)
                                                .Include(x => x.MinGrade)
                                                .Where(x => x.WorkNatureAllowance > 0)
                                                .ToListAsync();
                }

                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .Where(x => x.WorkNatureAllowance == 0)
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Job: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Job>> GetAllByJobGroupIdAsync(int jobGroupId)
        {
            try
            {
                _logger.LogInformation("GetAllByJobGroupIdAsync for Job was Called");

                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .Where(x => x.JobSubGroup.JobGroupId == jobGroupId)
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByJobGroupIdAsync for Job: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Job>> GetAllByJobSubGroupIdAsync(int jobSubGroupId)
        {
            try
            {
                _logger.LogInformation("GetAllByJobSubGroupIdAsync for Job was Called");

                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .Where(x => x.JobSubGroupId == jobSubGroupId)
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByJobSubGroupIdAsync for Job: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Job>> GetAllByMinGradeIdAsync(int minGradeId)
        {
            try
            {
                _logger.LogInformation("GetAllByMinGradeIdAsync for Job was Called");

                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .Where(x => x.MinGradeId == minGradeId)
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByMinGradeIdAsync for Job: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Job>> GetAllByMaxGradeIdAsync(int maxGradeId)
        {
            try
            {
                _logger.LogInformation("GetAllByMaxGradeIdAsync for Job was Called");

                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .Where(x => x.MaxGradeId == maxGradeId)
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByMaxGradeIdAsync for Job: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Job>> GetAllByWorkNatureAllowanceAsync(bool? haveWorkNatureAllowance = true)
        {
            try
            {
                _logger.LogInformation("GetAllByWorkNatureAllowanceAsync for Job was Called");
                if (haveWorkNatureAllowance.HasValue)
                {
                    if (haveWorkNatureAllowance == true)
                    {
                        return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                                    .ThenInclude(x => x.JobGroup)
                                                    .Include(x => x.MaxGrade)
                                                    .Include(x => x.MinGrade)
                                                    .Where(x => x.WorkNatureAllowance > 0)
                                                    .ToListAsync();
                    }
                    return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                                .ThenInclude(x => x.JobGroup)
                                                .Include(x => x.MaxGrade)
                                                .Include(x => x.MinGrade)
                                                .Where(x => x.WorkNatureAllowance <= 0)
                                                .ToListAsync();
                }
                return await _dbContext.Jobs.Include(x => x.JobSubGroup)
                                            .ThenInclude(x => x.JobGroup)
                                            .Include(x => x.MaxGrade)
                                            .Include(x => x.MinGrade)
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByWorkNatureAllowanceAsync for Job: {ex.Message}");
                return null;
            }
        }


        public async Task AddAsync(Job job)
        {
            try
            {
                _logger.LogInformation("AddAsync for Job was Called");

                if (job != null)
                {
                    job.CreatedBy = "Anonymous";
                    job.CreatedDate = DateTime.Now;

                    await _dbContext.Jobs.AddAsync(job);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Job: {ex.Message}");
            }
        }
        public void Update(Job job)
        {
            try
            {
                _logger.LogInformation("Update for Job was Called");
                if (job != null)
                {
                    job.ModifiedBy = "Anonymous";
                    job.LastModified = DateTime.Now;

                    _dbContext.Entry(job).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Job: {ex.Message}");
            }
        }
        public void Delete(Job job)
        {
            try
            {
                _logger.LogInformation("Delete for Jobs was Called");

                if (job != null)
                {
                    _dbContext.Jobs.Remove(job);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Jobs: {ex.Message}");
            }
        }


    }
}
