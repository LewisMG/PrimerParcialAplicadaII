using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimerParcialAplicadaII.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias cuenta = new CuentasBancarias();
            bool paso = false;

            cuenta.CuentaBancariaId = 1;
            cuenta.Fecha = DateTime.Now;
            cuenta.Nombre = "Pedro";
            cuenta.Balance = 0;

            paso = repositorio.Guardar(cuenta);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            var cuenta = BuscarM();
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();

            bool paso = false;
            cuenta.Nombre = "Eudy";
            paso = repositorio.Modificar(cuenta);
            Assert.AreEqual(true, paso);
        }

        public CuentasBancarias BuscarM()
        {
            int id = 1;
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias cuenta = new CuentasBancarias();
            cuenta = repositorio.Buscar(id);
            return cuenta;
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            int id = 1;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 1;
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias cuenta = new CuentasBancarias();
            cuenta = repositorio.Buscar(id);
            Assert.IsNotNull(cuenta);
        }

        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            List<CuentasBancarias> lista = new List<CuentasBancarias>();
            Expression<Func<CuentasBancarias, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }

        //Test de Depósitos.
        [TestMethod]
        public void GuardarD()
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Depositos deposito = new Depositos();
            bool paso = false;

            deposito.DepositoId = 3;
            deposito.Fecha = DateTime.Now;
            deposito.CuentaId = 3;
            deposito.Concepto = "Pago de Renta";
            deposito.Monto = 400;

            paso = repositorio.Guardar(deposito);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void ModificarD()
        {
            var deposito = BuscarMD();
            DepositoRepositorio repositorio = new DepositoRepositorio();

            bool paso = false;
            deposito.Concepto = "Pago de Celular";
            paso = repositorio.Modificar(deposito);
            Assert.AreEqual(true, paso);
        }

        public Depositos BuscarMD()
        {
            int id = 4;
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Depositos deposito = new Depositos();
            deposito = repositorio.Buscar(id);
            return deposito;
        }
      
        [TestMethod]
        public void BuscarD()
        {
            int id = 4;
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            Depositos deposito = new Depositos();
            deposito = repositorio.Buscar(id);
            Assert.IsNotNull(deposito);
        }

        [TestMethod()]
        public void GetListD()
        {
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            List<Depositos> lista = new List<Depositos>();
            Expression<Func<Depositos, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void EliminarD()
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            int id = 4;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

    }
}
