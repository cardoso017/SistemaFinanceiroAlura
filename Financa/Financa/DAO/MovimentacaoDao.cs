using Financa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financa.DAO
{
   
    public class MovimentacaoDao
    {

        private FinancaContext Context; 

        public MovimentacaoDao(FinancaContext context)
        {
            this.Context = context;
        }

        public void Adicionar(Movimentacao movimentacao)
        {
            Context.Movimentacao.Add(movimentacao);
            Context.SaveChanges();
        }

        public IList<Movimentacao> Lista()
        {
            return Context.Movimentacao.ToList();
        }

        public IList<Movimentacao> BuscaPorUsuario(int? usuarioId)
        {
            return Context.Movimentacao.Where(m => m.UsuarioId == usuarioId).ToList();
        }

        public List<Movimentacao> Busca(decimal? valorMinimo, decimal? valorMaximo,
                        DateTime? dataMinima, DateTime? dataMaxima,
                        Tipo? tipo, int? idUsuario)
        {

            IQueryable<Movimentacao> busca = Context.Movimentacao;
            if (valorMinimo.HasValue)
                busca = busca.Where(m => m.Valor >= valorMinimo);
            if (valorMaximo.HasValue)
                busca = busca.Where(m => m.Valor <= valorMaximo);
            if (dataMinima.HasValue)
                busca = busca.Where(m => m.Data >= dataMinima);
            if (dataMaxima.HasValue)
                busca = busca.Where(m => m.Data <= dataMaxima);

            if (tipo.HasValue)
                busca = busca.Where(m => m.Tipo == tipo);
            if (idUsuario.HasValue)
                busca = busca.Where(m => m.UsuarioId == idUsuario);

            return busca.ToList();
        }
    }
}