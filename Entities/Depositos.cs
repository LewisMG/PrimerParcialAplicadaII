using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Depositos
    {
        [Key]
        public int DepositoId { get; set; }
        public DateTime Fecha { get; set; }                   
        public int CuentaId { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("CunetaId")]
        public virtual CuentasBancarias CuentaBancaria { get; set; }

        public Depositos()
        {
            DepositoId = 0;
            Fecha = DateTime.Now;
            CuentaId = 0;
            Concepto = string.Empty;
            Monto = 0;
        }

        public Depositos(int depositoId, DateTime fecha, int cuentaId, string concepto, decimal monto)
        {
            DepositoId = depositoId;
            Fecha = fecha;
            CuentaId = cuentaId;
            Concepto = concepto;
            Monto = monto;
        }
    }
}
