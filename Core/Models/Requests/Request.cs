using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Requests
{
    public class Request
    {
        public int Id { get; set; }
        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string Receiver { get; set; }
        public string RequestReason { get; set; }
        public string Notes { get; set; }

        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
