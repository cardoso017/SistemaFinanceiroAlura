using Financa.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Financa.DAO
{
    public class FinancaContext : DbContext 
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Movimentacao> Movimentacao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimentacao>().HasRequired(m => m.Usuario);
        }

    }
}