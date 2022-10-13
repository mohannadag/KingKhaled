﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository
{
    public interface IJobRepository
    {
        Task<Job> GetByIdAsync(int id);
        Task<Job> GetByArabicNameAsync(string arabicName);
        Task<Job> GetByCodeAsync(string code);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicAsync(string arabicName);
        Task<bool> AlreadyExistCodeAsync(string code);

        Task<IEnumerable<Job>> GetAllAsync();
        Task<IEnumerable<Job>> GetAllByJobGroupIdAsync(int jobGroupId);
        Task<IEnumerable<Job>> GetAllByJobSubGroupIdAsync(int jobSubGroupId);
        Task<IEnumerable<Job>> GetAllByMinGradeIdAsync(int minGradeId);
        Task<IEnumerable<Job>> GetAllByMaxGradeIdAsync(int maxGradeId);
        Task<IEnumerable<Job>> GetAllByWorkNatureAllowanceAsync(bool? haveWorkNatureAllowance = true);

        Task AddAsync(Job job);
        void Update(Job job);
        void Delete(Job job);
    }
}
