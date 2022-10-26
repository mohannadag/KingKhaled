using Data.Context;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.IRepository.IGenerals;
using Data.Repositories.IRepository.IJobs;
using Data.Repositories.IRepository.IEmployeesInfo;
using Data.Repositories.IRepository.IFinancials;
using Data.Repositories.Repository.EmployeesInfo;
using Data.Repositories.Repository.General;
using Data.Repositories.Repository.Jobs;
using Data.Repositories.Repository.Financials;
using Data.Repositories.IRepository.IAllowances;
using Data.Repositories.Repository.Allowances;
using Data.Repositories.IRepository.IRequests;
using Data.Repositories.Repository.Requests;

namespace Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public INationalityRepository Nationalities => new NationalityRepository(
            _dbContext, new Logger<NationalityRepository>(new NullLoggerFactory()));

        public IIdentityRepository Identities => new IdentityRepository(
            _dbContext, new Logger<IdentityRepository>(new NullLoggerFactory()));

        public IEmployeeRepository Employees => new EmployeeRepository(
            _dbContext, new Logger<EmployeeRepository>(new NullLoggerFactory()));

        public IPassportRepository Passports => new PassportRepository(
            _dbContext, new Logger<PassportRepository>(new NullLoggerFactory()));

        public IBankRepository Banks => new BankRepository(
            _dbContext, new Logger<BankRepository>(new NullLoggerFactory()));

        public IEmployeeAccountRepository EmployeeAccounts => new EmployeeAccountRepository(
            _dbContext, new Logger<EmployeeAccountRepository>(new NullLoggerFactory()));

        public IJobGroupRepository JobGroups => new JobGroupRepository(
            _dbContext, new Logger<JobGroupRepository>(new NullLoggerFactory()));

        public IJobRepository Jobs => new JobRepository(
            _dbContext, new Logger<JobRepository>(new NullLoggerFactory()));

        public IJobSubGroupRepository JobSubGroups => new JobSubGroupRepository(
            _dbContext, new Logger<JobSubGroupRepository>(new NullLoggerFactory()));

        public IGradeRepository Grades => new GradeRepository(
            _dbContext, new Logger<GradeRepository>(new NullLoggerFactory()));

        public ILevelRepository Levels => new LevelRepository(
            _dbContext, new Logger<LevelRepository>(new NullLoggerFactory()));

        public ISalaryRepository Salaries => new SalaryRepository(
            _dbContext, new Logger<SalaryRepository>(new NullLoggerFactory()));

        public IDepartmentRepository Departments => new DepartmentRepository(
            _dbContext, new Logger<DepartmentRepository>(new NullLoggerFactory()));

        public IBranchRepository Branches => new BranchRepository(
            _dbContext, new Logger<BranchRepository>(new NullLoggerFactory()));

        public IQualificationRepository Qualifications => new QualificationRepository(
            _dbContext, new Logger<QualificationRepository>(new NullLoggerFactory()));

        public IJobVisaRepository JobVisa => new JobVisaRepository(
            _dbContext, new Logger<JobVisaRepository>(new NullLoggerFactory()));

        public IJobVacancyRepository JobVacancy => new JobVacancyRepository(
            _dbContext, new Logger<JobVacancyRepository>(new NullLoggerFactory()));

        public IAllowanceTypeRepository AllowanceTypes => new AllowanceTypeRepository(
            _dbContext, new Logger<AllowanceTypeRepository>(new NullLoggerFactory()));

        public IEntryCardRepository EntryCards => new EntryCardRepository(
            _dbContext, new Logger<EntryCardRepository>(new NullLoggerFactory()));

        public IRequestTypeRepository RequestTypes => new RequestTypeRepository(
            _dbContext, new Logger<RequestTypeRepository>(new NullLoggerFactory()));

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
