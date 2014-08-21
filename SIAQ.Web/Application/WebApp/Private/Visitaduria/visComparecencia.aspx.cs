/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visAsignarFuncionario
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
    public partial class visComparecencia : System.Web.UI.Page
    {
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();

		// Enumeraciones
		private enum ComparecenciaActionTypes { Delete, Insert, Reactivate, Update }


		// Servicio
		[System.Web.Script.Services.ScriptMethod()]
		[System.Web.Services.WebMethod]
		public static List<string> GetServiceList(string prefixText, int count){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();
			ENTResponse oENTResponse = new ENTResponse();

			List<String> ServiceResponse = new List<String>();
			String Item;

			try
			{

				// Formulario
				oENTCiudadano.Nombre = prefixText;

				// Transacción
				oENTResponse = oBPCiudadano.searchCiudadano(oENTCiudadano);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Configuración de arreglo de respuesta
				foreach (DataRow rowCiudadano in oENTResponse.dsResponse.Tables[1].Rows){
					Item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(rowCiudadano["NombreCiudadano"].ToString(), rowCiudadano["CiudadanoId"].ToString());
					ServiceResponse.Add(Item);
				}

			}catch (Exception){
				// Do Nothing
			}

			// Regresar listado de Ciudadanos
			return ServiceResponse;
		}


		// Funciones del programador

		String GetKey(String sKey) {
			String Response = "";

			try{

				Response = gcEncryption.DecryptString(sKey, true);

			}catch(Exception){
				Response = "";
			}

			return Response;
		}


		// Rutinas del programador

		void InsertComparecencia() { 

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

				// Ciudadanos
				this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[3];
				this.gvCiudadano.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
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
				oENTFuncionario.idArea = Int32.Parse(this.hddAreaId.Value);	// Área del expediente
				oENTFuncionario.idRol = 8; // Visitaduría - Visitador
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

		void SelectLugarComparecencia(){
			BPLugarComparecencia LugarComparecenciaProcess = new BPLugarComparecencia();

			// Transacción
			LugarComparecenciaProcess.SelectLugarComparecencia();

			// Validaciones
			if (LugarComparecenciaProcess.ErrorId != 0) { throw (new Exception(LugarComparecenciaProcess.ErrorDescription)); }

			// Llenado del control
			this.ddlLugarComparecencia.DataTextField = "Nombre";
			this.ddlLugarComparecencia.DataValueField = "LugarComparecenciaId";

			this.ddlLugarComparecencia.DataSource = LugarComparecenciaProcess.LugarComparecenciaEntity.ResultData.Tables[0];
			this.ddlLugarComparecencia.DataBind();

			this.ddlLugarComparecencia.Items.Insert(0, new ListItem("[Seleccione]", "0"));
		}

		void SelectTipoComparecencia(){
			BPTipoComparecencia TipoComparecenciaProcess = new BPTipoComparecencia();

			// Transacción
			TipoComparecenciaProcess.SelectTipoComparecencia();

			// Validaciones
			if (TipoComparecenciaProcess.ErrorId != 0) { throw (new Exception(TipoComparecenciaProcess.ErrorDescription)); }

			// Llenado del control
			this.ddlTipoComparecencia.DataTextField = "Nombre";
			this.ddlTipoComparecencia.DataValueField = "TipoComparecenciaId";

			this.ddlTipoComparecencia.DataSource = TipoComparecenciaProcess.TipoComparecenciaEntity.ResultData.Tables[0];
			this.ddlTipoComparecencia.DataBind();

			this.ddlTipoComparecencia.Items.Insert(0, new ListItem("[Seleccione]", "0"));
		}

		void UpdateComparecencia(Int32 ComparecenciaId){
			
		}


		// Rutinas del PopUp

		void ClearActionPanel(){
			CheckBox oCheckBox;

			try
			{

				// Limpiar formulario
				this.ddlFuncionario.SelectedIndex = 0;
				this.calFecha.SetCurrentDate();
				this.tmrInicio.DisplayTime = "10:00 a.m.";
				this.tmrFin.DisplayTime = "10:30 a.m.";
				this.ddlTipoComparecencia.SelectedIndex = 0;
				this.ddlLugarComparecencia.SelectedIndex = 0;

				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oCheckBox = (CheckBox) this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("chkCiudadano");
					oCheckBox.Checked = false;
				}

				this.txtServidorPublico.Text = "";
				this.hddServidorPublicoId.Value = "";

				this.gvServidorPublico.DataSource = null;
				this.gvServidorPublico.DataBind();

				this.ckeDetalle.Text = "";

				// Estado incial de controles
				this.pnlAction.Visible = false;
				this.lblActionTitle.Text = "";
				this.btnAction.Text = "";
				this.lblActionMessage.Text = "";
				this.hddComparecenciaId.Value = "";

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectComparecencia_ForEdit(Int32 ComparecenciaId){

		}

		void SetPanel(ComparecenciaActionTypes ComparecenciaActionTypes, Int32 idItem = 0){
			try
			{

				// Acciones comunes
				this.pnlAction.Visible = true;
				this.hddComparecenciaId.Value = idItem.ToString();

				// Detalle de acción
				switch (ComparecenciaActionTypes){
					case ComparecenciaActionTypes.Insert:
						this.lblActionTitle.Text = "Nueva Comparecencia";
						this.btnAction.Text = "Crear Comparecencia";

						break;

					case ComparecenciaActionTypes.Update:
						this.lblActionTitle.Text = "Edición de Comparecencia";
						this.btnAction.Text = "Actualizar Comparecencia";
						SelectComparecencia_ForEdit(idItem);
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

		void ValidateActionForm(){
			CheckBox oCheckBox;
			Boolean CheckCiudadano = false;

			try
			{

				if (this.ddlFuncionario.SelectedIndex == 0) { throw new Exception("El campo [Funcionario que ejecuta] es requerido"); }
				if (this.tmrInicio.DisplayTime == "") { throw new Exception("El campo [Hora Inicio] es requerido"); }
				if (this.tmrFin.DisplayTime == "") { throw new Exception("El campo [Hora Fin] es requerido"); }
				if (this.ddlTipoComparecencia.SelectedIndex == 0) { throw new Exception("El campo [Tipo de comparecencia] es requerido"); }
				if (this.ddlLugarComparecencia.SelectedIndex == 0) { throw new Exception("El campo [Lugar de comparecencia] es requerido"); }

				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oCheckBox = (CheckBox) this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("chkCiudadano");
					if (oCheckBox.Checked) { CheckCiudadano = true; }
				}

				if (!CheckCiudadano) { throw new Exception("Es necesario incluir por lo menos un ciudadano en la comparecencia"); }

				if (this.gvServidorPublico.Rows.Count == 0) { throw new Exception("Debe incluir por lo menos un Servidor Público en la comparecencia"); }
				if (this.ckeDetalle.Text.Trim() == "") { throw new Exception("El campo [Detalle] es requerido"); }

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
				SelectFuncionario();
				SelectTipoComparecencia();
				SelectLugarComparecencia();

				// Estado Inicial de la pantalla
				ClearActionPanel();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void btnNuevo_Click(object sender, EventArgs e){
			try
            {

				// Nueva comparecencia
				SetPanel(ComparecenciaActionTypes.Insert);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Atributos Over
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action'; ");

				// Atributos Out
				e.Row.Attributes.Add("onmouseout", "this.className='Grid_Row_Action'; ");

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvCiudadano, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvServidorPublico_RowCommand(object sender, GridViewCommandEventArgs e){
			//DataTable tblCanalizacion = null;
			//String CanalizacionId;

			//String strCommand = "";
			//Int32 intRow = 0;

			//try
			//{

			//    // Opción seleccionada
			//    strCommand = e.CommandName.ToString();

			//    // Se dispara el evento RowCommand en el ordenamiento
			//    if (strCommand == "Sort") { return; }

			//    // Fila
			//    intRow = Int32.Parse(e.CommandArgument.ToString());

			//    // Datakeys
			//    CanalizacionId = this.grdCanalizacion.DataKeys[intRow]["CanalizacionId"].ToString();

			//    // Acción
			//    switch (strCommand){
			//        case "Eliminar":

			//            // Obtener el DataTable del grid
			//            tblCanalizacion = gcParse.GridViewToDataTable(this.grdCanalizacion, true);

			//            // Eliminar el Item
			//            tblCanalizacion.Rows.Remove(tblCanalizacion.Select("CanalizacionId=" + CanalizacionId)[0]);

			//            // Refrescar el Grid
			//            this.grdCanalizacion.DataSource = tblCanalizacion;
			//            this.grdCanalizacion.DataBind();

			//            break;
			//    }

			//}catch (Exception ex){
			//    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlCanalizacion.ClientID + "'); }", true);
			//}
		}

		protected void gvServidorPublico_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDelete = null;

			String NombreServidorPublico = "";
			String sImagesAttributes = "";
			String sTootlTip = "";

			try
			{

				// Validación de que sea fila
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imágen
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// Datakeys
				NombreServidorPublico = this.grdCanalizacion.DataKeys[e.Row.RowIndex]["ServidorPublicoNombre"].ToString();

				// Tooltip Edición
				sTootlTip = "Eliminar [" + NombreServidorPublico + "]";
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

		protected void gvServidorPublico_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvServidorPublico, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


		// Eventos del PopUp

		protected void btnAction_Click(object sender, EventArgs e){
			try
			{

				// Validar formulario
				ValidateActionForm();

				// Determinar acción
				if (this.hddComparecenciaId.Value == "0"){

					InsertComparecencia();
				}else{

					UpdateComparecencia(Int32.Parse(this.hddComparecenciaId.Value));
				}

			}catch (Exception ex){
				this.lblActionMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "WAFocus ('" + this.ddlFuncionario.ClientID + "'); ", true);
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