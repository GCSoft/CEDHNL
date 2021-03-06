﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	segConfirmarCierreExpediente
' Autor:	Ruben.Cobos
' Fecha:	06-Junio-2014
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
	public partial class segConfirmarCierreExpediente : System.Web.UI.Page
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();


		// Rutinas del programador

		//void CerrarExpedienteDirector() {
		//    BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

		//    // Parámetros
		//    BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value.Trim());
		//    BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.EstatusId = 12; // Expediente cerrado

		//    // Transacción
		//    //BPSeguimientoRecomendacion.ActualizaEstatusExpedienteSeguimiento();

		//    // Errores
		//    if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

		//}

		//void DenegarCierre() {
		//    BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

		//    // Parámetros
		//    BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value.Trim());
		//    BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.EstatusId = 10; // Por atender expediente

		//    // Transacción
		//    //BPSeguimientoRecomendacion.ActualizaEstatusExpedienteSeguimiento();

		//    // Errores
		//    if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

		//}

		//void SelectedExpediente() {
		//    BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

		//    // Parámetros
		//    BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value );

		//    // Transacción
		//    //BPSeguimientoRecomendacion.SelectExpediente_DetalleSeguimientos();

		//    // Errores
		//    if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

		//    // No se encontró el expediente
		//    if (BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows.Count == 0){ throw (new Exception("No se encontro el expediente")); }

		//    // Formulario
		//    this.ExpedienteNumeroLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["ExpedienteNumero"].ToString();
		//    this.CalificacionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["CalificacionNombre"].ToString();
		//    this.EstatusLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["EstatusNombre"].ToString();
		//    this.TipoSolicitudLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["TipoSolicitudNombre"].ToString();
		//    this.DefensorLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["DefensorNombre"].ToString();

		//    this.FechaRecepcionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaRecepcion"].ToString();
		//    this.FechaAsignacionLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaAsignacion"].ToString();
		//    this.FechaInicioLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaInicioGestion"].ToString();
		//    this.FechaUltimaLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["FechaUltimaModificacion"].ToString();

		//    this.ObservacionesLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["Observaciones"].ToString();
		//    this.LugarHechosLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["LugarHechosNombre"].ToString();
		//    this.DireccionHechosLabel.Text = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[0].Rows[0]["DireccionHechos"].ToString();

		//    // Grid
		//    this.gvRecomendacion.DataSource = BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ResultData.Tables[1];
		//    this.gvRecomendacion.DataBind();

		//}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			//try
			//{

			//    // Validaciones
			//    if (Page.IsPostBack) { return; }
			//    if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
			//    if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

			//    // Obtener ExpedienteId
			//    this.ExpedienteIdHidden.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

			//    // Obtener Sender
			//    this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

			//    // Llenado de controles
			//    SelectedExpediente();

			//}catch (Exception ex){
			//    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			//}
		}

		//protected void btnCerrar_Click(object sender, EventArgs e){
		//    try
		//    {

		//        // Obtener Expedientes
		//        CerrarExpedienteDirector();

		//        // Regresar a la pantalla de el listado de expedientes
		//        Response.Redirect("segListadoExpediente.aspx", false);

		//    }catch (Exception ex){
		//        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
		//    }
		//}

		//protected void btnDenegar_Click(object sender, EventArgs e){
		//    try
		//    {

		//        // Obtener Expedientes
		//        DenegarCierre();

		//        // Regresar al detalle del expediente
		//        Response.Redirect("segDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);

		//    }catch (Exception ex){
		//        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
		//    }
		//}

		//protected void btnRegresar_Click(object sender, EventArgs e){
		//    Response.Redirect("segDetalleExpediente.aspx?key=" + this.ExpedienteIdHidden.Value + "|" + this.SenderId.Value, false);
		//}

		//protected void gvRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e){
		//    try
		//    {
				
		//        // Validación de que sea fila 
		//        if (e.Row.RowType != DataControlRowType.DataRow) { return; }

		//        // Atributos Over
		//        e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");

		//        // Atributos Out
		//        e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

		//    }catch (Exception ex){
		//        throw (ex);
		//    }
		//}

		//protected void gvRecomendacion_Sorting(object sender, GridViewSortEventArgs e){
		//    try
		//    {

		//        gcCommon.SortGridView(ref this.gvRecomendacion, ref this.hddSort, e.SortExpression);

		//    }catch (Exception ex){
		//        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
		//    }
		//}

	}
}