using AutoMapper;
using GestaoCulto.Domain.Models;
using GestaoCulto.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoCulto.Services.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<CongregacaoViewModel, CongregacaoModel>().ReverseMap();
        }
    }
}
