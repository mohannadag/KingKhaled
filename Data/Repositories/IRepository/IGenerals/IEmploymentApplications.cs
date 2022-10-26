using Core.Models.EmploymentApplications;
using Core.Models.General;
using Data.Repositories.Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data.Repositories.IRepository.IGenerals
{
    public interface IEmploymentApplications
    {
        Task<EmploymentApplications> GetByIdAsync(int id);
        
        Task<EmploymentApplications> GetByArabicNameAsync(string arabicName);
        Task<EmploymentApplications> GetByEnglishNameAsync(string englishName);

        Task<bool> IsValidIdAsync(int id);
        //Task<bool> AlreadyExistArabicAsync(string arabicName);
        //Task<bool> AlreadyExistEnglishAsync(string englishName); 

        Task<IEnumerable<EmploymentApplications>> GetAllAsync();

        Task AddAsync(EmploymentApplications Application);
        void Update(EmploymentApplications Application);
        void Delete(EmploymentApplications Application);
    }
}
