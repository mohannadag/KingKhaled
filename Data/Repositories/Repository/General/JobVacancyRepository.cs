using Core.Models.General;
using Core.Models.Jobs;
using Data.Context;
using Data.Repositories.IRepository.IGenerals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.General
{
    public class JobVacancyRepository : IJobVacancyRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<JobVacancyRepository> _logger;

        public JobVacancyRepository(AppDbContext dbContext, ILogger<JobVacancyRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<JobVacancy> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for JobVacancy was Called");

                return await _dbContext.JobVacancies.Include(x => x.Branch)
                                                    .ThenInclude(x => x.Department)
                                                    .Include(x => x.Job)
                                                    .ThenInclude(x => x.JobLevel)
                                                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for JobVacancy: {ex.Message}");
                return null;
            }
        }
        public async Task<JobVacancy> GetByVacantNumberAsync(int vacantNumber)
        {
            try
            {
                _logger.LogInformation("GetByVacantNumberAsync for JobVacancy was Called");

                return await _dbContext.JobVacancies.Include(x => x.Branch)
                                                    .ThenInclude(x => x.Department)
                                                    .Include(x => x.Job)
                                                    .ThenInclude(x => x.JobLevel)
                                                    .FirstOrDefaultAsync(x => x.VacantNumber == vacantNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByVacantNumberAsync for JobVacancy: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for JobVacancy was Called");
                return await _dbContext.JobVacancies.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for JobVacancy: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> IsValidVacantNumberAsync(int vacantNumber)
        {
            try
            {
                _logger.LogInformation("IsValidVacantNumberAsync for JobVacancy was Called");
                return await _dbContext.JobVacancies.AnyAsync(x => x.VacantNumber == vacantNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidVacantNumberAsync for JobVacancy: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> IsValidJobVacancyIdForGradeAsync(int jobVacancyId, int gradeId)
        {
            try
            {
                _logger.LogInformation("IsValidJobVacancyIdForGradeAsync for JobVacancy was Called");

                var grade = await _dbContext.Grades.FirstOrDefaultAsync(x => x.Id == gradeId);

                return await _dbContext.JobVacancies.Include(x => x.Job)
                                                    .ThenInclude(x => x.MinGrade)
                                                    .Include(x => x.Job)
                                                    .ThenInclude(x => x.MaxGrade)
                                                    .AnyAsync(x => x.Id == jobVacancyId &&
                                                                   x.Job.MinGrade.GradeNumber <= grade.GradeNumber &&
                                                                   x.Job.MaxGrade.GradeNumber >= grade.GradeNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidJobVacancyIdForGradeAsync for JobVacancy: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistVacantNumberAsync(int vacantNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for JobVacancy was Called");
                return await _dbContext.JobVacancies.AnyAsync(x => x.VacantNumber == vacantNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for JobVacancy: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<JobVacancy>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for JobVacancy was Called");

                return await _dbContext.JobVacancies.Include(x => x.Branch)
                                                    .ThenInclude(x => x.Department)
                                                    .Include(x => x.Job)
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for JobVacancy: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<JobVacancy>> GetAllByDepartmentIdAsync(int departmentId)
        {
            try
            {
                _logger.LogInformation("GetAllByDepartmentIdAsync for JobVacancy was Called");

                return await _dbContext.JobVacancies.Include(x => x.Branch)
                                                    .ThenInclude(x => x.Department)
                                                    .Include(x => x.Job)
                                                    .ThenInclude(x => x.JobLevel)
                                                    .Where(x => x.Branch.DepartmentId == departmentId)
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByDepartmentIdAsync for JobVacancy: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<JobVacancy>> GetAllByBranchIdAsync(int branchId)
        {
            try
            {
                _logger.LogInformation("GetAllByBranchIdAsync for JobVacancy was Called");

                return await _dbContext.JobVacancies.Include(x => x.Branch)
                                                    .ThenInclude(x => x.Department)
                                                    .Include(x => x.Job)
                                                    .ThenInclude(x => x.JobLevel)
                                                    .Where(x => x.BranchId == branchId)
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByBranchIdAsync for JobVacancy: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<JobVacancy>> GetAllByJobIdAsync(int jobId)
        {
            try
            {
                _logger.LogInformation("GetAllByJobIdAsync for JobVacancy was Called");

                return await _dbContext.JobVacancies.Include(x => x.Branch)
                                                    .ThenInclude(x => x.Department)
                                                    .Include(x => x.Job)
                                                    .ThenInclude(x => x.JobLevel)
                                                    .Where(x => x.JobId == jobId)
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByJobIdAsync for JobVacancy: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<JobVacancy>> GetAllByJobLevelIdAsync(int jobLevelId)
        {
            try
            {
                _logger.LogInformation("GetAllByJobLevelIdAsync for JobVacancy was Called");

                return await _dbContext.JobVacancies.Include(x => x.Branch)
                                                    .ThenInclude(x => x.Department)
                                                    .Include(x => x.Job)
                                                    .ThenInclude(x => x.JobLevel)
                                                    .Where(x => x.Job.JobLevelId == jobLevelId)
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByJobLevelIdAsync for JobVacancy: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(JobVacancy jobVacancy)
        {
            try
            {
                _logger.LogInformation("AddAsync for JobVacancy was Called");

                if (jobVacancy != null)
                {
                    jobVacancy.CreatedBy = "Anonymous";
                    jobVacancy.CreatedDate = DateTime.Now;

                    await _dbContext.JobVacancies.AddAsync(jobVacancy);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for JobVacancy: {ex.Message}");
            }
        }
        public void Update(JobVacancy jobVacancy)
        {
            try
            {
                _logger.LogInformation("Update for JobVacancy was Called");
                if (jobVacancy != null)
                {
                    jobVacancy.ModifiedBy = "Anonymous";
                    jobVacancy.LastModified = DateTime.Now;

                    _dbContext.Entry(jobVacancy).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for JobVacancy: {ex.Message}");
            }
        }
        public void Delete(JobVacancy jobVacancy)
        {
            try
            {
                _logger.LogInformation("Delete for JobVacancy was Called");

                if (jobVacancy != null)
                {
                    _dbContext.JobVacancies.Remove(jobVacancy);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for JobVacancy: {ex.Message}");
            }
        }

        
    }
}
