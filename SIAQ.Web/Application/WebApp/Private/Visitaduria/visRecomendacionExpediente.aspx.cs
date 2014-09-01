/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visRecomendacionExpediente
' Autor:	Ruben.Cobos
' Fecha:	31-Agosto-2014
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
    public partial class visRecomendacionExpediente : System.Web.UI.Page
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

		void DeleteRecomendacion(String RecomendacionId){
			ENTResponse oENTResponse = new ENTResponse();
			ENTRecomendacion oENTRecomendacion = new ENTRecomendacion();
			BPRecomendacion oBPRecomendacion = new BPRecomendacion();

			try
			{
				oENTRecomendacion.RecomendacionId = Int32.Parse( RecomendacionId);
				oENTRecomendacion.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
				oENTRecomendacion.ModuloId = 3; // Visitadurías

				oENTResponse = oBPRecomendacion.DeleteRecomendacion(oENTRecomendacion);

				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				SelectExpediente();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void ResetForm(){
			this.ddlTipoRecomendacion.SelectedIndex = 0;
			this.ckeDetalle.Text = "";
			this.hddRecomendacionId.Value = "0";

			ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlTipoRecomendacion.ClientID + "'); }", true);
		}

		void InsertRecomendacion(){
			BPRecomendacion oBPRecomendacion = new BPRecomendacion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTRecomendacion oENTRecomendacion = new ENTRecomendacion();
			ENTSession oENTSession;

			try
			{

				// Validaciones
				if (this.ddlTipoRecomendacion.SelectedIndex == 0) { throw new Exception("El campo [Tipo de Recomendación] es requerido"); }
				if (this.ckeDetalle.Text.Trim() == "") { throw new Exception("El campo [Detalle] es requerido"); }

				// Obtener Sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear Recomendaciones debido a que usted no es un funcionario"); }

				//Formulario
				oENTRecomendacion.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
				oENTRecomendacion.EstatusId = 13; // Sin atender
				oENTRecomendacion.FuncionarioId = oENTSession.FuncionarioId;
				oENTRecomendacion.ModuloId = 3; // Visitadurías
				oENTRecomendacion.TipoRecomendacionId = Int32.Parse(this.ddlTipoRecomendacion.SelectedItem.Value);
				oENTRecomendacion.Observaciones = this.ckeDetalle.Text.Trim();

				//Transacción
				oENTResponse = oBPRecomendacion.InsertRecomendacion(oENTRecomendacion);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Actualizar grid
				SelectExpediente();

				// Limpiar el formulario
				ResetForm();

			}catch (Exception ex){
			    throw (ex);
			}
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

				// Recomendaciones
				this.gvRecomendacion.DataSource = oENTResponse.dsResponse.Tables[11];
				this.gvRecomendacion.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectRecomendacion_ForEdit(String RecomendacionId){
			ENTRecomendacion oENTRecomendacion = new ENTRecomendacion();
			ENTResponse oENTResponse = new ENTResponse();
			BPRecomendacion oBPRecomendacion = new BPRecomendacion();

			try
			{
				// Formulario
				oENTRecomendacion.RecomendacionId = Int32.Parse(RecomendacionId);

				// Transacción
				oENTResponse = oBPRecomendacion.SelectRecomendacion_ByID(oENTRecomendacion);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

				// Llenado de formulario
				this.ddlTipoRecomendacion.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoRecomendacionId"].ToString();
				this.ckeDetalle.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Id a trabajar
				this.hddRecomendacionId.Value = RecomendacionId.ToString();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlTipoRecomendacion.ClientID + "'); }", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectTipoRecomendacion(){
			ENTTipoRecomendacion oENTTipoRecomendacion = new ENTTipoRecomendacion();
			ENTResponse oENTResponse = new ENTResponse();
			BPTipoRecomendacion oBPTipoRecomendacion = new BPTipoRecomendacion();

			try
			{
				// Formulario
				oENTTipoRecomendacion.TipoRecomendacionId = 0;
				oENTTipoRecomendacion.Nombre = "";

				// Transacción
				oENTResponse = oBPTipoRecomendacion.SelectTipoRecomendacion(oENTTipoRecomendacion);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Mensaje de la BD
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "');", true); }

				// Llenado de combo
				this.ddlTipoRecomendacion.DataTextField = "Nombre";
				this.ddlTipoRecomendacion.DataValueField = "TipoRecomendacionId";
				this.ddlTipoRecomendacion.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlTipoRecomendacion.DataBind();

				// Agregar Item de selección
				this.ddlTipoRecomendacion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void UpdateRecomendacion() { 
			BPRecomendacion oBPRecomendacion = new BPRecomendacion();

			ENTResponse oENTResponse = new ENTResponse();
			ENTRecomendacion oENTRecomendacion = new ENTRecomendacion();
			ENTSession oENTSession;

			try
			{

				// Validaciones
				if (this.ddlTipoRecomendacion.SelectedIndex == 0) { throw new Exception("El campo [Tipo de Recomendación] es requerido"); }
				if (this.ckeDetalle.Text.Trim() == "") { throw new Exception("El campo [Detalle] es requerido"); }

				// Obtener Sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear Recomendaciones debido a que usted no es un funcionario"); }

				//Formulario
				oENTRecomendacion.RecomendacionId = Int32.Parse(this.hddRecomendacionId.Value);
				oENTRecomendacion.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
				oENTRecomendacion.EstatusId = 13; // Sin atender
				oENTRecomendacion.FuncionarioId = oENTSession.FuncionarioId;
				oENTRecomendacion.ModuloId = 3; // Visitadurías
				oENTRecomendacion.TipoRecomendacionId = Int32.Parse(this.ddlTipoRecomendacion.SelectedItem.Value);
				oENTRecomendacion.Observaciones = this.ckeDetalle.Text.Trim();

				//Transacción
				oENTResponse = oBPRecomendacion.UpdateRecomendacion(oENTRecomendacion);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Actualizar grid
				SelectExpediente();

				// Limpiar el formulario
				ResetForm();

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
				SelectTipoRecomendacion();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlTipoRecomendacion.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoRecomendacion.ClientID + "'); }", true);
            }
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

				// Tipo de Transacción
				if (this.hddRecomendacionId.Value == "0"){
					InsertRecomendacion();
				}else {
					UpdateRecomendacion();
				}
            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoRecomendacion.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoRecomendacion.ClientID + "'); }", true);
            }
		}

		protected void gvRecomendacion_RowCommand(object sender, GridViewCommandEventArgs e){
			String RecomendacionId;
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
				RecomendacionId = gvRecomendacion.DataKeys[iRow]["RecomendacionId"].ToString();

				// Acción
				switch (CommandName){
					case "Editar":
						SelectRecomendacion_ForEdit(RecomendacionId);
						break;

					case "Borrar":
						DeleteRecomendacion(RecomendacionId);
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoRecomendacion.ClientID + "'); }", true);
			}
		}

		protected void gvRecomendacion_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;

			String sImagesAttributes = "";
			String sToolTip = "";
			String TipoRecomendacionNombre = "";

			String sImagesAttributesDelete = "";
			String sToolTipDelete = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				TipoRecomendacionNombre = gvRecomendacion.DataKeys[e.Row.RowIndex]["TipoRecomendacionNombre"].ToString();

				// Tooltip Edición
				sToolTip = "Editar gestión [" + TipoRecomendacionNombre + "]";
				sToolTipDelete = "Eliminar gestión [" + TipoRecomendacionNombre + "]";

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

		protected void gvRecomendacion_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvRecomendacion, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoRecomendacion.ClientID + "'); }", true);
			}
		}

    }
}