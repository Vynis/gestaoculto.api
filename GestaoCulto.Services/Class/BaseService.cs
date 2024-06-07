using GestaoCulto.Repository.Interfaces;
using GestaoCulto.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCulto.Services.Class
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Adicionar(TEntity obj)
        {
            return await _repository.Adicionar(obj);
        }

        public async Task<bool> Atualizar(TEntity obj)
        {
            return await _repository.Atualizar(obj);
        }


        public async Task<bool> Excluir(int id)
        {
            var result = await _repository.ObterPorId(id);

            return await _repository.Excluir(result);
        }


        public async Task<TEntity> ObterPorId(int id)
        {
            return await _repository.ObterPorId(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }
    }
}
