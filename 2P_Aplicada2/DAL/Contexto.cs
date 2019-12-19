using _2P_Aplicada2.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _2P_Aplicada2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Venta> Venta { get; set; }

        public Contexto() : base("Constr")
        {
        }
    }
}