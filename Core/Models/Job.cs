using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string Code { get; set; }

        public int JobSubGroupId { get; set; }
        public JobSubGroup JobSubGroup { get; set; }

        public int MinRank { get; set; }
        public int MaxRank { get; set; }
        public double WorkNatureAllowance { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
