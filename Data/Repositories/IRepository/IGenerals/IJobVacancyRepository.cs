using Core.Models.General;
using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IGenerals
{
    public interface IJobVacancyRepository
    {
        Task<JobVacancy> GetByIdAsync(int id);
        Task<JobVacancy> GetByVacantNumberAsync(int vacantNumber);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> IsValidJobVacancyIdForGradeAsync(int jobVacancyId, int gradeId);
        Task<bool> IsValidVacantNumberAsync(int vacantNumber);
        Task<bool> AlreadyExistVacantNumberAsync(int vacantNumber);

        Task<IEnumerable<JobVacancy>> GetAllAsync();
        Task<IEnumerable<JobVacancy>> GetAllByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<JobVacancy>> GetAllByBranchIdAsync(int branchId);
        Task<IEnumerable<JobVacancy>> GetAllByJobIdAsync(int jobId);

        Task AddAsync(JobVacancy jobVacancy);
        void Update(JobVacancy jobVacancy);
        void Delete(JobVacancy jobVacancy);
    }
}
