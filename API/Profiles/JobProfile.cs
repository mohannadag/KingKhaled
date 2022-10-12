using API.ViewModels.JobGroup;
using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            // JobGroup
            CreateMap<JobGroup, JobGroupVM>()
                .ReverseMap();
            CreateMap<JobGroup, CreateJobGroupVM>()
                .ReverseMap();
            CreateMap<JobGroup, UpdateJobGroupVM>()
                .ReverseMap();

            // JobSubGroup
            CreateMap<JobSubGroup, JobSubGroupVM>()
                .ReverseMap();
            CreateMap<JobSubGroup, CreateJobSubGroupVM>()
                .ReverseMap();
            CreateMap<JobSubGroup, UpdateJobSubGroupVM>()
                .ReverseMap();
        }
    }
}
