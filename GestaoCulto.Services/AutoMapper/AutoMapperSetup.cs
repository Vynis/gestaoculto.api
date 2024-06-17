using AutoMapper;
using GestaoCulto.Domain.Models;
using GestaoCulto.Services.ViewModel;

namespace GestaoCulto.Services.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<CongregacaoViewModel, CongregacaoModel>().ReverseMap();
            CreateMap<UsuarioAuthViewModel, UsuariosModel>().ReverseMap();
            CreateMap<PessoasViewModel, PessoasModel>().ReverseMap();   
        }
    }
}
