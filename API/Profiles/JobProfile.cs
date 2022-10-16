using API.ViewModels.JobGroup;
using API.ViewModels.Qualification;
using AutoMapper;
using Core.Models.Financial;
using Core.Models.Jobs;
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
            // Job
            CreateMap<Job, JobVM>()
                .ForMember(viewModel => viewModel.MinGradeName, model => model.MapFrom(x => x.MinGrade.Name))
                .ForMember(viewModel => viewModel.MaxGradeName, model => model.MapFrom(x => x.MaxGrade.Name))
                .ForMember(viewModel => viewModel.JobSubGroup, model => model.MapFrom(x => x.JobSubGroup.ArabicName))
                .ForMember(viewModel => viewModel.JobGroup, model => model.MapFrom(x => x.JobSubGroup.JobGroup.ArabicName))
                .ReverseMap();
            CreateMap<Job, CreateJobVM>()
                .ReverseMap();
            CreateMap<Job, UpdateJobVM>()
                .ReverseMap();

            // JobGroup
            CreateMap<JobGroup, JobGroupVM>()
                .ReverseMap();
            CreateMap<JobGroup, CreateJobGroupVM>()
                .ReverseMap();
            CreateMap<JobGroup, UpdateJobGroupVM>()
                .ReverseMap();

            // JobSubGroup
            CreateMap<JobSubGroup, JobSubGroupVM>()
                .ForMember(viewModel => viewModel.JobGroupName, model => model.MapFrom(x => x.JobGroup.ArabicName))
                .ReverseMap();
            CreateMap<JobSubGroup, CreateJobSubGroupVM>()
                .ReverseMap();
            CreateMap<JobSubGroup, UpdateJobSubGroupVM>()
                .ReverseMap();

            // Grade
            CreateMap<Grade, GradeVM>()
                .ReverseMap();
            CreateMap<Grade, CreateGradeVM>()
                .ReverseMap();
            CreateMap<Grade, UpdateGradeVM>()
                .ReverseMap();

            // Level
            CreateMap<Level, LevelVM>()
                .ReverseMap();
            CreateMap<Level, CreateLevelVM>()
                .ReverseMap();
            CreateMap<Level, UpdateLevelVM>()
                .ReverseMap();

            // Qualification
            CreateMap<Qualification, QualificationVM>()
                .ReverseMap();
            CreateMap<Qualification, CreateQualificationVM>()
                .ReverseMap();
            CreateMap<Qualification, UpdateQualificationVM>()
                .ReverseMap();
        }
    }
}
