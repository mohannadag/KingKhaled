using Core.Models.EmployeesInfo;
using Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Jobs
{
    public class JobVacancy
    {
        public int Id { get; set; }
        public int VacantNumber { get; set; }
        public string Notes { get; set; }

        //public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }// For JobVacancy

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
