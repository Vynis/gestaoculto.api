using GestaoCulto.Repository.Class;
using GestaoCulto.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoCulto.IOC.Repository
{
    public static class RegisterRepository
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddScoped<ICongregacaoRepository, CongregacaoRepository>();
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }
    }
}
