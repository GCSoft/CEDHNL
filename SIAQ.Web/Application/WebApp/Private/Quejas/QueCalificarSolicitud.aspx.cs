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
using GCUtility.Function;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;


namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueCalificarSolicitud : System.Web.UI.Page
	{

		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();
		GCParse gcParse = new GCParse();


		// Rutinas del programador

		void AgregaCanalizacion(){
			DataTable tblCanalizacion = null;
			DataRow rowCanalizacion = null;

			try
			{

				// Obtener el DataTable del grid
				tblCanalizacion = gcParse.GridViewToDataTable(this.grdCanalizacion, false);

				// Validaciones
				if (this.ddlCanalizacion.SelectedItem.Value == "0"){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Debe seleccionar una opción de canalización'); function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
					return;
				}
				if( tblCanalizacion.Select("CanalizacionId='" + this.ddlCanalizacion.SelectedItem.Value + "'").Length > 0 ){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Ya ha agregado esta canalización'); function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
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
				tblCanalizacion = gcParse.GridViewToDataTable(this.grdCanalizacion, true);

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

		void SelectMecanismoApertura(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.MecanismoAperturaId = 0;
				oENTQueja.Nombre = "";

				// Transacción
				oENTResponse = oBPQueja.SelectMecanismoApertura(oENTQueja);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlMecanismoApertura.DataTextField = "Nombre";
				this.ddlMecanismoApertura.DataValueField = "MecanismoAperturaId";
				this.ddlMecanismoApertura.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlMecanismoApertura.DataBind();

				// Opción todos
				this.ddlMecanismoApertura.Items.Insert(0, new ListItem("[Seleccione]", "-1"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectNivelAutoridad(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.NivelAutoridadId = 0;
				oENTQueja.Nombre = "";

				// Transacción
				oENTResponse = oBPQueja.SelectNivelAutoridad(oENTQueja);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlNivelAutoridad.DataTextField = "Nombre";
				this.ddlNivelAutoridad.DataValueField = "NivelAutoridadId";
				this.ddlNivelAutoridad.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlNivelAutoridad.DataBind();

				// Opción todos
				this.ddlNivelAutoridad.Items.Insert(0, new ListItem("[Seleccione]", "-1"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectProblematica(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.ProblematicaId = 0;
				oENTQueja.Nombre = "";

				// Transacción
				oENTResponse = oBPQueja.SelectProblematica(oENTQueja);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlProblematica.DataTextField = "Nombre";
				this.ddlProblematica.DataValueField = "ProblematicaId";
				this.ddlProblematica.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlProblematica.DataBind();

				// Opción todos
				this.ddlProblematica.Items.Insert(0, new ListItem("[Seleccione]", "-1"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectProblematicaDetalle(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.ProblematicaDetalleId = 0;
				oENTQueja.ProblematicaId = Int32.Parse(this.ddlProblematica.SelectedItem.Value);
				oENTQueja.Nombre = "";

				// Transacción
				oENTResponse = oBPQueja.SelectProblematicaDetalle(oENTQueja);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlProblematicaDetalle.DataTextField = "Nombre";
				this.ddlProblematicaDetalle.DataValueField = "ProblematicaDetalleId";
				this.ddlProblematicaDetalle.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlProblematicaDetalle.DataBind();

				// Opción todos
				this.ddlProblematicaDetalle.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Datos de calificación
				this.ddlProblematica.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaId"].ToString();
				SelectProblematicaDetalle();

				this.ddlProblematicaDetalle.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleId"].ToString();
				this.ddlMecanismoApertura.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaId"].ToString();
				this.ddlNivelAutoridad.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadId"].ToString();
				this.ddlCalificacion.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString();

				this.chkMedioComunicacion.Checked = ( oENTResponse.dsResponse.Tables[1].Rows[0]["MediosDeComunicacion"].ToString() == "1" ? true : false);
				this.chkMedioComunicacion.Enabled = (oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaId"].ToString() == "2" ? true : false);

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

				// Script de Validación de cambio de estatus (Antes Queja)
				if (oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString() == "2"){
					this.btnGuardar.Attributes.Add("onclick", " if ( document.getElementById('" + ddlCalificacion.ClientID + "').options[document.getElementById('" + ddlCalificacion.ClientID + "').selectedIndex].value != 2 ) { return confirm('Al cambiar la calificación se eliminarán todas las capturas de Autoridades y Voces realizadas en la solicitud, ¿Seguro que desea continuar?'); }");
				}

				// Script de Validación de cambio de estatus (Antes Medidas Cautelares)
				if (oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString() == "8"){
					this.btnGuardar.Attributes.Add("onclick", " if ( document.getElementById('" + ddlCalificacion.ClientID + "').options[document.getElementById('" + ddlCalificacion.ClientID + "').selectedIndex].value != 2 ) { return confirm('Al cambiar la calificación se eliminarán todas las capturas de Autoridades realizadas en la solicitud, ¿Seguro que desea continuar?'); }");
				}

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
				tblCanalizacion = gcParse.GridViewToDataTable(this.grdCanalizacion, false);

			    // Validaciones
				if (this.ddlProblematica.SelectedIndex == 0) { throw (new Exception("Es necesario seleccionar una Problemática")); }
				if (this.ddlProblematicaDetalle.SelectedIndex == 0) { throw (new Exception("Es necesario seleccionar un Detalle de Problemática")); }
				if (this.ddlMecanismoApertura.SelectedIndex == 0) { throw (new Exception("Es necesario seleccionar un Mecanismo de Apertura")); }
				if (this.ddlNivelAutoridad.SelectedIndex == 0) { throw (new Exception("Es necesario seleccionar un Nivel de Autoridad")); }
				if (this.ddlCalificacion.SelectedIndex == 0) { throw (new Exception("Es necesario seleccionar una Calificación")); }
				if (this.ddlTipoOrientacion.Enabled && this.ddlTipoOrientacion.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un Cierre de Orientación")); }
				if (this.ddlCanalizacion.Enabled && tblCanalizacion.Rows.Count == 0) { throw (new Exception("Es necesario seleccionar una Canalización")); }
				if (this.ckeFundamento.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un fundamento")); }
				
			    // Formulario
			    oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.ProblematicaId = Int32.Parse(this.ddlProblematica.SelectedItem.Value);
				oENTQueja.ProblematicaDetalleId = Int32.Parse(this.ddlProblematicaDetalle.SelectedItem.Value);
				oENTQueja.MecanismoAperturaId = Int32.Parse(this.ddlMecanismoApertura.SelectedItem.Value);
				oENTQueja.NivelAutoridadId = Int32.Parse(this.ddlNivelAutoridad.SelectedItem.Value);
				oENTQueja.CalificacionId = Int32.Parse(this.ddlCalificacion.SelectedItem.Value);
				oENTQueja.TipoOrientacionId = Int32.Parse(this.ddlTipoOrientacion.SelectedItem.Value);
				oENTQueja.Fundamento = this.ckeFundamento.Text.Trim();
				oENTQueja.MediosComunicacion = Int16.Parse( ( this.chkMedioComunicacion.Checked ? 1 : 0 ).ToString() );

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
				SelectProblematica();
				SelectMecanismoApertura();
				SelectNivelAutoridad();
				SelectCalificacion();
				SelectOrientacion();
				SelectCanalizacion();

				// Carátula
				SelectSolicitud();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlProblematica.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlProblematica.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlProblematica.ClientID + "'); }", true);
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

						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlCalificacion.ClientID + "'); }", true);

						break;
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlProblematica.ClientID + "'); }", true);
            }
		}

		protected void ddlMecanismoApertura_SelectedIndexChanged(Object sender, EventArgs e){
			try
            {

				switch (this.ddlMecanismoApertura.SelectedItem.Value){
					case "2": // Oficio

						this.chkMedioComunicacion.Enabled = true;
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.chkMedioComunicacion.ClientID + "'); }", true);
						break;

					default:

						this.chkMedioComunicacion.Enabled = false;
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlNivelAutoridad.ClientID + "'); }", true);
						break;
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlProblematica.ClientID + "'); }", true);
            }
		}

		protected void ddlProblematica_SelectedIndexChanged(Object sender, EventArgs e){
			try
            {

				// Detalles de problemáticas
				SelectProblematicaDetalle();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlProblematicaDetalle.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlProblematica.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlProblematica.ClientID + "'); }", true);
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
						tblCanalizacion = gcParse.GridViewToDataTable(this.grdCanalizacion, true);

						// Eliminar el Item
						tblCanalizacion.Rows.Remove(tblCanalizacion.Select("CanalizacionId=" + CanalizacionId)[0]);

						// Refrescar el Grid
						this.grdCanalizacion.DataSource = tblCanalizacion;
						this.grdCanalizacion.DataBind();

						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
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