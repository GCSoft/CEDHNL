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
    public partial class opeDetalleExpedienteVisitador : System.Web.UI.Page
    {
        
        // Funciones del programador
        private void selectExpedienteDetalle(int ExpedienteId)
        {
            BPExpediente oBPExpediente = new BPExpediente();
            ENTExpediente oENTExpediente = new ENTExpediente();
            ENTResponse oENTResponse = new ENTResponse();

            try { 
            
                // Datos para consulta
                oENTExpediente.ExpedienteId = ExpedienteId;

                // Transacción
                oENTResponse = oBPExpediente.searchExpedienteDetalle(oENTExpediente);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException)
                { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true);", true); }

                // Mensaje de base de datos
                if (oENTResponse.sMessage != "")
                { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Fail', true);", true);
                    this.gvCiudadano.DataSource = null;
                    this.gvCiudadano.DataBind();

                    this.gvAutoridades.DataSource = null;
                    this.gvAutoridades.DataBind();
                    return; 
                }

                // Llenado de controles
                this.lbNumeroSolictud.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Numero"].ToString();
                this.txtCalificacion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Calificacion"].ToString();
                this.txtEstatus.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Estatus"].ToString();
                this.txtFuncionario.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreFuncionario"].ToString();
                this.txtTipoSolicitud.Text= oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitud"].ToString();
                this.txtObservaciones.Text= oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();
                //this.txtLugarHechos.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechos"].ToString();
                this.txtDireccionHechos.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
                this.txtFechaResepcion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
                this.txtFechaAsignacion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
                this.txtUltimaModificacion.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["UltimaModificacion"].ToString();

                this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[2];
                this.gvCiudadano.DataBind();

                this.gvAutoridades.DataSource = null;
                this.gvAutoridades.DataBind();

            }
            catch (Exception ex) {

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true); 
                return;
            }
        }

        //Eventos de la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack) { return; }

            selectExpedienteDetalle(int.Parse(Request.QueryString["id"]));
        }

        protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;

            String CiudadanoId = "";

            try
            {

                // Validación de que sea fila
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");



                // Datakeys
                CiudadanoId = this.gvCiudadano.DataKeys[e.Row.RowIndex]["Ciudadanoid"].ToString();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtCalificacion.ClientID + "');", true);
            }
        }

        

        
    }
}