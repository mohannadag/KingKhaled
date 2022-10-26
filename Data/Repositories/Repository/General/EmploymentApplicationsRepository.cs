using Core.Models.EmploymentApplications;
using Core.Models.General;
using Data.Context;
using Data.Repositories.IRepository.IGenerals;
using Data.Repositories.Repository.Allowances;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.General
{
    public class EmploymentApplicationsRepository : IEmploymentApplications
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EmploymentApplicationsRepository> _logger;
        public EmploymentApplicationsRepository(AppDbContext dbContext, ILogger<EmploymentApplicationsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task AddAsync(EmploymentApplications Application)
        {
            try
            {
                _logger.LogInformation("AddAsync for Application  was Called");

                if (Application != null)
                {
               
                    Application.CreatedDate = DateTime.Now;

                    await _dbContext.EmploymentApplications.AddAsync(Application);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Application: {ex.Message}");
            }
        }

        //public async Task<bool> AlreadyExistArabicAsync(string arabicName)
        //{
        //    try
        //    {
        //        _logger.LogInformation("AlreadyExistCodeAsync for EmploymentApplications was Called");
        //        return await _dbContext.EmploymentApplications.AnyAsync(x => x.ArabicName.ToLower().Trim() == arabicName.ToLower().Trim());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Faild to AlreadyExistCodeAsync for EmploymentApplications: {ex.Message}");
        //        return true;
        //    }
        //}

        //public async Task<bool> AlreadyExistEnglishAsync(string englishName)
        //{
        //    try
        //    {
        //        _logger.LogInformation("AlreadyExistCodeAsync for EmploymentApplications was Called");
        //        return await _dbContext.EmploymentApplications.AnyAsync(x => x.EnglishName.ToLower().Trim() == englishName.ToLower().Trim());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Faild to AlreadyExistCodeAsync for EmploymentApplications: {ex.Message}");
        //        return true;
        //    }
        //}

        public  void Delete(EmploymentApplications Application)
        {
            try
            {
                _logger.LogInformation("Delete for EmploymentApplications was Called");

                if (Application != null)
                {
                    _dbContext.EmploymentApplications.Remove(Application);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for EmploymentApplications: {ex.Message}");
            }
        }

        public async Task<IEnumerable<EmploymentApplications>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for EmploymentApplications was Called");

                return await _dbContext.EmploymentApplications.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for EmploymentApplications: {ex.Message}");
                return null;
            }
        }

        public async Task<EmploymentApplications> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for EmploymentApplications was Called");

                return await _dbContext.EmploymentApplications.FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for EmploymentApplications: {ex.Message}");
                return null;
            }
        }

        public async Task<EmploymentApplications> GetByEnglishNameAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for EmploymentApplications was Called");

                return await _dbContext.EmploymentApplications.FirstOrDefaultAsync(x => x.EnglishName == englishName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for EmploymentApplications: {ex.Message}");
                return null;
            }
        }

        public async Task<EmploymentApplications> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for employemnt application was Called");

                return await _dbContext.EmploymentApplications.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for employemnt application: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for EmploymentApplications was Called");
                return await _dbContext.EmploymentApplications.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for EmploymentApplications: {ex.Message}");
                return false;
            }
        }

        public void Update(EmploymentApplications Application)
        {
            try
            {
                _logger.LogInformation("Update for Application was Called");
                if (Application != null)
                {
                     
                    //bank.LastModified = DateTime.Now;

                    _dbContext.Entry(Application).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Application: {ex.Message}");
            }
        }
    }
}
