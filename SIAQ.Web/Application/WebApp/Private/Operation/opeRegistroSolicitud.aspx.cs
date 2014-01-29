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
   public partial class opeRegistroSolicitud : System.Web.UI.Page
   {
       // Rutinas del programador
       private void selectTipoSolicitud()
       {
           BPTipoSolicitud oBPTipoSolicitud = new BPTipoSolicitud();
           ENTTipoSolicitud oENTTipoSolicitud = new ENTTipoSolicitud();
           ENTResponse oENTResponse = new ENTResponse();

           try { 
                
               // Transacción
               oENTResponse = oBPTipoSolicitud.searchcatTipoSolicitud(oENTTipoSolicitud);

               // Validación de error en la consulta
               if (oENTResponse.GeneratesException) {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
               }

               // Mensaje de la base de datos
               if(oENTResponse.sMessage!=""){
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true); focusControl('" + this.txtNombre.ClientID + "');", true);
               }

               //LLenado de control
               this.ddlTipoSolicitud.DataTextField = "TipoSolicitudId";
               this.ddlTipoSolicitud.DataValueField = "Nombre";
               this.ddlTipoSolicitud.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlTipoSolicitud.DataBind();

               // Agregar Item de selección
               this.ddlTipoSolicitud.Items.Insert(0, new ListItem("--Seleccionar--", "0"));


           }
           catch (Exception ex) {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
           }

       }

       // Eventos de la página
       protected void Page_Load(object sender, EventArgs e)
       {
           // Validación. Solo la primera vez que se ejecuta la página
           if (this.IsPostBack)
           {
               return;
           }

           // Lógica de la página
           try {

               // Llenado de controles
               selectTipoSolicitud();
           }
           catch (Exception ex) {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.txtNombre.ClientID + "');", true);
           }


       }

   }
}