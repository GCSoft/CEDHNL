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


		void SetPermisos() {
			ENTSession SessionEntity = new ENTSession();

			try
            {

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];


				// Permisos por rol
				switch (SessionEntity.idRol){
					case 1:	// System Administrator
						this.InformacionPanel.Visible = true;
						this.AsignarPanel.Visible = true;
						this.SeguimientoPanel.Visible = true;
						this.NotificacionesPanel.Visible = true;
						this.DiligenciaPanel.Visible = true;
						this.CerrarExpedientePanel.Visible = true;
						this.ConfirmarCierreExpedientePanel.Visible = true;
						break;
				}
	

            }catch (Exception ex){
				throw(ex);
            }
		}

		// Solo el defensor al que se le asignó el expediente es quien le puede mover
		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }

				// Obtener ExpedienteId
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", true); }
				this.ExpedienteIdHidden.Value = this.Request.QueryString["key"].ToString();

				// Seguridad
				SetPermisos();

				//// Llenado de controles
				//SelectDefensor();

				//// Estado inicial
				//this.gvExpediente.DataSource = null;
				//this.gvExpediente.DataBind();

				//// Foco
				//ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.txtExpediente.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
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