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
    public class JobVisaRepository : IJobVisaRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<JobVisaRepository> _logger;

        public JobVisaRepository(AppDbContext dbContext, ILogger<JobVisaRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<JobVisa> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for JobVisa was Called");

                return await _dbContext.JobVisas.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for JobVisa: {ex.Message}");
                return null;
            }
        }
        public async Task<JobVisa> GetByNameAsync(string name)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for JobVisa was Called");

                return await _dbContext.JobVisas.FirstOrDefaultAsync(x => x.Name == name);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for JobVisa: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for JobVisa was Called");
                return await _dbContext.JobVisas.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for JobVisa: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string name)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for JobVisa was Called");
                return await _dbContext.JobVisas.AnyAsync(x => x.Name.Trim() == name.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for JobVisa: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<JobVisa>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for JobVisa was Called");

                return await _dbContext.JobVisas.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for JobVisa: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(JobVisa jobVisa)
        {
            try
            {
                _logger.LogInformation("AddAsync for JobVisa was Called");

                if (jobVisa != null)
                {
                    jobVisa.CreatedBy = "Anonymous";
                    jobVisa.CreatedDate = DateTime.Now;

                    await _dbContext.JobVisas.AddAsync(jobVisa);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for JobVisa: {ex.Message}");
            }
        }
        public void Update(JobVisa jobVisa)
        {
            try
            {
                _logger.LogInformation("Update for JobVisa was Called");
                if (jobVisa != null)
                {
                    jobVisa.ModifiedBy = "Anonymous";
                    jobVisa.LastModified = DateTime.Now;

                    _dbContext.Entry(jobVisa).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for JobVisa: {ex.Message}");
            }
        }
        public void Delete(JobVisa jobVisa)
        {
            try
            {
                _logger.LogInformation("Delete for JobVisa was Called");

                if (jobVisa != null)
                {
                    _dbContext.JobVisas.Remove(jobVisa);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for JobVisa: {ex.Message}");
            }
        }
    }
}
