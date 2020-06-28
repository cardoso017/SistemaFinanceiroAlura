using Financa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financa.Models
{
    public class MovimentacaoPorUsuarioModel
    {
        public int? UsuarioId { get; set; }


        public IList<Movimentacao> Movimentacaos { get; set; }

        public IList<Usuario> usuarios { get; set; }
    }
}