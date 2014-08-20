/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visSeguimientoExpediente
' Autor:	Ruben.Cobos
' Fecha:	19-Agosto-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Visitaduria
{
    public partial class visSeguimientoExpediente : System.Web.UI.Page
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

		void DeleteExpedienteSeguimiento(String ExpedienteSeguimientoId){
			BPExpedienteSeguimiento ExpedienteSeguimientoProcess = new BPExpedienteSeguimiento();

			// Parámetros
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteSeguimientoId = Int32.Parse(ExpedienteSeguimientoId);
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ModuloId = 3;

			// Transacción
			ExpedienteSeguimientoProcess.DeleteExpedienteSeguimiento();

			// Validaciones
			if (ExpedienteSeguimientoProcess.ErrorId != 0) { throw (new Exception(ExpedienteSeguimientoProcess.ErrorDescription)); }

			// Limpiar el formulario
			ResetForm();

			// Actualizar la información
			SelectExpedienteSeguimiento();

		}

		void ResetForm(){
			this.wucFecha.SetCurrentDate();
			this.ddlTipoSeguimiento.SelectedIndex = 0;
			this.ckeSeguimiento.Text = "";
			this.hddExpedienteSeguimientoId.Value = "0";
		}

		void SaveExpedienteSeguimiento(){
			BPExpedienteSeguimiento ExpedienteSeguimientoProcess = new BPExpedienteSeguimiento();
			ENTSession SessionEntity = new ENTSession();

			// Validaciones
			if (this.ddlTipoSeguimiento.SelectedIndex == 0) { throw new Exception("El campo [Tipo de seguimiento] es requerido"); }
			if (this.ckeSeguimiento.Text.Trim() == "") { throw new Exception("El campo [Detalle] es requerido"); }

			// Obtener la sesión
			SessionEntity = (ENTSession)Session["oENTSession"];

			// Parámetros
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteSeguimientoId = Int32.Parse(this.hddExpedienteSeguimientoId.Value);
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ModuloId = 3;
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.FuncionarioId = SessionEntity.FuncionarioId;
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.TipoSeguimientoId = Int32.Parse(this.ddlTipoSeguimiento.SelectedItem.Value);
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.Fecha = this.wucFecha.BeginDate;
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.Detalle = this.ckeSeguimiento.Text.Trim();

			// Transacción
			ExpedienteSeguimientoProcess.SaveExpedienteSeguimiento();

			// Validaciones
			if (ExpedienteSeguimientoProcess.ErrorId != 0) { throw (new Exception(ExpedienteSeguimientoProcess.ErrorDescription)); }

			// Limpiar el formulario
			ResetForm();

			// Actualizar la información
			SelectExpedienteSeguimiento();
		}

		void SelectExpediente() {
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpediente_Detalle(oENTVisitaduria);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Campos ocultos
				this.hddAreaId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["AreaId"].ToString();
				this.hddExpedienteId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteId"].ToString();

				// Formulario
				this.ExpedienteNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ExpedienteNumero"].ToString();
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Afectado"].ToString();
				this.AreaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["AreaNombre"].ToString();

				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();
				this.ProblematicaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaNombre"].ToString();
				this.ProblematicaDetalleLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaQuejasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaQuejas"].ToString();
				this.FechaVisitaduriasLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaVisitadurias"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();

				this.TipoOrientacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoOrientacionNombre"].ToString();
				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();
				this.FundamentoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Fundamento"].ToString();

				// Canalizaciones
				if (oENTResponse.dsResponse.Tables[2].Rows.Count > 0){

					this.CanalizacionesLabel.Visible = true;

					this.grdCanalizacion.DataSource = oENTResponse.dsResponse.Tables[2];
					this.grdCanalizacion.DataBind();
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectExpedienteSeguimiento(String ExpedienteSeguimientoId){
			BPExpedienteSeguimiento ExpedienteSeguimientoProcess = new BPExpedienteSeguimiento();

			// Parámetros
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteSeguimientoId = Int32.Parse( ExpedienteSeguimientoId );
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteId = Int32.Parse( this.hddExpedienteId.Value );

			// Transacción
			ExpedienteSeguimientoProcess.SelectExpedienteSeguimiento();

			// Validaciones
			if (ExpedienteSeguimientoProcess.ErrorId != 0) { throw (new Exception(ExpedienteSeguimientoProcess.ErrorDescription)); }
			if (ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ResultData.Tables[0].Rows.Count == 0) { throw (new Exception("No se encontró información de la gestión para el expediente")); }
			
			// Llenado de formulario
			this.wucFecha.SetDateTime = DateTime.Parse(ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ResultData.Tables[0].Rows[0]["Fecha"].ToString());
			this.ddlTipoSeguimiento.SelectedValue = ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ResultData.Tables[0].Rows[0]["TipoSeguimientoId"].ToString();
			this.ckeSeguimiento.Text = ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ResultData.Tables[0].Rows[0]["Detalle"].ToString();

			// Id a trabajar
			this.hddExpedienteSeguimientoId.Value = ExpedienteSeguimientoId.ToString();
		}

		void SelectExpedienteSeguimiento(){
			BPExpedienteSeguimiento ExpedienteSeguimientoProcess = new BPExpedienteSeguimiento();

			// Estado inicial
			this.gvSeguimiento.DataSource = null;
			this.gvSeguimiento.DataBind();

			// Parámetros
			ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);

			// Transacción
			ExpedienteSeguimientoProcess.SelectExpedienteSeguimiento();

			// Validaciones
			if (ExpedienteSeguimientoProcess.ErrorId != 0) { throw (new Exception(ExpedienteSeguimientoProcess.ErrorDescription)); }

			// Bind
			this.gvSeguimiento.DataSource = ExpedienteSeguimientoProcess.ExpedienteSeguimientoEntity.ResultData;
			this.gvSeguimiento.DataBind();
		}

		void SelectTipoSeguimiento(){
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
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

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

				// Obtener ExpedienteId
				this.hddExpedienteId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = sKey.Split(new Char[] { '|' })[1];

				// Carátula
				SelectExpediente();

				// Llenado de controles
				SelectTipoSeguimiento();
				SelectExpedienteSeguimiento();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlTipoSeguimiento.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoSeguimiento.ClientID + "'); }", true);
            }
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

				// Guardar/Actualizar el seguimiento
				SaveExpedienteSeguimiento();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoSeguimiento.ClientID + "'); }", true);
            }
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visDetalleExpediente.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoSeguimiento.ClientID + "'); }", true);
            }
		}

		protected void gvSeguimiento_RowCommand(object sender, GridViewCommandEventArgs e){
			String ExpedienteSeguimientoId;
			String CommandName;

			Int32 iRow = 0;

			try
			{
				
				// Opción seleccionada
				CommandName = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (CommandName == "Sort") { return; }

				// Fila
				iRow = Convert.ToInt32(e.CommandArgument.ToString());

				// DataKeys
				ExpedienteSeguimientoId = gvSeguimiento.DataKeys[iRow]["ExpedienteSeguimientoId"].ToString();

				// Acción
				switch (CommandName){
					case "Editar":
						SelectExpedienteSeguimiento(ExpedienteSeguimientoId);
						break;

					case "Borrar":
						DeleteExpedienteSeguimiento(ExpedienteSeguimientoId);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoSeguimiento.ClientID + "'); }", true);
			}
		}

		protected void gvSeguimiento_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;

			String sImagesAttributes = "";
			String sToolTip = "";
			String FechaGestion = "";

			String sImagesAttributesDelete = "";
			String sToolTipDelete = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				FechaGestion = gvSeguimiento.DataKeys[e.Row.RowIndex]["Fecha"].ToString();

				// Tooltip Edición
				sToolTip = "Editar gestión con fecha del " + FechaGestion;
				sToolTipDelete = "Eliminar gestión con fecha del " + FechaGestion;

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

		protected void gvSeguimiento_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvSeguimiento, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoSeguimiento.ClientID + "'); }", true);
			}
		}

    }
}