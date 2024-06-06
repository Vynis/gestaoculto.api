using GestaoCulto.Services.Interfaces;
using GestaoCulto.Shared;
using GestaoCulto.WebApi.Configurations.Swagger;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoCulto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CongregacaoController : BaseController
    {
        private readonly ICongregacaoService _congregacaoService;

        public CongregacaoController(ICongregacaoService congregacaoService)
        {
            _congregacaoService = congregacaoService;
        }

        [HttpGet("buscar-por-ativos")]
        [SwaggerGroup("Congregacao")]
        public async Task<IActionResult> BuscarPorAtivos()
        {
            try
            {
                var response = await _congregacaoService.BuscarExpressao(x => x.Status.Equals("A"));

                return Response(response.ToList().OrderBy(c => c.Nome));
            }
            catch (Exception ex)
            {

                return Response(ex.Message, false);
            }
        }
    }
}
