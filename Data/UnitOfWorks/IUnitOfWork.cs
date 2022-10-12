﻿using Data.Repositories.IRepository;
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

        Task<bool> SaveAsync();
    }
}
