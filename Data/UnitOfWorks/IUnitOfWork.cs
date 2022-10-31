using Core.Models.EmployeesInfo;
using Core.Models.EmploymentApplications;
using Data.Repositories.IRepository.IAllowances;
using Data.Repositories.IRepository.IEmployeesInfo;
using Data.Repositories.IRepository.IFinancials;
using Data.Repositories.IRepository.IGenerals;
using Data.Repositories.IRepository.IJobs;
using Data.Repositories.IRepository.IRequests;
using Data.Repositories.IRepository.IStaffShifts;
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
        public IIdentityTransactionRepository IdentityTransactions { get; }
        public IEmployeeRepository Employees { get; }
        public IPassportRepository Passports { get; }
        public IPassportTransactionRepository PassportTransactions { get; }
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
        public IJobVisaRepository JobVisa { get; }
        public IJobVacancyRepository JobVacancy { get; }
        public IAllowanceTypeRepository AllowanceTypes { get; }
        public IEmploymentApplications EmploymentApplications { get; }
        public IEntryCardRepository EntryCards { get; }
        public IWorkShifts WorkShifts { get; }
        public IEmpShifts EmpShifts { get; } 
        public IRequestTypeRepository RequestTypes { get; }
        public IRequestRepository Requests { get; }
        public IContractRepository Contracts { get; }
        public IContractTransactionRepository ContractTransactions { get; }
        public IContractTypeRepository ContractTypes { get; }
        Task<bool> SaveAsync();
    }
}
