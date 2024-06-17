using GestaoCulto.Services.Interfaces;
using GestaoCulto.Services.ViewModel;
using GestaoCulto.Shared;
using GestaoCulto.WebApi.Configurations.Swagger;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestaoCulto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : BaseController
    {
        private readonly IPessoasService _pessoasService;

        public PessoaController(IPessoasService pessoasService)
        {
            _pessoasService = pessoasService;
        }

        [HttpPost]
        [SwaggerGroup("Pessoa")]
        public async Task<IActionResult> Post(PessoasViewModel pessoa)
        {
            try
            {
                //var idCongregacao = await _congregacaoService.GetCongrecaoUsuario(Convert.ToInt32(User.Identity.Name));

                //pessoa.CongregacaoId = idCongregacao;

                return Response(await _pessoasService.Adicionar(pessoa));
            }
            catch (Exception ex)
            {
                return Response(ex.Message, false);
            }
        }
    }
}
