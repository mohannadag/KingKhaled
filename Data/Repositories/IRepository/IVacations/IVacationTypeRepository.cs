using Core.Models.EmployeesInfo;
using Core.Models.Vacations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IVacations
{
    public interface IVacationTypeRepository
    {
        Task<VacationType> GetByIdAsync(int id);
        Task<VacationType> GetByArabicNameAsync(string arabicName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistAsync(string arabicName);

        Task<IEnumerable<VacationType>> GetAllAsync();

        Task AddAsync(VacationType vacationType);
        void Update(VacationType vacationType);
        void Delete(VacationType vacationType);
    }
}
