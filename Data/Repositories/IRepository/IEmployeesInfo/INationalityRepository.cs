using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IEmployeesInfo
{
    public interface INationalityRepository
    {
        Task<Nationality> GetByIdAsync(int id);
        Task<Nationality> GetByArabicNameAsync(string arabicName);
        Task<Nationality> GetByEnglishNameAsync(string englishName);

        Task<bool> IsValidIdAsync(int id);
        Task<bool> AlreadyExistArabicAsync(string arabicName);
        Task<bool> AlreadyExistEnglishAsync(string englishName);

        Task<IEnumerable<Nationality>> GetAllAsync();

        Task AddAsync(Nationality nationality);
        void Update(Nationality nationality);
        void Delete(Nationality nationality);
    }
}
