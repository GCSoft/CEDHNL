/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	VicDictamenMedico
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
	public partial class VicDictamenMedico : System.Web.UI.Page
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

		void InsertDictamen() {
			ENTDictamen oENTDictamen = new ENTDictamen();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			BPDictamen oBPDictamen = new BPDictamen();

			try
			{

				// Validaciones
				if (this.ddlResolucionDictamen.Enabled) { if (this.ddlResolucionDictamen.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar una Resolución de Dictamen")); } }
				if (this.ckeDictamen.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un detalle del dictamen")); }

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				// Validaciones de sesión
				if (SessionEntity.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear diligencias debido a que usted no es un funcionario"); }

				// Formulario
				oENTDictamen.AtencionId = Int32.Parse(this.hddAtencionId.Value);
				oENTDictamen.FuncionarioId = SessionEntity.FuncionarioId;
				oENTDictamen.ResolucionDictamenId = ( this.ddlResolucionDictamen.Enabled ? Int32.Parse(this.ddlResolucionDictamen.SelectedValue) : 0 );
				oENTDictamen.Dictamen = this.ckeDictamen.Text.Trim();

				// Transacción
				oENTResponse = oBPDictamen.InsertDictamen(oENTDictamen);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectAtencion() {
			BPAtencion oBPAtencion = new BPAtencion();
			ENTAtencion oENTAtencion = new ENTAtencion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTAtencion.AtencionId = Int32.Parse(this.hddAtencionId.Value);

				// Transacción
				oENTResponse = oBPAtencion.SelectAtencion_Detalle(oENTAtencion);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Formulario
				this.AtencionNumeroFolio.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AtencionNumeroFolio"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Ciudadanos"].ToString();
				this.AtencionNumeroOficio.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AtencionNumeroOficio"].ToString();
				this.AreaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Area"].ToString();
				this.ExpedienteNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.SolicitudNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.DoctorLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();

				this.FechaAtencionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAtencion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.UltimaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.DictamenMedicoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoDictamenNombre"].ToString();
				this.LugarRevisionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarAtencionNombre"].ToString();

				// Control de resolución de dictamen
				if ( oENTResponse.dsResponse.Tables[1].Rows[0]["TipoDictamenId"].ToString() != "1" ){

					this.ddlResolucionDictamen.Items.Clear();
					this.ddlResolucionDictamen.Enabled = false;
				}else{

					this.ddlResolucionDictamen.SelectedValue = oENTResponse.dsResponse.Tables[4].Rows[0]["ResolucionDictamenId"].ToString();
				}

				// Detalle de resolución
				if ( oENTResponse.dsResponse.Tables[4].Rows.Count > 0 ){

					this.hddAtencionDictamenId.Value = oENTResponse.dsResponse.Tables[4].Rows[0]["AtencionDictamenId"].ToString();
					this.ckeDictamen.Text = oENTResponse.dsResponse.Tables[4].Rows[0]["Dictamen"].ToString();
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectResolucionDictamen(){
			ENTDictamen oENTDictamen = new ENTDictamen();
			ENTResponse oENTResponse = new ENTResponse();

			BPDictamen oBPDictamen = new BPDictamen();

			try
			{

				// Formulario
				oENTDictamen.ResolucionDictamenId = 0;
				oENTDictamen.Nombre = "";

				// Transacción
				oENTResponse = oBPDictamen.SelectResolucionDictamen(oENTDictamen);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

				// Llenado de combo
				this.ddlResolucionDictamen.DataTextField = "Nombre";
				this.ddlResolucionDictamen.DataValueField = "ResolucionDictamenId";
				this.ddlResolucionDictamen.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlResolucionDictamen.DataBind();

				// Agregar Item de selección
				this.ddlResolucionDictamen.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void UpdateDictamen() {
			ENTDictamen oENTDictamen = new ENTDictamen();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			BPDictamen oBPDictamen = new BPDictamen();

			try
			{

				// Validaciones
				if (this.ddlResolucionDictamen.Enabled) { if (this.ddlResolucionDictamen.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar una Resolución de Dictamen")); } }
				if (this.ckeDictamen.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un detalle del dictamen")); }

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				// Validaciones de sesión
				if (SessionEntity.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear diligencias debido a que usted no es un funcionario"); }

				// Formulario
				oENTDictamen.DictamenId = Int32.Parse( this.hddAtencionDictamenId.Value );
				oENTDictamen.AtencionId = Int32.Parse(this.hddAtencionId.Value);
				oENTDictamen.FuncionarioId = SessionEntity.FuncionarioId;
				oENTDictamen.ResolucionDictamenId = ( this.ddlResolucionDictamen.Enabled ? Int32.Parse(this.ddlResolucionDictamen.SelectedValue) : 0 );
				oENTDictamen.Dictamen = this.ckeDictamen.Text.Trim();

				// Transacción
				oENTResponse = oBPDictamen.UpdateDictamen(oENTDictamen);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

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

				// Obtener AtencionId
				this.hddAtencionId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = sKey.Split(new Char[] { '|' })[1];

				// Controles del formulario
				SelectResolucionDictamen();

				// Carátula
				SelectAtencion();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), (this.ddlResolucionDictamen.Enabled ? "focusControl('" + this.ddlResolucionDictamen.ClientID + "');" : ""), true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); " + (this.ddlResolucionDictamen.Enabled ? "focusControl('" + this.ddlResolucionDictamen.ClientID + "');" : ""), true);
            }
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

                // Tipo de transacción
				if( this.hddAtencionDictamenId.Value == "0" ){

					InsertDictamen();
	
				}else{

					UpdateDictamen();

				}

				// Regresar
				sKey = this.hddAtencionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("VicDetalleAtencion.aspx?key=" + sKey, false);


            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); " + (this.ddlResolucionDictamen.Enabled ? "focusControl('" + this.ddlResolucionDictamen.ClientID + "');" : ""), true); ;
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Llave encriptada
				sKey = this.hddAtencionId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("VicDetalleAtencion.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); " + (this.ddlResolucionDictamen.Enabled ? "focusControl('" + this.ddlResolucionDictamen.ClientID + "');" : ""), true);
            }
		}

	}
}