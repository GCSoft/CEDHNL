// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
	public partial class opeRegistroSolicitud : BPPage
   {

		// Utilerías
		Function utilFunction = new Function();
       
      
		// Rutinas del programador

		void Clear(){
			this.wucFixedDateTime.SetDateTime();
			this.wucBusquedaCiudadano.Text = "";
			this.ddlAbogado.SelectedValue = "0";
			this.ckeObservaciones.Text = "";
		}

		void SelectCiudadanoByID(String CiudadanoId){
			BPCiudadano BPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

				// Formulario
				oENTCiudadano.CiudadanoId = Int32.Parse(CiudadanoId);

				// Transacción
				oENTResponse = BPCiudadano.SelectCiudadano_ByID(oENTCiudadano);

				// Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Cargar el WUC de Búsqueda de ciudadano
				this.wucBusquedaCiudadano.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreCompleto"].ToString();
				this.wucBusquedaCiudadano.NombreCiud = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreCompleto"].ToString();
				this.wucBusquedaCiudadano.CiudadanoID = Int32.Parse( oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadanoId"].ToString());

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectFuncionario(){
			BPFuncionario oBPFuncionario = new BPFuncionario();
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Transacción
				oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				// Validación de error en la consulta
				if (oENTResponse.GeneratesException){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sErrorMessage + "', 'Fail', true);", true);
					return;
				}

				// Mensaje de la base de datos
				if (oENTResponse.sMessage != ""){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Success', true);", true);
				}

				//LLenado de control
				this.ddlAbogado.DataTextField = "sFullName";
				this.ddlAbogado.DataValueField = "FuncionarioId";
				this.ddlAbogado.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlAbogado.DataBind();

				// Agregar Item de selección
				this.ddlAbogado.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw(ex);
			}
		}

		void InsertSolicitud(){
			BPSolicitud oBPSolicitud = new BPSolicitud();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSolicitud oENTSolicitud = new ENTSolicitud();

			String sFolio = "";

			try{

				// Validaciones
				if (this.wucBusquedaCiudadano.Text.Trim() == "") { throw new Exception("El campo [Nombre del ciudadano] es requerido"); }
				if (this.ckeObservaciones.Text.Trim() == "") { throw new Exception("El campo [Observaciones] es requerido"); }
               
				// Validación cambio de nombre
				if (this.wucBusquedaCiudadano.Text != this.wucBusquedaCiudadano.NombreCiud) { this.wucBusquedaCiudadano.CiudadanoID = 0; }

				// Formulario
				oENTSolicitud.FuncionarioId = Int32.Parse(this.ddlAbogado.SelectedValue);
				oENTSolicitud.CalificacionId = 1;	// Sin calificar
				oENTSolicitud.TipoSolicitudId = 1;	// Individual
				oENTSolicitud.LugarHechosId = 5;	// Otro
				oENTSolicitud.EstatusId = (this.ddlAbogado.SelectedValue == "0" ? 1 : 2);	// Por Asignar o Por Atender
				oENTSolicitud.CiudadanoId = this.wucBusquedaCiudadano.CiudadanoID;
				oENTSolicitud.NombreTemporal = this.wucBusquedaCiudadano.Text.Trim();
				oENTSolicitud.Observaciones = this.ckeObservaciones.Text.Trim();

				// Transacción
				oENTResponse = oBPSolicitud.InsertSolicitud(oENTSolicitud);

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

				// Mensaje de Exito
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Se registro la solicitud exitosamente para el ciudadano [" + this.wucBusquedaCiudadano.Text.Trim() + "] con folio: " + sFolio + "', 'Success', true);", true);

				// Se limpia el formulario
				Clear();

			}catch (Exception ex){
				throw(ex);
			}
		}

       
		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String CiudadanoId = "";

			try
			{

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener CiudadanoId
				CiudadanoId = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				switch (this.SenderId.Value){
					case "0": // Invocado desde [Menú]
						this.Sender.Value = "opeInicio.aspx";
						break;

					case "1": // Invocado desde [Recepción]
						this.Sender.Value = "opeInicio.aspx";
						break;

					case "2": // Invocado desde [Buscar ciudadano]
						this.Sender.Value = "opeBusquedaCiudadano.aspx";
						break;

					default:
						this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
						return;
				}

				// Llenado de controles
				SelectFuncionario();
				if (CiudadanoId != "0") { SelectCiudadanoByID(CiudadanoId); }

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + (CiudadanoId == "0" ? this.wucBusquedaCiudadano.CanvasID : this.ddlAbogado.ClientID) + "');", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); focusControl('" + this.wucBusquedaCiudadano.CanvasID + "');", true);
			}
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
			{

				// Transacción
				InsertSolicitud();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.wucBusquedaCiudadano.CanvasID + "');", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
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