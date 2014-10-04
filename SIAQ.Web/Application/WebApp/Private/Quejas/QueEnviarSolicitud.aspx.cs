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
using GCUtility.Function;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueEnviarSolicitud : System.Web.UI.Page
	{

		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();


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
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();

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

				// Atención a victimas (No impide el envío)
				switch( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["AtencionVictimas"].ToString() ){
					case"0":

						this.AtencionPanel.Visible = false;
						break;

					case "1":

						this.imgAtencion.ImageUrl = "~/Include/Image/Icon/AtencionVictimasIcon_Warning.png";
						this.imgAtencion.ToolTip = "Existen atenciones a víctimas asociadas a la solicitud sin cerrar";
						break;

					default:
						// Do Nothing
						break;
				}

				// Validación de ciudadanos
				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Ciudadanos"].ToString() == "0"){
					this.imgCiudadanos.ImageUrl = "~/Include/Image/Icon/CiudadanoIcon_Pending.png";
					this.imgCiudadanos.ToolTip = "No se han capturado ciudadanos en la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["CiudadanosEdadCero"].ToString() != "0"){
					this.imgCiudadanos.ImageUrl = "~/Include/Image/Icon/CiudadanoIcon_Pending.png";
					this.imgCiudadanos.ToolTip = "Existen ciudadanos con edad cero asociados a la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				// Validación de Diligencias
				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["DiligenciasBandera"].ToString() == "0"){

					this.DiligenciasPanel.Visible = false;
				}else{

					if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Diligencias"].ToString() == "0"){
						this.imgDiligencias.ImageUrl = "~/Include/Image/Icon/DiligenciaIcon_Pending.png";
						this.imgDiligencias.ToolTip = "No se han capturado diligencias en la solicitud";
						this.btnEnviar.Enabled = false;
						this.btnEnviar.CssClass = "Button_General_Disabled";
					}

				}

				// Grupos Minoritarios
				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["GruposMinoritarios"].ToString() == "0"){
					this.imgIndicador.ImageUrl = "~/Include/Image/Icon/IndicadorIcon_Pending.png";
					this.imgIndicador.ToolTip = "No se han capturado grupos minoritarios en la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				// Calificar solicitud 
				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["CalificacionId"].ToString() == "0" || oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["CalificacionId"].ToString() == "1" ){
					this.imgCalificar.ImageUrl = "~/Include/Image/Icon/CalificarIcon_Pending.png";
					this.imgCalificar.ToolTip = "No se ha calificado la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["FormaContactoId"].ToString() == "0" ){
					this.imgCalificar.ImageUrl = "~/Include/Image/Icon/CalificarIcon_Pending.png";
					this.imgCalificar.ToolTip = "No se ha establecido una Forma de Contacto la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["LugarHechosId"].ToString() == "0" ){
					this.imgCalificar.ImageUrl = "~/Include/Image/Icon/CalificarIcon_Pending.png";
					this.imgCalificar.ToolTip = "No se ha establecido el Lugar de los Hechos la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["MecanismoAperturaId"].ToString() == "0" ){
					this.imgCalificar.ImageUrl = "~/Include/Image/Icon/CalificarIcon_Pending.png";
					this.imgCalificar.ToolTip = "No se ha establecido un Mecanismo de Apertura la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["NivelAutoridadId"].ToString() == "0" ){
					this.imgCalificar.ImageUrl = "~/Include/Image/Icon/CalificarIcon_Pending.png";
					this.imgCalificar.ToolTip = "No se ha establecido el Nivel de Autoridad la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["ProblematicaId"].ToString() == "0" ){
					this.imgCalificar.ImageUrl = "~/Include/Image/Icon/CalificarIcon_Pending.png";
					this.imgCalificar.ToolTip = "No se ha establecido la problemática de la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["ProblematicaDetalleId"].ToString() == "0" ){
					this.imgCalificar.ImageUrl = "~/Include/Image/Icon/CalificarIcon_Pending.png";
					this.imgCalificar.ToolTip = "No se ha establecido el detalle de la problemática de la solicitud";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				// Asuntos
				this.lblAsuntos.Text = "Asuntos capturados: " + oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Asuntos"].ToString(); 
				if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Asuntos"].ToString() == "0"){
					this.lblAsuntos.CssClass = "Asunto_Pending";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				// Autoridades señaladas y voces
				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["CalificacionId"].ToString() != "2" && oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["CalificacionId"].ToString() != "8" ){
					this.AutoridadPanel.Visible = false;
					return;
				}

				// Calificación de Queja
				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["CalificacionId"].ToString() == "2" ){

					if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Autoridades"].ToString() == "0"){
						this.imgAutoridad.ImageUrl = "~/Include/Image/Icon/AutoridadIcon_Pending.png";
						this.imgAutoridad.ToolTip = "No se ha capturado Autoridades en la solicitud";
						this.btnEnviar.Enabled = false;
						this.btnEnviar.CssClass = "Button_General_Disabled";
					}

					if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Autoridades"].ToString() != oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["AutoridadesConVoces"].ToString()){
						this.imgAutoridad.ImageUrl = "~/Include/Image/Icon/AutoridadIcon_Pending.png";
						this.imgAutoridad.ToolTip = "Existe por lo menos una autoridad sin captura de voces en la Solictud";
						this.btnEnviar.Enabled = false;
						this.btnEnviar.CssClass = "Button_General_Disabled";
					}

				}

				// Calificación de Medidas Cautelares
				if ( oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["CalificacionId"].ToString() == "8" ){

					if (oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Autoridades"].ToString() == "0"){
						this.imgAutoridad.ImageUrl = "~/Include/Image/Icon/AutoridadIcon_Pending.png";
						this.imgAutoridad.ToolTip = "No se ha capturado Autoridades en la solicitud";
						this.btnEnviar.Enabled = false;
						this.btnEnviar.CssClass = "Button_General_Disabled";
					}
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
				this.btnEnviar.Enabled = false;
				this.btnEnviar.CssClass = "Button_General_Disabled";
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "','Fail',true);", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

	}
}