using GestaoCulto.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCulto.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UsuarioAuthViewModel> Post(AutenticarViewModel autenticarViewModel);
        Task<UsuarioAuthViewModel> Get(int idUser);
    }
}
