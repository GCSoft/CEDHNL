/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	vicEnviarAtencion
' Autor:	Ruben.Cobos
' Fecha:	19-Junio-2014
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
using GCUtility.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segEnviarRecomendacion : System.Web.UI.Page
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();


		// Rutinas del programador

		String GetKey(String sKey) {
			String Response = "";

			try{

				Response = gcEncryption.DecryptString(sKey, true);

			}catch(Exception){
				Response = "";
			}

			return Response;
		}


		// Funciones el programador

		void EnviarRecomendacion(){
			//BPAtencion oBPAtencion = new BPAtencion();
			//ENTAtencion oENTAtencion = new ENTAtencion();
			//ENTResponse oENTResponse = new ENTResponse();

			//try
			//{

			//    // TODO: Checar en el SP la actualización de la fecha/hora 
			//    // Formulario
			//    oENTAtencion.AtencionId = Int32.Parse(this.hddRecomendacionId.Value);
			//    oENTAtencion.EstatusId = 20; // Pendiente de aprobar atención
			//    oENTAtencion.ModuloId = 5; // Atención a Víctimas

			//    // Transacción
			//    oENTResponse = oBPAtencion.UpdateAtencion_Estatus(oENTAtencion);

			//    // Errores y Warnings
			//    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
			//    if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

			//}catch (Exception ex){
			//    throw (ex);
			//}
		}

		void SelectRecomendacion() {
			BPSeguimiento oBPSeguimiento = new BPSeguimiento();
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);

				// Transacción
				oENTResponse = oBPSeguimiento.SelectRecomendacion_Detalle(oENTSeguimiento);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Encabezado
				this.lblEncabezado.Text = "Envío de " + (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "la recomendación" : "el acuerdo de no responsabilidad");
				this.lblNumero.Text = (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "Recomendación" : "Acuerdo") + " Número";

				// Formulario
				this.RecomendacionNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["RecomendacionNumero"].ToString();
				this.ExpedienteNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();

				this.TipoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusSeguimientoNombre"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.NombreAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreAutoridad"].ToString();
				this.PuestoAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["PuestoAutoridad"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaQuejasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaQuejas"].ToString();
				this.FechaVisitaduriasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaVisitadurias"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.NivelesAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Autoridades"].ToString();
				
			}catch (Exception ex){
				throw (ex);
			}
		}

		void SetCheckList() {
			BPSeguimiento oBPSeguimiento = new BPSeguimiento();
			ENTSeguimiento oENTSeguimiento = new ENTSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTSeguimiento.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);

				// Transacción
				oENTResponse = oBPSeguimiento.SelectRecomendacion_Detalle(oENTSeguimiento);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Enviar a autoridad
				if ( Int32.Parse( oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusSeguimientoId"].ToString() ) < 4 ){
					this.imgEnviarAutoridad.ImageUrl = "~/Include/Image/Icon/NotificacionIcon_Pending.png";
					this.imgEnviarAutoridad.ToolTip = "No se ha enviado el documento a la autoridad";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				// Gestión a puntos resolutivos
				if ( oENTResponse.dsResponse.Tables[1].Rows[0]["Aceptada"].ToString() != "1" || oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() != "0" )
				{
					this.pnlSeguimiento.Visible = false;
				}
				else
				{
					this.imgSeguimiento.ImageUrl = "~/Include/Image/Icon/SeguimientoIcon_Pending.png";
					this.imgSeguimiento.ToolTip = "No se ha finalizado los puntos resolutivos del seguimiento";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				// Impugnar
				if (oENTResponse.dsResponse.Tables[1].Rows[0]["Impugnada"].ToString() == "0" && oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusSeguimientoId"].ToString() != "6")
				{

					this.pnlImpugnar.Visible = false;
				}
				else
				{

					if ( oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusSeguimientoId"].ToString() == "6" ){
						this.imgImpugnar.ImageUrl = "~/Include/Image/Icon/ComparecenciaIcon_Pending.png";
						this.imgImpugnar.ToolTip = "No se ha finalizado el proceso de impugnación";
						this.btnEnviar.Enabled = false;
						this.btnEnviar.CssClass = "Button_General_Disabled";
					}

				}
				
			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String sKey = "";

			try
			{

				// Validaciones de llamada
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Validaciones de parámetros
				sKey = GetKey(this.Request.QueryString["key"].ToString());
				if (sKey == "") { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (sKey.ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener RecomendacionId
				this.hddRecomendacionId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = sKey.Split(new Char[] { '|' })[1];

				// Carátula
				SelectRecomendacion();

				// CheckList
				SetCheckList();

            }catch (Exception ex){
				this.btnEnviar.Enabled = false;
				this.btnEnviar.CssClass = "Button_General_Disabled";
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnEnviar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Envío de la Expediente al director
				EnviarRecomendacion();

				// Regresar a la pantalla del detalle del expediente de atención
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segDetalleRecomendacion.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Llave encriptada
				sKey = this.hddRecomendacionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("segDetalleRecomendacion.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

	}
}