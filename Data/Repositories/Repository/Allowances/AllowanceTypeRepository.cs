using Core.Models.Allowance;
using Core.Models.Jobs;
using Data.Context;
using Data.Repositories.IRepository.IAllowances;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.Allowances
{
    public class AllowanceTypeRepository : IAllowanceTypeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<AllowanceTypeRepository> _logger;

        public AllowanceTypeRepository(AppDbContext dbContext, ILogger<AllowanceTypeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<AllowanceType> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for AllowanceType was Called");

                return await _dbContext.AllowanceTypes.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for AllowanceType: {ex.Message}");
                return null;
            }
        }
        public async Task<AllowanceType> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for AllowanceType was Called");

                return await _dbContext.AllowanceTypes.FirstOrDefaultAsync(x => x.ArabicName.ToLower() == arabicName.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for AllowanceType: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for AllowanceType was Called");
                return await _dbContext.AllowanceTypes.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for AllowanceType: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistArabicAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for AllowanceType was Called");
                return await _dbContext.AllowanceTypes.AnyAsync(x => x.ArabicName.ToLower().Trim() == arabicName.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for AllowanceType: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<AllowanceType>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for AllowanceType was Called");

                return await _dbContext.AllowanceTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for AllowanceType: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(AllowanceType allowanceType)
        {
            try
            {
                _logger.LogInformation("AddAsync for AllowanceType was Called");

                if (allowanceType != null)
                {
                    allowanceType.CreatedBy = "Anonymous";
                    allowanceType.CreatedDate = DateTime.Now;

                    await _dbContext.AllowanceTypes.AddAsync(allowanceType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for AllowanceType: {ex.Message}");
            }
        }
        public void Update(AllowanceType allowanceType)
        {
            try
            {
                _logger.LogInformation("Update for AllowanceType was Called");
                if (allowanceType != null)
                {
                    allowanceType.ModifiedBy = "Anonymous";
                    allowanceType.LastModified = DateTime.Now;

                    _dbContext.Entry(allowanceType).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for AllowanceType: {ex.Message}");
            }
        }
        public void Delete(AllowanceType allowanceType)
        {
            try
            {
                _logger.LogInformation("Delete for AllowanceType was Called");

                if (allowanceType != null)
                {
                    _dbContext.AllowanceTypes.Remove(allowanceType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for AllowanceType: {ex.Message}");
            }
        }
    }
}
