using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoCulto.Services.ViewModel
{
    public class PessoasViewModel
    {
		public int Id { get; set; }
		[Required]
		public string Nome { get; set; }
		[Required]
		public string Email { get; set; }
		public string FoneCelular { get; set; }
		public DateTime DtNascimento { get; set; }
		public string Status { get; set; }
		public DateTime DataCriacao { get; set; }
		[Required]
		public int CongregacaoId { get; set; }
	}
}
