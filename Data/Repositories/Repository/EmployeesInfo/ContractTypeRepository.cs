using Core.Models.EmployeesInfo;
using Core.Models.General;
using Data.Context;
using Data.Repositories.IRepository.IEmployeesInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository.EmployeesInfo
{
    public class ContractTypeRepository : IContractTypeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ContractTypeRepository> _logger;

        public ContractTypeRepository(AppDbContext dbContext, ILogger<ContractTypeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<ContractType> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for ContractType was Called");

                return await _dbContext.ContractTypes.Include(x => x.Contracts)
                                                     .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for ContractType: {ex.Message}");
                return null;
            }
        }
        public async Task<ContractType> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByArabicNameAsync for ContractType was Called");

                return await _dbContext.ContractTypes.Include(x => x.Contracts)
                                                     .FirstOrDefaultAsync(x => x.ArabicName == arabicName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByArabicNameAsync for ContractType: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for ContractType was Called");
                return await _dbContext.ContractTypes.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for ContractType: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for ContractType was Called");
                return await _dbContext.ContractTypes.AnyAsync(x => x.ArabicName.Trim() == arabicName.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for ContractType: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<ContractType>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for ContractType was Called");

                return await _dbContext.ContractTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for ContractType: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(ContractType contractType)
        {
            try
            {
                _logger.LogInformation("AddAsync for ContractType was Called");

                if (contractType != null)
                {
                    contractType.CreatedBy = "Anonymous";
                    contractType.CreatedDate = DateTime.Now;

                    await _dbContext.ContractTypes.AddAsync(contractType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for ContractType: {ex.Message}");
            }
        }
        public void Update(ContractType contractType)
        {
            try
            {
                _logger.LogInformation("Update for ContractType was Called");
                if (contractType != null)
                {
                    contractType.ModifiedBy = "Anonymous";
                    contractType.LastModified = DateTime.Now;

                    _dbContext.Entry(contractType).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for ContractType: {ex.Message}");
            }
        }
        public void Delete(ContractType contractType)
        {
            try
            {
                _logger.LogInformation("Delete for ContractType was Called");

                if (contractType != null)
                {
                    _dbContext.ContractTypes.Remove(contractType);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for ContractType: {ex.Message}");
            }
        }
    }
}
