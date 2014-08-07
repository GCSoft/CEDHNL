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
using GCUtility.Function;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Archivo
{
	public partial class arcAsignarExpediente : System.Web.UI.Page
	{
		
		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		void InsertArchivoExpediente() {
			BPArchivoExpediente oBPArchivoExpediente = new BPArchivoExpediente();

			ENTArchivoExpediente oENTArchivoExpediente = new ENTArchivoExpediente();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			Int32 UbicacionExpedienteId;

			try
			{

				// Ubicación seleccionada
				UbicacionExpedienteId = Int32.Parse(this.ddlUbicacionExpediente.SelectedItem.Value);

				// Validaciones
				if (UbicacionExpedienteId == 0) { throw (new Exception("Es necesario seleccionar una Ubicación del Expediente")); }

				if (UbicacionExpedienteId == 4) {
					if (this.ddlUsuario_Recibe.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Tipo de Seguimiento")); }
				}

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];
				
				// Formulario
				oENTArchivoExpediente.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value);
				oENTArchivoExpediente.UbicacionExpedienteId = UbicacionExpedienteId;
				oENTArchivoExpediente.idUsuario_Presta = SessionEntity.idUsuario;
				oENTArchivoExpediente.idUsuario_Recibe = Int32.Parse(this.ddlUsuario_Recibe.SelectedItem.Value);
				oENTArchivoExpediente.Comentario = this.ckeComentarios.Text.Trim();

				// Transacción
				oENTResponse = oBPArchivoExpediente.InsertArchivoExpediente(oENTArchivoExpediente);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }	

			}catch (Exception ex){
				throw (ex);
			}
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
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', false);", true); }

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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlUbicacionExpediente.ClientID + "');", true);
            }
		}

		protected void btnAsignar_Click(object sender, EventArgs e){
			try
            {

                // Crear la asignación
				InsertArchivoExpediente();

				// Regresar
				Response.Redirect("arcDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlUbicacionExpediente.ClientID + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("arcDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);
		}

		protected void ddlUbicacionExpediente_SelectedIndexChanged(object sender, EventArgs e){
			try
            {

                // Determinar la opción seleccionada
				switch (this.ddlUbicacionExpediente.SelectedItem.Value) { 
					case "1":
					case "2":
					case "3":
						this.ddlUsuario_Recibe.SelectedIndex = 0;
						this.ddlUsuario_Recibe.Enabled = false;
						this.ckeComentarios.Focus();
						break;
					default:
						this.ddlUsuario_Recibe.Enabled = true;
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlUsuario_Recibe.ClientID + "');", true);
						break;
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlUbicacionExpediente.ClientID + "');", true);
            }
		}

	}
}