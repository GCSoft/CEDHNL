using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Reportes
{
    public partial class rptTema1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                Fillcbo();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.cboEstatus.ClientID + "'); }", true);
            }
        }

        #region Rutinas de la página

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string script = "window.open('rptPresentaReporte.aspx?TipoReporte=Temas&FechaInicial=" + wucFechaInicial.BeginDate.ToString() + "&FechaFinal= " + wucFechaFinal.EndDate.ToString() + "&EstatusId= " + cboEstatus.SelectedValue.ToString() + "', '');";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "popup", script, true);
        }

        #endregion

        #region Rutinas del programador

        // Proceso de llenado de combos
        void Fillcbo()
        {
            // Declaración de variables
            ENTResponse oResponse = new ENTResponse();
            ENTEstatus ent = new ENTEstatus();
            BPEstatus bss = new BPEstatus();

            try
            {
                // Asignación de valores
                ent.TipoEstatusId = 1; // Quejas

                // Transacción
                oResponse = bss.searchcatEstatusTipoEstatus(ent);

                if (oResponse.dsResponse.Tables[1].Rows.Count > 0)
                {
                    cboEstatus.DataSource = oResponse.dsResponse.Tables[1];
                    cboEstatus.DataValueField = "EstatusId";
                    cboEstatus.DataTextField = "Nombre";
                    cboEstatus.DataBind();
                }
            }
            catch (Exception ex) { throw (ex); }
            finally { }
        }

        #endregion

    }
}