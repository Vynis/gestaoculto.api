using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoCulto.Domain.Models
{
    public class FuncoesMinisteriaisModel
    {
		public int Id { get; set; }
		public int MinisterioId { get; set; }
		public MinisterioModel Ministerio { get; set; }
		[Column(TypeName = "varchar(60)")]
		public string Titulo { get; set; }
		[Column(TypeName = "text")]
		public string IntrucoesFuncao { get; set; }
		[Column(TypeName = "char(1)")]
		public string Status { get; set; }
		public DateTime DataCriacao { get; set; }
	}
}
