using Data.Repositories.IRepository.IEmployeesInfo;
using Data.Repositories.IRepository.IFinancials;
using Data.Repositories.IRepository.IGenerals;
using Data.Repositories.IRepository.IJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public INationalityRepository Nationalities { get; }
        public IIdentityRepository Identities { get; }
        public IEmployeeRepository Employees { get; }
        public IPassportRepository Passports { get; }
        public IBankRepository Banks { get; }
        public IEmployeeAccountRepository EmployeeAccounts { get; }
        public IJobRepository Jobs { get; }
        public IJobGroupRepository JobGroups { get; }
        public IJobSubGroupRepository JobSubGroups { get; }
        public IGradeRepository Grades { get; }
        public ILevelRepository Levels { get; }
        public ISalaryRepository Salaries { get; }
        public IDepartmentRepository Departments { get; }
        public IBranchRepository Branches { get; }
        public IQualificationRepository Qualifications { get; }

        Task<bool> SaveAsync();
    }
}
