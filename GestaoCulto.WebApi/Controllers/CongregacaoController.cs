using GestaoCulto.Domain.Models;
using GestaoCulto.Services.Interfaces;
using GestaoCulto.Services.ViewModel;
using GestaoCulto.Shared;
using GestaoCulto.WebApi.Configurations.Swagger;
using Microsoft.AspNetCore.Authorization;
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


        [HttpPost, AllowAnonymous]
        [SwaggerGroup("Congregacao")]
        public async Task<IActionResult> Post(CongregacaoViewModel congregacao)
        {
            try
            {
                return Response(await _congregacaoService.Adicionar(congregacao));
            }
            catch (Exception ex)
            {
                return Response(ex.Message, false);
            }
        }

        [HttpPut, AllowAnonymous]
        [SwaggerGroup("Congregacao")]
        public async Task<IActionResult> Put(CongregacaoViewModel congregacao)
        {
            try
            {
                return Response(await _congregacaoService.Atualizar(congregacao));
            }
            catch (Exception ex)
            {
                return Response(ex.Message, false);
            }
        }

        [HttpDelete, AllowAnonymous]
        [SwaggerGroup("Congregacao")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Response(await _congregacaoService.Excluir(id));
            }
            catch (Exception ex)
            {
                return Response(ex.Message, false);
            }
        }

        [HttpGet, AllowAnonymous]
        [SwaggerGroup("Congregacao")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Response(await _congregacaoService.ObterTodos());
            }
            catch (Exception ex)
            {
                return Response(ex.Message, false);
            }
        }
    }
}
