using API.ViewModels.Allowance;
using AutoMapper;
using Core.Models.Allowance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class AllowanceProfile : Profile
    {
        public AllowanceProfile()
        {
            // Allowance Type
            CreateMap<AllowanceType, AllowanceTypeVM>()
                .ReverseMap();
            CreateMap<AllowanceType, CreateAllowanceTypeVM>()
                .ReverseMap();
            CreateMap<AllowanceType, UpdateAllowanceTypeVM>()
                .ReverseMap();
        }
    }
}
