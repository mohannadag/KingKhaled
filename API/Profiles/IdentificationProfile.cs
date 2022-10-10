using API.ViewModels.Identity;
using API.ViewModels.Passport;
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
            // Identity
            CreateMap<Identity, IdentityVM>()
                .ForMember(viewModel => viewModel.ArabicName, model => model.MapFrom(x => x.Employee.ArabicName))
                .ForMember(viewModel => viewModel.EnglishName, model => model.MapFrom(x => x.Employee.EnglishName))
                .ForMember(viewModel => viewModel.EmployeeNumber, model => model.MapFrom(x => x.Employee.EmployeeNumber))
                .ReverseMap();
            CreateMap<Identity, CreateIdentityVM>()
                .ForMember(viewModel => viewModel.IdentityType, model => model.MapFrom(x => x.IdentityType))
                .ReverseMap();
            CreateMap<Identity, UpdateIdentityVM>()
                .ForMember(viewModel => viewModel.IdentityType, model => model.MapFrom(x => x.IdentityType))
                .ReverseMap();

            // Passport
            CreateMap<Passport, PassportVM>()
                .ForMember(viewModel => viewModel.ArabicName, model => model.MapFrom(x => x.Employee.ArabicName))
                .ForMember(viewModel => viewModel.EnglishName, model => model.MapFrom(x => x.Employee.EnglishName))
                .ForMember(viewModel => viewModel.EmployeeNumber, model => model.MapFrom(x => x.Employee.EmployeeNumber))
                .ReverseMap();
            CreateMap<Passport, CreatePassportVM>()
                .ReverseMap();
            CreateMap<Passport, UpdatePassportVM>()
                .ReverseMap();
        }
    }
}
