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
				//if (this.ddlCiudadano.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Ciudadano")); }
				if (this.ddlTipoDictamen.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Tipo de Dictamen")); }
				if (this.ddlLugarAtencion.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Lugar de Atención")); }
				if (this.ckeDictamen.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un detalle del dictamen")); }

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				// Formulario
				oENTDictamen.AtencionId = Int32.Parse(this.hddAtencionId.Value);
				oENTDictamen.FuncionarioId = SessionEntity.FuncionarioId;
				//oENTDictamen.CiudadanoId = Int32.Parse(this.ddlCiudadano.SelectedItem.Value);
				oENTDictamen.TipoDictamenId = Int32.Parse(this.ddlTipoDictamen.SelectedItem.Value);
				oENTDictamen.LugarAtencionId = Int32.Parse(this.ddlLugarAtencion.SelectedItem.Value);
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
				this.AtencionNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AtencionNumero"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Ciudadanos"].ToString();
				this.ExpedienteNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.SolicitudNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.DoctorLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();

				this.FechaAtencionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAtencion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.UltimaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelecDictamen(){
			ENTDictamen oENTDictamen = new ENTDictamen();
			ENTResponse oENTResponse = new ENTResponse();

			BPDictamen oBPDictamen = new BPDictamen();

			try
			{

				// Formulario
				oENTDictamen.AtencionId = Int32.Parse(this.hddAtencionId.Value);

				// Transacción
				oENTResponse = oBPDictamen.SelectDictamen(oENTDictamen);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Llenado Grid
				this.gvDictamen.DataSource = oENTResponse.dsResponse.Tables[1];
				this.gvDictamen.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectLugarAtencion(){
			ENTDictamen oENTDictamen = new ENTDictamen();
			ENTResponse oENTResponse = new ENTResponse();

			BPDictamen oBPDictamen = new BPDictamen();

			try
			{

				// Formulario
				oENTDictamen.LugarAtencionId = 0;
				oENTDictamen.Nombre = "";

				// Transacción
				oENTResponse = oBPDictamen.SelectLugarAtencion(oENTDictamen);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

				// Llenado de combo
				this.ddlLugarAtencion.DataTextField = "Nombre";
				this.ddlLugarAtencion.DataValueField = "LugarAtencionId";
				this.ddlLugarAtencion.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlLugarAtencion.DataBind();

				// Agregar Item de selección
				this.ddlLugarAtencion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectTipoDictamen(){
			ENTDictamen oENTDictamen = new ENTDictamen();
			ENTResponse oENTResponse = new ENTResponse();

			BPDictamen oBPDictamen = new BPDictamen();

			try
			{

				// Formulario
				oENTDictamen.TipoDictamenId = 0;
				oENTDictamen.Nombre = "";

				// Transacción
				oENTResponse = oBPDictamen.SelectTipoDictamen(oENTDictamen);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

				// Llenado de combo
				this.ddlTipoDictamen.DataTextField = "Nombre";
				this.ddlTipoDictamen.DataValueField = "TipoDictamenId";
				this.ddlTipoDictamen.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlTipoDictamen.DataBind();

				// Agregar Item de selección
				this.ddlTipoDictamen.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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

				// Carátula
				SelectAtencion();

				// Llenado de controles
				SelectTipoDictamen();
				SelectLugarAtencion();
				SelecDictamen();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlTipoDictamen.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlTipoDictamen.ClientID + "');", true);
            }
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

                // Obtener Expedientes
				InsertDictamen();

				// Refrescar Dictámenes
				SelecDictamen();

				// Estado inicial del formulario
				this.ddlTipoDictamen.SelectedIndex = 0;
				this.ddlLugarAtencion.SelectedIndex = 0;
				this.ckeDictamen.Text = "";

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlTipoDictamen.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlTipoDictamen.ClientID + "');", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlTipoDictamen.ClientID + "');", true);
            }
		}

		protected void gvDictamen_RowDataBound(object sender, GridViewRowEventArgs e){
			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Atributos Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");

				// Atributos Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvDictamen_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvDictamen, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlTipoDictamen.ClientID + "');", true);
			}
		}

	}
}