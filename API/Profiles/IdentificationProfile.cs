using API.ViewModels.Contracts;
using API.ViewModels.Identity;
using API.ViewModels.Passport;
using AutoMapper;
using Core.Models.EmployeesInfo;
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
                .ForMember(viewModel => viewModel.JobVisa, model => model.MapFrom(x => x.JobVisa.Name))
                .ReverseMap();
            CreateMap<Identity, CreateIdentityVM>()
                .ForMember(viewModel => viewModel.IdentityType, model => model.MapFrom(x => x.IdentityType))
                .ReverseMap();
            CreateMap<Identity, UpdateIdentityVM>()
                .ForMember(viewModel => viewModel.IdentityType, model => model.MapFrom(x => x.IdentityType))
                .ReverseMap();

            // IdentityTransaction
            CreateMap<IdentityTransaction, IdentityTransactionVM>()
                .ForMember(viewModel => viewModel.IdentityNumber, model => model.MapFrom(x => x.Identity.IdentityNumber))
                .ForMember(viewModel => viewModel.JobVisaName, model => model.MapFrom(x => x.JobVisa.Name))
                .ReverseMap();
            CreateMap<IdentityTransaction, CreateIdentityTransactionVM>()
                .ReverseMap();
            CreateMap<Identity, CreateIdentityTransactionVM>()
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

            // PassportTransaction
            CreateMap<PassportTransaction, PassportTransactionVM>()
                .ForMember(viewModel => viewModel.PassportNumber, model => model.MapFrom(x => x.Passport.PassportNumber))
                .ForMember(viewModel => viewModel.ArabicName, model => model.MapFrom(x => x.Passport.Employee.ArabicName))
                .ReverseMap();
            CreateMap<PassportTransaction, CreatePassportTransactionVM>()
                .ReverseMap();
            CreateMap<Passport, CreatePassportTransactionVM>()
                .ReverseMap();
        }
    }
}
