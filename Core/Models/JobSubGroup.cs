using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class JobSubGroup
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }

        public int JobGroupId { get; set; }
        public JobGroup JobGroup { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
