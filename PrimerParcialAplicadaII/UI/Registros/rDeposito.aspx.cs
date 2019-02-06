using BLL;
using Entities;
using PrimerParcialAplicadaII.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialAplicadaII.UI.Registros
{
    public partial class rDeposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDropDownList();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DepositoidTextBox.Text = "0";
            }
        }

        private void LimpiarCampos()
        {
            DepositoidTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            cuentaDropDownList.SelectedIndex = 0;
            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "0";
        }

        public void LlenarCampos(Depositos depositos)
        {
            LimpiarCampos();
            DepositoidTextBox.Text = depositos.DepositoId.ToString();
            FechaTextBox.Text = depositos.Fecha.ToString("yyyy-MM-dd");
            cuentaDropDownList.Text = Convert.ToString(depositos.CuentaId);
            ConceptoTextBox.Text = depositos.Concepto;
            MontoTextBox.Text = depositos.Monto.ToString();
        }

        private void LlenarDropDownList()
        {
            RepositorioBase<CuentasBancarias> cuentas = new RepositorioBase<CuentasBancarias>();
            cuentaDropDownList.Items.Clear();
            cuentaDropDownList.DataSource = cuentas.GetList(x => true);
            cuentaDropDownList.DataValueField = "CuentaBancariaId";
            cuentaDropDownList.DataTextField = "Nombre";
            cuentaDropDownList.DataBind();
        }

        private Depositos LlenaClase()
        {
            Depositos depositos = new Depositos();

            depositos.DepositoId = Utils.ToInt(DepositoidTextBox.Text);
            depositos.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            depositos.CuentaId = Utils.ToInt(cuentaDropDownList.Text);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Monto = Utils.ToInt(MontoTextBox.Text);

            return depositos;
        }
        
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();
            Depositos depositos = repositorio.Buscar(Utils.ToInt(DepositoidTextBox.Text));

            if (depositos != null)
            {
                LlenarCampos(depositos);
                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            Depositos depositos = LlenaClase();
            RepositorioBase<CuentasBancarias> cuentas = new RepositorioBase<CuentasBancarias>();
            
            bool paso = false;

            if (cuentaDropDownList != null)
            {

                if (Page.IsValid)
                {
                    if (DepositoidTextBox.Text == "0")
                    {
                        paso = repositorio.Guardar(depositos);
                    }
                    else
                    {
                        var verificar = repositorio.Buscar(Utils.ToInt(DepositoidTextBox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(depositos);
                        }
                        else
                        {
                            Utils.ShowToastr(this, "No se encuentra el ID", "Fallo", "error");
                            return;
                        }
                    }
                    if (paso)
                    {
                        Utils.ShowToastr(this, "Registro Con Exito", "Exito", "success");
                    }
                    else
                    {
                        Utils.ShowToastr(this, "No se pudo Guardar", "Fallo", "error");
                    }
                    LimpiarCampos();
                    return;
                }
            }
            else
            {
                Utils.ShowToastr(this, "El numero de cuenta no existe", "Fallo", "error");
                return;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            DepositoRepositorio repositorio = new DepositoRepositorio();
            RepositorioBase<Depositos> dep = new RepositorioBase<Depositos>();
            
            int id = Utils.ToInt(DepositoidTextBox.Text);
            var depositos = repositorio.Buscar(id);
            
            if (depositos == null)
            {
                 Utils.ShowToastr(this, "El deposito no existe", "Fallo", "error");
            }
            else
            {
                repositorio.Eliminar(id);
                               
                Utils.ShowToastr(this, "Elimino Correctamente", "Exito", "info");
                LimpiarCampos();
            }            
        }
    }
}