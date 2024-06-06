using GestaoCulto.Domain.Models;
using GestaoCulto.Repository.Interfaces;
using GestaoCulto.Repository.Persistence.Context;

namespace GestaoCulto.Repository.Class
{
    public class CongregacaoRepository : BaseRepository<CongregacaoModel>, ICongregacaoRepository
    {
        public CongregacaoRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {

        }
    }
}
