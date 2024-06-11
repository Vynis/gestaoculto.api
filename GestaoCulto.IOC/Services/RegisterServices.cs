using GestaoCulto.Services.Class;
using GestaoCulto.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoCulto.IOC.Services
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection service)
        {
            service.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            service.AddScoped<ICongregacaoService, CongregacaoService>();
            service.AddScoped<IAuthService, AuthService>(); 
        }
    }
}
