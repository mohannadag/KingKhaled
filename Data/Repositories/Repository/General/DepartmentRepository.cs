using Core.Models.General;
using Data.Context;
using Data.Repositories.IRepository.IGenerals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.General
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<DepartmentRepository> _logger;

        public DepartmentRepository(AppDbContext dbContext, ILogger<DepartmentRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Department was Called");

                return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Department: {ex.Message}");
                return null;
            }
        }

        public async Task<Department> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByArabicNameAsync for Department was Called");

                return await _dbContext.Departments.FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByArabicNameAsync for Department: {ex.Message}");
                return null;
            }
        }
        public async Task<Department> GetByEnglishNameAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("GetByEnglishNameAsync for Department was Called");

                return await _dbContext.Departments.FirstOrDefaultAsync(x => x.EnglishName.ToLower() == englishName.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEnglishNameAsync for Department: {ex.Message}");
                return null;
            }
        }

        public async Task<Department> GetByShortArNameAsync(string shortArName)
        {
            try
            {
                _logger.LogInformation("GetByShortArNameAsync for Department was Called");

                return await _dbContext.Departments.FirstOrDefaultAsync(x => x.ShortArName == shortArName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByShortArNameAsync for Department: {ex.Message}");
                return null;
            }
        }
        public async Task<Department> GetByShortEnNameAsync(string shortEnName)
        {
            try
            {
                _logger.LogInformation("GetByShortEnNameAsync for Department was Called");

                return await _dbContext.Departments.FirstOrDefaultAsync(x => x.ShortArName.ToLower() == shortEnName.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByShortArNameAsync for Department: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Department was Called");
                return await _dbContext.Departments.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Department: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AlreadyExistArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistArabicNameAsync for Department was Called");
                return await _dbContext.Departments.AnyAsync(x => x.ArabicName.Trim() == arabicName.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistArabicNameAsync for Department: {ex.Message}");
                return true;
            }
        }

        public async Task<bool> AlreadyExistEnglishNameAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistEnglishNameAsync for Department was Called");
                return await _dbContext.Departments.AnyAsync(x => x.EnglishName.ToLower().Trim() == englishName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistEnglishNameAsync for Department: {ex.Message}");
                return true;
            }
        }

        public async Task<bool> AlreadyExistShortArNameAsync(string shortArName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistShortArNameAsync for Department was Called");
                return await _dbContext.Departments.AnyAsync(x => x.ShortArName.Trim() == shortArName.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistShortArNameAsync for Department: {ex.Message}");
                return true;
            }
        }

        public async Task<bool> AlreadyExistShortEnNameAsync(string shortEnName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistShortEnNameAsync for Department was Called");
                return await _dbContext.Departments.AnyAsync(x => x.ShortEnName.ToLower().Trim() == shortEnName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistShortEnNameAsync for Department: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Department was Called");

                return await _dbContext.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Department: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Department department)
        {
            try
            {
                _logger.LogInformation("AddAsync for Department was Called");

                if (department != null)
                {
                    department.CreatedBy = "Anonymous";
                    department.CreatedDate = DateTime.Now;

                    await _dbContext.Departments.AddAsync(department);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Department: {ex.Message}");
            }
        }
        public void Update(Department department)
        {
            try
            {
                _logger.LogInformation("Update for Department was Called");
                if (department != null)
                {
                    department.ModifiedBy = "Anonymous";
                    department.LastModified = DateTime.Now;

                    _dbContext.Entry(department).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Department: {ex.Message}");
            }
        }
        public void Delete(Department department)
        {
            try
            {
                _logger.LogInformation("Delete for Department was Called");

                if (department != null)
                {
                    _dbContext.Departments.Remove(department);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Department: {ex.Message}");
            }
        }
    }
}
