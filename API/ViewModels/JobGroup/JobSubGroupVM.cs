using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.JobGroup
{
    public class JobSubGroupVM
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }

        public int JobGroupId { get; set; }
        public string JobGroupName { get; set; }
    }
}
