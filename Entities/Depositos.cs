using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Depositos
    {
        public int DepositoId { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }

        public Depositos()
        {

        }
    }
}
