/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueEnviarSolicitud
' Autor:	Ruben.Cobos
' Fecha:	17-Julio-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueEnviarSolicitud : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador

		void EnviarSolicitud(){
			BPQueja oBPQueja = new BPQueja();
			ENTResponse oENTResponse = new ENTResponse();
			ENTQueja oENTQueja = new ENTQueja();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.EstatusId = 4; // Pendiente de aprobar Queja

				//Transacción
				oENTResponse = oBPQueja.UpdateSolicitudEstatus(oENTQueja);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectSolicitud(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);

				// Transacción
				oENTResponse = oBPQueja.SelectSolicitud_Detalle(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Formulario
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Afectado"].ToString();

				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();
				this.ProblematicaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaNombre"].ToString();
				this.ProblematicaDetalleLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SetCheckList(){
			BPSolicitud oBPSolicitud = new BPSolicitud();

			try
			{

				// Formulario
				oBPSolicitud.SolicitudEntity.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);

				// Transacción
				oBPSolicitud.ValidarEnviarSolicitud();

				// Validaciones generales en la consulta
				if (oBPSolicitud.ErrorId != 0) { throw (new Exception(oBPSolicitud.ErrorDescription)); }
				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows.Count == 0) { throw new Exception("No se ha encontrado información de la solicitud"); }

				// Establecer imágenes a mostrar
				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Ciudadanos"].ToString() == "0"){
					this.imgCiudadanos.ImageUrl = "~/Include/Image/Icon/CiudadanoIcon_Pending.png";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["CalificacionId"].ToString() == "1" ){
					this.imgCalificar.ImageUrl = "~/Include/Image/Icon/CalificarIcon_Pending.png";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["CalificacionId"].ToString() != "2"){
					this.AutoridadPanel.Visible = false;
					return;
				}

				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Autoridades"].ToString() == "0"){
					this.imgAutoridad.ImageUrl = "~/Include/Image/Icon/AutoridadIcon_Pending.png";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Autoridades"].ToString() != oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["AutoridadesConVoces"].ToString()){
					this.imgAutoridad.ImageUrl = "~/Include/Image/Icon/AutoridadIcon_Pending.png";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

			}catch (Exception ex){
				this.btnEnviar.Enabled = false;
				this.btnEnviar.CssClass = "Button_General_Disabled";
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

				// Obtener SolicitudId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Carátula
				SelectSolicitud();

				// CheckList
				SetCheckList();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
		}

		protected void btnEnviar_Click(object sender, EventArgs e){
			try
			{

				// Envío de la solicitud al director
				EnviarSolicitud();

				// Regresar a la pantalla de detalle de solicitudes
				Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "','Fail',true);", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

	}
}