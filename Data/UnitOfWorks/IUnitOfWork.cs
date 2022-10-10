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

        Task<bool> SaveAsync();
    }
}
