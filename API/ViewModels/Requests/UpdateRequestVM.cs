using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Requests
{
    public class UpdateRequestVM
    {
        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string Receiver { get; set; }
        public string RequestReason { get; set; }
        public string Notes { get; set; }

        public int EmployeeId { get; set; }
        public int RequestTypeId { get; set; }
    }
}
