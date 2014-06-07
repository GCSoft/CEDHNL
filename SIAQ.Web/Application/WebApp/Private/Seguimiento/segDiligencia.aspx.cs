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

		void InsertSeguimientoRecomendacion() {
			BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			// Validaciones
			if (this.ddlFuncionario.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un funcionario")); }

			// Parámetros
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value.Trim());
			BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedItem.Value);

			// Transacción
			BPSeguimientoRecomendacion.InsertSeguimientoRecomendacion();

			// Errores
			if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

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

			// Grid
			this.gvRecomendacion.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[1];
			this.gvRecomendacion.DataBind();

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
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

                // Obtener Expedientes
				InsertSeguimientoRecomendacion();

				// Regresar al detalle del formulario
				Response.Redirect("segDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlFuncionario.ClientID + "');", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("segDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);
		}

		protected void gvRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e){
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

		protected void gvRecomendacion_Sorting(object sender, GridViewSortEventArgs e){
			DataTable TableAutoridad = null;
			DataView ViewAutoridad = null;

			try
			{
				//Obtener DataTable y View del GridView
				TableAutoridad = utilFunction.ParseGridViewToDataTable(gvRecomendacion, false);
				ViewAutoridad = new DataView(TableAutoridad);

				//Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				//Ordenar Vista
				ViewAutoridad.Sort = hddSort.Value;

				//Vaciar datos
				this.gvRecomendacion.DataSource = ViewAutoridad;
				this.gvRecomendacion.DataBind();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}


		//#region Atributos

		//Function utilFunction = new Function();
		//protected string RecomendacionId;
		//protected string NumeroRecomendacion;

		//#endregion

		//#region Propiedades

		//#endregion

		//#region Eventos

		//protected void Page_Load(object sender, EventArgs e)
		//{
		//    if (Page.IsPostBack) { return; }

		//    RecomendacionId = GetRawQueryParameter("recId");
		//    NumeroRecomendacion = GetRawQueryParameter("numRec");

		//    hdnRecomendacionId.Value = RecomendacionId;

		//    ComboFuncionariosEjecuta();
		//    ComboLugarDiligencia();
		//    ComboTipoDiligencia();
		//    GridDiligencias(RecomendacionId);
		//    LlenarDetalle(NumeroRecomendacion);
		//}

		//#region "Grid diligencias"

		//protected void gvDiligenciasRecomendacion_RowCommand(object sender, GridViewCommandEventArgs e)
		//{
		//    string ExpedienteId = string.Empty;
		//    string DiligenciaId = string.Empty;
		//    int intRow = 0;

		//    try
		//    {
		//        string sCommandName = e.CommandName.ToString();

		//        if (sCommandName == "Sort") { return; }

		//        //Fila 
		//        intRow = Convert.ToInt32(e.CommandArgument.ToString());

		//        // ExpedienteId 
		//        ExpedienteId = hdnRecomendacionId.Value;
		//        if (String.IsNullOrEmpty(ExpedienteId)) { ExpedienteId = GetRawQueryParameter("recId"); }
		//        DiligenciaId = gvDiligenciasRecomendacion.DataKeys[intRow]["DiligenciaId"].ToString();

		//        switch (sCommandName)
		//        {
		//            case "Editar":
		//                MostrarDatosEdicion(ExpedienteId, DiligenciaId);
		//                break;

		//            case "Borrar":
		//                EliminarDiligencia(ExpedienteId, DiligenciaId);
		//                break;
		//        }

		//    }
		//    catch (Exception ex)
		//    {
		//        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
		//    }
		//}

		//protected void gvDiligenciasRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e)
		//{
		//    ImageButton imgEdit = null;
		//    ImageButton imgDelete = null;

		//    String sImagesAttributes = "";
		//    String sToolTip = "";
		//    String sNumeroDiligencia = "";

		//    String sImagesAttributesDelete = "";
		//    String sToolTipDelete = "";

		//    try
		//    {
		//        //Validación de que sea fila 
		//        if (e.Row.RowType != DataControlRowType.DataRow) { return; }

		//        //Obtener imagenes
		//        imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
		//        imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

		//        sNumeroDiligencia = gvDiligenciasRecomendacion.DataKeys[e.Row.RowIndex]["DiligenciaId"].ToString();

		//        //Tooltip Edición
		//        sToolTip = "Editar diligencia [" + sNumeroDiligencia + "]";
		//        sToolTipDelete = "Eliminar diligencia [" + sNumeroDiligencia + "]";

		//        imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
		//        imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
		//        imgEdit.Attributes.Add("style", "cursor:hand;");

		//        imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTipDelete + "', 'Izq');");
		//        imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
		//        imgDelete.Attributes.Add("style", "cursor:hand;");

		//        //Atributos Over
		//        sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png';";
		//        sImagesAttributesDelete = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";

		//        //Puntero y Sombra en fila Over
		//        e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes + sImagesAttributesDelete);

		//        //Atributos Out
		//        sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
		//        sImagesAttributesDelete = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";

		//        //Puntero y Sombra en fila Out
		//        e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes + sImagesAttributesDelete);
		//    }
		//    catch (Exception ex)
		//    {
		//        throw (ex);
		//    }
		//}

		//protected void gvDiligenciasRecomendacion_Sorting(object sender, GridViewSortEventArgs e)
		//{
		//    DataTable TableRecomendacion = null;
		//    DataView ViewRecomendacion = null;

		//    try
		//    {
		//        //Obtener DataTable y View del GridView
		//        TableRecomendacion = utilFunction.ParseGridViewToDataTable(gvDiligenciasRecomendacion, false);
		//        ViewRecomendacion = new DataView(TableRecomendacion);

		//        //Determinar ordenamiento
		//        hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

		//        //Ordenar Vista
		//        ViewRecomendacion.Sort = hddSort.Value;

		//        //Vaciar datos
		//        gvDiligenciasRecomendacion.DataSource = ViewRecomendacion;
		//        gvDiligenciasRecomendacion.DataBind();

		//    }
		//    catch (Exception ex)
		//    {
		//        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
		//    }
		//}

		//#endregion

		//#region "Botones

		//protected void btnRegresar_Click(object sender, EventArgs e)
		//{
		//    if (String.IsNullOrEmpty(RecomendacionId))
		//    {
		//        RecomendacionId = hdnRecomendacionId.Value;
		//    }

		//    Response.Redirect("~/Application/WebApp/Private/Visitaduria/opeDetalleSolicitud.aspx?recId=" + RecomendacionId);
		//}

		//protected void btnGuardar_Click(object sender, EventArgs e)
		//{
		//    string recomendacionId = hdnRecomendacionId.Value;
		//    if (String.IsNullOrEmpty(recomendacionId)) { recomendacionId = GetRawQueryParameter("recId"); }

		//    string diligenciaId = hdnDiligenciaId.Value;

		//    try
		//    {
		//        if (String.IsNullOrEmpty(diligenciaId))
		//        {
		//            //Agregar
		//            AgregarDiligencia(recomendacionId);
		//            GridDiligencias(recomendacionId);
		//            LimpiarControles();
		//        }
		//        else
		//        {
		//            //Modificar
		//            ModificarDiligencia(recomendacionId, diligenciaId);
		//            GridDiligencias(recomendacionId);
		//            LimpiarControles();
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        ScriptManager.RegisterStartupScript(this.Page
		//            , this.GetType()
		//            , Convert.ToString(Guid.NewGuid())
		//            , "tinyboxMessage('" + ex.Message + "', 'Fail', true);"
		//            , true);
		//    }
		//}

		//#endregion

		//#endregion

		//#region Funciones

		//public string GetRawQueryParameter(string parameterName)
		//{
		//    string raw = Request.RawUrl;
		//    int startQueryIdx = raw.IndexOf('?');
		//    if (startQueryIdx < 0)
		//        return null;

		//    int nameLength = parameterName.Length + 1;
		//    int startIdx = raw.IndexOf(parameterName + "=", startQueryIdx);
		//    if (startIdx < 0)
		//        return null;

		//    startIdx += nameLength;
		//    int endIdx = raw.IndexOf('&', startIdx);
		//    if (endIdx < 0)
		//        endIdx = raw.Length;

		//    return raw.Substring(startIdx, endIdx - startIdx);
		//}

		//private void ComboFuncionariosEjecuta()
		//{
		//    BPFuncionario oBPFuncionario = new BPFuncionario();

		//    oBPFuncionario.SelectFuncionarioRecomendacion();

		//    if (oBPFuncionario.ErrorId == 0)
		//    {
		//        if (oBPFuncionario.FuncionarioEntity.ResultData.Tables[0].Rows.Count > 0)
		//        {
		//            ddlVisitadorEjecuta.DataSource = oBPFuncionario.FuncionarioEntity.ResultData;
		//            ddlVisitadorEjecuta.DataTextField = "FuncionarioNombre";
		//            ddlVisitadorEjecuta.DataValueField = "FuncionarioId";
		//            ddlVisitadorEjecuta.DataBind();
		//        }
		//    }
		//}



		//private void GridDiligencias(string recomendacionId)
		//{
		//    BPDiligencia oBPDiligencias = new BPDiligencia();

		//    oBPDiligencias.DiligenciaEntity.SolicitudId = Convert.ToInt32(recomendacionId);
		//    oBPDiligencias.SelectDiligencias();

		//    if (oBPDiligencias.ErrorId == 0)
		//    {

		//        if (oBPDiligencias.DiligenciaEntity.DataResult.Tables[2].Rows.Count > 0)
		//        {
		//            gvDiligenciasRecomendacion.DataSource = oBPDiligencias.DiligenciaEntity.DataResult.Tables[2];
		//            gvDiligenciasRecomendacion.DataBind();
		//        }
		//        else
		//        {
		//            gvDiligenciasRecomendacion.DataSource = null;
		//            gvDiligenciasRecomendacion.DataBind();
		//        }
		//    }
		//    else
		//    {
		//        gvDiligenciasRecomendacion.DataSource = null;
		//        gvDiligenciasRecomendacion.DataBind();
		//    }
		//}

		//private void LlenarDetalle(string numeroRecomendacion)
		//{
		//    ENTSession oENTSession;

		//    oENTSession = (ENTSession)this.Session["oENTSession"];


		//    SolicitudLabel.Text = numeroRecomendacion;
		//    VisitadorAtiendeLabel.Text = oENTSession.sNombre;
		//    FechaRegistroLabel.Text = DateTime.Now.ToShortDateString();
		//}

		//private void AgregarDiligencia(string recomendacionId)
		//{
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
		//}

		//private void ModificarDiligencia(string recomendacionId, string diligenciaId)
		//{
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

		//}

		//private void EliminarDiligencia(string recomendacionId, string diligenciaId)
		//{
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
		//}

		//private void LimpiarControles()
		//{
		//    ddlVisitadorEjecuta.SelectedIndex = 0;
		//    calFecha.SetCurrentDate();
		//    ddlTipoDiligencia.SelectedIndex = 0;
		//    ddlLugarDiligencia.SelectedIndex = 0;
		//    txtCampo.Text = String.Empty;
		//    txtSolicitadaPor.Text = String.Empty;
		//    txtResultado.Text = String.Empty;
		//    hdnDiligenciaId.Value = String.Empty;

		//    ddlVisitadorEjecuta.Focus();

		//}

		//private void MostrarDatosEdicion(string recomendacionId, string diligenciaId)
		//{
		//    BPDiligencia oBPDiligencia = new BPDiligencia();

		//    oBPDiligencia.DiligenciaEntity.RecomendacionId = Convert.ToInt32(recomendacionId);
		//    oBPDiligencia.DiligenciaEntity.DiligenciaId = Convert.ToInt32(diligenciaId);

		//    oBPDiligencia.SelectDetalleDiligenciaRecomendacion();

		//    if (oBPDiligencia.ErrorId == 0)
		//    {
		//        if (oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows.Count > 0)
		//        {
		//            hdnDiligenciaId.Value = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["DiligenciaId"].ToString();
		//            ddlVisitadorEjecuta.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FuncionarioEjecuta"].ToString();
		//            calFecha.SetDate = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["FechaDiligencia"].ToString();
		//            ddlTipoDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["TipoDiligencia"].ToString();
		//            ddlLugarDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["LugarDiligencia"].ToString();
		//            txtCampo.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Detalle"].ToString();
		//            txtSolicitadaPor.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["SolicitadaPor"].ToString();
		//            txtResultado.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[0].Rows[0]["Resultado"].ToString();
		//        }
		//    }
		//}

		//#endregion
	}
}