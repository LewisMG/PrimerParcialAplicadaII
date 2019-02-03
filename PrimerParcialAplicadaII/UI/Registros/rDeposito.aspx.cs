using BLL;
using Entities;
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
            CuentasBancarias CB = new CuentasBancarias();

            if (!Page.IsPostBack)
            {
                RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();

                cuentaDropDownList.DataSource = repositorio.GetList(t => true);
                cuentaDropDownList.DataValueField = "CuentaBancariaId";
                cuentaDropDownList.DataTextField = "Nombre";
                cuentaDropDownList.DataBind();

                ViewState["Deposito"] = new Depositos();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}