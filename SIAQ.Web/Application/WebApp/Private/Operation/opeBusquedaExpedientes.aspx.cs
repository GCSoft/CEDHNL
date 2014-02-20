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
    public partial class opeBusquedaExpedientes : System.Web.UI.Page
    {
        // Rutinas del programador
        private void selectExpediente(int Tipo)
        {
            BPExpediente oBPExpediente = new BPExpediente();
            ENTExpediente oENTExpediente = new ENTExpediente();
            ENTResponse oENTResponse = new ENTResponse();

            try { 
                
                // Formulario
                oENTExpediente.Numero = this.txtNumeroExpediente.Text.Trim();
                oENTExpediente.Ciudadano = this.txtQuejoso.Text.Trim();
                oENTExpediente.MedioComunicacionId = Int32.Parse(this.ddlFormaContacto.SelectedValue);
                oENTExpediente.FuncionarioId = Int32.Parse(this.ddlVisitador.SelectedValue);

                // Transacción 
                oENTResponse = oBPExpediente.searchExpediente(oENTExpediente);

                // Validacion de error en consulta
                if (oENTResponse.GeneratesException) 
                { 
                    ScriptManager.RegisterStartupScript(this.Page,this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
                    return;
                }

                // Validación mendaje de base de datos
                if (oENTResponse.sMessage != "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
                    this.gvApps.DataSource = null;
                    this.gvApps.DataBind();
                    return;
                }


                // Llenado de controles
                if (Tipo == 0)
                {
                    this.gvApps.DataSource = oENTResponse.dsResponse.Tables[1];
                    this.gvApps.DataBind();
                }
                else
                {
                    this.gvApps.DataSource = oENTResponse.dsResponse.Tables[2];
                    this.gvApps.DataBind();
                }
                

            }
            catch(Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
            }

        }
        
        private void selectMediosContacto()
        {

            BPMedioComunicacion oBPMedioComunicacion = new BPMedioComunicacion();
            ENTMedioComunicacion oENTMedioComunicacion = new ENTMedioComunicacion();
            ENTResponse oENTResponse = new ENTResponse();

            // Transacción
            try
            {

                oENTResponse = oBPMedioComunicacion.searchcatMedioComunicacion(oENTMedioComunicacion);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
                    return;
                }

                // Validación mensaje base de datos
                if (oENTResponse.sMessage != "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
                    return;
                }

                // Llenado de controles
                this.ddlFormaContacto.DataTextField = "Nombre";
                this.ddlFormaContacto.DataValueField = "MedioComunicacionId";
                this.ddlFormaContacto.DataSource = oENTResponse.dsResponse.Tables[1];
                this.ddlFormaContacto.DataBind();

                this.ddlFormaContacto.Items.Insert(0,new ListItem("--Seleccionar--","0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
            }
        }

        private void selectVisitador()
        {
            BPFuncionario oBPFuncionario = new BPFuncionario();
            ENTFuncionario oENTFuncionario = new ENTFuncionario();
            ENTResponse oENTResponse = new ENTResponse();

            // transacción
            try { 
            
                oENTResponse= oBPFuncionario.searchFuncionario(oENTFuncionario);

                // Validación de error en consulta
                if( oENTResponse.GeneratesException)
                {
                    ScriptManager.RegisterStartupScript(this.Page,this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
                    return;
                }

                // Validación mensaje base de datos
                if(oENTResponse.sMessage !="")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
                    
                }

                // LLenado de Controles
                this.ddlVisitador.DataTextField = "Nombre";
                this.ddlVisitador.DataValueField = "FuncionarioId";
                this.ddlVisitador.DataSource = oENTResponse.dsResponse.Tables[1];
                this.ddlVisitador.DataBind();

                this.ddlVisitador.Items.Insert(0, new ListItem("--Seleccionar--", "0"));

            }
            catch(Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
               
            }
        }

        // Eventos de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack) { return; }

            try {
                
                selectMediosContacto();
                selectVisitador();
                selectExpediente(0);
            }
            catch (Exception ex)
            { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true); }
        }

        protected void gvApps_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ImageButton imgEdit = null;
            

            String ExpedienteId = "";
            String FuncionarioId = "";
            String EstatusId = "";
            String CiudadanoId = "";

            try { 
            
                // Validación de que sea fila
                if(e.Row.RowType != DataControlRowType.DataRow){ return; }

                // Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
                
                

                // Datakeys
                ExpedienteId = this.gvApps.DataKeys[e.Row.RowIndex]["ExpedienteId"].ToString();
                FuncionarioId = this.gvApps.DataKeys[e.Row.RowIndex]["FuncionarioId"].ToString();
                EstatusId= this.gvApps.DataKeys[e.Row.RowIndex]["EstatusId"].ToString();
                CiudadanoId= this.gvApps.DataKeys[e.Row.RowIndex]["CiudadanoId"].ToString();

            }
            catch(Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
            }
             
        }

        protected void gvApps_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String idExpediente = "";
            String strCommand = "";
            Int32 iRow = 0;

            try {

                // Opción seleccionada
                strCommand = e.CommandName.ToString();

                // Se dispara el evento RowCommand en el ordenamient
                if (strCommand == "Sort") { return; }

                // Fila
                iRow = Int32.Parse(e.CommandArgument.ToString());

                // Datakeys
                idExpediente = this.gvApps.DataKeys[iRow]["ExpedienteId"].ToString();

                // Acción
                switch (strCommand) { 
                    case "Detalle":
                        Response.Redirect("opeDetalleExpedienteVisitador.aspx?id=" + idExpediente);
                        break;

                    case "Editar":
                        Response.Redirect("opeDetalleExpedienteVisitador.aspx?id=" + idExpediente);
                        break;
                
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNumeroExpediente.ClientID + "');", true);
                return;
            }

        }

    }
}