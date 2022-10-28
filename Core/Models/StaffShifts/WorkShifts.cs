using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.StaffShifts
{
    public class WorkShifts
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }
    }
}
