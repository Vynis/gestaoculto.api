using AutoMapper;
using GestaoCulto.Domain.Models;
using GestaoCulto.Repository.Interfaces;
using GestaoCulto.Services.Interfaces;
using GestaoCulto.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace GestaoCulto.Services.Class
{
    public class CongregacaoService : ICongregacaoService
    {
        private readonly ICongregacaoRepository _congregacaoRepository;
        private readonly IMapper _mapper;

        public CongregacaoService(ICongregacaoRepository congregacaoRepository, IMapper mapper)
        {
            _congregacaoRepository = congregacaoRepository;
            _mapper = mapper;
        }

        public async Task<bool> Adicionar(CongregacaoViewModel obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            CongregacaoModel congregacao = _mapper.Map<CongregacaoModel>(obj);

            return await _congregacaoRepository.Adicionar(congregacao);
        }

        public async Task<bool> Atualizar(CongregacaoViewModel obj)
        {
            if (obj.Id == 0)
                throw new Exception("Id inváldo!");

            var congregacao = await _congregacaoRepository.ObterPorId(obj.Id);

            if (congregacao == null)
                throw new Exception("Congregação não encontrada");

            congregacao = _mapper.Map<CongregacaoModel>(obj);

            return await _congregacaoRepository.Atualizar(congregacao);

        }

        public async Task<bool> Excluir(int id)
        {
            var congregacao = await _congregacaoRepository.ObterPorId(id);

            if (congregacao == null)
                throw new Exception("Congregação não encontrada");

            return await _congregacaoRepository.Excluir(congregacao);
        }

        public async Task<CongregacaoViewModel> ObterPorId(int id)
        {
            if (id == 0)
                throw new Exception("Id inváldo!");

            var congregacao = await _congregacaoRepository.ObterPorId(id);

            if (congregacao == null)
                throw new Exception("Congregação não encontrada");

            return _mapper.Map<CongregacaoViewModel>(congregacao);   
        }

        public async Task<IEnumerable<CongregacaoViewModel>> ObterTodos()
        {
            var congregacao = await _congregacaoRepository.ObterTodos();

            return _mapper.Map<IEnumerable<CongregacaoViewModel>>(congregacao);
        }
    }
}
