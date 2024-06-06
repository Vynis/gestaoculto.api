using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoCulto.Domain.Models
{
    public class CongregacaoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }

        public IEnumerable<ParametrosSistema> ParametrosSistemas { get; set; }
    }
}
