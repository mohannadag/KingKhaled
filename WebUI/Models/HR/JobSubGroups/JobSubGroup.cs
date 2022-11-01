using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Models.HR.JobSubGroups
{
    public class JobSubGroup
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public int JobGroupId { get; set; }
        public string JobGroupName { get; set; }
        public SelectList JobGroupList { get; set; }
    }
}
