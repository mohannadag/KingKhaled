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
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BranchRepository> _logger;
        public BranchRepository(AppDbContext dbContext, ILogger<BranchRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Branch was Called");

                return await _dbContext.Branches.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Branch: {ex.Message}");
                return null;
            }
        }

        public async Task<Branch> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByArabicNameAsync for Branch was Called");

                return await _dbContext.Branches.FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByArabicNameAsync for Branch: {ex.Message}");
                return null;
            }
        }
        public async Task<Branch> GetByEnglishNameAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("GetByEnglishNameAsync for Branch was Called");

                return await _dbContext.Branches.FirstOrDefaultAsync(x => x.EnglishName.ToLower() == englishName.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEnglishNameAsync for Branch: {ex.Message}");
                return null;
            }
        }

        public async Task<Branch> GetByShortArNameAsync(string shortArName)
        {
            try
            {
                _logger.LogInformation("GetByShortArNameAsync for Branch was Called");

                return await _dbContext.Branches.FirstOrDefaultAsync(x => x.ShortArName == shortArName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByShortArNameAsync for Branch: {ex.Message}");
                return null;
            }
        }
        public async Task<Branch> GetByShortEnNameAsync(string shortEnName)
        {
            try
            {
                _logger.LogInformation("GetByShortEnNameAsync for Branch was Called");

                return await _dbContext.Branches.FirstOrDefaultAsync(x => x.ShortArName.ToLower() == shortEnName.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByShortArNameAsync for Branch: {ex.Message}");
                return null;
            }
        }


        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Branch was Called");
                return await _dbContext.Branches.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Branch: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> IsAllowedToAddVacanyAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsAllowedToAddVacanyAsync for Branch was Called");
                return await _dbContext.Branches.Include(x => x.JobVacancies)
                                                .AnyAsync(x => x.Id == id && x.JobVacancies.Count < x.NumberOfVacant);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsAllowedToAddVacanyAsync for Branch: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AlreadyExistArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistArabicNameAsync for Branch was Called");
                return await _dbContext.Branches.AnyAsync(x => x.ArabicName.Trim() == arabicName.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistArabicNameAsync for Branch: {ex.Message}");
                return true;
            }
        }
        public async Task<bool> AlreadyExistEnglishNameAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistEnglishNameAsync for Branch was Called");
                return await _dbContext.Branches.AnyAsync(x => x.EnglishName.ToLower().Trim() == englishName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistEnglishNameAsync for Branch: {ex.Message}");
                return true;
            }
        }

        public async Task<bool> AlreadyExistShortArNameAsync(string shortArName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistShortArNameAsync for Branch was Called");
                return await _dbContext.Branches.AnyAsync(x => x.ShortArName.Trim() == shortArName.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistShortArNameAsync for Branch: {ex.Message}");
                return true;
            }
        }
        public async Task<bool> AlreadyExistShortEnNameAsync(string shortEnName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistShortEnNameAsync for Branch was Called");
                return await _dbContext.Branches.AnyAsync(x => x.ShortEnName.ToLower().Trim() == shortEnName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistShortEnNameAsync for Branch: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Branch was Called");

                return await _dbContext.Branches.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Branch: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Branch>> GetAllByDepartmentIdAsync(int departmentId)
        {
            try
            {
                _logger.LogInformation("GetAllByDepartmentIdAsync for Branch was Called");

                return await _dbContext.Branches.Include(x => x.Department)
                                                .Where(x => x.DepartmentId == departmentId)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByDepartmentIdAsync for Branch: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Branch branch)
        {
            try
            {
                _logger.LogInformation("AddAsync for Branch was Called");

                if (branch != null)
                {
                    branch.CreatedBy = "Anonymous";
                    branch.CreatedDate = DateTime.Now;

                    await _dbContext.Branches.AddAsync(branch);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Branch: {ex.Message}");
            }
        }
        public void Update(Branch branch)
        {
            try
            {
                _logger.LogInformation("Update for Branch was Called");
                if (branch != null)
                {
                    branch.ModifiedBy = "Anonymous";
                    branch.LastModified = DateTime.Now;

                    _dbContext.Entry(branch).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Branch: {ex.Message}");
            }
        }
        public void Delete(Branch branch)
        {
            try
            {
                _logger.LogInformation("Delete for Branch was Called");

                if (branch != null)
                {
                    _dbContext.Branches.Remove(branch);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Branch: {ex.Message}");
            }
        }
    }
}
