using AutoMapper;
using GestaoCulto.Domain.Models;
using GestaoCulto.Repository.Interfaces;
using GestaoCulto.Services.Interfaces;
using GestaoCulto.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestaoCulto.Services.Class
{
    public class PessoasService : IPessoasService
    {
        private readonly IPessoasRepository _pessoasRepository;
        private readonly IMapper _mapper;

        public PessoasService(IPessoasRepository pessoasRepository, IMapper mapper)
        {
            _pessoasRepository = pessoasRepository;
            _mapper = mapper;
        }

        public async Task<bool> Adicionar(PessoasViewModel obj)
        {
            ValidaEmail(obj.Email);

            var pessoaExistente = await _pessoasRepository.BuscarExpressao(x => x.Email.ToUpper().Equals(obj.Email.ToUpper()));

            if (pessoaExistente.Any())
                throw new Exception("Email já cadastrado!");

            obj.Status = "A";
            obj.DataCriacao = DateTime.Now;

            return await _pessoasRepository.Adicionar(_mapper.Map<PessoasModel>(obj));
        }

        public async Task<bool> Atualizar(PessoasViewModel obj)
        {
            if (obj.Id == 0)
                throw new Exception("Id inváldo!");

            var pessoa = await _pessoasRepository.ObterPorId(obj.Id);

            if (pessoa == null)
                throw new Exception("Pessoa não encontrada");

            ValidaEmail(obj.Email);

            if (!pessoa.Email.Equals(obj.Email))
            {
                var pessoaExistente = await _pessoasRepository.BuscarExpressao(x => x.Email.ToUpper().Equals(obj.Email.ToUpper()));

                if (pessoaExistente != null)
                    throw new Exception("Email já cadastrado!");
            }

            pessoa = _mapper.Map<PessoasModel>(obj);

            return await _pessoasRepository.Atualizar(pessoa);
        }

        public async Task<bool> Excluir(int id)
        {
            var pessoa = await _pessoasRepository.ObterPorId(id);

            if (pessoa == null)
                throw new Exception("Pessoa não encontrada");

            pessoa.DataExclusao = DateTime.Now;

            return await _pessoasRepository.Atualizar(pessoa);
        }

        public async Task<PessoasViewModel> ObterPorId(int id)
        {
            if (id == 0)
                throw new Exception("Id inváldo!");

            var pessoa = await _pessoasRepository.ObterPorId(id);

            if (pessoa == null)
                throw new Exception("Pessoa não encontrada");

            return _mapper.Map<PessoasViewModel>(pessoa);
        }

        public async Task<IEnumerable<PessoasViewModel>> ObterTodos()
        {
            var listPessoas = await _pessoasRepository.ObterTodos();

            return _mapper.Map<IEnumerable<PessoasViewModel>>(listPessoas);
        }

        private static void ValidaEmail(string email)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (!Regex.IsMatch(email, strModelo))
                throw new Exception("Email inváldo!");
        }
    }
}
