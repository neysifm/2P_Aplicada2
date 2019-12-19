using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2P_Aplicada2.Entidades
{
    [Serializable]
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }

        public Venta()
        {
            VentaId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            Balance = 0;
        }
    }
}