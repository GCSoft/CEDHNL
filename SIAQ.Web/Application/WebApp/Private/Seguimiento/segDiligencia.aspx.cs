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
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segDiligencia : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador

		void DeleteDiligencia() {
			//    ENTResponse oENTResponse = new ENTResponse();
			//    ENTDiligencia oENTDiligencia = new ENTDiligencia();
			//    BPDiligencia oBPDiligencia = new BPDiligencia();

			//    try
			//    {
			//        oENTDiligencia.DiligenciaId = Convert.ToInt32(diligenciaId);
			//        oENTDiligencia.RecomendacionId = Convert.ToInt32(recomendacionId);

			//        oENTResponse = oBPDiligencia.DeleteDiligenciaRecomendacion(oENTDiligencia);

			//        if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			//        if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			//        GridDiligencias(recomendacionId);
			//    }
			//    catch (Exception ex)
			//    {
			//        throw (ex);
			//    }
		}

		void InsertDiligencia() {
			//    ENTResponse oENTResponse = new ENTResponse();
			//    ENTDiligencia oENTDiligencia = new ENTDiligencia();
			//    ENTSession oENTSession;

			//    oENTSession = (ENTSession)this.Session["oENTSession"];
			//    BPDiligencia oBPDiligencia = new BPDiligencia();

			//    if (ddlVisitadorEjecuta.SelectedValue == "0") { throw new Exception("* El campo [Visitador que ejecuta] es requerido"); }
			//    if (String.IsNullOrEmpty(calFecha.DisplayDate)) { throw new Exception("* El campo [Fecha de la diligencia] es requerido"); }
			//    if (ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Tipo de diligencia] es requerido"); }
			//    if (ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Lugar de diligencia] es requerido"); }
			//    if (String.IsNullOrEmpty(txtCampo.Text)) { throw new Exception("* El campo [Detalle] es requerido"); }
			//    if (String.IsNullOrEmpty(txtSolicitadaPor.Text)) { throw new Exception("* El campo [Solicitada por] es requerido"); }
			//    if (String.IsNullOrEmpty(txtResultado.Text)) { throw new Exception("* El campo [Resultado] es requerido"); }

			//    try
			//    {
			//        //Formulario
			//        oENTDiligencia.RecomendacionId = Convert.ToInt32(recomendacionId);
			//        oENTDiligencia.FuncionarioAtiendeId = oENTSession.FuncionarioId;
			//        oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlVisitadorEjecuta.SelectedValue);
			//        oENTDiligencia.FechaDiligencia = Convert.ToDateTime(calFecha.DisplayDate);
			//        oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
			//        oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
			//        oENTDiligencia.Detalle = txtCampo.Text;
			//        oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
			//        oENTDiligencia.Resultado = txtResultado.Text;

			//        //Transacción
			//        oENTResponse = oBPDiligencia.InsertDiligenciaRecomendacion(oENTDiligencia);

			//        //Validación
			//        if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			//        if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			//        //Mensaje de usuario
			//        ScriptManager.RegisterStartupScript(this.Page
			//            , this.GetType()
			//            , Convert.ToString(Guid.NewGuid())
			//            , "tinyboxMessage('Diligencia agregada con éxito', 'Success', true);"
			//            , true);
			//    }
			//    catch (Exception ex)
			//    {
			//        throw (ex);
			//    }


		}

		void LimpiarFormulario(Boolean RecalculoDiligencias) {
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
				oENTFuncionario.idArea = 10;	// Seguimientos
				oENTFuncionario.TituloId = 0;
				oENTFuncionario.PuestoId = 0;
				oENTFuncionario.Nombre = "";

				// Transacción
				oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);", true); }

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
			//    ENTResponse oENTResponse = new ENTResponse();
			//    ENTDiligencia oENTDiligencia = new ENTDiligencia();
			//    BPDiligencia oBPDiligencia = new BPDiligencia();


			//    if (ddlVisitadorEjecuta.SelectedValue == "0") { throw new Exception("* El campo [Visitador que ejecuta] es requerido"); }
			//    if (String.IsNullOrEmpty(calFecha.DisplayDate)) { throw new Exception("* El campo [Fecha de la diligencia] es requerido"); }
			//    if (ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Tipo de diligencia] es requerido"); }
			//    if (ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Lugar de diligencia] es requerido"); }
			//    if (String.IsNullOrEmpty(txtCampo.Text)) { throw new Exception("* El campo [Detalle] es requerido"); }
			//    if (String.IsNullOrEmpty(txtSolicitadaPor.Text)) { throw new Exception("* El campo [Solicitada por] es requerido"); }
			//    if (String.IsNullOrEmpty(txtResultado.Text)) { throw new Exception("* El campo [Resultado] es requerido"); }

			//    try
			//    {
			//        //Formulario
			//        oENTDiligencia.DiligenciaId = Convert.ToInt32(diligenciaId);
			//        oENTDiligencia.RecomendacionId = Convert.ToInt32(recomendacionId);
			//        oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlVisitadorEjecuta.SelectedValue);
			//        oENTDiligencia.FechaDiligencia = Convert.ToDateTime(calFecha.DisplayDate);
			//        oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
			//        oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
			//        oENTDiligencia.Detalle = txtCampo.Text;
			//        oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
			//        oENTDiligencia.Resultado = txtResultado.Text;

			//        //Transacción
			//        oENTResponse = oBPDiligencia.UpdateDiligenciaRecomendacion(oENTDiligencia);

			//        //Validación
			//        if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			//        if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			//        //Mensaje usuario
			//        ScriptManager.RegisterStartupScript(this.Page
			//            , this.GetType()
			//            , Convert.ToString(Guid.NewGuid())
			//            , "tinyboxMessage('Diligencia modificada con éxito', 'Success', true);"
			//            , true);

			//    }

			//    catch (Exception ex)
			//    {
			//        throw (ex);
			//    }
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
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
				LimpiarFormulario(true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			try
            {

                // Determinar el tipo de transacción
				if (this.EditMode.Value == "0"){

					Response.Redirect("segDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);
				}else {

					LimpiarFormulario(false);
				}

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);
            }
		}

		protected void gvDiligencia_RowDataBound(object sender, GridViewRowEventArgs e){
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

		protected void gvDiligencia_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblData = null;
			DataView viewData = null;

			try
			{
				//Obtener DataTable y View del GridView
				tblData = utilFunction.ParseGridViewToDataTable(gvDiligencia, false);
				viewData = new DataView(tblData);

				//Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				//Ordenar Vista
				viewData.Sort = hddSort.Value;

				//Vaciar datos
				this.gvDiligencia.DataSource = viewData;
				this.gvDiligencia.DataBind();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

	}
}