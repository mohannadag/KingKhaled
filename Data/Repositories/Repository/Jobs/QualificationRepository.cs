using Core.Models.Jobs;
using Data.Context;
using Data.Repositories.IRepository.IJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.Jobs
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<QualificationRepository> _logger;

        public QualificationRepository(AppDbContext dbContext, ILogger<QualificationRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Qualification> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Qualification was Called");

                return await _dbContext.Qualifications.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Qualification: {ex.Message}");
                return null;
            }
        }
        public async Task<Qualification> GetByNameAsync(string name)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for Qualification was Called");

                return await _dbContext.Qualifications.FirstOrDefaultAsync(x => x.Name == name);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Qualification: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Qualification was Called");
                return await _dbContext.Qualifications.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Qualification: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string name)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Qualification was Called");
                return await _dbContext.Qualifications.AnyAsync(x => x.Name.Trim() == name.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Qualification: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Qualification>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Qualification was Called");

                return await _dbContext.Qualifications.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Qualification: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Qualification qualification)
        {
            try
            {
                _logger.LogInformation("AddAsync for Qualification was Called");

                if (qualification != null)
                {
                    qualification.CreatedBy = "Anonymous";
                    qualification.CreatedDate = DateTime.Now;

                    await _dbContext.Qualifications.AddAsync(qualification);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Qualification: {ex.Message}");
            }
        }
        public void Update(Qualification qualification)
        {
            try
            {
                _logger.LogInformation("Update for Qualification was Called");
                if (qualification != null)
                {
                    qualification.ModifiedBy = "Anonymous";
                    qualification.LastModified = DateTime.Now;

                    _dbContext.Entry(qualification).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Qualification: {ex.Message}");
            }
        }
        public void Delete(Qualification qualification)
        {
            try
            {
                _logger.LogInformation("Delete for Qualification was Called");

                if (qualification != null)
                {
                    _dbContext.Qualifications.Remove(qualification);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Qualification: {ex.Message}");
            }
        }
    }
}
