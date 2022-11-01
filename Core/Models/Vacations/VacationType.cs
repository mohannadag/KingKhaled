using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Vacations
{
    public class VacationType
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public int DurationPerDay { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

        //public ICollection<Vacation> Vacations { get; set; }
    }
}
