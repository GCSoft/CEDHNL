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
				this.lblEncabezado.Text = "Agregar información " + (oENTResponse.dsResponse.Tables[1].Rows[0]["AcuerdoNoResponsabilidad"].ToString() == "0" ? "a la recomendación" : "al acuerdo de no responsabilidad");

				// Formulario
				this.RecomendacionNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["RecomendacionNumero"].ToString();
				this.ExpedienteNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();

				this.TipoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Tipo"].ToString();
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
			//BPAtencion oBPAtencion = new BPAtencion();
			//ENTAtencion oENTAtencion = new ENTAtencion();
			//ENTResponse oENTResponse = new ENTResponse();

			//try
			//{

			//    // Formulario
			//    oENTAtencion.AtencionId = Int32.Parse(this.hddRecomendacionId.Value);

			//    // Transacción
			//    oENTResponse = oBPAtencion.SelectAtencion_Detalle(oENTAtencion);

			//    // Errores y Warnings
			//    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
			//    if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

			//    // Gestiones
			//    if (oENTResponse.dsResponse.Tables[4].Rows.Count == 0){
			//        this.imgSeguimiento.ImageUrl = "~/Include/Image/Icon/SeguimientoIcon_Pending.png";
			//        this.imgSeguimiento.ToolTip = "No se ha emitido el dictamen del expediente de atención a víctimas";
			//        this.btnEnviar.Enabled = false;
			//        this.btnEnviar.CssClass = "Button_General_Disabled";
			//    }

			//}catch (Exception ex){
			//    throw (ex);
			//}

			this.imgSeguimiento.ImageUrl = "~/Include/Image/Icon/SeguimientoIcon_Pending.png";
			this.imgSeguimiento.ToolTip = "No se ha finalizado los puntos resolutivos del seguimiento";
			this.btnEnviar.Enabled = false;
			this.btnEnviar.CssClass = "Button_General_Disabled";

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