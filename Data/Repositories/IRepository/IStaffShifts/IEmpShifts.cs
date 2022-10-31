using Core.Models.StaffShifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.IRepository.IStaffShifts
{
    public interface IEmpShifts
    {
        public   Task<EmployeeShifts> GetByIdAsync(int id); 
        public   Task<bool> IsValidIdAsync(int id);
        public   Task<IEnumerable<EmployeeShifts>> GetAllAsync();
        public Task<IEnumerable<EmployeeShifts>> GetAllShiftForoneEmploymentByIDAsync(int EmpID); 
        public Task AddAsync(EmployeeShifts empShift);
        public Task AddListAsync(EmployeeShifts[] empShift);
        
        public void Update(EmployeeShifts empShift);
        public void Delete(EmployeeShifts empShift);
    }
}
