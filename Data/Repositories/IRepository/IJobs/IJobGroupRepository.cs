﻿using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IJobs
{
    public interface IJobGroupRepository
    {
        Task<JobGroup> GetByIdAsync(int id);
        Task<JobGroup> GetByArabicNameAsync(string arabicName);
        Task<JobGroup> GetByJobSubGroupIdAsync(int jobSubGroupId);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicAsync(string arabicName);

        Task<IEnumerable<JobGroup>> GetAllAsync();

        Task AddAsync(JobGroup jobGroup);
        void Update(JobGroup jobGroup);
        void Delete(JobGroup jobGroup);
    }
}
