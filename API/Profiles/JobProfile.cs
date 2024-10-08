﻿using API.ViewModels.JobGroup;
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
                .ForMember(viewModel => viewModel.JobLevelName, model => model.MapFrom(x => x.JobLevel.Name))
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

            // JobVisa
            CreateMap<JobVisa, JobVisaVM>()
                .ReverseMap();
            CreateMap<JobVisa, CreateJobVisaVM>()
                .ReverseMap();
            CreateMap<JobVisa, UpdateJobVisaVM>()
                .ReverseMap();

            // JobLevel
            CreateMap<JobLevel, JobLevelVM>()
                .ReverseMap();
            CreateMap<JobLevel, CreateJobLevelVM>()
                .ReverseMap();
            CreateMap<JobLevel, UpdateJobLevelVM>()
                .ReverseMap();

            // JobVacancy
            CreateMap<JobVacancy, JobVacancyVM>()
                .ForMember(viewModel => viewModel.DepartmentId, model => model.MapFrom(x => x.Branch.Department.Id))
                .ForMember(viewModel => viewModel.DepartmentName, model => model.MapFrom(x => x.Branch.Department.ArabicName))
                .ForMember(viewModel => viewModel.BranchName, model => model.MapFrom(x => x.Branch.ArabicName))
                .ForMember(viewModel => viewModel.JobName, model => model.MapFrom(x => x.Job.ArabicName))
                .ForMember(viewModel => viewModel.JobLevelId, model => model.MapFrom(x => x.Job.JobLevelId))
                .ForMember(viewModel => viewModel.JobLevelName, model => model.MapFrom(x => x.Job.JobLevel.Name))
                .ReverseMap();
            CreateMap<JobVacancy, CreateJobVacancyVM>()
                .ReverseMap();
            CreateMap<JobVacancy, UpdateJobVacancyVM>()
                .ReverseMap();
        }
    }
}
