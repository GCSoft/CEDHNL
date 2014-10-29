using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAQ.Web.Application.WebApp.Private.Reportes
{
	public partial class rptVisGeneral1 : System.Web.UI.Page
    {

        #region Rutinas de la página

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            // cboEstatus.SelectedValue.ToString()
            string script = "window.open('rptPresentaReporte.aspx?TipoReporte=rptVisGeneral&FechaInicial=" + wucFechaInicial.BeginDate.ToString() + "&FechaFinal= " + wucFechaFinal.EndDate.ToString() + "&EstatusId= " + "1" + "', '');";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
        }
        
        #endregion

        #region Rutinas del programador

        #endregion

        
	}
}