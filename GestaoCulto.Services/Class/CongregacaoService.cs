using GestaoCulto.Domain.Models;
using GestaoCulto.Repository.Interfaces;
using GestaoCulto.Services.Interfaces;

namespace GestaoCulto.Services.Class
{
    public class CongregacaoService : BaseService<CongregacaoModel>, ICongregacaoService
    {
        public CongregacaoService(ICongregacaoRepository congregacaoRepository) : base(congregacaoRepository)
        {

        }
    }
}
