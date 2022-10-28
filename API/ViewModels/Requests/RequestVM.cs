using Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ViewModels.Requests
{
    public class RequestVM
    {
        public int Id { get; set; }
        public string RequestNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public string Receiver { get; set; }
        public string RequestReason { get; set; }
        public string Notes { get; set; }

        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }

        public int EmployeeId { get; set; }
        public string ArabicName { get; set; }

        public int RequestTypeId { get; set; }
        public string RequestType { get; set; }
    }
}
