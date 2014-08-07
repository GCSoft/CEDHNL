/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	    opeRegistroSolicitud
' Autor:		Ruben.Cobos
' Fecha:		17-Julio-2014
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
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
	public partial class opeRegistroSolicitud : BPPage
   {

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCParse gcParse = new GCParse();

		// Servicio
		[System.Web.Script.Services.ScriptMethod()]
		[System.Web.Services.WebMethod]
		public static List<string> GetCitizenList(string prefixText, int count){
			BPCiudadano oBPCiudadano = new BPCiudadano();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();
			ENTResponse oENTResponse = new ENTResponse();

			List<String> ServiceResponse = new List<String>();
			String Item;

			// Errores conocidos:
			//		* El control toma el foco con el metodo JS Focus() sólo si es llamado con la función JS pageLoad() 
			//		* No se pudo encapsular en un WUC
			//		* Si se selecciona un nombre válido, enseguida se borra y se pone uno inválido, el control almacena el ID del nombre válido

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
       
      
		// Rutinas del programador

		void Clear(){
			this.wucFixedDateTime.SetDateTime();
			this.ddlFormaContacto.SelectedIndex = 0;
			this.ddlProblematica.SelectedIndex = 0;
			this.ddlFuncionario.SelectedIndex = 0;
			this.txtCiudadano.Text = "";
			this.hddCiudadanoId.Value = "";
			this.ddlTipoParticipacion.SelectedIndex = 0;
			this.rblPresente.Items[0].Selected = true;
			this.ckeObservaciones.Text = "";

			this.gvCiudadano.DataSource = null;
			this.gvCiudadano.DataBind();
		}

		void InsertSolicitud(){
			BPSolicitud oBPSolicitud = new BPSolicitud();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSolicitud oENTSolicitud = new ENTSolicitud();
			ENTSession oENTSession;

			String JSMensaje = "";
			String JSScript = "";

			String SolicitudId = "";
			String sFolio = "";

			DataTable tblCiudadano = null;
			DataRow rowCiudadano;
			Boolean HayQuejoso = false;

			try{

				// Obtener el DataTable del grid
				tblCiudadano = gcParse.GridViewToDataTable(this.gvCiudadano, false);

				// Validaciones
				if (this.ddlFormaContacto.SelectedItem.Value == "0") { throw new Exception("El campo [Forma de Contacto] es requerido"); }
				if (this.ddlProblematica.SelectedItem.Value == "0") { throw new Exception("El campo [Problemática] es requerido"); }
				if (tblCiudadano.Rows.Count == 0) { throw (new Exception("Es necesario seleccionar un Ciudadano")); }
				if (this.ckeObservaciones.Text.Trim() == "") { throw new Exception("El campo [Observaciones] es requerido"); }

				// Obtener la sesión
				oENTSession = (ENTSession)this.Session["oENTSession"];

			    // Formulario
			    oENTSolicitud.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedValue);
			    oENTSolicitud.CalificacionId = 1;	// Sin calificar
			    oENTSolicitud.TipoSolicitudId = 1;	// Individual
			    oENTSolicitud.LugarHechosId = 5;	// Otro
			    oENTSolicitud.EstatusId = (this.ddlFuncionario.SelectedValue == "0" ? 1 : 2);	// Por Asignar o Por Atender
			    oENTSolicitud.FormaContactoId = Int32.Parse(this.ddlFormaContacto.SelectedItem.Value);
				oENTSolicitud.ProblematicaId = Int32.Parse(this.ddlProblematica.SelectedItem.Value);
			    oENTSolicitud.Observaciones = this.ckeObservaciones.Text.Trim();

			    // Ciudadanoes seleccionadas
				oENTSolicitud.tblCiudadano = new DataTable("tblCiudadano");
				oENTSolicitud.tblCiudadano.Columns.Add("CiudadanoId", typeof(Int32));
				oENTSolicitud.tblCiudadano.Columns.Add("TipoParticipacionId", typeof(Int32));
				oENTSolicitud.tblCiudadano.Columns.Add("UsuarioId", typeof(Int32));
				oENTSolicitud.tblCiudadano.Columns.Add("Presente", typeof(Int16));

				foreach(DataRow oDataRow in tblCiudadano.Rows){

					rowCiudadano = oENTSolicitud.tblCiudadano.NewRow();
					rowCiudadano["CiudadanoId"] = oDataRow["CiudadanoId"];
					rowCiudadano["TipoParticipacionId"] = oDataRow["TipoParticipacionId"];
					rowCiudadano["UsuarioId"] = oENTSession.idUsuario;
					rowCiudadano["Presente"] = oDataRow["Presente"];
					oENTSolicitud.tblCiudadano.Rows.Add(rowCiudadano);

					if (oDataRow["TipoParticipacionId"].ToString() == "1" ) { HayQuejoso = true; }

				}

				// Validación, por lo menos un quejoso
				if (HayQuejoso == false){
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Es necesario establecer por lo menos a un Quejoso', 'Warning', false); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
					return;
				}

				//Transacción
			    oENTResponse = oBPSolicitud.InsertSolicitud(oENTSolicitud);

			    // Validación de error
			    if (oENTResponse.GeneratesException){
			        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(oENTResponse.sErrorMessage) + "', 'Fail', true);;", true);
			        return;
			    }

			    if (oENTResponse.sMessage != ""){
			        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(oENTResponse.sMessage) + "', 'Warning', false);", true);
			        return;
			    }

			    // Obtener el folio y las Solicitud generados
			    sFolio = oENTResponse.dsResponse.Tables[1].Rows[0]["Folio"].ToString();
			    SolicitudId = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudId"].ToString();

				// Se limpia el formulario
				Clear();

			    // Mensaje a desplegar
				JSMensaje = "Se registro la solicitud exitosamente con folio: " + sFolio;
			    JSScript = "if( confirm('" + JSMensaje + "¿Desea ir al detalle para continuar con la captura?') ) { window.location.href('../Quejas/QueDetalleSolicitud.aspx?key=" + SolicitudId + "|3'); } else { tinyboxMessage('" + JSMensaje + "', 'Success', true);  }";

			    // Registrar Script
			    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), JSScript, true);

			}catch (Exception ex){
			    throw(ex);
			}
		}

		void InsertSolicitudCiudadano_Local(String CiudadanoId, String Foco){
			BPCiudadano BPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			DataTable tblCiudadano = null;
			DataRow rowCiudadano = null;

			try
			{

				// Formulario
				oENTCiudadano.CiudadanoId = Int32.Parse(CiudadanoId);

				// Transacción
				oENTResponse = BPCiudadano.SelectCiudadano_ByID(oENTCiudadano);

				// Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") {
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(oENTResponse.sMessage) + "', 'Warning', false); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
					return;
				}

				// Obtener el DataTable del grid
				tblCiudadano = gcParse.GridViewToDataTable(this.gvCiudadano, false);

				// Validación de que no se haya agregado el ciudadano
				if (tblCiudadano.Select("CiudadanoId='" + oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadanoId"].ToString() + "'").Length > 0) {
					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Ya ha seleccionado éste ciudadano', 'Warning', false); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
					return;
				}

				// Nuevo Item
				rowCiudadano = tblCiudadano.NewRow();
				rowCiudadano["CiudadanoId"] = oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadanoId"];
				rowCiudadano["NombreCompleto"] = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreCompleto"];
				rowCiudadano["Edad"] = oENTResponse.dsResponse.Tables[1].Rows[0]["Edad"];
				rowCiudadano["SexoNombre"] = oENTResponse.dsResponse.Tables[1].Rows[0]["SexoNombre"];
				rowCiudadano["TelefonoPrincipal"] = oENTResponse.dsResponse.Tables[1].Rows[0]["TelefonoPrincipal"];
				rowCiudadano["Domicilio"] = oENTResponse.dsResponse.Tables[1].Rows[0]["Domicilio"];

				rowCiudadano["TipoParticipacionId"] = (this.ddlTipoParticipacion.SelectedIndex == 0 ? 1 : Int32.Parse(this.ddlTipoParticipacion.SelectedItem.Value));
				rowCiudadano["TipoParticipacionNombre"] = (this.ddlTipoParticipacion.SelectedIndex == 0 ? "Afectado" : this.ddlTipoParticipacion.SelectedItem.Text);
				rowCiudadano["Presente"] = Int16.Parse((this.rblPresente.Items[0].Selected ? 1 : 0).ToString());
				rowCiudadano["PresenteString"] = (this.rblPresente.Items[0].Selected ? "Si" : "No");

				tblCiudadano.Rows.Add(rowCiudadano);

				// Refrescar el Grid
				this.gvCiudadano.DataSource = tblCiudadano;
				this.gvCiudadano.DataBind();

				// Estado del atosuggest y controles
				this.txtCiudadano.Text = "";
				this.hddCiudadanoId.Value = "";
				this.ddlTipoParticipacion.SelectedIndex = 0;
				this.rblPresente.Items[0].Selected = true;

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + Foco + "'); }", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectFormaContacto() {
			try
			{

				// Transporte
				BPFormaContacto BPFormaContacto = new BPFormaContacto();

				// COnfguración del objeto
				this.ddlFormaContacto.DataTextField = "Nombre";
				this.ddlFormaContacto.DataValueField = "FormaContactoId";

				// Transacción
				this.ddlFormaContacto.DataSource = BPFormaContacto.SelectFormaContacto();

				// Bind
				this.ddlFormaContacto.DataBind();
				this.ddlFormaContacto.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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
				oENTFuncionario.idArea = 0;
				oENTFuncionario.idRol = 5;			// Queja - Funcionario
				oENTFuncionario.TituloId = 0;
				oENTFuncionario.PuestoId = 0;
				oENTFuncionario.Nombre = "";

				// Transacción
				oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', false);", true); }

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

		void SelectProblematica(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.ProblematicaId = 0;
				oENTQueja.Nombre = "";

				// Transacción
				oENTResponse = oBPQueja.SelectProblematica(oENTQueja);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', false);", true); }

				// Llenado de control
				this.ddlProblematica.DataTextField = "Nombre";
				this.ddlProblematica.DataValueField = "ProblematicaId";
				this.ddlProblematica.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlProblematica.DataBind();

				// Opción todos
				this.ddlProblematica.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectTipoParticipacion() { 
			BPTipoCiudadano oBPTipoCiudadano = new BPTipoCiudadano();
			ENTTipoCiudadano oENTTipoCiudadano = new ENTTipoCiudadano();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTTipoCiudadano.TipoCiudadanoId = 0;
				oENTTipoCiudadano.Nombre = "";

				// Transacción
				oENTResponse = oBPTipoCiudadano.SelectTipoCiudadano(oENTTipoCiudadano);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', false);", true); }

				// Llenado de control
				this.ddlTipoParticipacion.DataTextField = "Nombre";
				this.ddlTipoParticipacion.DataValueField = "TipoCiudadanoId";
				this.ddlTipoParticipacion.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlTipoParticipacion.DataBind();

				// Opción todos
				this.ddlTipoParticipacion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

       
		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String CiudadanoId = "";

			try
			{

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener CiudadanoId
				CiudadanoId = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				switch (this.SenderId.Value){
					case "0": // Invocado desde [Menú]
						this.Sender.Value = "opeInicio.aspx";
						break;

					case "1": // Invocado desde [Recepción]
						this.Sender.Value = "opeInicio.aspx";
						break;

					case "2": // Invocado desde [Buscar ciudadano]
						this.Sender.Value = "opeBusquedaCiudadano.aspx";
						break;

					default:
						this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false);
						return;
				}

				// Estado inicial
				this.gvCiudadano.DataSource = null;
				this.gvCiudadano.DataBind();

				// Llenado de controles
				SelectFuncionario();
				SelectFormaContacto();
				SelectProblematica();
				SelectTipoParticipacion();

				if (CiudadanoId != "0") {

					InsertSolicitudCiudadano_Local(CiudadanoId, this.ddlFormaContacto.ClientID); 
				} else {

					ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlFormaContacto.ClientID + "'); }", true);
				}


			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFormaContacto.ClientID + "'); }", true);
			}
		}

		protected void btnAgregarCiudadano_Click(object sender, EventArgs e){
			String CiudadanoId;

			try
			{

				// Obtener información del ciudadano del Autosuggest
				CiudadanoId = this.Request.Form[this.hddCiudadanoId.UniqueID];

				// Normalización
				if (CiudadanoId == "") { CiudadanoId = "0"; }

				// Validaciones (se valida aquí por el comportamiento de la rutina)
				if (CiudadanoId == "0") { throw new Exception("Es necesario seleccionar un ciudadano válido"); }
				if (this.ddlTipoParticipacion.SelectedItem.Value == "0") { throw new Exception("El campo [Tipo de Participación] es requerido"); }

				// Transacción
				InsertSolicitudCiudadano_Local(CiudadanoId, this.txtCiudadano.ClientID);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
			}
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
			{

				// Transacción
				InsertSolicitud();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlFormaContacto.ClientID + "'); }", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
		}

		protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e){
			String CiudadanoId = "";
			String strCommand = "";

			DataTable tblCiudadano = null;

			try
			{

				// Opción seleccionada
				strCommand = e.CommandName.ToString();

				// Se dispara el evento RowCommand en el ordenamiento
				if (strCommand == "Sort") { return; }

				// Obtener CiudadanoId
				CiudadanoId = e.CommandArgument.ToString();

				// Transacción
				switch (strCommand){

					case "Eliminar":

						// Obtener el DataTable del grid
						tblCiudadano = gcParse.GridViewToDataTable(this.gvCiudadano, true);

						// Eliminar el Item
						tblCiudadano.Rows.Remove(tblCiudadano.Select("CiudadanoId=" + CiudadanoId)[0]);

						// Refrescar el Grid
						this.gvCiudadano.DataSource = tblCiudadano;
						this.gvCiudadano.DataBind();

						// Foco
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlFormaContacto.ClientID + "'); }", true);

						break;

				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlFormaContacto.ClientID + "');", true);
			}
        }

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDelete = null;

			String sCiudadanoId = "";
			String sNombreCiudadano = "";

			String sToolTip = "";
			String sImagesAttributes = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				//Obtener imagenes
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				//DataKeys
				sCiudadanoId = gvCiudadano.DataKeys[e.Row.RowIndex]["CiudadanoId"].ToString();
				sNombreCiudadano = this.gvCiudadano.DataKeys[e.Row.RowIndex]["NombreCompleto"].ToString();

				//Tooltips
				sToolTip = "Eliminar de la Solicitud a [" + sNombreCiudadano + "]";
				imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
				imgDelete.Attributes.Add("style", "cursor:hand;");

				//Atributos Over
				sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
				e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

				//Atributos Out
				sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
				e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
			try
            {

				gcCommon.SortGridView(ref this.gvCiudadano, ref this.hddSort, e.SortExpression);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + gcJavascript.ClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}
   
   }
}