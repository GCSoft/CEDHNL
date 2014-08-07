/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	segDiligencia
' Autor:	Ruben.Cobos
' Fecha:	07-Junio-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segDiligencia : System.Web.UI.Page
	{

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		void DeleteDiligencia(Int32 DiligenciaId) {
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			BPDiligencia oBPDiligencia = new BPDiligencia();

			try
			{

				// Parámetros
				oENTDiligencia.DiligenciaId = DiligenciaId;

				// Transacción
				oENTResponse = oBPDiligencia.DeleteDiligenciaRecomendacion(oENTDiligencia);

				// Mensajes de la BD
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				//Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Diligencia eliminada con éxito', 'Success', false);", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void FormularioModoEdicion(Int32 DiligenciaId) {
			try {

				// Banderas
				this.EditMode.Value = "1";
				this.DiligenciaId.Value = DiligenciaId.ToString();

				// Leyendas de botones
				this.btnGuardar.Text = "Actualizar";
				this.btnRegresar.Text = "Cancelar";

				// Consultar Diligencia
				SelectDiligenciaForEdit();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);

			}catch (Exception ex) {
				throw (ex);
			}
		}

		void FormularioModoInicial(Boolean RecalculoDiligencias) {
			try {

				// Banderas
				this.EditMode.Value = "0";
				this.DiligenciaId.Value = "0";

				// Leyendas de botones
				this.btnGuardar.Text = "Guardar";
				this.btnRegresar.Text = "Regresar";
				
				// Controles
				this.ddlFuncionario.SelectedIndex = 0;
				this.ddlTipoDiligencia.SelectedIndex = 0;
				this.ddlLugarDiligencia.SelectedIndex = 0;
				this.wucFechaDiligencia.SetCurrentDate();
				this.txtSolicitadaPor.Text = "";
				this.ckeDetalle.Text = "";
				this.ckeResultado.Text = "";

				// Actualizar Diligencias
				if (RecalculoDiligencias) { SelectDiligencia(); }

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);

			}catch (Exception ex) {
				throw (ex);
			}
		}

		void InsertDiligencia() {
			BPDiligencia oBPDiligencia = new BPDiligencia();
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			ENTSession oENTSession;

			try
			{

				// Validaciones
				if (this.ddlFuncionario.SelectedValue == "0") { throw new Exception("El campo [Defensor que ejecuta] es requerido"); }
				if (this.ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("El campo [Tipo de diligencia] es requerido"); }
				if (this.ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("El campo [Lugar de la diligencia] es requerido"); }
				if (this.txtSolicitadaPor.Text.Trim() == "") { throw new Exception("El campo [Solicitada Por] es requerido"); }
				if (this.ckeDetalle.Text.Trim() == "") { throw new Exception("El campo [Detalle] es requerido"); }

				// Obtener la sesión
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if ( oENTSession.FuncionarioId == 0 ) { throw new Exception("No cuenta con permisos para crear diligencias debido a que usted no es un funcionario"); }

				//Formulario
				oENTDiligencia.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value);
				oENTDiligencia.FuncionarioAtiendeId = oENTSession.FuncionarioId;
				oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(this.ddlFuncionario.SelectedValue);
				oENTDiligencia.TipoDiligencia = Convert.ToInt32(this.ddlTipoDiligencia.SelectedValue);
				oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(this.ddlLugarDiligencia.SelectedValue);
				oENTDiligencia.FechaDiligencia = this.wucFechaDiligencia.BeginDate;
				oENTDiligencia.SolicitadaPor = this.txtSolicitadaPor.Text.Trim();
				oENTDiligencia.Detalle = this.ckeDetalle.Text.Trim();

				//Transacción
				oENTResponse = oBPDiligencia.InsertDiligenciaRecomendacion(oENTDiligencia);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				//Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Diligencia agregada con éxito', 'Success', false);", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectDiligencia() {
			BPDiligencia oBPDiligencias = new BPDiligencia();

			// Parámetros
			oBPDiligencias.DiligenciaEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value);
			oBPDiligencias.DiligenciaEntity.DiligenciaId = 0;

			// Transacción
			oBPDiligencias.SelectRecomendacionDiligencia();

			// Validaciones
			if (oBPDiligencias.ErrorId != 0) { throw (new Exception(oBPDiligencias.ErrorDescription)); }

			// Listado de recomendaciones
			this.gvDiligencia.DataSource = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0];
			this.gvDiligencia.DataBind();
		}

		void SelectDiligenciaForEdit(){
			BPDiligencia oBPDiligencias = new BPDiligencia();

			// Parámetros
			oBPDiligencias.DiligenciaEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value);
			oBPDiligencias.DiligenciaEntity.DiligenciaId = Int32.Parse(this.DiligenciaId.Value);

			// Transacción
			oBPDiligencias.SelectRecomendacionDiligencia();

			// Validaciones
			if (oBPDiligencias.ErrorId != 0) { throw (new Exception(oBPDiligencias.ErrorDescription)); }

			// Llenado de Formulario
			this.ddlFuncionario.SelectedValue = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FuncionarioId_Ejecuta"].ToString();
			this.ddlTipoDiligencia.SelectedValue = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0].Rows[0]["TipoDiligenciaId"].ToString();
			this.ddlLugarDiligencia.SelectedValue = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0].Rows[0]["LugarDiligenciaId"].ToString();
			this.wucFechaDiligencia.SetDate = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FechaUniversal"].ToString();
			this.txtSolicitadaPor.Text = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0].Rows[0]["SolicitadaPor"].ToString();
			this.ckeDetalle.Text = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Detalle"].ToString();
			this.ckeResultado.Text = oBPDiligencias.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Resultado"].ToString();

		}

		void SelectedExpediente() {
			BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			// Parámetros
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value );

			// Transacción
			BPSeguimientoRecomendacion.SelectExpediente_DetalleSeguimientos();

			// Errores
			if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

			// No se encontró el expediente
			if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count == 0){ throw (new Exception("No se encontro el expediente")); }

			// Formulario
			this.ExpedienteNumeroLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["ExpedienteNumero"].ToString();
			this.CalificacionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["CalificacionNombre"].ToString();
			this.EstatusLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["EstatusNombre"].ToString();
			this.TipoSolicitudLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["TipoSolicitudNombre"].ToString();
			this.DefensorLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["DefensorNombre"].ToString();

			this.FechaRecepcionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaRecepcion"].ToString();
			this.FechaAsignacionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaAsignacion"].ToString();
			this.FechaInicioLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaInicioGestion"].ToString();
			this.FechaUltimaLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaUltimaModificacion"].ToString();

			this.ObservacionesLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
			this.LugarHechosLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["LugarHechosNombre"].ToString();
			this.DireccionHechosLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();

		}

		void SelectedFuncionario(){
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();

			BPFuncionario oBPFuncionario = new BPFuncionario();

			try
			{

				// Formulario
				oENTFuncionario.FuncionarioId = 0;
				oENTFuncionario.idUsuario = 0;
				oENTFuncionario.idArea = 0;
				oENTFuncionario.idRol = 11;			// Seguimiento - Defensor
				oENTFuncionario.TituloId = 0;
				oENTFuncionario.PuestoId = 0;
				oENTFuncionario.Nombre = "";

				// Transacción
				oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(oENTResponse.sMessage) + "', 'Warning', false);", true); }

				// Llenado de combo
				this.ddlFuncionario.DataTextField = "sFullName";
				this.ddlFuncionario.DataValueField = "FuncionarioId";
				this.ddlFuncionario.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlFuncionario.DataBind();

				// Agregar Item de selección
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

		void UpdateDiligencia() {
			BPDiligencia oBPDiligencia = new BPDiligencia();
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			ENTSession oENTSession;

			try
			{

				// Validaciones
				if (this.ddlFuncionario.SelectedValue == "0") { throw new Exception("El campo [Defensor que ejecuta] es requerido"); }
				if (this.ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("El campo [Tipo de diligencia] es requerido"); }
				if (this.ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("El campo [Lugar de la diligencia] es requerido"); }
				if (this.txtSolicitadaPor.Text.Trim() == "") { throw new Exception("El campo [Solicitada Por] es requerido"); }
				if (this.ckeDetalle.Text.Trim() == "") { throw new Exception("El campo [Detalle] es requerido"); }

				// Obtener la sesión
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if ( oENTSession.FuncionarioId == 0 ) { throw new Exception("No cuenta con permisos para crear diligencias debido a que usted no es un funcionario"); }

				//Formulario
				oENTDiligencia.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value);
				oENTDiligencia.DiligenciaId = Int32.Parse(this.DiligenciaId.Value);
				oENTDiligencia.FuncionarioAtiendeId = oENTSession.FuncionarioId;
				oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(this.ddlFuncionario.SelectedValue);
				oENTDiligencia.TipoDiligencia = Convert.ToInt32(this.ddlTipoDiligencia.SelectedValue);
				oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(this.ddlLugarDiligencia.SelectedValue);
				oENTDiligencia.FechaDiligencia = this.wucFechaDiligencia.BeginDate;
				oENTDiligencia.SolicitadaPor = this.txtSolicitadaPor.Text.Trim();
				oENTDiligencia.Detalle = this.ckeDetalle.Text.Trim();
				oENTDiligencia.Resultado = this.ckeResultado.Text.Trim();

				//Transacción
				oENTResponse = oBPDiligencia.UpdateDiligenciaRecomendacion(oENTDiligencia);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				//Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Diligencia actualizada con éxito', 'Success', false);", true);

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
				this.ExpedienteIdHidden.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Llenado de controles
				SelectedExpediente();
				SelectedFuncionario();
				SelectTipoDiligencia();
				SelectLugarDiligencia();
				SelectDiligencia();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);
            }
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

                // Determinar el tipo de transacción
				if (this.EditMode.Value == "0"){

					InsertDiligencia();
				}else {

					UpdateDiligencia();
				}

				// Estado inicial del formulario
				FormularioModoInicial(true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			try
            {

                // Determinar el tipo de transacción
				if (this.EditMode.Value == "0"){

					Response.Redirect("segDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);
				}else {

					FormularioModoInicial(false);
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);
            }
		}

		protected void gvDiligencia_RowCommand(object sender, GridViewCommandEventArgs e){
			Int32 DiligenciaId = 0;
			Int32 intRow = 0;

			String strCommand = "";

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Fila
				intRow = Int32.Parse(e.CommandArgument.ToString());

				// DataKeys
				DiligenciaId = Int32.Parse(this.gvDiligencia.DataKeys[intRow]["DiligenciaId"].ToString());

				// Acción
				switch (strCommand){
					case "Editar":
						FormularioModoEdicion(DiligenciaId);
						break;

					case "Eliminar":
						DeleteDiligencia(DiligenciaId);
						FormularioModoInicial(true);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);
			}
		}

		protected void gvDiligencia_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;

			String sImagesAttributes = "";
			String sTootlTip = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// Tooltip Edición
				sTootlTip = "Editar Diligencia";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Delete
				sTootlTip = "Eliminar Diligencia";
				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				// Imagen del botón [imgDelete]
				imgDelete.ImageUrl = "../../../../Include/Image/Buttons/Delete.png";

				// Atributos Over
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
				sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

				// Puntero y Sombra en fila Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
				sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

				// Puntero y Sombra en fila Out
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvDiligencia_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvDiligencia, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);
			}
		}

	}
}