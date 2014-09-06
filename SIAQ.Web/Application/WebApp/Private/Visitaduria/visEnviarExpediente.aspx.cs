/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visEnviarExpediente
' Autor:	Ruben.Cobos
' Fecha:	30-Septiembre-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visEnviarExpediente : System.Web.UI.Page
    {
        
		// Utilerías
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


		// Funciones del programador

		Boolean ValidaVoz(Int32 AutoridadId){
            BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			Boolean Response = true;

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.AutoridadId = AutoridadId;

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpedienteAutoridadVoces(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Validación
				if (oENTResponse.dsResponse.Tables[0].Select("CalificacionAutoridadId=1").Length > 0) { Response = false; }

			}catch (Exception ex){
				throw (ex);
			}

			return Response;
        }


		// Rutinas del programador

		void EnviarExpediente(){
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.EstatusId = 16; // Pendiente de aprobar Visitaduria
				oENTVisitaduria.ModuloId = 3; // Visitadurías

				//Transacción
				oENTResponse = oBPVisitaduria.UpdateExpedienteEstatus(oENTVisitaduria);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectExpediente() {
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpediente_Detalle(oENTVisitaduria);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Campos ocultos
				this.hddExpedienteId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteId"].ToString();

				// Formulario
				this.ExpedienteNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Afectado"].ToString();
				this.AreaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AreaNombre"].ToString();
				this.ResolucionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoResolucionNombre"].ToString();

				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();
				this.ProblematicaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaNombre"].ToString();
				this.ProblematicaDetalleLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaQuejasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaQuejas"].ToString();
				this.FechaVisitaduriasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaVisitadurias"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();

				this.TipoOrientacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoOrientacionNombre"].ToString();
				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();
				this.FundamentoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Fundamento"].ToString();

				// Cierre de Orientación
				if ( oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString() != "3" ){
					this.CierreOrientacionLabel.Visible = false;
					this.TipoOrientacionLabel.Visible = false;
				}

				// Canalizaciones
				if (oENTResponse.dsResponse.Tables[2].Rows.Count > 0){

					this.CanalizacionesLabel.Visible = true;

					this.grdCanalizacion.DataSource = oENTResponse.dsResponse.Tables[2];
					this.grdCanalizacion.DataBind();
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SetCheckList(){
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpediente_Detalle(oENTVisitaduria);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Gestiones
				if (oENTResponse.dsResponse.Tables[12].Rows.Count == 0){
					this.imgGestion.ImageUrl = "~/Include/Image/Icon/SeguimientoIcon_Pending.png";
					this.imgGestion.ToolTip = "No se han capturado gestiones en el Expediente";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				// Comparecencia
				if (oENTResponse.dsResponse.Tables[9].Rows.Count == 0){
					this.imgComparecencia.ImageUrl = "~/Include/Image/Icon/ComparecenciaIcon_Pending.png";
					this.imgComparecencia.ToolTip = "No se han capturado comparecencias en el Expediente";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				// Autoridades y Voces
				if (oENTResponse.dsResponse.Tables[10].Select("CalificacionAutoridadId=1").Length > 0 ){
					this.imgAutoridad.ImageUrl = "~/Include/Image/Icon/AutoridadIcon_Pending.png";
					this.imgAutoridad.ToolTip = "No se han calificado algunas autoridades en el Expediente";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				foreach(DataRow rowAutoridad in oENTResponse.dsResponse.Tables[10].Rows){

					if (ValidaVoz( Int32.Parse( rowAutoridad["AutoridadId"].ToString()) ) == false){

						this.imgAutoridad.ImageUrl = "~/Include/Image/Icon/AutoridadIcon_Pending.png";
						this.imgAutoridad.ToolTip = "No se han calificado algunas voces en el Expediente";
						this.btnEnviar.Enabled = false;
						this.btnEnviar.CssClass = "Button_General_Disabled";
					}
				}

				// Resolución
				if (oENTResponse.dsResponse.Tables[1].Rows[0]["TipoResolucionId"].ToString() == "1"){
					this.imgResolucion.ImageUrl = "~/Include/Image/Icon/ResolucionIcon_Pending.png";
					this.imgResolucion.ToolTip = "No se ha resuelto el Expediente";
					this.btnEnviar.Enabled = false;
					this.btnEnviar.CssClass = "Button_General_Disabled";
				}

				// Recomendación
				if (oENTResponse.dsResponse.Tables[1].Rows[0]["TipoResolucionId"].ToString() == "2"){
					
					if (oENTResponse.dsResponse.Tables[11].Rows.Count == 0){
						this.imgRecomendacion.ImageUrl = "~/Include/Image/Icon/RecomendacionIcon_Pending.png";
						this.imgRecomendacion.ToolTip = "No se han asociado recomendaciones en el Expediente";
						this.btnEnviar.Enabled = false;
						this.btnEnviar.CssClass = "Button_General_Disabled";
					}

				}else{

					this.pnlRecomendacion.Visible = false;

				}

				// Acuerdo de No Responsabilidad
				if (oENTResponse.dsResponse.Tables[1].Rows[0]["TipoResolucionId"].ToString() == "3"){
					
					if (oENTResponse.dsResponse.Tables[13].Rows.Count == 0){
						this.imgAcuerdoNoResponsabilidad.ImageUrl = "~/Include/Image/Icon/RecomendacionIcon_Pending.png";
						this.imgAcuerdoNoResponsabilidad.ToolTip = "No se han asociado Acuerdo de No Responsabilidad en el Expediente";
						this.btnEnviar.Enabled = false;
						this.btnEnviar.CssClass = "Button_General_Disabled";
					}

				}else{

					this.pnlAcuerdoNoResponsabilidad.Visible = false;

				}

				//// Asuntos
				//this.lblAsuntos.Text = "Asuntos capturados: " + oBPExpediente.ExpedienteEntity.ResultData.Tables[1].Rows[0]["Asuntos"].ToString(); 
				//if (oBPExpediente.ExpedienteEntity.ResultData.Tables[1].Rows[0]["Asuntos"].ToString() == "0"){
				//    this.lblAsuntos.CssClass = "Asunto_Pending";
				//    this.btnEnviar.Enabled = false;
				//    this.btnEnviar.CssClass = "Button_General_Disabled";
				//}

			}catch (Exception ex){
				this.btnEnviar.Enabled = false;
				this.btnEnviar.CssClass = "Button_General_Disabled";
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

				// Obtener ExpedienteId
				this.hddExpedienteId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = sKey.Split(new Char[] { '|' })[1];

				// Carátula
				SelectExpediente();

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
				EnviarExpediente();

				// Regresar a la pantalla de detalle de Expediente
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visDetalleExpediente.aspx?key=" + sKey, false);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "','Fail',true);", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visDetalleExpediente.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "','Fail',true);", true);
            }
		}

    }
}