using Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IGenerals
{
    public interface IDepartmentRepository
    {
        Task<Department> GetByIdAsync(int id);
        Task<Department> GetByArabicNameAsync(string arabicName);
        Task<Department> GetByShortArNameAsync(string shortArName);
        Task<Department> GetByEnglishNameAsync(string englishName);
        Task<Department> GetByShortEnNameAsync(string shortEnName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicNameAsync(string arabicName);
        Task<bool> AlreadyExistEnglishNameAsync(string englishName);
        Task<bool> AlreadyExistShortArNameAsync(string shortArName);
        Task<bool> AlreadyExistShortEnNameAsync(string shortEnName);

        Task<IEnumerable<Department>> GetAllAsync();

        Task AddAsync(Department department);
        void Update(Department department);
        void Delete(Department department);
    }
}
