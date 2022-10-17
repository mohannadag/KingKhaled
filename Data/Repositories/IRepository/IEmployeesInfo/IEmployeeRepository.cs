using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> GetByEmployeeNumberAsync(int employeeNumber);
        Task<Employee> GetByGeneralNumberAsync(string generalNumber);
        Task<Employee> GetByArabicNameAsync(string arabicName);
        Task<Employee> GetByEnglishNameAsync(string englishName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(int employeeNumber);
        Task<bool> AlreadyExistAsync(string generalNumber);

        Task<IEnumerable<Employee>> GetAllAsync();
        Task<IEnumerable<Employee>> GetAllByNationalityIdAsync(int nationalityId);
        Task<IEnumerable<Employee>> GetAllByBranchIdAsync(int branchId);
        Task<IEnumerable<Employee>> GetAllByJobIdAsync(int jobId);
        Task<IEnumerable<Employee>> GetAllByGradeIdAsync(int gradeId);
        Task<IEnumerable<Employee>> GetAllByLevelIdAsync(int levelId);
        Task<IEnumerable<Employee>> GetAllByGradeIdAndLevelIdAsync(int gradeId, int levelId);
        Task<IEnumerable<Employee>> GetAllByQualificationIdAsync(int qualificationId);
        Task<IEnumerable<Employee>> GetAllByGenderAsync(string gender);
        Task<IEnumerable<Employee>> GetAllByReligionAsync(string religion);
        Task<IEnumerable<Employee>> GetAllByMarritalStatusAsync(string marritalStatus);

        Task AddAsync(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
