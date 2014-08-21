/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueDiligenciaSolicitud
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
	public partial class QueDiligenciaSolicitud : System.Web.UI.Page
	{

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();

		// Enumeraciones
		private enum DiligenciaActionTypes { DeleteDiligencia, InsertDiligencia, ReactivateDiligencia, UpdateDiligencia }


		// Rutinas del Programador

		void DeleteDiligencia(string solicitudId, string diligenciaId){
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			BPDiligencia oBPDiligencia = new BPDiligencia();

			try
			{
				oENTDiligencia.DiligenciaId = Convert.ToInt32(diligenciaId);
				oENTDiligencia.SolicitudId = Convert.ToInt32(solicitudId);

				oENTResponse = oBPDiligencia.DeleteDiligenciaSolicitud(oENTDiligencia);

				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				SelectDiligencia();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void InsertSolicitudDiligencia(){
			BPDiligencia oBPDiligencia = new BPDiligencia();

			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			ENTSession oENTSession;

			try
			{

				// Validaciones
				if (this.ddlFuncionario.SelectedIndex == 0) { throw new Exception("El campo [Funcionario que ejecuta] es requerido"); }
				if (String.IsNullOrEmpty(calFecha.DisplayDate)) { throw new Exception("El campo [Fecha de la diligencia] es requerido"); }
				if (this.ddlTipoDiligencia.SelectedIndex == 0) { throw new Exception("El campo [Tipo de diligencia] es requerido"); }
				if (this.ddlLugarDiligencia.SelectedIndex == 0) { throw new Exception("El campo [Lugar de diligencia] es requerido"); }
				if (this.txtSolicitadaPor.Text.Trim() == "") { throw new Exception("El campo [Solicitada por] es requerido"); }
				if (this.ckeDetalle.Text.Trim() == "") { throw new Exception("El campo [Detalle] es requerido"); }
				if (this.ckeResultado.Text.Trim() == "") { throw new Exception("El campo [Resultado] es requerido"); }

				// Obtener Sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear diligencias debido a que usted no es un funcionario"); }
				
				//Formulario
				oENTDiligencia.SolicitudId = Convert.ToInt32(this.hddSolicitudId.Value);
				oENTDiligencia.FuncionarioAtiendeId = oENTSession.FuncionarioId;
				oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlFuncionario.SelectedValue);
				oENTDiligencia.FechaDiligencia = this.calFecha.BeginDate;
				oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
				oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
				oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
				oENTDiligencia.Detalle = this.ckeDetalle.Text.Trim();
				oENTDiligencia.Resultado = this.ckeResultado.Text.Trim();

				//Transacción
				oENTResponse = oBPDiligencia.InsertDiligenciaSolicitud(oENTDiligencia);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectDiligencia();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectDiligencia() {
			BPDiligencia oBPDiligencias = new BPDiligencia();

			// Parámetros
			oBPDiligencias.DiligenciaEntity.SolicitudId = Convert.ToInt32(this.hddSolicitudId.Value);

			// Transacción
			oBPDiligencias.SelectDiligencias();

			// Validaciones
			if (oBPDiligencias.ErrorId != 0) { throw (new Exception(oBPDiligencias.ErrorDescription)); }

			// Listado de recomendaciones
			gvDiligencia.DataSource = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0];
			gvDiligencia.DataBind();
		}

		void SelectFuncionario(){
			BPFuncionario oBPFuncionario = new BPFuncionario();
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTFuncionario.FuncionarioId = 0;
				oENTFuncionario.idUsuario = 0;
				oENTFuncionario.idArea = 0;
				oENTFuncionario.idRol = 5;			// Queja - Funcionario
				oENTFuncionario.TituloId = 0;
				oENTFuncionario.PuestoId = 0;
				oENTFuncionario.Nombre = "";

				// Transacción
				oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlFuncionario.DataTextField = "sFullName";
				this.ddlFuncionario.DataValueField = "FuncionarioId";
				this.ddlFuncionario.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlFuncionario.DataBind();

				// Opción todos
				this.ddlFuncionario.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectLugarDiligencia() {
			BPDiligencia oBPDiligencia = new BPDiligencia();

			// Transacción
			oBPDiligencia.SelectLugarDiligencias();

			// Validaciones
			if (oBPDiligencia.ErrorId != 0) { throw (new Exception(oBPDiligencia.ErrorDescription)); }

			// Llenado de combo
			this.ddlLugarDiligencia.DataSource = oBPDiligencia.DiligenciaEntity.DataResult;
			this.ddlLugarDiligencia.DataTextField = "Nombre";
			this.ddlLugarDiligencia.DataValueField = "LugarDiligenciaId";
			this.ddlLugarDiligencia.DataBind();

			// Agregar Item de selección
			this.ddlLugarDiligencia.Items.Insert(0, new ListItem("[Seleccione]", "0"));
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

				// Estatus de capturas de diligencias
				if (oENTResponse.dsResponse.Tables[1].Rows[0]["Diligencias"].ToString() == "1"){

					// Habilitar controles
					this.chkDiligencias.Checked = true;
					this.btnNuevo.Enabled = true;
					this.btnNuevo.CssClass = "Button_General";
				}else{

					// Inhabilitar controles
					this.chkDiligencias.Checked = false;
					this.btnNuevo.Enabled = false;
					this.btnNuevo.CssClass = "Button_General_Disabled";
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectTipoDiligencia() {
			BPDiligencia oBPDiligencia = new BPDiligencia();

			// Transacción
			oBPDiligencia.SelectTipoDiligencias();

			// Validaciones
			if (oBPDiligencia.ErrorId != 0) { throw (new Exception(oBPDiligencia.ErrorDescription)); }

			// Llenado de combo
			this.ddlTipoDiligencia.DataSource = oBPDiligencia.DiligenciaEntity.DataResult;
			this.ddlTipoDiligencia.DataTextField = "Nombre";
			this.ddlTipoDiligencia.DataValueField = "TipoDiligenciaId";
			this.ddlTipoDiligencia.DataBind();

			// Agregar Item de selección
			this.ddlTipoDiligencia.Items.Insert(0, new ListItem("[Seleccione]", "0"));
		}

		void UpdateSolicitudBanderaDiligencia(Int16 Diligencias){
			BPQueja oBPQueja = new BPQueja();
			ENTResponse oENTResponse = new ENTResponse();
			ENTQueja oENTQueja = new ENTQueja();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.Diligencias = Diligencias;

				//Transacción
				oENTResponse = oBPQueja.UpdateSolicitudCapturaDiligencia(oENTQueja);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			}catch (Exception ex){
				throw (ex);
			}
		}

		void UpdateSolicitudDiligencia(string diligenciaId){
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			BPDiligencia oBPDiligencia = new BPDiligencia();


			if (ddlFuncionario.SelectedValue == "0") { throw new Exception("* El campo [Visitador que ejecuta] es requerido"); }
			if (String.IsNullOrEmpty(calFecha.DisplayDate)) { throw new Exception("* El campo [Fecha de la diligencia] es requerido"); }
			if (ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Tipo de diligencia] es requerido"); }
			if (ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Lugar de diligencia] es requerido"); }
			if (String.IsNullOrEmpty(ckeDetalle.Text)) { throw new Exception("* El campo [Detalle] es requerido"); }
			if (String.IsNullOrEmpty(txtSolicitadaPor.Text)) { throw new Exception("* El campo [Solicitada por] es requerido"); }
			if (String.IsNullOrEmpty(ckeResultado.Text)) { throw new Exception("* El campo [Resultado] es requerido"); }

			try
			{
				// Formulario
				oENTDiligencia.DiligenciaId = Convert.ToInt32(diligenciaId);
				oENTDiligencia.SolicitudId = Convert.ToInt32(this.hddSolicitudId.Value);
				oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlFuncionario.SelectedValue);
				oENTDiligencia.FechaDiligencia = calFecha.BeginDate;
				oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
				oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
				oENTDiligencia.Detalle = ckeDetalle.Text;
				oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
				oENTDiligencia.Resultado = ckeResultado.Text;

				// Transacción
				oENTResponse = oBPDiligencia.UpdateDiligenciaSolicitud(oENTDiligencia);

				// Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectDiligencia();

			}catch (Exception ex){
				throw (ex);
			}
		}

		
		// Rutinas del PopUp

		void ClearActionPanel(){
			try
			{

				// Limpiar formulario
				this.ddlFuncionario.SelectedIndex = 0;
				this.calFecha.SetCurrentDate();
				this.ddlTipoDiligencia.SelectedIndex = 0;
				this.ddlLugarDiligencia.SelectedIndex = 0;
				this.txtSolicitadaPor.Text = "";
				this.ckeDetalle.Text = "";
				this.ckeResultado.Text = "";

				// Estado incial de controles
				this.pnlAction.Visible = false;
				this.lblActionTitle.Text = "";
				this.btnAction.Text = "";
				this.lblActionMessage.Text = "";
				this.hddDiligenciaId.Value = "";

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectDiligencia_ForEdit(string solicitudId, string diligenciaId){
			BPDiligencia oBPDiligencia = new BPDiligencia();

			// Formulario
			oBPDiligencia.DiligenciaEntity.SolicitudId = Convert.ToInt32(solicitudId);
			oBPDiligencia.DiligenciaEntity.DiligenciaId = Convert.ToInt32(diligenciaId);

			// Transacción
			oBPDiligencia.SelectDetalleDiligenciaSolicitud();

			// Validaciones
			if (oBPDiligencia.ErrorId != 0) { throw (new Exception(oBPDiligencia.ErrorDescription)); }

			// Vaciado de datos
			this.hddDiligenciaId.Value = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["DiligenciaId"].ToString();
			this.ddlFuncionario.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FuncionarioEjecuta"].ToString();
			this.calFecha.SetDate = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FechaDiligencia"].ToString();
			this.ddlTipoDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["TipoDiligencia"].ToString();
			this.ddlLugarDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["LugarDiligencia"].ToString();
			this.ckeDetalle.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Detalle"].ToString();
			this.txtSolicitadaPor.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["SolicitadaPor"].ToString();
			this.ckeResultado.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Resultado"].ToString();
		}

		void SetPanel(DiligenciaActionTypes DActionType, Int32 idItem){
			try
			{

				// Acciones comunes
				this.pnlAction.Visible = true;
				this.hddDiligenciaId.Value = idItem.ToString();

				// Detalle de acción
				switch (DActionType){
					case DiligenciaActionTypes.InsertDiligencia:

						this.lblActionTitle.Text = "Nueva Diligencia";
						this.btnAction.Text = "Crear Diligencia";
						break;

					case DiligenciaActionTypes.UpdateDiligencia:

						this.lblActionTitle.Text = "Edición de Diligencia";
						this.btnAction.Text = "Actualizar Diligencia";
						SelectDiligencia_ForEdit( this.hddSolicitudId.Value, idItem.ToString());
						break;

					default:
						throw (new Exception("Opción inválida"));
				}

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "WAFocus ('" + this.ddlFuncionario.ClientID + "'); ", true);

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
				SelectFuncionario();
				SelectTipoDiligencia();
				SelectLugarDiligencia();
				SelectDiligencia();

				// Carátula
				SelectSolicitud();

				// Estado inicial de la pantalla
				ClearActionPanel();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.chkDiligencias.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.chkDiligencias.ClientID + "'); }", true);
            }
		}

		protected void btnNuevo_Click(object sender, EventArgs e){
			try
			{

				// Nuevo registro
				SetPanel(DiligenciaActionTypes.InsertDiligencia, 0);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

		protected void chkDiligencias_CheckedChanged(object sender, EventArgs e){
			try
			{

				if (this.chkDiligencias.Checked){

					// Marcar las diligencias como necesarias en la solicitud
					UpdateSolicitudBanderaDiligencia(1);

					// Habilitar controles
					this.btnNuevo.Enabled = true;
					this.btnNuevo.CssClass = "Button_General";
				}else{

					// Marcar las diligencias como no necesarias en la solicitud y eliminar las capturas
					UpdateSolicitudBanderaDiligencia(0);

					// Inhabilitar controles
					this.btnNuevo.Enabled = false;
					this.btnNuevo.CssClass = "Button_General_Disabled";

					// Las diligencias se eliminaron en el SP, limpiar el grid
					this.gvDiligencia.DataSource = null;
					this.gvDiligencia.DataBind();
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvDiligencia_RowCommand(object sender, GridViewCommandEventArgs e){
			String sCommandName;
			String SolicitudId = string.Empty;
			String DiligenciaId = string.Empty;

			Int32 intRow = 0;

			try
			{
				
				// Opción seleccionada
				sCommandName = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (sCommandName == "Sort") { return; }

				// Fila
				intRow = Convert.ToInt32(e.CommandArgument.ToString());

				// DataKeys
				DiligenciaId = gvDiligencia.DataKeys[intRow]["DiligenciaId"].ToString();

				// SolicitudId 
				SolicitudId = this.hddSolicitudId.Value;

				// Acción
				switch (sCommandName){
					case "Editar":
						SetPanel(DiligenciaActionTypes.UpdateDiligencia, Int32.Parse(DiligenciaId));
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;

					case "Borrar":
						DeleteDiligencia(SolicitudId, DiligenciaId);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.chkDiligencias.ClientID + "'); }", true);
			}
		}

		protected void gvDiligencia_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;

			String sImagesAttributes = "";
			String sToolTip = "";
			String sNumeroDiligencia = "";

			String sImagesAttributesDelete = "";
			String sToolTipDelete = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				sNumeroDiligencia = gvDiligencia.DataKeys[e.Row.RowIndex]["DiligenciaId"].ToString();

				// Tooltip Edición
				sToolTip = "Editar diligencia [" + sNumeroDiligencia + "]";
				sToolTipDelete = "Eliminar diligencia [" + sNumeroDiligencia + "]";

				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTipDelete + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				// Atributos Over
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
				sImagesAttributesDelete = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

				// Puntero y Sombra en fila Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes + sImagesAttributesDelete);

				// Atributos Out
				sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
				sImagesAttributesDelete = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

				// Puntero y Sombra en fila Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes + sImagesAttributesDelete);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvDiligencia_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvDiligencia, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.chkDiligencias.ClientID + "'); }", true);
			}
		}


		// Eventos de PopUp

		protected void btnAction_Click(object sender, EventArgs e){
			try
			{
				
				if (this.hddDiligenciaId.Value == "0"){

					InsertSolicitudDiligencia();
				}else{

					UpdateSolicitudDiligencia(this.hddDiligenciaId.Value);
				}

			}catch (Exception ex){
				this.lblActionMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlFuncionario.ClientID + "');", true);
			}
		}

		protected void imgCloseWindow_Click(object sender, ImageClickEventArgs e){
			try
			{

				// Cancelar transacción
				ClearActionPanel();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

	}
}