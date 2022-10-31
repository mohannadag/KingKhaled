using API.ViewModels.Contracts;
using API.ViewModels.Vacations;
using AutoMapper;
using Core.Models.EmployeesInfo;
using Core.Models.Vacations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class VacationProfile : Profile
    {
        public VacationProfile()
        {
            // VacationType
            CreateMap<VacationType, VacationTypeVM>()
                .ReverseMap();
            CreateMap<VacationType, CreateVacationTypeVM>()
                .ReverseMap();
            CreateMap<VacationType, UpdateVacationTypeVM>()
                .ReverseMap();
        }
    }
}
