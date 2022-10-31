using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Identity
{
    public class CreateIdentityTransactionVM
    {
        public int IdentityId { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Notes { get; set; }

        public int JobVisaId { get; set; }
    }
}
