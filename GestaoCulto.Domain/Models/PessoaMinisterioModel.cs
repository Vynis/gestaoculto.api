using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoCulto.Domain.Models
{
    public class PessoaMinisterioModel
    {
        public int Id { get; set; }
        public int MinisterioId { get; set; }
        public MinisterioModel Ministerio { get; set; } 
        public int PessoasId { get; set; }
        public PessoasModel Pessoas { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
