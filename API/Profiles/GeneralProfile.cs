using API.ViewModels.Nationality;
using AutoMapper;
using Core.Models;
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
        }
    }
}
