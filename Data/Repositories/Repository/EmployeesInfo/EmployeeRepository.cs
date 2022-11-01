using Core.Enums;
using Core.Models.EmployeesInfo;
using Core.Models.Financial;
using Data.Context;
using Data.Repositories.IRepository.IEmployeesInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
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
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .FirstOrDefaultAsync(x => x.EmployeeNumber == employeeNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByEmployeeNumberAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<Employee> GetByJobVacancyIdAsync(int jobVacancyId)
        {
            try
            {
                _logger.LogInformation("GetByJobVacancyIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .FirstOrDefaultAsync(x => x.JobVacancyId == jobVacancyId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByJobVacancyIdAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<Employee> GetByVacantNumberAsync(int vacantNumber)
        {
            try
            {
                _logger.LogInformation("GetByVacantNumberAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .FirstOrDefaultAsync(x => x.JobVacancy.VacantNumber == vacantNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetByVacantNumberAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<Employee> GetByGeneralNumberAsync(string generalNumber)
        {
            try
            {
                _logger.LogInformation("GetByGeneralNumberAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
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
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
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
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 //.Include(x => x.Job)
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
        public async Task<bool> AlreadyInUseVacantNumberAsync(int vacantNumber)
        {
            try
            {
                _logger.LogInformation("AlreadyInUseVacantNumberAsync for Employee was Called");
                return await _dbContext.Employees.AnyAsync(x => x.JobVacancy.VacantNumber == vacantNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyInUseVacantNumberAsync for Employee: {ex.Message}");
                return true;
            }
        }
        public async Task<bool> AlreadyInUseJobVacancyIdAsync(int jobVacancyId)
        {
            try
            {
                _logger.LogInformation("AlreadyInUseJobVacancyIdAsync for Employee was Called");
                return await _dbContext.Employees.AnyAsync(x => x.JobVacancyId == jobVacancyId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to AlreadyInUseJobVacancyIdAsync for Employee: {ex.Message}");
                return true;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("GetAllAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByJobIdAsync(int jobId)
        {
            try
            {
                _logger.LogInformation("GetAllByJobIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Job)
                                                 .Where(x => x.JobVacancy.JobId == jobId)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByJobIdAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByGradeIdAsync(int gradeId)
        {
            try
            {
                _logger.LogInformation("GetAllByGradeIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .Where(x => x.GradeId == gradeId)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByGradeIdAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByLevelIdAsync(int levelId)
        {
            try
            {
                _logger.LogInformation("GetAllByLevelIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .Where(x => x.LevelId == levelId)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByLevelIdAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByGradeIdAndLevelIdAsync(int gradeId, int levelId)
        {
            try
            {
                _logger.LogInformation("GetAllByGradeIdAndLevelIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .Where(x => x.GradeId == gradeId && x.LevelId == levelId)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByGradeIdAndLevelIdAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByNationalityIdAsync(int nationalityId)
        {
            try
            {
                _logger.LogInformation("GetAllByNationalityIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .Where(x => x.NationalityId == nationalityId)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByNationalityIdAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByBranchIdAsync(int branchId)
        {
            try
            {
                _logger.LogInformation("GetAllByBranchIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .Where(x => x.JobVacancy.BranchId == branchId)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByBranchIdAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByQualificationIdAsync(int qualificationId)
        {
            try
            {
                _logger.LogInformation("GetAllByQualificationIdAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .Where(x => x.QualificationId == qualificationId)
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByQualificationIdAsync for Employee: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllByWorkType(string workType)
        {
            try
            {
                _logger.LogInformation("GetAllByGenderAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
                                                 .Where(x => x.WorkType.ToLower() == workType.ToLower())
                                                 .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Faild to GetAllByGenderAsync for Employee: {ex.Message}");
                return null;
            }
        }
        public async Task<IEnumerable<Employee>> GetAllByGenderAsync(string gender)
        {
            try
            {
                _logger.LogInformation("GetAllByGenderAsync for Employee was Called");

                return await _dbContext.Employees.Include(x => x.Nationality)
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
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
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
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
                                                 .Include(x => x.Qualification)
                                                 .Include(x => x.Grade)
                                                 .Include(x => x.Level)
                                                 .Include(x => x.JobVacancy)
                                                 .ThenInclude(x => x.Branch)
                                                 .ThenInclude(x => x.Department)
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
