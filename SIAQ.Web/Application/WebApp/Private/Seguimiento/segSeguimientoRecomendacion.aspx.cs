/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	segSeguimientoRecomendacion
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
using GCSoft.Utilities.Common;
using GCSoft.Utilities.Security;
using SIAQ.Entity.Object;
using SIAQ.BusinessProcess.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Seguimiento
{
	public partial class segSeguimientoRecomendacion : System.Web.UI.Page
	{
		
		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Rutinas del programador

		void InsertSeguimientoRecomendacion() {
			//BPSeguimientoRecomendacion BPSeguimientoRecomendacion = new BPSeguimientoRecomendacion();

			//// Validaciones
			//if (this.ddlTipoSeguimiento.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar un TipoSeguimiento")); }

			//// Parámetros
			//BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.ExpedienteId = Int32.Parse(this.ExpedienteIdHidden.Value.Trim());
			//BPSeguimientoRecomendacion.SeguimientoRecomendacionEntity.TipoSeguimientoId = Int32.Parse(this.ddlTipoSeguimiento.SelectedItem.Value);

			//// Transacción
			//BPSeguimientoRecomendacion.InsertSeguimientoRecomendacion();

			//// Errores
			//if (BPSeguimientoRecomendacion.ErrorId != 0) { throw (new Exception(BPSeguimientoRecomendacion.ErrorString)); }

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

		void SelectedTipoSeguimiento(){
			ENTTipoSeguimiento oENTTipoSeguimiento = new ENTTipoSeguimiento();
			ENTResponse oENTResponse = new ENTResponse();

			BPTipoSeguimiento oBPTipoSeguimiento = new BPTipoSeguimiento();

			try
			{

				// Formulario
				oENTTipoSeguimiento.TipoSeguimientoId = 0;
				oENTTipoSeguimiento.Nombre = "";

				// Transacción
				oENTResponse = oBPTipoSeguimiento.SelectTipoSeguimiento(oENTTipoSeguimiento);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);", true); }

				// Llenado de combo
				this.ddlTipoSeguimiento.DataTextField = "Nombre";
				this.ddlTipoSeguimiento.DataValueField = "TipoSeguimientoId";
				this.ddlTipoSeguimiento.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlTipoSeguimiento.DataBind();

				// Agregar Item de selección
				this.ddlTipoSeguimiento.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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
				this.ExpedienteIdHidden.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Llenado de controles
				SelectedExpediente();
				SelectedTipoSeguimiento();

				// Seleccionar la recomendación
				if (this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[2].ToString() != "0") {
					this.ddlRecomendacion.SelectedValue = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[2].ToString();
				}
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlRecomendacion.ClientID + "');", true);

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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlRecomendacion.ClientID + "');", true);
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

	}
}