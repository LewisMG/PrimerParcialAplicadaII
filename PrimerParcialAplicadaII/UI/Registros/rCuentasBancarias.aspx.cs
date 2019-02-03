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
    public partial class rCuentasBancarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BalanceTextBox.Text = "0";
        }

        private void LimpiarCampos()
        {
            CBTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = "";            
            BalanceTextBox.Text = "0";
        }

        private CuentasBancarias LlenaClase()
        {
            CuentasBancarias cb = new CuentasBancarias();

            cb.CuentaBancariaId = Utils.ToInt(CBTextBox.Text);
            cb.Fecha = Convert.ToDateTime(FechaTextBox.Text).Date;
            cb.Nombre = NombreTextBox.Text;            
            cb.Balance = Utils.ToInt(BalanceTextBox.Text);

            return cb;

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<CuentasBancarias> repositoriobase = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias cuentasbancarias = repositoriobase.Buscar(Utils.ToInt(CBTextBox.Text));
            if (cuentasbancarias != null)
            {
                FechaTextBox.Text = cuentasbancarias.Fecha.ToString();
                NombreTextBox.Text = cuentasbancarias.Nombre;
                BalanceTextBox.Text = cuentasbancarias.Balance.ToString();
            }
            else
            {
                Response.Write("<script>alert('Usuario no encontrado');</script>");
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias cuentasbancarias = new CuentasBancarias();
            bool paso = false;

            //todo: validaciones adicionales
            cuentasbancarias = LlenaClase();

                if (cuentasbancarias.CuentaBancariaId == 0)
                {
                    paso = repositorio.Guardar(cuentasbancarias);
                    Response.Write("<script>alert('Guardado');</script>");
                    LimpiarCampos();
                }
                else
                {
                CuentasBancarias user = new CuentasBancarias();
                    int id = Utils.ToInt(CBTextBox.Text);
                    RepositorioBase<CuentasBancarias> repository = new RepositorioBase<CuentasBancarias>();
                cuentasbancarias = repository.Buscar(id);

                    if (user != null)
                    {
                        paso = repositorio.Modificar(LlenaClase());
                        Response.Write("<script>alert('Modificado');</script>");
                    }
                    else
                        Response.Write("<script>alert('Id no existe');</script>");
                }

                if (paso)
                {
                    LimpiarCampos();
                }
                else
                    Response.Write("<script>alert('No se pudo guardar');</script>");
            

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            int id = Utils.ToInt(CBTextBox.Text);

            var CuentasBancarias = repositorio.Buscar(id);

            if (CuentasBancarias != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Response.Write("<script>alert('Eliminado');</script>");
                    LimpiarCampos();
                }
                else
                    Response.Write("<script>alert('No se pudo eliminar');</script>");
            }
            else
                Response.Write("<script>alert('No existe');</script>");
        }
    }
}