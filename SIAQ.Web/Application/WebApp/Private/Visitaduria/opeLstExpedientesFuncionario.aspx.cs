// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using SIAQ.BusinessProcess.Object;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
    public partial class opeLstExpedientesFuncionario : System.Web.UI.Page
    {

        // Rutinas del programador
        private void selectExpediente()
        {
            BPExpediente oBPExpediente = new BPExpediente();
            ENTExpediente oENTExpediente = new ENTExpediente();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Formulario
                oENTExpediente.Numero = "";
                oENTExpediente.Ciudadano = "";
                oENTExpediente.MedioComunicacionId = 0;
                oENTExpediente.FuncionarioId = 0;

                // Transacción 
                oENTResponse = oBPExpediente.searchExpediente(oENTExpediente);

                // Validacion de error en consulta
                if (oENTResponse.GeneratesException)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true); focusControl('" + this.gvApps.ClientID + "');", true);
                    return;
                }

                // Validación mendaje de base de datos
                if (oENTResponse.sMessage != "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true); focusControl('" + this.gvApps.ClientID + "');", true);
                    this.gvApps.DataSource = null;
                    this.gvApps.DataBind();
                    return;
                }


                // Llenado de controles
                this.gvApps.DataSource = oENTResponse.dsResponse.Tables[1];
                this.gvApps.DataBind();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.gvApps.ClientID + "');", true);
            }

        }

        // Eventos de la página
        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.Page.IsPostBack) { return; }


            selectExpediente();
        }

        protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String idExpediente = "";
            String strCommand = "";
            Int32 iRow = 0;

            try
            {

                // Opción seleccionada
                strCommand = e.CommandName.ToString();

                // Se dispara el evento RowCommand en el ordenamient
                if (strCommand == "Sort") { return; }

                // Fila
                iRow = Int32.Parse(e.CommandArgument.ToString());

                // Datakeys
                idExpediente = this.gvApps.DataKeys[iRow]["ExpedienteId"].ToString();

                // Acción
                switch (strCommand)
                {
                    case "Detalle":
                        Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeDetalleExpedienteVisitador.aspx?expId=" + idExpediente);
                        break;

                    case "Asignar":
                        Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeDetalleExpedienteVisitador.aspx?expId=" + idExpediente);
                        break;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.gvApps.ClientID + "');", true);
                return;
            }
        }

        protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            String ExpedienteId = "";
            String FuncionarioId = "";
            String EstatusId = "";
            String CiudadanoId = "";

            try
            {

                // Validación de que sea fila
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }


                // Datakeys
                ExpedienteId = this.gvApps.DataKeys[e.Row.RowIndex]["ExpedienteId"].ToString();
                FuncionarioId = this.gvApps.DataKeys[e.Row.RowIndex]["FuncionarioId"].ToString();
                EstatusId = this.gvApps.DataKeys[e.Row.RowIndex]["EstatusId"].ToString();
                CiudadanoId = this.gvApps.DataKeys[e.Row.RowIndex]["CiudadanoId"].ToString();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.gvApps.ClientID + "');", true);
            }

        }


    }
}