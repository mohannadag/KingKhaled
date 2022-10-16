using API.ViewModels.Bank;
using API.ViewModels.Branch;
using API.ViewModels.Department;
using API.ViewModels.Nationality;
using API.ViewModels.Salary;
using AutoMapper;
using Core.Models.EmployeesInfo;
using Core.Models.Financial;
using Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            // Nationality
            CreateMap<Nationality, NationalityVM>()
                .ReverseMap();
            CreateMap<Nationality, CreateNationalityVM>()
                .ReverseMap();
            CreateMap<Nationality, UpdateNationalityVM>()
                .ReverseMap();

            // Banks
            CreateMap<Bank, BankVM>()
                .ReverseMap();
            CreateMap<Bank, CreateBankVM>()
                .ReverseMap();
            CreateMap<Bank, UpdateBankVM>()
                .ReverseMap();

            // Department
            CreateMap<Department, DepartmentVM>()
                .ReverseMap();
            CreateMap<Department, CreateDepartmentVM>()
                .ReverseMap();
            CreateMap<Department, UpdateDepartmentVM>()
                .ReverseMap();

            // Branch
            CreateMap<Branch, BranchVM>()
                .ForMember(viewModel => viewModel.DepartmentName, model => model.MapFrom(x => x.Department.ArabicName))
                .ReverseMap();
            CreateMap<Branch, CreateBranchVM>()
                .ReverseMap();
            CreateMap<Branch, UpdateBranchVM>()
                .ReverseMap();

            // Salary
            CreateMap<Salary, SalaryVM>()
                .ForMember(viewModel => viewModel.GradeName, model => model.MapFrom(x => x.Grade.Name))
                .ForMember(viewModel => viewModel.LevelName, model => model.MapFrom(x => x.Level.Name))
                .ReverseMap();
            CreateMap<Salary, CreateSalaryVM>()
                .ReverseMap();
            CreateMap<Salary, UpdateSalaryVM>()
                .ReverseMap();
        }
    }
}
