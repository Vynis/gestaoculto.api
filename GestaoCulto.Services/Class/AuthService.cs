using AutoMapper;
using GestaoCulto.Repository.Interfaces;
using GestaoCulto.Services.Interfaces;
using GestaoCulto.Services.ViewModel;
using GestaoCulto.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCulto.Services.Class
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public AuthService(IUsuarioRepository usuarioRepository, IMapper mapper) 
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioAuthViewModel> Post(AutenticarViewModel autenticarViewModel)
        {
            autenticarViewModel.Senha = SenhaHashService.CalculateMD5Hash(autenticarViewModel.Senha);

            var response = await _usuarioRepository.BuscarExpressao(x => x.Email.Equals(autenticarViewModel.Email) && x.Senha.Equals(autenticarViewModel.Senha) && x.Status.Equals("A"));

            if (!response.Any())
                throw new Exception("Usuario não encontrado");

            return _mapper.Map<UsuarioAuthViewModel>(response.FirstOrDefault());
        }
    }
}
