using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class CuentasBancarias
    {
        [Key]
        public int CuentaBancariaId { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombre { get; set; }

        public int Balance { get; set; }

        public virtual List<Depositos> Detalle { get; set; }


        public CuentasBancarias()
        {
            this.Detalle = new List<Depositos>();
        }

        public void AgregarDetalle(int DepositoId, DateTime Fecha, int CuentaId, string Concepto, int Monto)
        {
            this.Detalle.Add(new Depositos(DepositoId, Fecha, CuentaId, Concepto, Monto));
        }
    }
}
