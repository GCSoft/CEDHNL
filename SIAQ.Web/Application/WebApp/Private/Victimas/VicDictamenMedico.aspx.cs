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
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class VicDictamenMedico : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador

		void InsertDictamen() {
			ENTDictamen oENTDictamen = new ENTDictamen();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			BPDictamen oBPDictamen = new BPDictamen();

			try
			{

				// Validaciones
				if (this.ddlCiudadano.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Ciudadano")); }
				if (this.ddlTipoDictamen.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Tipo de Dictamen")); }
				if (this.ddlLugarAtencion.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Lugar de Atención")); }
				if (this.ckeDictamen.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un detalle del dictamen")); }

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];

				// Formulario
				oENTDictamen.AtencionId = Int32.Parse(this.hddAtencionId.Value);
				oENTDictamen.FuncionarioId = SessionEntity.FuncionarioId;
				oENTDictamen.CiudadanoId = Int32.Parse(this.ddlCiudadano.SelectedItem.Value);
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
				this.ExpedienteNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.SolicitudNumeroLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.EstatusLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.DoctorLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.FechaAtencionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAtencion"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Combo Ciudadanos
				this.ddlCiudadano.DataTextField = "NombreCompleto";
				this.ddlCiudadano.DataValueField = "CiudadanoId";
				this.ddlCiudadano.DataSource = oENTResponse.dsResponse.Tables[2];
				this.ddlCiudadano.DataBind();
				this.ddlCiudadano.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);", true); }

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
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);", true); }

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
			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 3) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddAtencionId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Llenado de controles
				SelectAtencion();
				SelectTipoDictamen();
				SelectLugarAtencion();
				SelecDictamen();

				// Seleccionar la recomendación y Foco
				if (this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[2].ToString() != "0") {

					this.ddlCiudadano.SelectedValue = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[2].ToString();
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlTipoDictamen.ClientID + "');", true);
				}else{

					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCiudadano.ClientID + "');", true);
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
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
				this.ddlCiudadano.SelectedIndex = 0;
				this.ddlTipoDictamen.SelectedIndex = 0;
				this.ddlLugarAtencion.SelectedIndex = 0;
				this.ckeDictamen.Text = "";

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCiudadano.ClientID + "');", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlCiudadano.ClientID + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("VicDetalleAtencion.aspx?key=" + this.hddAtencionId.Value + "|" + this.SenderId.Value, false);
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
			DataTable tblData = null;
			DataView viewData = null;

			try
			{
				//Obtener DataTable y View del GridView
				tblData = utilFunction.ParseGridViewToDataTable(gvDictamen, false);
				viewData = new DataView(tblData);

				//Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				//Ordenar Vista
				viewData.Sort = hddSort.Value;

				//Vaciar datos
				this.gvDictamen.DataSource = viewData;
				this.gvDictamen.DataBind();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

	}
}