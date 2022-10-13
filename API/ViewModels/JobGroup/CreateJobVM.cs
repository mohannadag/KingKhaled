using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.JobGroup
{
    public class CreateJobVM
    {
        public string ArabicName { get; set; }
        public string Code { get; set; }

        public int JobSubGroupId { get; set; }

        public int MinGradeId { get; set; }
        public int MaxGradeId { get; set; }
        public double WorkNatureAllowance { get; set; }
    }
}
