using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepositoReposito : RepositorioBase<Depositos>
    {
        public override bool Guardar(Depositos depositos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Depositos.Add(depositos);
                contexto.CuentasBancarias.Find(depositos.CuentaId).Balance += depositos.Monto;
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Depositos depositos = contexto.Depositos.Find(id);
                contexto.CuentasBancarias.Find(depositos.CuentaId).Balance -= depositos.Monto;
                contexto.Depositos.Remove(depositos);
                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public override Depositos Buscar(int id)
        {            
            Depositos depositos = new Depositos();
            try
            {
                CuentasBancarias cuentas = new CuentasBancarias();
                depositos = _contexto.Depositos.Find(id);
                cuentas.Detalle.Count();

                foreach (var item in cuentas.Detalle)
                {
                    string s = item.CuentaBancaria.Nombre;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return depositos;
        }

        public override bool Modificar(Depositos depositos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(depositos).State = EntityState.Modified;

                Depositos DepAnt = contexto.Depositos.Find(depositos.DepositoId);
                var cuenta = contexto.CuentasBancarias.Find(depositos.CuentaId);
                var cuentaAnt = contexto.CuentasBancarias.Find(DepAnt.CuentaId);

                if (depositos.CuentaId != DepAnt.CuentaId)
                {
                    cuenta.Balance += depositos.Monto;
                    cuentaAnt.Balance -= DepAnt.Monto;
                }
                else
                {
                    int diferencia = depositos.Monto - DepAnt.Monto;
                    cuenta.Balance += diferencia;
                }

                contexto.SaveChanges();
                paso = true;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

    }
}
