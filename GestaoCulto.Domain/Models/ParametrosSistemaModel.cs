using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoCulto.Domain.Models
{
    public class ParametrosSistemaModel
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Valor { get; set; }
        [Column(TypeName = "char(1)")]
        public string Status { get; set; }
        public int CongregacaoId { get; set; }
        public CongregacaoModel Congregacao { get; set; }
    }
}
