using GestaoCulto.Domain.Models;
using GestaoCulto.Repository.Interfaces;
using GestaoCulto.Repository.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoCulto.Repository.Class
{
    public class PessoasRepository : BaseRepository<PessoasModel>, IPessoasRepository
    {
        public PessoasRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {

        }
    }
}
