using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.EmployeesInfo
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public string Notes { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
