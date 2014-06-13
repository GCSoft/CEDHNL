/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	arcAsignarExpediente
' Autor:	Ruben.Cobos
' Fecha:	12-Junio-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

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
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Archivo
{
	public partial class arcAsignarExpediente : System.Web.UI.Page
	{
		
		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador

		void InsertSeguimientoRecomendacion() {
			ENTSession SessionEntity = new ENTSession();
			BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			// Validaciones
			if (this.ddlUbicacionExpediente.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar una Recomendación")); }
			if (this.ddlUsuario_Recibe.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Tipo de Seguimiento")); }
			if (this.ckeSeguimiento.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un detalle del seguimiento")); }

			// Obtener sesión
			SessionEntity = (ENTSession)Session["oENTSession"];

			// Parámetros
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.RecomendacionId = Int32.Parse(this.ddlUbicacionExpediente.SelectedItem.Value);
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.TipoSeguimientoId = Int32.Parse(this.ddlUsuario_Recibe.SelectedItem.Value);
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.FuncionarioId = SessionEntity.FuncionarioId;
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.Comentario = this.ckeSeguimiento.Text.Trim();


			// Transacción
			BPSeguimientoRecomendacion.InsertSegSeguimiento();

			// Errores
			if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

		}

		void SelectedExpediente() {
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTArchivoExpediente.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value);

				// Transacción
				oENTResponse = oBPArchivoExpediente.SelectArchivoExpedienteDetalle(oENTArchivoExpediente);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Formulario
				this.ExpedienteNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusArchivoNombre"].ToString();
				this.UsuarioNombreRecibeLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["UsuarioNombreRecibe"].ToString();
				this.UbicacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Ubicacion"].ToString();
				this.ComentariosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Comentarios"].ToString();

				this.FechaPrestamoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaPrestamo"].ToString();

			}catch (Exception ex){
				this.btnAsignar.Visible = false;
				throw (ex);
			}
		}

		void SelectUbicacionExpediente(){
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTArchivoExpediente.UbicacionExpedienteId = 0;
				oENTArchivoExpediente.Nombre = "";

				// Transacción
				oENTResponse = oBPArchivoExpediente.SelectUbicacionExpediente(oENTArchivoExpediente);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Llenado de combo
				this.ddlUbicacionExpediente.DataTextField = "Nombre";
				this.ddlUbicacionExpediente.DataValueField = "UbicacionExpedienteId";
				this.ddlUbicacionExpediente.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlUbicacionExpediente.DataBind();

				// Agregar Item de selección
				this.ddlUbicacionExpediente.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				this.btnAsignar.Visible = false;
				throw (ex);
			}
		}

		void SelectUsuarioRecibe() { 
			ENTUsuario oENTUsuario = new ENTUsuario();
			ENTResponse oENTResponse = new ENTResponse();

			BPUsuario oBPUsuario = new BPUsuario();

			try
			{

				// Formulario
				oENTUsuario.idRol = 0;
				oENTUsuario.idArea = 0;
				oENTUsuario.sEmail = "";
				oENTUsuario.sNombre = "";
				oENTUsuario.tiActivo = 1;

				// Transacción
				oENTResponse = oBPUsuario.SelectUsuario(oENTUsuario);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', true);", true); }

				// Llenado de control
				this.ddlUsuario_Recibe.DataTextField = "sFullName";
				this.ddlUsuario_Recibe.DataValueField = "idUsuario";
				this.ddlUsuario_Recibe.DataSource = oENTResponse.dsResponse.Tables[3];
				this.ddlUsuario_Recibe.DataBind();

				// Opción todos
				this.ddlUsuario_Recibe.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				this.btnAsignar.Visible = false;
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.ExpedienteIdHidden.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Llenado de controles
				SelectedExpediente();
				SelectUbicacionExpediente();
				SelectUsuarioRecibe();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlUbicacionExpediente.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
		}

		protected void btnAsignar_Click(object sender, EventArgs e){
			try
            {

                // Obtener Expedientes
				InsertSeguimientoRecomendacion();

				// Refrescar Formulario
				SelectedExpediente();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlUbicacionExpediente.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlUbicacionExpediente.ClientID + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("arcDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);
		}

		protected void ddlUbicacionExpediente_SelectedIndexChanged(object sender, EventArgs e){

		}

	}
}