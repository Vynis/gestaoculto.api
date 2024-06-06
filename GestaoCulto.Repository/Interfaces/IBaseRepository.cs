using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoCulto.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<bool> Adicionar(TEntity obj);
        Task<bool> Atualizar(TEntity obj);
        Task<bool> AtualizarLista(List<TEntity> obj);
        Task<bool> SaveChangesAsync();
        Task<bool> Excluir(TEntity obj);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<TEntity> ObterPorId(int Id);
        Task<IEnumerable<TEntity>> ObterPorDescricao(string Descricao);
        Task<IEnumerable<TEntity>> BuscarExpressao(Expression<Func<TEntity, bool>> predicado);
        Task<bool> AdiconarLista(TEntity[] obj);
        Task<bool> ExcluirLista(TEntity[] obj);
    }
}
