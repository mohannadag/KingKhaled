using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.JobGroup
{
    public class JobVM
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string Code { get; set; }

        public int JobSubGroupId { get; set; }
        public string JobSubGroup { get; set; }

        public int JobGroupId { get; set; }
        public string JobGroup { get; set; }

        public int MinGradeId { get; set; }
        public string MinGradeName { get; set; }

        public int MaxGradeId { get; set; }
        public string MaxGradeName { get; set; }

        public double WorkNatureAllowance { get; set; }
    }
}
