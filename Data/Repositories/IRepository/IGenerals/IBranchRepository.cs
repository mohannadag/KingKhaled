using Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IGenerals
{
    public interface IBranchRepository
    {
        Task<Branch> GetByIdAsync(int id);
        Task<Branch> GetByArabicNameAsync(string arabicName);
        Task<Branch> GetByShortArNameAsync(string shortArName);
        Task<Branch> GetByEnglishNameAsync(string englishName);
        Task<Branch> GetByShortEnNameAsync(string shortEnName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicNameAsync(string arabicName);
        Task<bool> AlreadyExistEnglishNameAsync(string englishName);
        Task<bool> AlreadyExistShortArNameAsync(string shortArName);
        Task<bool> AlreadyExistShortEnNameAsync(string shortEnName);

        Task<IEnumerable<Branch>> GetAllAsync();
        Task<IEnumerable<Branch>> GetAllByDepartmentIdAsync(int departmentId);

        Task AddAsync(Branch branch);
        void Update(Branch branch);
        void Delete(Branch branch);
    }
}
