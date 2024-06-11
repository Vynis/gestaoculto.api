using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoCulto.Services.ViewModel
{
    public class UsuarioAuthViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool DadosComp { get; set; }
    }
}
