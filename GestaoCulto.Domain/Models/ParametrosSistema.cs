using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoCulto.Domain.Models
{
    public class ParametrosSistema
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string Status { get; set; }
        public int CongregacaoId { get; set; }
        public CongregacaoModel Congregacao { get; set; }
    }
}
