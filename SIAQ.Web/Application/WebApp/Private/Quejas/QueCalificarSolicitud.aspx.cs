/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueCalificarSolicitud
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
	public partial class QueCalificarSolicitud : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador

		void AgregaCanalizacion(){
			DataTable tblCanalizacion = null;
			DataRow rowCanalizacion = null;

			try
			{

				// Obtener el DataTable del grid
				tblCanalizacion = utilFunction.ParseGridViewToDataTable(this.grdCanalizacion, false);

				// Validaciones
				if (this.ddlCanalizacion.SelectedItem.Value == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Debe seleccionar una opción de canalización', 'Warning', false); function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
					return;
				}
				if( tblCanalizacion.Select("CanalizacionId='" + this.ddlCanalizacion.SelectedItem.Value + "'").Length > 0 ){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Ya ha agregado esta canalización', 'Warning', false); function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
					return;
				}

				// Nuevo Item
				rowCanalizacion = tblCanalizacion.NewRow();
				rowCanalizacion["CanalizacionId"] = this.ddlCanalizacion.SelectedItem.Value;
				rowCanalizacion["Nombre"] = this.ddlCanalizacion.SelectedItem.Text;
				tblCanalizacion.Rows.Add(rowCanalizacion);

				// Refrescar el Grid
				this.grdCanalizacion.DataSource = tblCanalizacion;
				this.grdCanalizacion.DataBind();

			}catch (Exception ex) { 
				throw(ex);
			}
		}

		void LimpiaGridCanalizaciones() {
			DataTable tblCanalizacion = null;

			try
			{

				// Obtener el DataTable del grid
				tblCanalizacion = utilFunction.ParseGridViewToDataTable(this.grdCanalizacion, true);

				// Limpiar la tabla
				tblCanalizacion.Rows.Clear();

				// Refrescar el Grid
				this.grdCanalizacion.DataSource = tblCanalizacion;
				this.grdCanalizacion.DataBind();

			}catch (Exception ex) { 
				throw(ex);
			}
		}

		void SelectCalificacion(){
			BPCalificacion BPCalificacion = new BPCalificacion();

			try
            {

				// Configuración del control
				this.ddlCalificacion.DataValueField = "CalificacionId";
				this.ddlCalificacion.DataTextField = "Nombre";

				// Transacción
				this.ddlCalificacion.DataSource = BPCalificacion.SelectCalificacion();

				// Validaciones
				if (BPCalificacion.ErrorId != 0) { throw (new Exception(BPCalificacion.ErrorDescription)); }

				// Llenado de datos
				this.ddlCalificacion.DataBind();
				this.ddlCalificacion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw(ex);
			}
		}

		void SelectCanalizacion(){
			BPCanalizacion BPCanalizacion = new BPCanalizacion();

			try
            {

				// Configuración del control
				this.ddlCanalizacion.DataValueField = "CanalizacionId";
				this.ddlCanalizacion.DataTextField = "Nombre";

				// Transacción
				this.ddlCanalizacion.DataSource = BPCanalizacion.SelectCanalizacion();

				// Validaciones
				if (BPCanalizacion.ErrorId != 0) { throw (new Exception(BPCanalizacion.ErrorDescription)); }

				// Llenado de datos
				this.ddlCanalizacion.DataBind();
				this.ddlCanalizacion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw(ex);
			}
		}

		void SelectOrientacion(){
			BPTipoOrientacion BPTipoOrientacion = new BPTipoOrientacion();

			try
            {

				// Configuración del control
				this.ddlTipoOrientacion.DataValueField = "TipoOrientacionId";
				this.ddlTipoOrientacion.DataTextField = "Nombre";

				// Transacción
				this.ddlTipoOrientacion.DataSource = BPTipoOrientacion.SelectTipoOrientacion();

				// Validaciones
				if (BPTipoOrientacion.ErrorId != 0) { throw (new Exception(BPTipoOrientacion.ErrorDescription)); }

				// Llenado de datos
				this.ddlTipoOrientacion.DataBind();
				this.ddlTipoOrientacion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw(ex);
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
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Datos de calificación
				this.ddlCalificacion.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString();

				if (oENTResponse.dsResponse.Tables[1].Rows[0]["TipoOrientacionId"].ToString() != "0") {
					
					this.ddlTipoOrientacion.Enabled = true;
					this.ddlTipoOrientacion.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoOrientacionId"].ToString();
				}

				if (oENTResponse.dsResponse.Tables[7].Rows.Count  > 0) {

					this.ddlCanalizacion.Enabled = true;

					this.btnAgregarCanalizacion.Enabled = true;
					this.btnAgregarCanalizacion.CssClass = "Button_General";

					this.grdCanalizacion.DataSource = oENTResponse.dsResponse.Tables[7];
					this.grdCanalizacion.DataBind();
				}

				this.ckeFundamento.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Fundamento"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void UpdateSolicitud_Calificacion() {
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			BPQueja oBPQueja = new BPQueja();

			DataTable tblCanalizacion = null;
			DataRow rowCanalizacion;

			try
			{

				// Obtener el DataTable del grid
				tblCanalizacion = utilFunction.ParseGridViewToDataTable(this.grdCanalizacion, false);

			    // Validaciones
				if (this.ddlCalificacion.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar una Calificación")); }
				if (this.ddlTipoOrientacion.Enabled && this.ddlTipoOrientacion.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Cierre de Orientación")); }
				if (this.ddlCanalizacion.Enabled && tblCanalizacion.Rows.Count == 0) { throw (new Exception("Es necesario seleccionar una Canalización")); }
				if (this.ckeFundamento.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un fundamento")); }
				
			    // Formulario
			    oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.CalificacionId = Int32.Parse(this.ddlCalificacion.SelectedItem.Value);
				oENTQueja.TipoOrientacionId = Int32.Parse(this.ddlTipoOrientacion.SelectedItem.Value);
				oENTQueja.Fundamento = this.ckeFundamento.Text.Trim();

				// Canalizaciones seleccionadas
				oENTQueja.tblCanalizacion = new DataTable("tblCanalizacion");
				oENTQueja.tblCanalizacion.Columns.Add("CanalizacionId", typeof(Int32));

				foreach(DataRow oDataRow in tblCanalizacion.Rows){

					rowCanalizacion = oENTQueja.tblCanalizacion.NewRow();
					rowCanalizacion["CanalizacionId"] = oDataRow["CanalizacionId"];
					oENTQueja.tblCanalizacion.Rows.Add(rowCanalizacion);
				}

			    // Transacción
				oENTResponse = oBPQueja.UpdateSolicitudCalificacion(oENTQueja);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
			    if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

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
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Llenado de controles
				SelectCalificacion();
				SelectOrientacion();
				SelectCanalizacion();

				// Carátula
				SelectSolicitud();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCalificacion.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlCalificacion.ClientID + "'); }", true);
            }
		}

		protected void btnAgregarCanalizacion_Click(object sender, EventArgs e){
			try
            {

				// Nuevo Item
				AgregaCanalizacion();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
            }
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

				// Asignar el Defensor
				UpdateSolicitud_Calificacion();

				// Regresar al detalle de la solicitud
				Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlCalificacion.ClientID + "'); }", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

		protected void ddlCalificacion_SelectedIndexChanged(Object sender, EventArgs e){
			try
            {

				// Determinar la opcion seleccionada por el usuario
				switch( this.ddlCalificacion.SelectedItem.Value  ){

					case "3" :	// Orientación

						this.ddlTipoOrientacion.Enabled = true;
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlTipoOrientacion.ClientID + "'); }", true);
						break;

					default:

						this.ddlTipoOrientacion.SelectedIndex = 0;
						this.ddlCanalizacion.SelectedIndex = 0;

						this.ddlTipoOrientacion.Enabled = false;
						this.ddlCanalizacion.Enabled = false;

						this.btnAgregarCanalizacion.Enabled = false;
						this.btnAgregarCanalizacion.CssClass = "Button_General_Disabled";

						LimpiaGridCanalizaciones();

						break;
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlCalificacion.ClientID + "'); }", true);
            }
		}

		protected void ddlTipoOrientacion_SelectedIndexChanged(Object sender, EventArgs e){
			try
            {

				// Determinar la opcion seleccionada por el usuario
				switch( this.ddlTipoOrientacion.SelectedItem.Value  ){

					case "2":	// Canalización

						this.btnAgregarCanalizacion.Enabled = true;
						this.btnAgregarCanalizacion.CssClass = "Button_General";

						this.ddlCanalizacion.Enabled = true;
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
						break;

					default:

						this.ddlCanalizacion.SelectedIndex = 0;
						this.ddlCanalizacion.Enabled = false;

						this.btnAgregarCanalizacion.Enabled = false;
						this.btnAgregarCanalizacion.CssClass = "Button_General_Disabled";

						LimpiaGridCanalizaciones();

						break;
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlCalificacion.ClientID + "'); }", true);
            }
		}

		protected void grdCanalizacion_RowCommand(object sender, GridViewCommandEventArgs e){
			DataTable tblCanalizacion = null;
			String CanalizacionId;

			String strCommand = "";
			Int32 intRow = 0;

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// Datakeys
				CanalizacionId = this.grdCanalizacion.DataKeys[intRow]["CanalizacionId"].ToString();

				// Acción
				switch (strCommand){
					case "Eliminar":

						// Obtener el DataTable del grid
						tblCanalizacion = utilFunction.ParseGridViewToDataTable(this.grdCanalizacion, true);

						// Eliminar el Item
						tblCanalizacion.Rows.Remove(tblCanalizacion.Select("CanalizacionId=" + CanalizacionId)[0]);

						// Refrescar el Grid
						this.grdCanalizacion.DataSource = tblCanalizacion;
						this.grdCanalizacion.DataBind();

						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
			}
		}

		protected void grdCanalizacion_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDelete = null;

			String NombreCanalizacion = "";
			String sImagesAttributes = "";
			String sTootlTip = "";

			try
			{

				// Validación de que sea fila
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imágen
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// Datakeys
				NombreCanalizacion = this.grdCanalizacion.DataKeys[e.Row.RowIndex]["Nombre"].ToString();

				// Tooltip Edición
				sTootlTip = "Eliminar [" + NombreCanalizacion + "]";
				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				// Atributos Over
				sImagesAttributes = " document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = " document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";
				e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row_Action'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

	}
}