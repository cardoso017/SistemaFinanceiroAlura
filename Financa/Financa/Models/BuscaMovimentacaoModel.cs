using Financa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financa.Models
{
    public class BuscaMovimentacaoModel
    {
        public decimal? ValorMinimo {get;set;}

        public decimal? ValorMaximo { get; set; }


        public DateTime? DataMinima { get; set; }

        public DateTime? DataMaxima { get; set; }

        public Tipo? Tipo { get; set; }

        public int? IdUsuario { get; set; }


        public List<Movimentacao> Movimentacaos { get; set; }

        public List<Usuario> Usuarios { get; set; }

    }
}