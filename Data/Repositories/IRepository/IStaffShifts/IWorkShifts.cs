using Core.Models.StaffShifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IStaffShifts
{
    public interface IWorkShifts
    {
        public  Task<WorkShifts> GetByIdAsync(int id);
        public  Task<WorkShifts> GetByNameAsync(string Name);
        public Task<IEnumerable<WorkShifts>> GetAllAsync();
        public Task<bool> IsValidIdAsync(int id);
        public Task AddAsync(WorkShifts WorkShifts);
        public void Update(WorkShifts WorkShifts);
        public void Delete(WorkShifts WorkShifts);


    }
}
