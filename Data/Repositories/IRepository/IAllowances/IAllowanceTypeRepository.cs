using Core.Models.Allowance;
using Core.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IAllowances
{
    public interface IAllowanceTypeRepository
    {
        Task<AllowanceType> GetByIdAsync(int id);
        Task<AllowanceType> GetByArabicNameAsync(string arabicName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicAsync(string arabicName);

        Task<IEnumerable<AllowanceType>> GetAllAsync();

        Task AddAsync(AllowanceType allowanceType);
        void Update(AllowanceType allowanceType);
        void Delete(AllowanceType allowanceType);
    }
}
