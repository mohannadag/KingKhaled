using Core.Models.Financial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Jobs
{
    public class JobGrade
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public double WorkAllowanceAmount { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
