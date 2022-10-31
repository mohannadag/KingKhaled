using Core.Models.EmployeesInfo;
using Core.Models.Vacations;
using Data.Context;
using Data.Repositories.IRepository.IVacations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.Vacations
{
    public class VacationTypeRepository : IVacationTypeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<VacationTypeRepository> _logger;

        public VacationTypeRepository(AppDbContext dbContext, ILogger<VacationTypeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<VacationType> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for VacationType was Called");

                return await _dbContext.VacationTypes.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for VacationType: {ex.Message}");
                return null;
            }
        }
        public async Task<VacationType> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByArabicNameAsync for VacationType was Called");

                return await _dbContext.VacationTypes.FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByArabicNameAsync for VacationType: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for VacationType was Called");
                return await _dbContext.VacationTypes.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for VacationType: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for VacationType was Called");
                return await _dbContext.VacationTypes.AnyAsync(x => x.ArabicName.Trim() == arabicName.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for VacationType: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<VacationType>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for VacationType was Called");

                return await _dbContext.VacationTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for VacationType: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(VacationType vacationType)
        {
            try
            {
                _logger.LogInformation("AddAsync for VacationType was Called");

                if (vacationType != null)
                {
                    vacationType.CreatedBy = "Anonymous";
                    vacationType.CreatedDate = DateTime.Now;

                    await _dbContext.VacationTypes.AddAsync(vacationType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for VacationType: {ex.Message}");
            }
        }
        public void Update(VacationType vacationType)
        {
            try
            {
                _logger.LogInformation("Update for VacationType was Called");
                if (vacationType != null)
                {
                    vacationType.ModifiedBy = "Anonymous";
                    vacationType.LastModified = DateTime.Now;

                    _dbContext.Entry(vacationType).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for VacationType: {ex.Message}");
            }
        }
        public void Delete(VacationType vacationType)
        {
            try
            {
                _logger.LogInformation("Delete for VacationType was Called");

                if (vacationType != null)
                {
                    _dbContext.VacationTypes.Remove(vacationType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for VacationType: {ex.Message}");
            }
        }
    }
}
