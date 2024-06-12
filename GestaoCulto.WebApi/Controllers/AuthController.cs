
using GestaoCulto.Services.Class;
using GestaoCulto.Services.Interfaces;
using GestaoCulto.Services.ViewModel;
using GestaoCulto.Shared;
using GestaoCulto.WebApi.Configurations.Swagger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace GestaoCulto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost, AllowAnonymous]
        [SwaggerGroup("Autenticacao")]
        public async Task<IActionResult> Post(AutenticarViewModel autenticarViewModel )
        {
            try
            {
                var usuario = await _authService.Post(autenticarViewModel);

                var token = TokenService.GenerateToken(usuario, _configuration);

                return Response(new { usuario, token });
            }
            catch (Exception ex)
            {
                return Response(ex.Message, false);
            }
        }

        [HttpGet]
        [SwaggerGroup("Autenticacao")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuario = await _authService.Get(Convert.ToInt32(User.Identity.Name));

                return Ok(new { name = usuario.Nome, picture = "" });
            }
            catch (Exception ex)
            {

                return Response(ex.Message, false);
            }
        }

    }
}
