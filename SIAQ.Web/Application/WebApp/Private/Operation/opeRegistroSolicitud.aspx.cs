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
using GCSoft.Utilities.Common;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
   public partial class opeRegistroSolicitud : System.Web.UI.Page
   {

      // Utilerías
      Function utilFunction = new Function();
       
       // Variables publicas
       string AllDefault = "[Seleccione]";
       
      
      // Rutinas del programador

       private void Clear(){
           this.ddlAbogado.SelectedValue = "0";
           wucBusquedaCiudadano.Text = "";
           this.txtObservaciones.Text = "";
           this.wucFixedDateTime.SetDateTime();
       }

       private void selectFuncionario()
       {
           BPFuncionario oBPFuncionario = new BPFuncionario();
           ENTFuncionario oENTFuncionario = new ENTFuncionario();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

               // Transacción
               oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

               // Validación de error en la consulta
               if (oENTResponse.GeneratesException)
               {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true);", true);
                   return;
               }

               // Mensaje de la base de datos
               if (oENTResponse.sMessage != "")
               {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true);", true);

               }

               //LLenado de control
               this.ddlAbogado.DataTextField = "sFullName";
               this.ddlAbogado.DataValueField = "FuncionarioId";
               this.ddlAbogado.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlAbogado.DataBind();

               // Agregar Item de selección
               this.ddlAbogado.Items.Insert(0, new ListItem(AllDefault, "0"));

           }
           catch (Exception ex)
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true);
           }

       }

      private void insertSolicitud(){
         BPSolicitud oBPSolicitud = new BPSolicitud();
         ENTResponse oENTResponse = new ENTResponse();
         ENTSolicitud oENTSolicitud = new ENTSolicitud();

         String sFolio = "";

         try{
               
            // Validación cambio de nombre
            if (wucBusquedaCiudadano.Text != wucBusquedaCiudadano.NombreCiud) { wucBusquedaCiudadano.CiudadanoID = 0; }

            // Formulario
            oENTSolicitud.FuncionarioId = Int32.Parse(this.ddlAbogado.SelectedValue);
            oENTSolicitud.CalificacionId = 1;
            oENTSolicitud.TipoSolicitudId = 1;
            oENTSolicitud.LugarHechosId = 5;
            oENTSolicitud.EstatusId = 1;
            oENTSolicitud.CiudadanoId = wucBusquedaCiudadano.CiudadanoID;
            oENTSolicitud.Nombre = wucBusquedaCiudadano.Text;
            oENTSolicitud.Fecha = this.wucFixedDateTime.GetDateTime;
            oENTSolicitud.Observaciones = this.txtObservaciones.Text.Trim();

            // Transacción
            oENTResponse = oBPSolicitud.insertSolicitud(oENTSolicitud);

            // Validación de error
            if (oENTResponse.GeneratesException){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sErrorMessage) + "', 'Fail', true);;", true);
               return;
            }

            if (oENTResponse.sMessage != ""){
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Success', true);", true);
               return;
            }

            // Obtener el folio generado
            sFolio = oENTResponse.dsResponse.Tables[1].Rows[0]["Folio"].ToString();

            // Se limpia el formulario
            Clear();

            // Mensaje de Exito
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Se registro la solicitud exitosamente con folio: " + sFolio + "', 'Success', true);", true);

         }catch (Exception ex){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true);
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
           try
           {

               // Llenado de controles
               selectFuncionario();

               // Se agrega atributo para validación de controles
               this.btnGuardar.Attributes.Add("OnClick", "javascript: return validateForm();");

              // Foco
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.wucBusquedaCiudadano.CanvasID + "');", true);

           }
           catch (Exception ex)
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true);
           }


       }

       protected void btnGuardar_Click(object sender, EventArgs e)
       {
           insertSolicitud();
       }

       protected void btnRegresar_Click(object sender, EventArgs e)
       {
           Response.Redirect("opeInicio.aspx");
       }

       protected void wucBusquedaCiudadano_ItemSelected(){
          try
          {

             // Foco
             ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlAbogado.ClientID + "');", true);

          }catch (Exception ex){
             ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.wucBusquedaCiudadano.CanvasID + "');", true);
          }
       }
   
   }
}