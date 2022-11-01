using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Vacations
{
    public class Vacation
    {
        public int Id { get; set; }
        public string VacationNumber { get; set; }
        public string Notes { get; set; }
        public DateTime RequestedDate { get; set; }

        public int NumberOfDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        //public int VacationTypeId { get; set; }
        //public VacationType VacationType { get; set; }

        public bool? IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
