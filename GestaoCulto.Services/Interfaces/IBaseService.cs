using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoCulto.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<bool> Adicionar(TEntity obj);
        Task<bool> Atualizar(TEntity obj);
        Task<bool> Excluir(int id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<TEntity> ObterPorId(int id);
    }
}
