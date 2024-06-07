using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoCulto.Domain.Models
{
    public class CongregacaoModel
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string Nome { get; set; }
        [Column(TypeName = "char(1)")]
        public string Status { get; set; }

        public IEnumerable<ParametrosSistemaModel> ParametrosSistemas { get; set; }
        public IEnumerable<UsuariosModel> UsuariosSistemas { get; set; }
        public IEnumerable<PessoasModel> Pessoas { get; set; }
        public IEnumerable<MinisterioModel> Ministerios { get; set; } 
        public IEnumerable<MusicaModel> Musicas { get; set; }
    }
}
