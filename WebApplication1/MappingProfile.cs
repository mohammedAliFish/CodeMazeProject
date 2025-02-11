﻿using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace CodeMazeProject1
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress",
                    opt => opt.MapFrom(x => string.Join(" ", x.CompanyAddress, x.Country)));

            

        }
    }
}
