using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GCUtility.Function;
using GCUtility.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.BusinessProcess.Object;

namespace SIAQ.Web.Application.WebApp.Private.Reportes
{
	public partial class rptVisGeneral1 : System.Web.UI.Page
    {
        // Utilerías
        GCCommon gcCommon = new GCCommon();
        GCEncryption gcEncryption = new GCEncryption();
        GCJavascript gcJavascript = new GCJavascript();

        void SelectArea()
        {
            this.ddlArea.Items.Insert(0, new ListItem("Tercera Visitaduría", "6"));
            this.ddlArea.Items.Insert(0, new ListItem("Segunda Visitaduría", "5"));
            this.ddlArea.Items.Insert(0, new ListItem("Primera Visitaduría", "4"));
        }

        #region Rutinas de la página

        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{

				// Validaciones
				if (Page.IsPostBack) { return; }

                // Llenado de controles
                SelectArea();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.btnAceptar.ClientID + "'); }", true);

			}
			catch (Exception)
			{
				// Do Nothing
			}
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            // cboEstatus.SelectedValue.ToString()
            string script = "window.open('rptPresentaReporte.aspx?TipoReporte=rptVisitaduriaGeneralpage&FechaInicial=" + wucFechaInicial.BeginDate.ToString() + "&FechaFinal= " + wucFechaFinal.EndDate.ToString() + "&AreaId= " + ddlArea.SelectedValue.ToString() + "', '');";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
        }

        #endregion

        #region Rutinas del programador

        #endregion

        
	}
}