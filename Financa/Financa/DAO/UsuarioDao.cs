using Financa.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Financa.DAO
{
    public class UsuarioDao
    {
        private FinancaContext Context;

        public UsuarioDao(FinancaContext context)
        {
            this.Context = context;


        }

        public void Adiciona(Usuario usuario)
        {
            Context.Usuarios.Add(usuario);
            Context.SaveChanges();
        }

        public List<Usuario> Lista()
        {
            return Context.Usuarios.ToList();
        }


    }
}