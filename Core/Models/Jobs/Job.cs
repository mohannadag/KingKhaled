using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Financial;

namespace Core.Models.Jobs
{
    public class Job
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string Code { get; set; }

        public int JobSubGroupId { get; set; }
        public JobSubGroup JobSubGroup { get; set; }

        public int MinGradeId { get; set; }
        public Grade MinGrade { get; set; }

        public int MaxGradeId { get; set; }
        public Grade MaxGrade { get; set; }

        public double WorkNatureAllowance { get; set; }
        public double AllowancePercentage { get; set; }
        public double AllowanceAmount { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
