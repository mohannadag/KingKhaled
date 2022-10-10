using API.ViewModels.Employee;
using AutoMapper;
using Core.Models;
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
            CreateMap<Employee, EmployeeVM>()
                .ForMember(viewModel => viewModel.NationalityAr, model => model.MapFrom(x => x.Nationality.ArabicName))
                .ForMember(viewModel => viewModel.NationalityEn, model => model.MapFrom(x => x.Nationality.EnglishName))
                .ReverseMap();
            CreateMap<Employee, CreateEmployeeVM>()
                .ForMember(viewModel => viewModel.Gender, model => model.MapFrom(x => x.Gender))
                .ForMember(viewModel => viewModel.Religion, model => model.MapFrom(x => x.Religion))
                .ForMember(viewModel => viewModel.MarritalStatus, model => model.MapFrom(x => x.MarritalStatus))
                .ReverseMap();
        }
    }
}
