using GestaoCulto.Domain.Models;
using GestaoCulto.Repository.Interfaces;
using GestaoCulto.Repository.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoCulto.Repository.Class
{
    public class CongregacaoRepository : BaseRepository<CongregacaoModel>, ICongregacaoRepository
    {
        private readonly MySqlContext _mySqlContext;

        public CongregacaoRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public async override Task<CongregacaoModel> ObterPorId(int Id)
        {
            IQueryable<CongregacaoModel> query = _mySqlContext.congregacao.Where(c => c.Id.Equals(Id));

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
