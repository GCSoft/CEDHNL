﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visDiligenciaExpediente
' Autor:	Ruben.Cobos
' Fecha:	18-Agosto-2014
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
	public partial class visDiligenciaExpediente : System.Web.UI.Page
	{

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();

		// Enumeraciones
		private enum DiligenciaActionTypes { DeleteDiligencia, InsertDiligencia, ReactivateDiligencia, SelectDiligencia, UpdateDiligencia }


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

		String GetStandarTime(String Input){
			String sTime = "";

			try{

				// Obtener la hora   10:30 a.m.
				if (Input.Substring(6, 4) == "a.m."){

					sTime = Input.Substring(0, 2);
				}else {
					sTime = ( Int32.Parse( Input.Substring(0, 2)) + 12).ToString();
					if (sTime == "24") { sTime = "12"; }
				}

				// Obtener los minutos
				sTime = sTime + Input.Substring(2, 3);

				// Hora universal
				return sTime;

			}catch(Exception ex){
				throw(ex);
			}
		}


		// Rutinas el programador

		void DeleteDiligencia(Int32 DiligenciaId){
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			BPDiligencia oBPDiligencia = new BPDiligencia();

			try
			{
				oENTDiligencia.DiligenciaId = DiligenciaId;
				oENTDiligencia.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
				oENTDiligencia.ModuloId = 3; // Visitadurías

				oENTResponse = oBPDiligencia.DeleteExpedienteDiligencia(oENTDiligencia);

				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				SelectExpediente();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void InsertExpedienteDiligencia(){
			BPDiligencia oBPDiligencia = new BPDiligencia();

			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			ENTSession oENTSession;

			try
			{

				// Validaciones
				if (this.ddlFuncionario.SelectedIndex == 0) { throw new Exception("El campo [Funcionario que ejecuta] es requerido"); }
				if (String.IsNullOrEmpty(this.calFecha.DisplayDate)) { throw new Exception("El campo [Fecha de la diligencia] es requerido"); }
				if (this.tmrInicio.DisplayTime == "") { throw new Exception("El campo [Hora Inicio] es requerido"); }
				if (this.tmrFin.DisplayTime == "") { throw new Exception("El campo [Hora Fin] es requerido"); }
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
				oENTDiligencia.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
				oENTDiligencia.ModuloId = 3; // Visitadurías
				oENTDiligencia.FuncionarioAtiendeId = oENTSession.FuncionarioId;
				oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(this.ddlFuncionario.SelectedValue);
				oENTDiligencia.FechaDiligencia = this.calFecha.BeginDate;
				oENTDiligencia.HoraInicio = GetStandarTime(this.tmrInicio.DisplayTime);
				oENTDiligencia.HoraFin = GetStandarTime(this.tmrFin.DisplayTime);
				oENTDiligencia.TipoDiligencia = Convert.ToInt32(this.ddlTipoDiligencia.SelectedValue);
				oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(this.ddlLugarDiligencia.SelectedValue);
				oENTDiligencia.SolicitadaPor = this.txtSolicitadaPor.Text;
				oENTDiligencia.Detalle = this.ckeDetalle.Text.Trim();
				oENTDiligencia.Resultado = this.ckeResultado.Text.Trim();

				//Transacción
				oENTResponse = oBPDiligencia.InsertExpedienteDiligencia(oENTDiligencia);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectExpediente();


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

				// Diligencias
				this.gvDiligencia.DataSource = oENTResponse.dsResponse.Tables[8];
				this.gvDiligencia.DataBind();

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
				oENTFuncionario.idArea = ( this.hddAreaId.Value == "10" ? 6 : Int32.Parse(this.hddAreaId.Value) );	// Área del expediente
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

		void UpdateExpedienteDiligencia(Int32 DiligenciaId){
			ENTResponse oENTResponse = new ENTResponse();
			ENTDiligencia oENTDiligencia = new ENTDiligencia();
			BPDiligencia oBPDiligencia = new BPDiligencia();

			ENTSession oENTSession;

			try
			{

				// Validaciones
				if (ddlFuncionario.SelectedValue == "0") { throw new Exception("* El campo [Visitador que ejecuta] es requerido"); }
				if (String.IsNullOrEmpty(calFecha.DisplayDate)) { throw new Exception("* El campo [Fecha de la diligencia] es requerido"); }
				if (this.tmrInicio.DisplayTime == "") { throw new Exception("El campo [Hora Inicio] es requerido"); }
				if (this.tmrFin.DisplayTime == "") { throw new Exception("El campo [Hora Fin] es requerido"); }
				if (ddlTipoDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Tipo de diligencia] es requerido"); }
				if (ddlLugarDiligencia.SelectedValue == "0") { throw new Exception("* El campo [Lugar de diligencia] es requerido"); }
				if (String.IsNullOrEmpty(ckeDetalle.Text)) { throw new Exception("* El campo [Detalle] es requerido"); }
				if (String.IsNullOrEmpty(txtSolicitadaPor.Text)) { throw new Exception("* El campo [Solicitada por] es requerido"); }
				if (String.IsNullOrEmpty(ckeResultado.Text)) { throw new Exception("* El campo [Resultado] es requerido"); }

				// Obtener Sesion
				oENTSession = (ENTSession)this.Session["oENTSession"];

				// Validaciones de sesión
				if (oENTSession.FuncionarioId == 0) { throw new Exception("No cuenta con permisos para crear diligencias debido a que usted no es un funcionario"); }

				//Formulario
				oENTDiligencia.DiligenciaId = Convert.ToInt32(DiligenciaId);
				oENTDiligencia.ExpedienteId = Convert.ToInt32(this.hddExpedienteId.Value);
				oENTDiligencia.ModuloId = 3; // Visitadurías
				oENTDiligencia.FuncionarioAtiendeId = oENTSession.FuncionarioId;
			    oENTDiligencia.FuncionarioEjecuta = Convert.ToInt32(ddlFuncionario.SelectedValue);
			    oENTDiligencia.FechaDiligencia = calFecha.BeginDate;
				oENTDiligencia.HoraInicio = GetStandarTime(this.tmrInicio.DisplayTime);
				oENTDiligencia.HoraFin = GetStandarTime(this.tmrFin.DisplayTime);
			    oENTDiligencia.TipoDiligencia = Convert.ToInt32(ddlTipoDiligencia.SelectedValue);
			    oENTDiligencia.LugarDiligenciaId = Convert.ToInt32(ddlLugarDiligencia.SelectedValue);
			    oENTDiligencia.Detalle = ckeDetalle.Text;
			    oENTDiligencia.SolicitadaPor = txtSolicitadaPor.Text;
			    oENTDiligencia.Resultado = ckeResultado.Text;

			    // Transacción
				oENTResponse = oBPDiligencia.UpdateExpedienteDiligencia(oENTDiligencia);

			    // Validación
			    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Transacción exitosa
				ClearActionPanel();

				// Actualizar grid
				SelectExpediente();

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
				this.tmrInicio.DisplayTime = "10:00 a.m.";
				this.tmrFin.DisplayTime = "10:30 a.m.";
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

		void SelectDiligencia_ForEdit(String DiligenciaId, Boolean Consulta){
			BPDiligencia oBPDiligencia = new BPDiligencia();

			// Formulario
			oBPDiligencia.DiligenciaEntity.DiligenciaId = Convert.ToInt32(DiligenciaId);

			// Transacción
			oBPDiligencia.SelectExpedienteDiligencia();

			// Validaciones
			if (oBPDiligencia.ErrorId != 0) { throw (new Exception(oBPDiligencia.ErrorDescription)); }

			// Vaciado de datos
			this.hddDiligenciaId.Value = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["DiligenciaId"].ToString();
			this.calFecha.SetDate = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["FechaDiligencia"].ToString();
			this.tmrInicio.DisplayTime = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["HoraInicio"].ToString();
			this.tmrFin.DisplayTime = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["HoraFin"].ToString();
			this.ddlTipoDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["TipoDiligencia"].ToString();
			this.ddlLugarDiligencia.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["LugarDiligencia"].ToString();
			this.ckeDetalle.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["Detalle"].ToString();
			this.txtSolicitadaPor.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["SolicitadaPor"].ToString();
			this.ckeResultado.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["Resultado"].ToString();


			// Determinar si es consultä
			if (Consulta){

				this.ddlFuncionario.SelectedIndex = 0;
				this.ddlFuncionario.SelectedItem.Text = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["NombreVisitadorEjecuta"].ToString();
				this.ddlFuncionario.Enabled = false;
			}else{

				this.ddlFuncionario.SelectedIndex = 0;
				this.ddlFuncionario.SelectedItem.Text = "[Seleccione]";
				this.ddlFuncionario.Enabled = true;
				this.ddlFuncionario.SelectedValue = oBPDiligencia.DiligenciaEntity.DataResult.Tables[1].Rows[0]["FuncionarioEjecuta"].ToString();
			}

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
						this.btnAction.Visible = true;

						this.ddlFuncionario.Items.Clear();
						SelectFuncionario();
						this.ddlFuncionario.Enabled = true;

						break;

					case DiligenciaActionTypes.SelectDiligencia:
						this.lblActionTitle.Text = "Consulta de Diligencia";
						this.btnAction.Visible = false;
						SelectDiligencia_ForEdit(idItem.ToString(), true);
						break;

					case DiligenciaActionTypes.UpdateDiligencia:

						this.lblActionTitle.Text = "Edición de Diligencia";
						this.btnAction.Text = "Actualizar Diligencia";
						this.btnAction.Visible = true;

						this.ddlFuncionario.Items.Clear();
						SelectFuncionario();
						this.ddlFuncionario.Enabled = true;

						SelectDiligencia_ForEdit(idItem.ToString(), false);
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
				SelectTipoDiligencia();
				SelectLugarDiligencia();

				// Estado inicial del formulario
				ClearActionPanel();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
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

		protected void gvDiligencia_RowCommand(object sender, GridViewCommandEventArgs e){
			String CommandName = "";
			String DiligenciaId = "";

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
				DiligenciaId = gvDiligencia.DataKeys[iRow]["DiligenciaId"].ToString();

				// Acción
				switch (CommandName){
					case "Detalle":
						SetPanel(DiligenciaActionTypes.SelectDiligencia, Int32.Parse(DiligenciaId));
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;

					case "Editar":
						SetPanel(DiligenciaActionTypes.UpdateDiligencia, Int32.Parse(DiligenciaId));
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;

					case "Borrar":
						DeleteDiligencia(Int32.Parse(DiligenciaId));
						break;
				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}

		protected void gvDiligencia_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDetail = null;
			ImageButton imgEdit = null;
			ImageButton imgDelete = null;

			String ModuloId = "";
			String FechaDiligencia = "";

			String sImagesAttributes = "";
			String sToolTip = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgDetail = (ImageButton)e.Row.FindControl("imgDetail");
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// Datakeys
				ModuloId = this.gvDiligencia.DataKeys[e.Row.RowIndex]["ModuloId"].ToString();
				FechaDiligencia = this.gvDiligencia.DataKeys[e.Row.RowIndex]["Fecha"].ToString();

				// Seguridad
				if( ModuloId != "3"){

					imgEdit.Visible = false;
					imgDelete.Visible = false;

					// Tooltip Detalle
					sToolTip = "Detalle de diligencia del " + FechaDiligencia;
					imgDetail.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgDetail.Attributes.Add("onmouseout", "tooltip.hide();");
					imgDetail.Attributes.Add("style", "cursor:hand;");

					// Atributos Over
					sImagesAttributes = "document.getElementById('" + imgDetail.ClientID + "').src='../../../../Include/Image/Buttons/ConsultarCiudadano_Over.png'; ";
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

					// Atributos Out
					sImagesAttributes = "document.getElementById('" + imgDetail.ClientID + "').src='../../../../Include/Image/Buttons/ConsultarCiudadano.png';";
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

				}else{

					// Tooltip Detalle
					sToolTip = "Detalle de diligencia del " + FechaDiligencia;
					imgDetail.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgDetail.Attributes.Add("onmouseout", "tooltip.hide();");
					imgDetail.Attributes.Add("style", "cursor:hand;");

					// Tooltip Edición
					sToolTip = "Editar diligencia del " + FechaDiligencia;
					imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
					imgEdit.Attributes.Add("style", "cursor:hand;");

					// Tooltip Eliminar
					sToolTip = "Eliminar diligencia del " + FechaDiligencia;
					imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
					imgDelete.Attributes.Add("style", "cursor:hand;");

					// Atributos Over
					sImagesAttributes = "document.getElementById('" + imgDetail.ClientID + "').src='../../../../Include/Image/Buttons/ConsultarCiudadano_Over.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

					// Atributos Out
					sImagesAttributes = "document.getElementById('" + imgDetail.ClientID + "').src='../../../../Include/Image/Buttons/ConsultarCiudadano.png';";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png';";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvDiligencia_Sorting(object sender, GridViewSortEventArgs e){
			try
			{

				gcCommon.SortGridView(ref this.gvDiligencia, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
			}
		}


		// Eventos de PopUp

		protected void btnAction_Click(object sender, EventArgs e){
			try
			{
				
				if (this.hddDiligenciaId.Value == "0"){

					InsertExpedienteDiligencia();
				}else{

					UpdateExpedienteDiligencia(Int32.Parse(this.hddDiligenciaId.Value));
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