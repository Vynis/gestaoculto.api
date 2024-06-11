using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoCulto.Domain.Models
{
    public class UsuariosModel
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        [Column(TypeName = "char(1)")]
        public string Status { get; set; }
        public int CongregacaoId { get; set; }
        public CongregacaoModel Congregacao { get; set; }
    }
}
