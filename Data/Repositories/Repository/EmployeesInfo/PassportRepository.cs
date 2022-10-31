using Core.Enums;
using Core.Models.EmployeesInfo;
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
    public class PassportRepository : IPassportRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<PassportRepository> _logger;

        public PassportRepository(AppDbContext dbContext, ILogger<PassportRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Passport> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Passport was Called");

                return await _dbContext.Passports.Include(x => x.Employee)
                                                 .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Passport: {ex.Message}");
                return null;
            }
        }
        public async Task<Passport> GetByNumberAsync(string passportNumber)
        {
            try
            {
                _logger.LogInformation("GetByNumberAsync for Passport was Called");

                return await _dbContext.Passports.Include(x => x.Employee)
                                                 .FirstOrDefaultAsync(x => x.PassportNumber == passportNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByNameAsync for Passport: {ex.Message}");
                return null;
            }
        }
        public async Task<Passport> GetByEmployeeIdAsync(int employeeId)
        {
            try
            {
                _logger.LogInformation("GetByEmployeeIdAsync for Passport was Called");

                return await _dbContext.Passports.Include(x => x.Employee)
                                                 .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEmployeeIdAsync for Passport: {ex.Message}");
                return null;
            }
        }
        public async Task<Passport> GetByEmployeeNumberAsync(int employeeNumber)
        {
            try
            {
                _logger.LogInformation("GetByEmployeeNumberAsync for Passport was Called");

                return await _dbContext.Passports.Include(x => x.Employee)
                                                 .FirstOrDefaultAsync(x => x.Employee.EmployeeNumber == employeeNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEmployeeNumberAsync for Passport: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Passport was Called");
                return await _dbContext.Passports.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Passport: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> IsValidToExtendAsync(int passportId, DateTime startDate)
        {
            try
            {
                _logger.LogInformation("IsValidToExtendAsync for Passport was Called");
                return await _dbContext.Passports.Where(x => x.Id == passportId &&
                                                             x.ExpireDate < DateTime.Now && x.ExpireDate < startDate)
                                                 .AnyAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidToExtendAsync for Passport: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> AlreadyExistAsync(string passportNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Passport was Called");
                return await _dbContext.Passports.AnyAsync(x => x.PassportNumber == passportNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Passport: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Passport>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Passport was Called");

                return await _dbContext.Passports.Include(x => x.Employee)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Passport: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Passport>> GetAllExpiredAsync()
        {
            try
            {
                _logger.LogInformation("GetAllByExpireAsync for Passport was Called");

                return await _dbContext.Passports.Include(x => x.Employee)
                                                 .Where(x => x.ExpireDate <= DateTime.Now)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByExpireAsync for Passport: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Passport>> GetAllByNationalityIdAsync(int nationalityId)
        {
            try
            {
                _logger.LogInformation("GetAllByNationalityIdAsync for Identity was Called");

                return await _dbContext.Passports.Include(x => x.Employee)
                                                 .ThenInclude(x => x.Nationality)
                                                 .Where(x => x.Employee.NationalityId == nationalityId)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByNationalityIdAsync for Identity: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Passport passport)
        {
            try
            {
                _logger.LogInformation("AddAsync for Passport was Called");

                if (passport != null)
                {
                    passport.CreatedDate = DateTime.Now;
                    passport.LastModified = DateTime.Now;

                    await _dbContext.Passports.AddAsync(passport);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Passport: {ex.Message}");
            }
        }
        public void Update(Passport passport)
        {
            try
            {
                _logger.LogInformation("Update for Passport was Called");
                if (passport != null)
                {
                    passport.LastModified = DateTime.Now;
                    _dbContext.Entry(passport).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Passport: {ex.Message}");
            }
        }
        public void Delete(Passport passport)
        {
            try
            {
                _logger.LogInformation("Delete for Passport was Called");

                if (passport != null)
                {
                    _dbContext.Passports.Remove(passport);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Passport: {ex.Message}");
            }
        }
    }
}
