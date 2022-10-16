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
