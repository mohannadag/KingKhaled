using Core.Enums;
using Core.Models;
using Data.Context;
using Data.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Repositories.Repository
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<IdentityRepository> _logger;
        public IdentityRepository(AppDbContext dbContext, ILogger<IdentityRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Identity> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Identity was Called");

                return await _dbContext.Identities.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Identity: {ex.Message}");
                return null;
            }
        }
        public async Task<Identity> GetByNumberAsync(string identityNumber)
        {
            try
            {
                _logger.LogInformation("GetByNameAsync for Identity was Called");

                return await _dbContext.Identities.FirstOrDefaultAsync(x => x.IdentityNumber == identityNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Identity: {ex.Message}");
                return null;
            }
        }
        public async Task<Identity> GetByEmployeeIdAsync(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetByEmployeeIdAsync for Identity was Called");

                return await _dbContext.Identities.Include(x => x.Employee)
                                                  .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEmployeeIdAsync for Identity: {ex.Message}");
                return null;
            }
        }
        public async Task<Identity> GetByEmployeeNumberAsync(int employeeNumber)
        {
            try
            {
                _logger.LogInformation("GetByEmployeeNumberAsync for Identity was Called");

                return await _dbContext.Identities.Include(x => x.Employee)
                                                  .FirstOrDefaultAsync(x => x.Employee.EmployeeNumber == employeeNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEmployeeNumberAsync for Identity: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Identity was Called");
                return await _dbContext.Identities.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Identity: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string identityNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Identity was Called");
                return await _dbContext.Identities.AnyAsync(x => x.IdentityNumber.ToLower().Trim() == identityNumber.ToLower().Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Identity: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Identity>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Identity was Called");

                return await _dbContext.Identities.Include(x => x.Employee)
                                                  .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Identity: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Identity>> GetAllExpiredAsync()
        {
            try
            {
                _logger.LogInformation("GetAllByExpireAsync for Identity was Called");

                return await _dbContext.Identities.Include(x => x.Employee)
                                                  .Where(x => x.ExpireDate <= DateTime.Now)
                                                  .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByExpireAsync for Identity: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Identity>> GetAllByTypeAsync(string identityType = "Iqama")
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Identity was Called");

                if (!String.IsNullOrEmpty(identityType))
                {
                    return await _dbContext.Identities.Include(x => x.Employee)
                                                      .Where(x => x.IdentityType.ToLower() == identityType.ToLower())
                                                      .ToListAsync();
                }

                return await _dbContext.Identities.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Identity: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Identity identity)
        {
            try
            {
                _logger.LogInformation("AddAsync for Identity was Called");

                if (identity != null)
                {
                    identity.CreatedDate = DateTime.Now;
                    identity.LastModified = DateTime.Now;

                    await _dbContext.Identities.AddAsync(identity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Identity: {ex.Message}");
            }
        }
        public void Update(Identity identity)
        {
            try
            {
                _logger.LogInformation("Update for Identity was Called");
                if (identity != null)
                {
                    identity.LastModified = DateTime.Now;
                    _dbContext.Entry(identity).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Identity: {ex.Message}");
            }
        }
        public void Delete(Identity identity)
        {
            try
            {
                _logger.LogInformation("Delete for Identity was Called");

                if (identity != null)
                {
                    _dbContext.Identities.Remove(identity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Identity: {ex.Message}");
            }
        }
    }
}
