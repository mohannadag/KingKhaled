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
using System.Xml.Linq;

namespace Data.Repositories.Repository.EmployeesInfo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(AppDbContext dbContext, ILogger<EmployeeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("GetByIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByIdAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<Employee> GetByEmployeeNumberAsync(int employeeNumber)
        {
            try
            {
                _logger.LogInformation("GetByEmployeeNumberAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .FirstOrDefaultAsync(x => x.EmployeeNumber == employeeNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEmployeeNumberAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<Employee> GetByGeneralNumberAsync(string generalNumber)
        {
            try
            {
                _logger.LogInformation("GetByGeneralNumberAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .FirstOrDefaultAsync(x => x.GeneralNumber == generalNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByGeneralNumberAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<Employee> GetByArabicNameAsync(string arabicName)
        {
            try
            {
                _logger.LogInformation("GetByArabicNameAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .FirstOrDefaultAsync(x => x.ArabicName.ToLower() == arabicName.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByArabicNameAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<Employee> GetByEnglishNameAsync(string englishName)
        {
            try
            {
                _logger.LogInformation("GetByEnglishNameAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .FirstOrDefaultAsync(x => x.EnglishName.ToLower() == englishName.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEnglishNameAsync for Employee: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsValidIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("IsValidIdAsync for Employee was Called");
                return await _dbContext.Employees.AnyAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to IsValidIdAsync for Employee: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AlreadyExistAsync(int employeeNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Employee was Called");
                return await _dbContext.Employees.AnyAsync(x => x.EmployeeNumber == employeeNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Employee EmployeeNumber: {ex.Message}");
                return true;
            }
        }
        public async Task<bool> AlreadyExistAsync(string generalNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyExistAsync for Employee was Called");
                return await _dbContext.Employees.AnyAsync(x => x.GeneralNumber.Trim() == generalNumber.Trim());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyExistAsync for Employee GeneralNumber: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByNationalityIdAsync(int nationalityId)
        {
            try
            {
                _logger.LogInformation("GetAllByNationalityIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Where(x => x.NationalityId == nationalityId)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByNationalityIdAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByGenderAsync(string gender)
        {
            try
            {
                _logger.LogInformation("GetAllByGenderAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Where(x => x.Gender.ToLower() == gender.ToLower())
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByGenderAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByReligionAsync(string religion)
        {
            try
            {
                _logger.LogInformation("GetAllByReligionAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Where(x => x.Religion.ToLower() == religion.ToLower())
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByReligionAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByMarritalStatusAsync(string marritalStatus)
        {
            try
            {
                _logger.LogInformation("GetAllByMarritalStatusAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Where(x => x.MarritalStatus.ToLower() == marritalStatus.ToLower())
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByMarritalStatusAsync for Employee: {ex.Message}");
                return null;
            }
        }

        public async Task AddAsync(Employee employee)
        {
            try
            {
                _logger.LogInformation("AddAsync for Employee was Called");

                if (employee != null)
                {
                    employee.CreatedDate = DateTime.Now;
                    await _dbContext.Employees.AddAsync(employee);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AddAsync for Employee: {ex.Message}");
            }
        }
        public void Update(Employee employee)
        {
            try
            {
                _logger.LogInformation("Update for Employee was Called");
                if (employee != null)
                {
                    employee.LastModified = DateTime.Now;
                    _dbContext.Entry(employee).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Update for Employee: {ex.Message}");
            }
        }
        public void Delete(Employee employee)
        {
            try
            {
                _logger.LogInformation("Delete for Employee was Called");

                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to Delete for Employee: {ex.Message}");
            }
        }
    }
}
