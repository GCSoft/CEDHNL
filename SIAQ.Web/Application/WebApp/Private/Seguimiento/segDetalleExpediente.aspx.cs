/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	segBusquedaExpediente
' Autor:	Ruben.Cobos
' Fecha:	02-Junio-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segDetalleExpediente : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador


		void SelectedExpediente() {
			BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			// Parámetros
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value );

			// Transacción
			BPSeguimientoRecomendacion.SelectExpediente_DetalleSeguimientos();

			// Errores
			if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

			// Warnings
			if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count == 0){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('No se encontraron expedientes', 'Warning', false);", true);
			}

			// Descargar unformación en formulario

		}

		void SetPermisosGenerales(Int32 idRol) {
			try
            {

				// Permisos por rol
				switch (idRol){

					case 1:	// System Administrator
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.NotificacionesPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.CerrarExpedientePanel.Visible = true;
						this.ConfirmarCierreExpedientePanel.Visible = true;
						break;

					case 2:	// Administrador
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.NotificacionesPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.CerrarExpedientePanel.Visible = true;
						this.ConfirmarCierreExpedientePanel.Visible = true;
						break;

					case 10:	// Seguimiento - Secretaria
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.NotificacionesPanel.Visible = false;
						this.DiligenciaPanel.Visible = false;
						this.CerrarExpedientePanel.Visible = false;
						this.ConfirmarCierreExpedientePanel.Visible = false;
						break;

					case 11:	// Seguimiento - Defensor
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = false;
						this.SeguimientoPanel.Visible = true;
						this.NotificacionesPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.CerrarExpedientePanel.Visible = true;
						this.ConfirmarCierreExpedientePanel.Visible = false;
						break;

					case 12:	// Seguimiento - Director
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.NotificacionesPanel.Visible = false;
						this.DiligenciaPanel.Visible = false;
						this.CerrarExpedientePanel.Visible = false;
						this.ConfirmarCierreExpedientePanel.Visible = true;
						break;

					default:
						this.InformacionPanel.Visible = false;
						this.AsignarPanel.Visible = false;
						this.SeguimientoPanel.Visible = false;
						this.NotificacionesPanel.Visible = false;
						this.DiligenciaPanel.Visible = false;
						this.CerrarExpedientePanel.Visible = false;
						this.ConfirmarCierreExpedientePanel.Visible = false;
						break;

				}
	

            }catch (Exception ex){
				throw(ex);
            }
		}

		void SetPermisosParticulares(Int32 idRol, Int32 idUsuario) {
			try
            {

				// Si es Defensor pero el expediente no está asignado a él no lo podrá operar
				if (idRol == 11 && Int32.Parse(this.FuncionarioIdHidden.Value) != idUsuario) {
					this.SeguimientoPanel.Visible = false;
					this.NotificacionesPanel.Visible = false;
					this.DiligenciaPanel.Visible = false;
					this.CerrarExpedientePanel.Visible = false;
				}

				// Si es Director y el expediente no está en estatus de confirmación de cierre ocultar dicha opción
				if (idRol == 12 && Int32.Parse(this.EstatusIdHidden.Value) != 8) {
					this.ConfirmarCierreExpedientePanel.Visible = false;
				}
	

            }catch (Exception ex){
				throw(ex);
            }
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			ENTSession SessionEntity = new ENTSession();

			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.ExpedienteIdHidden.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				switch (this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1]) {
					case "1": // Invocado desde [Listado de Expedientes]
						this.Sender.Value = "segListadoExpediente.aspx";
						break;

					case "2": // Invocado desde [Búsqueda de Expedientes]
						this.Sender.Value = "segBusquedaExpediente.aspx";
						break;

					case "3": // Invocado desde [Listado de Expedientes pendientes por aprobar su cierre]
						this.Sender.Value = "segListadoExpedienteAprobacion.aspx";
						break;

					default:
						this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
						return;
				}

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				// Consultar detalle de expediente
				SelectedExpediente();

				// Seguridad
				SetPermisosGenerales(SessionEntity.idRol);
				SetPermisosParticulares(SessionEntity.idRol, SessionEntity.idUsuario);


            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
		}


		// Opciones de Menu

		protected void AsignarButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void CerrarExpedienteButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void ConfirmarCierreExpedienteButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void DiligenciasButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void InformacionGeneralButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void NotificacionesButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

		protected void SeguimientoButton_Click(object sender, ImageClickEventArgs e){
			//Response.Redirect("/Application/WebApp/Private/Visitaduria/visDetalleExpediente.aspx?s=" + this.ExpedienteIdHidden.Value.ToString());
		}

	}
}