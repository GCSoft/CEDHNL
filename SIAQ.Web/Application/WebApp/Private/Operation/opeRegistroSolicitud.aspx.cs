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
       private void Clear()
       {

           this.ddlAbogado.SelectedValue = "0";
           wucBusquedaCiudadano1.Text = "";
           this.txtObservaciones.Text = "";
           this.txtFechaCargado.Tiempo.Insert(0, "00:00");
       }

       private void selectFuncionario()
       {
           BPFuncionario oBPFuncionario = new BPFuncionario();
           ENTFuncionario oENTFuncionario = new ENTFuncionario();
           ENTResponse oENTResponse = new ENTResponse();

           try
           {

               // Transacción
               oENTResponse = oBPFuncionario.searchFuncionario(oENTFuncionario);

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
               this.ddlAbogado.DataTextField = "Nombre";
               this.ddlAbogado.DataValueField = "FuncionarioId";
               this.ddlAbogado.DataSource = oENTResponse.dsResponse.Tables[1];
               this.ddlAbogado.DataBind();

               // Agregar Item de selección
               this.ddlAbogado.Items.Insert(0, new ListItem("--Seleccionar--", "0"));


           }
           catch (Exception ex)
           {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true);", true);
           }

       }

       private void insertSolicitud()
       {
           BPSolicitud oBPSolicitud = new BPSolicitud();
           ENTResponse oENTResponse = new ENTResponse();
           ENTSolicitud oENTSolicitud = new ENTSolicitud();

           try
           {
               // Validación cambio de nombre
               if (wucBusquedaCiudadano1.Text != wucBusquedaCiudadano1.NombreCiud)
               {
                   wucBusquedaCiudadano1.CiudadanoID = 0;
               }

               // Formulario
               oENTSolicitud.FuncinarioId = Int32.Parse(this.ddlAbogado.SelectedValue);
               oENTSolicitud.CalificacionId = 1;
               oENTSolicitud.TipoSolicitudId = 1;
               oENTSolicitud.LugarHechosId = 5;
               oENTSolicitud.EstatusId = 1;
               oENTSolicitud.CiudadanoId = wucBusquedaCiudadano1.CiudadanoID;
               oENTSolicitud.Nombre = wucBusquedaCiudadano1.Text;
               oENTSolicitud.Fecha = this.txtFechaCaptura.EndDate;
               oENTSolicitud.Observaciones = this.txtObservaciones.Text.Trim();

               // Transacción
               oENTResponse = oBPSolicitud.insertSolicitud(oENTSolicitud);

               // Validación de error
               if (oENTResponse.GeneratesException)
               {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true);;", true);
                   return;
               }

               if (oENTResponse.sMessage != "")
               {
                   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true);", true);
                   return;
               }

               // Se limpia el formulario
               Clear();

               // Mensaje de Exito
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Se registro la solicitud exitosamente', 'Success', true);", true);

           }
           catch (Exception ex)
           {
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
   }
}