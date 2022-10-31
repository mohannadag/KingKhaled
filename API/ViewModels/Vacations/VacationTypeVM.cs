using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Vacations
{
    public class VacationTypeVM
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public int DurationPerDay { get; set; }
    }
}
