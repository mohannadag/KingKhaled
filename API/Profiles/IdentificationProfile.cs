using API.ViewModels.Identity;
using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Repository
{
    public class IdentificationProfile : Profile
    {
        public IdentificationProfile()
        {
            CreateMap<Identity, IdentityVM>()
                .ForMember(viewModel => viewModel.EmployeeNameAr, model => model.MapFrom(x => x.Employee.ArabicName))
                .ForMember(viewModel => viewModel.EmployeeNameEn, model => model.MapFrom(x => x.Employee.EnglishName))
                .ForMember(viewModel => viewModel.EmployeeNumber, model => model.MapFrom(x => x.Employee.EmployeeNumber))
                .ReverseMap();
            CreateMap<Identity, CreateIdentityVM>()
                .ForMember(viewModel => viewModel.IdentityType, model => model.MapFrom(x => x.IdentityType))
                .ReverseMap();
        }
    }
}
