using API.ViewModels.Employee;
using API.ViewModels.EmployeeAccount;
using AutoMapper;
using Core.Models.EmployeesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Employee
            CreateMap<Employee, EmployeeVM>()
                .ForMember(viewModel => viewModel.NationalityAr, model => model.MapFrom(x => x.Nationality.ArabicName))
                .ForMember(viewModel => viewModel.NationalityEn, model => model.MapFrom(x => x.Nationality.EnglishName))
                .ForMember(viewModel => viewModel.QualificationName, model => model.MapFrom(x => x.Qualification.Name))
                .ForMember(viewModel => viewModel.BranchName, model => model.MapFrom(x => x.Branch.ArabicName))
                .ForMember(viewModel => viewModel.GradeName, model => model.MapFrom(x => x.Grade.Name))
                .ForMember(viewModel => viewModel.GradeNumber, model => model.MapFrom(x => x.Grade.GradeNumber))
                .ForMember(viewModel => viewModel.LevelName, model => model.MapFrom(x => x.Level.Name))
                .ForMember(viewModel => viewModel.LevelNumber, model => model.MapFrom(x => x.Level.LevelNumber))
                .ForMember(viewModel => viewModel.JobName, model => model.MapFrom(x => x.Job.ArabicName))
                .ReverseMap();
            CreateMap<Employee, CreateEmployeeVM>()
                .ForMember(viewModel => viewModel.Gender, model => model.MapFrom(x => x.Gender))
                .ForMember(viewModel => viewModel.Religion, model => model.MapFrom(x => x.Religion))
                .ForMember(viewModel => viewModel.MarritalStatus, model => model.MapFrom(x => x.MarritalStatus))
                .ReverseMap();

            // EmployeeAccount
            CreateMap<EmployeeAccount, EmployeeAccountVM>()
                .ForMember(viewModel => viewModel.BankArabic, model => model.MapFrom(x => x.Bank.ArabicName))
                .ForMember(viewModel => viewModel.BankEnglish, model => model.MapFrom(x => x.Bank.EnglishName))
                .ForMember(viewModel => viewModel.EmployeeArabic, model => model.MapFrom(x => x.Employee.ArabicName))
                .ForMember(viewModel => viewModel.EmployeeEnglish, model => model.MapFrom(x => x.Employee.EnglishName))
                .ReverseMap();
            CreateMap<EmployeeAccount, CreateEmployeeAccountVM>()
                .ReverseMap();
            CreateMap<EmployeeAccount, UpdateEmployeeAccountVM>()
                .ReverseMap();
        }
    }
}
