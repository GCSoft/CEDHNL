/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visComparecencia
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
		GCParse gcParse = new GCParse();
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();

		// Enumeraciones
		private enum ComparecenciaActionTypes { Delete, Insert, Reactivate, Update }


		// Servicio
		[System.Web.Script.Services.ScriptMethod()]
		[System.Web.Services.WebMethod]
		public static List<string> GetServiceList(string prefixText, int count){
			BPServidorPublico oBPServidorPublico = new BPServidorPublico();
			ENTServidorPublico oENTServidorPublico = new ENTServidorPublico();
			ENTResponse oENTResponse = new ENTResponse();

			List<String> ServiceResponse = new List<String>();
			String Item;

			try
			{

				// Formulario
				oENTServidorPublico.Nombre = prefixText;

				// Transacción
				oENTResponse = oBPServidorPublico.SelectServidorPublico_ASService(oENTServidorPublico);

				// Validaciones
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Configuración de arreglo de respuesta
				foreach (DataRow rowServidorPublico in oENTResponse.dsResponse.Tables[0].Rows){
					Item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(rowServidorPublico["NombreCompleto"].ToString(), rowServidorPublico["ServidorPublicoId"].ToString());
					ServiceResponse.Add(Item);
				}

			}catch (Exception){
				// Do Nothing
			}

			// Regresar listado de ServidorPublicos
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


		// Funciones del programador

		String GetStandarTime(String Input){
			String sTime = "";

			try{

				// Obtener la hora   10:30 a.m.
				if (Input.Substring(6, 4) == "a.m."){

					sTime = Input.Substring(0, 2);
				}else {
					sTime = ( Int32.Parse( Input.Substring(0, 2)) + 12).ToString();
				}

				// Obtener los minutos
				sTime = sTime + Input.Substring(2, 3);

				// Hora universal
				return sTime;

			}catch(Exception ex){
				throw(ex);
			}
		}


		// Rutinas del programador

		void DeleteExpedienteComparecencia(Int32 ExpedienteComparecenciaId){
			ENTResponse oENTResponse = new ENTResponse();
			ENTExpedienteComparecencia oENTExpedienteComparecencia = new ENTExpedienteComparecencia();
			BPExpedienteComparecencia oBPExpedienteComparecencia = new BPExpedienteComparecencia();

			try
			{
				oENTExpedienteComparecencia.ExpedienteComparecenciaId = ExpedienteComparecenciaId;
				oENTExpedienteComparecencia.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
				oENTExpedienteComparecencia.ModuloId = 3; // Visitadurías

				oENTResponse = oBPExpedienteComparecencia.DeleteExpedienteComparecencia(oENTExpedienteComparecencia);

				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				SelectExpediente();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void InsertComparecencia() { 
			ENTExpedienteComparecencia oENTExpedienteComparecencia = new ENTExpedienteComparecencia();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession oENTSession;

			BPExpedienteComparecencia oBPExpedienteComparecencia = new BPExpedienteComparecencia();

			DataTable tblCommon = null;
			DataRow rowCommon;

			CheckBox oCheckBox;

			try
			{

				// Obtener Sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear comparecencias debido a que usted no es un funcionario"); }
				
				// Formulario
				oENTExpedienteComparecencia.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTExpedienteComparecencia.LugarComparecenciaId = Int32.Parse(this.ddlLugarComparecencia.SelectedItem.Value);
				oENTExpedienteComparecencia.ModuloId = 3;	// Visitadurías
				oENTExpedienteComparecencia.TipoComparecenciaId = Int32.Parse(this.ddlTipoComparecencia.SelectedItem.Value);
				oENTExpedienteComparecencia.FuncionarioAtiende = oENTSession.FuncionarioId;
				oENTExpedienteComparecencia.FuncionarioEjecuta = Int32.Parse(this.ddlFuncionario.SelectedItem.Value);
				oENTExpedienteComparecencia.Detalle = this.ckeDetalle.Text.Trim();
				oENTExpedienteComparecencia.Fecha = this.calFecha.BeginDate;
				oENTExpedienteComparecencia.HoraInicio = GetStandarTime( this.tmrInicio.DisplayTime );
				oENTExpedienteComparecencia.HoraFin = GetStandarTime(this.tmrFin.DisplayTime);

				oENTExpedienteComparecencia.tblCiudadano = new DataTable("tblCiudadano");
				oENTExpedienteComparecencia.tblCiudadano.Columns.Add("CiudadanoId", typeof(Int32));
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oCheckBox = (CheckBox) this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("chkCiudadano");
					if (oCheckBox.Checked) {

						rowCommon = oENTExpedienteComparecencia.tblCiudadano.NewRow();
						rowCommon["CiudadanoId"] = this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString();
						oENTExpedienteComparecencia.tblCiudadano.Rows.Add(rowCommon);

					}
				}

				tblCommon = gcParse.GridViewToDataTable(this.gvServidorPublico, false);
				oENTExpedienteComparecencia.tblServidorPublico = new DataTable("tblServidorPublico");
				oENTExpedienteComparecencia.tblServidorPublico.Columns.Add("ServidorPublicoId", typeof(Int32));
				foreach(DataRow oDataRow in tblCommon.Rows){

					rowCommon = oENTExpedienteComparecencia.tblServidorPublico.NewRow();
					rowCommon["ServidorPublicoId"] = oDataRow["ServidorPublicoId"];
					oENTExpedienteComparecencia.tblServidorPublico.Rows.Add(rowCommon);
				}

				// Transacción
				oENTResponse = oBPExpedienteComparecencia.InsertExpedienteComparecencia(oENTExpedienteComparecencia);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

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
				this.ResolucionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoResolucionNombre"].ToString();

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

				// Cierre de Orientación
				if ( oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString() != "3" ){
					this.CierreOrientacionLabel.Visible = false;
					this.TipoOrientacionLabel.Visible = false;
				}

				// Canalizaciones
				if (oENTResponse.dsResponse.Tables[2].Rows.Count > 0){

					this.CanalizacionesLabel.Visible = true;

					this.grdCanalizacion.DataSource = oENTResponse.dsResponse.Tables[2];
					this.grdCanalizacion.DataBind();
				}

				// Ciudadanos
				this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[3];
				this.gvCiudadano.DataBind();

				// Comparecencias
				this.gvComparecencia.DataSource = oENTResponse.dsResponse.Tables[9];
				this.gvComparecencia.DataBind();

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
			ENTExpedienteComparecencia oENTExpedienteComparecencia = new ENTExpedienteComparecencia();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession oENTSession;

			BPExpedienteComparecencia oBPExpedienteComparecencia = new BPExpedienteComparecencia();

			DataTable tblCommon = null;
			DataRow rowCommon;

			CheckBox oCheckBox;

			try
			{

				// Obtener Sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para actualizar comparecencias debido a que usted no es un funcionario"); }
				
				// Formulario
				oENTExpedienteComparecencia.ExpedienteComparecenciaId = ComparecenciaId;
				oENTExpedienteComparecencia.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTExpedienteComparecencia.LugarComparecenciaId = Int32.Parse(this.ddlLugarComparecencia.SelectedItem.Value);
				oENTExpedienteComparecencia.ModuloId = 3;	// Visitadurías
				oENTExpedienteComparecencia.TipoComparecenciaId = Int32.Parse(this.ddlTipoComparecencia.SelectedItem.Value);
				oENTExpedienteComparecencia.FuncionarioAtiende = oENTSession.FuncionarioId;
				oENTExpedienteComparecencia.FuncionarioEjecuta = Int32.Parse(this.ddlFuncionario.SelectedItem.Value);
				oENTExpedienteComparecencia.Detalle = this.ckeDetalle.Text.Trim();
				oENTExpedienteComparecencia.Fecha = this.calFecha.BeginDate;
				oENTExpedienteComparecencia.HoraInicio = GetStandarTime( this.tmrInicio.DisplayTime );
				oENTExpedienteComparecencia.HoraFin = GetStandarTime(this.tmrFin.DisplayTime);

				oENTExpedienteComparecencia.tblCiudadano = new DataTable("tblCiudadano");
				oENTExpedienteComparecencia.tblCiudadano.Columns.Add("CiudadanoId", typeof(Int32));
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oCheckBox = (CheckBox) this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("chkCiudadano");
					if (oCheckBox.Checked) {

						rowCommon = oENTExpedienteComparecencia.tblCiudadano.NewRow();
						rowCommon["CiudadanoId"] = this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString();
						oENTExpedienteComparecencia.tblCiudadano.Rows.Add(rowCommon);

					}
				}

				tblCommon = gcParse.GridViewToDataTable(this.gvServidorPublico, false);
				oENTExpedienteComparecencia.tblServidorPublico = new DataTable("tblServidorPublico");
				oENTExpedienteComparecencia.tblServidorPublico.Columns.Add("ServidorPublicoId", typeof(Int32));
				foreach(DataRow oDataRow in tblCommon.Rows){

					rowCommon = oENTExpedienteComparecencia.tblServidorPublico.NewRow();
					rowCommon["ServidorPublicoId"] = oDataRow["ServidorPublicoId"];
					oENTExpedienteComparecencia.tblServidorPublico.Rows.Add(rowCommon);
				}

				// Transacción
				oENTResponse = oBPExpedienteComparecencia.UpdateExpedienteComparecencia(oENTExpedienteComparecencia);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

			}catch (Exception ex){
				throw (ex);
			}
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

		void InsertServidorPublico_Local(String ServidorPublicoId, String Foco){
			BPServidorPublico BPServidorPublico = new BPServidorPublico();
			ENTResponse oENTResponse = new ENTResponse();
			ENTServidorPublico oENTServidorPublico = new ENTServidorPublico();

			DataTable tblServidorPublico = null;
			DataRow rowServidorPublico = null;

			try
			{

				// Formulario
				oENTServidorPublico.ServidorPublicoId = Int32.Parse(ServidorPublicoId);

				// Transacción
				oENTResponse = BPServidorPublico.SelectServidorPublicoByID(oENTServidorPublico);

				// Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") {
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.sMessage) + "'); focusControl('" + this.txtServidorPublico.ClientID + "');", true);
					return;
				}

				// Obtener el DataTable del grid
				tblServidorPublico = gcParse.GridViewToDataTable(this.gvServidorPublico, false);

				// Validación de que no se haya agregado el ServidorPublico
				if (tblServidorPublico.Select("ServidorPublicoId='" + oENTResponse.dsResponse.Tables[1].Rows[0]["ServidorPublicoId"].ToString() + "'").Length > 0) {
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Ya ha seleccionado éste ServidorPublico'); function pageLoad(){ focusControl('" + this.txtServidorPublico.ClientID + "'); }", true);
					return;
				}

				// Nuevo Item
				rowServidorPublico = tblServidorPublico.NewRow();
				rowServidorPublico["ServidorPublicoId"] = oENTResponse.dsResponse.Tables[1].Rows[0]["ServidorPublicoId"];
				rowServidorPublico["NombreCompleto"] = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreCompleto"];

				rowServidorPublico["AutoridadAgrupada"] = oENTResponse.dsResponse.Tables[1].Rows[0]["AutoridadNivel1Nombre"];
				if ( oENTResponse.dsResponse.Tables[1].Rows[0]["AutoridadNivel2Id"].ToString() != "0"  ) { rowServidorPublico["AutoridadAgrupada"] = oENTResponse.dsResponse.Tables[1].Rows[0]["AutoridadNivel2Nombre"]; }
				if ( oENTResponse.dsResponse.Tables[1].Rows[0]["AutoridadNivel3Id"].ToString() != "0"  ) { rowServidorPublico["AutoridadAgrupada"] = oENTResponse.dsResponse.Tables[1].Rows[0]["AutoridadNivel3Nombre"]; }

				tblServidorPublico.Rows.Add(rowServidorPublico);

				// Refrescar el Grid
				this.gvServidorPublico.DataSource = tblServidorPublico;
				this.gvServidorPublico.DataBind();

				// Estado del atosuggest
				this.txtServidorPublico.Text = "";
				this.hddServidorPublicoId.Value = "";

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + Foco + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectComparecencia_ForEdit(Int32 ComparecenciaId){
			ENTExpedienteComparecencia oENTExpedienteComparecencia = new ENTExpedienteComparecencia();
			ENTResponse oENTResponse = new ENTResponse();

			BPExpedienteComparecencia oBPExpedienteComparecencia = new BPExpedienteComparecencia();
			CheckBox oCheckBox;

			try
			{
				
				// Formulario
				oENTExpedienteComparecencia.ExpedienteComparecenciaId = ComparecenciaId;

				// Transacción
				oENTResponse = oBPExpedienteComparecencia.SelectExpedienteComparecenciaByID(oENTExpedienteComparecencia);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Vaciar el formulario
				this.ddlFuncionario.SelectedValue = oENTResponse.dsResponse.Tables[0].Rows[0]["FuncionarioEjecutaId"].ToString();
				this.ddlTipoComparecencia.SelectedValue = oENTResponse.dsResponse.Tables[0].Rows[0]["TipoComparecenciaId"].ToString();
				this.ddlLugarComparecencia.SelectedValue = oENTResponse.dsResponse.Tables[0].Rows[0]["LugarComparecenciaId"].ToString();
				this.calFecha.SetDate = oENTResponse.dsResponse.Tables[0].Rows[0]["FechaComparecenciaCorta"].ToString();
				this.tmrInicio.DisplayTime = oENTResponse.dsResponse.Tables[0].Rows[0]["HoraInicio"].ToString();
				this.tmrFin.DisplayTime = oENTResponse.dsResponse.Tables[0].Rows[0]["HoraFin"].ToString();
				this.ckeDetalle.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Detalle"].ToString();

				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oCheckBox = (CheckBox) this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("chkCiudadano");
					if (oENTResponse.dsResponse.Tables[1].Select("CiudadanoId=" + this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString()).Length > 0) { oCheckBox.Checked = true; }
				}

				this.gvServidorPublico.DataSource = oENTResponse.dsResponse.Tables[2];
				this.gvServidorPublico.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
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
			Boolean CheckServidorPublico = false;

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
				if (this.gvServidorPublico.Rows.Count > 0) { CheckServidorPublico = true; }

				if (CheckCiudadano == false && CheckServidorPublico == false ) { throw new Exception("Es necesario incluir por lo menos un Ciudadano o un Servidor Público en la comparecencia"); }
				if (this.ckeDetalle.Text.Trim() == "") { throw new Exception("El campo [Detalle] es requerido"); }

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Rutinas de recuperación de formulario

		void RecoveryForm(){
			ENTSession oENTSession = new ENTSession();
			ENTExpedienteComparecencia oENTExpedienteComparecencia;

			CheckBox oCheckBox;

            try
            {

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones
				if (oENTSession.Entity == null) { return; }
				if (oENTSession.Entity.GetType().Name != "ENTExpedienteComparecencia") { return; }

                // Obtener Formulario
				oENTExpedienteComparecencia = (ENTExpedienteComparecencia)oENTSession.Entity;

				// Abrir el panel
				if( oENTExpedienteComparecencia.ExpedienteComparecenciaId == 0 ){

					SetPanel(ComparecenciaActionTypes.Insert);
				}else{

					SetPanel(ComparecenciaActionTypes.Update, oENTExpedienteComparecencia.ExpedienteComparecenciaId);
				}
				

				// Vaciar formulario
				this.ddlFuncionario.SelectedValue = oENTExpedienteComparecencia.FuncionarioId.ToString();
				this.calFecha.SetDate = oENTExpedienteComparecencia.Fecha;
				this.tmrInicio.DisplayTime = oENTExpedienteComparecencia.HoraInicio;
				this.tmrInicio.DisplayTime = oENTExpedienteComparecencia.HoraFin;
				this.ddlTipoComparecencia.SelectedValue = oENTExpedienteComparecencia.TipoComparecenciaId.ToString();
				this.ddlLugarComparecencia.SelectedValue = oENTExpedienteComparecencia.LugarComparecenciaId.ToString();

				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oCheckBox = (CheckBox) this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("chkCiudadano");
					if (oENTExpedienteComparecencia.tblCiudadano.Select("CiudadanoId=" + this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString()).Length > 0) { oCheckBox.Checked = true; }
				}

				this.gvServidorPublico.DataSource = oENTExpedienteComparecencia.tblServidorPublico;
				this.gvServidorPublico.DataBind();

				this.ckeDetalle.Text = oENTExpedienteComparecencia.Detalle;


				// Liberar el formulario en la sesión
				oENTSession.Entity = null;
				this.Session["oENTSession"] = oENTSession;

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('No fue posible recuperar el formulario: " + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SaveForm(){
			ENTSession oENTSession = new ENTSession();
			ENTExpedienteComparecencia oENTExpedienteComparecencia = new ENTExpedienteComparecencia();

			CheckBox oCheckBox;
			DataRow rowCiudadano;

            try
            {

                // Formulario
				oENTExpedienteComparecencia.ExpedienteComparecenciaId = Int32.Parse(this.hddComparecenciaId.Value);
				oENTExpedienteComparecencia.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedItem.Value);
				oENTExpedienteComparecencia.Fecha = this.calFecha.DisplayDate;
				oENTExpedienteComparecencia.HoraInicio = this.tmrInicio.DisplayTime;
				oENTExpedienteComparecencia.HoraFin = this.tmrInicio.DisplayTime;
				oENTExpedienteComparecencia.TipoComparecenciaId = Int32.Parse(this.ddlTipoComparecencia.SelectedItem.Value);
				oENTExpedienteComparecencia.LugarComparecenciaId = Int32.Parse(this.ddlLugarComparecencia.SelectedItem.Value);

				oENTExpedienteComparecencia.tblCiudadano = new DataTable("tblCiudadano");
				oENTExpedienteComparecencia.tblCiudadano.Columns.Add("CiudadanoId", typeof(Int32));
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oCheckBox = (CheckBox) this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("chkCiudadano");
					if (oCheckBox.Checked) {
						rowCiudadano = oENTExpedienteComparecencia.tblCiudadano.NewRow();
						rowCiudadano["CiudadanoId"] = this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString();
						oENTExpedienteComparecencia.tblCiudadano.Rows.Add(rowCiudadano);
					}
				}

				oENTExpedienteComparecencia.tblServidorPublico = gcParse.GridViewToDataTable(this.gvServidorPublico, true);
				oENTExpedienteComparecencia.Detalle = this.ckeDetalle.Text.Trim();

				// Obtener la sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

                // Guardar el formulario en la sesión
				oENTSession.Entity = oENTExpedienteComparecencia;
				this.Session["oENTSession"] = oENTSession;

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

				// Recuperar el formulario
				RecoveryForm();

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
			DataTable tblCiudadano;
			DataRow rowCiudadano;

			CheckBox oCheckBox;

			try
			{

				// Guardar los ID's checados
				tblCiudadano = new DataTable("tblCiudadano");
				tblCiudadano.Columns.Add("CiudadanoId", typeof(Int32));
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oCheckBox = (CheckBox) this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("chkCiudadano");
					if (oCheckBox.Checked) {

						rowCiudadano = tblCiudadano.NewRow();
						rowCiudadano["CiudadanoId"] = this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString();
						tblCiudadano.Rows.Add(rowCiudadano);

					}
				}

				// Ordenar el grid
				gcCommon.SortGridView(ref this.gvCiudadano, ref this.hddSort, e.SortExpression);

				// Marcar ciudadanos checados
				foreach (GridViewRow gvRow in this.gvCiudadano.Rows) {

					oCheckBox = (CheckBox) this.gvCiudadano.Rows[gvRow.RowIndex].FindControl("chkCiudadano");
					if (tblCiudadano.Select("CiudadanoId=" + this.gvCiudadano.DataKeys[gvRow.RowIndex]["CiudadanoId"].ToString()).Length > 0) { oCheckBox.Checked = true; }
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvComparecencia_RowCommand(object sender, GridViewCommandEventArgs e){
			String CommandName = "";
			String ComparecenciaId = "";

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
				ComparecenciaId = gvComparecencia.DataKeys[iRow]["ExpedienteComparecenciaId"].ToString();

				// Acción
				switch (CommandName){
					case "Editar":
						SetPanel(ComparecenciaActionTypes.Update, Int32.Parse(ComparecenciaId));
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;

					case "Borrar":
						DeleteExpedienteComparecencia(Int32.Parse(ComparecenciaId));
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvComparecencia_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;

			String ModuloId = "";
			String FechaComparecencia = "";

			String sImagesAttributes = "";
			String sToolTip = "";

			String sImagesAttributesDelete = "";
			String sToolTipDelete = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// Datakeys
				ModuloId = this.gvComparecencia.DataKeys[e.Row.RowIndex]["ModuloId"].ToString();
				FechaComparecencia = this.gvComparecencia.DataKeys[e.Row.RowIndex]["FechaComparecenciaCorta"].ToString();

				// Seguridad
				if( ModuloId != "3"){

					imgEdit.Visible = false;
					imgDelete.Visible = false;

					// Atributos Over y Out
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

				}else{

					// Tooltip Edición
					sToolTip = "Editar Comparecencia del " + FechaComparecencia;
					sToolTipDelete = "Eliminar Comparecencia del " + FechaComparecencia;

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

				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvComparecencia_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvComparecencia, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvServidorPublico_RowCommand(object sender, GridViewCommandEventArgs e){
			DataTable tblServidorPublico = null;
			
			String ServidorPublicoId;
			String strCommand = "";
			String sKey = "";

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
				ServidorPublicoId = this.gvServidorPublico.DataKeys[intRow]["ServidorPublicoId"].ToString();

				// Acción
				switch (strCommand){
					case "Editar":

						// Guardar el formulario
						SaveForm();

						// Llave encriptada
						sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value + "|1|" + ServidorPublicoId;
						sKey = gcEncryption.EncryptString(sKey, true);
						this.Response.Redirect("VisRegistroServidorPublico.aspx?key=" + sKey, false);

						break;

					case "Eliminar":

						// Obtener el DataTable del grid
						tblServidorPublico = gcParse.GridViewToDataTable(this.gvServidorPublico, true);

						// Eliminar el Item
						tblServidorPublico.Rows.Remove(tblServidorPublico.Select("ServidorPublicoId=" + ServidorPublicoId)[0]);

						// Refrescar el Grid
						this.gvServidorPublico.DataSource = tblServidorPublico;
						this.gvServidorPublico.DataBind();

						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvServidorPublico_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;

			String NombreServidorPublico = "";
			String sImagesAttributes = "";
			String sTootlTip = "";

			try
			{

				// Validación de que sea fila
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// Datakeys
				NombreServidorPublico = this.gvServidorPublico.DataKeys[e.Row.RowIndex]["NombreCompleto"].ToString();

				// Tooltip Edición
				sTootlTip = "Editar [" + NombreServidorPublico + "]";
				imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
				imgEdit.Attributes.Add("style", "cursor:hand;");

				// Tooltip Eliminar
				sTootlTip = "Eliminar [" + NombreServidorPublico + "]";
				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sTootlTip + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				// Atributos Over
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
				sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over_Action'; " + sImagesAttributes);

				// Atributos Out
				sImagesAttributes = " document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
				sImagesAttributes = sImagesAttributes + " document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
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

				// Limpiar el panel
				ClearActionPanel();

				// Actualizar
				SelectExpediente();

			}catch (Exception ex){
				this.lblActionMessage.Text = ex.Message;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "WAFocus ('" + this.ddlFuncionario.ClientID + "'); ", true);
			}
		}

		protected void btnAgregarFuncionario_Click(object sender, EventArgs e){
			String ServidorPublicoId;

			try
			{

				// Obtener información del ServidorPublico del Autosuggest
				ServidorPublicoId = this.Request.Form[this.hddServidorPublicoId.UniqueID];

				// Validaciones
				if (ServidorPublicoId == "" || ServidorPublicoId == "0") { throw(new Exception("Es necesario seleccionar un Servidor Publico válido")); }

				// Transacción
				InsertServidorPublico_Local(ServidorPublicoId, this.txtServidorPublico.ClientID);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.txtServidorPublico.ClientID + "');", true);
			}
		}

		protected void btnNuevoFuncionario_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Guardar el formulario
				SaveForm();

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value + "|1|0";
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("VisRegistroServidorPublico.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
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