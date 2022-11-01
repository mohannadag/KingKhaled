using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Tickets
{
    public class CreateTicketVM
    {
        public string TicketNumber { get; set; }
        public string Notes { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

        public int ContractId { get; set; }
    }
}
