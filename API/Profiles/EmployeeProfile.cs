using API.ViewModels.Contracts;
using API.ViewModels.Employee;
using API.ViewModels.EmployeeAccount;
using API.ViewModels.EntryCard;
using API.ViewModels.Tickets;
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

                .ForMember(viewModel => viewModel.GradeName, model => model.MapFrom(x => x.Grade.Name))
                .ForMember(viewModel => viewModel.GradeNumber, model => model.MapFrom(x => x.Grade.GradeNumber))

                .ForMember(viewModel => viewModel.LevelName, model => model.MapFrom(x => x.Level.Name))
                .ForMember(viewModel => viewModel.LevelNumber, model => model.MapFrom(x => x.Level.LevelNumber))

                .ForMember(viewModel => viewModel.JobVacancyId, model => model.MapFrom(x => x.JobVacancyId))
                .ForMember(viewModel => viewModel.VacantNumber, model => model.MapFrom(x => x.JobVacancy.VacantNumber))

                .ForMember(viewModel => viewModel.BranchId, model => model.MapFrom(x => x.JobVacancy.BranchId))
                .ForMember(viewModel => viewModel.BranchName, model => model.MapFrom(x => x.JobVacancy.Branch.ArabicName))

                .ForMember(viewModel => viewModel.DepartmentId, model => model.MapFrom(x => x.JobVacancy.Branch.DepartmentId))
                .ForMember(viewModel => viewModel.DepartmentName, model => model.MapFrom(x => x.JobVacancy.Branch.Department.ArabicName))
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

            // EntryCard
            CreateMap<EntryCard, EntryCardVM>()
                .ForMember(viewModel => viewModel.EmployeeName, model => model.MapFrom(x => x.Employee.ArabicName))
                .ReverseMap();
            CreateMap<EntryCard, CreateEmployeeVM>()
                .ReverseMap();
            CreateMap<EntryCard, UpdateEntryCardVM>()
                .ReverseMap();

            // Contract
            CreateMap<Contract, ContractVM>()
                .ForMember(viewModel => viewModel.EmployeeName, model => model.MapFrom(x => x.Employee.ArabicName))
                .ForMember(viewModel => viewModel.ContractType, model => model.MapFrom(x => x.ContractType.ArabicName))
                .ReverseMap();
            CreateMap<Contract, CreateContractVM>()
                .ReverseMap();
            CreateMap<Contract, UpdateContractVM>()
                .ReverseMap();

            // ContractTransaction
            CreateMap<ContractTransaction, ContractTransactionVM>()
                .ForMember(viewModel => viewModel.ContractNumber, model => model.MapFrom(x => x.Contract.ContractNumber))
                .ForMember(viewModel => viewModel.ContractType, model => model.MapFrom(x => x.ContractType.ArabicName))
                .ReverseMap();
            CreateMap<ContractTransaction, CreateContractTransactionVM>()
                .ReverseMap();
            CreateMap<Contract, CreateContractTransactionVM>()
                .ReverseMap();

            // ContractType
            CreateMap<ContractType, ContractTypeVM>()
                .ReverseMap();
            CreateMap<ContractType, CreateContractTypeVM>()
                .ReverseMap();
            CreateMap<ContractType, UpdateContractTypeVM>()
                .ReverseMap();

            // Ticket
            CreateMap<Ticket, TicketVM>()
                .ForMember(viewModel => viewModel.ContractId, model => model.MapFrom(x => x.ContractId))
                .ForMember(viewModel => viewModel.ContractNumber, model => model.MapFrom(x => x.Contract.ContractNumber))
                .ForMember(viewModel => viewModel.ArabicName, model => model.MapFrom(x => x.Contract.Employee.ArabicName))
                .ReverseMap();
            CreateMap<Ticket, CreateTicketVM>()
                .ReverseMap();
            CreateMap<Ticket, UpdateTicketVM>()
                .ReverseMap();
        }
    }
}
