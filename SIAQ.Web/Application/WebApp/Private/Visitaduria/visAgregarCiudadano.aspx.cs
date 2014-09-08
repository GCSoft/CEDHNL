/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visAgregarCiudadano
' Autor:	Ruben.Cobos
' Fecha:	08-Septiembre-2014
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
	public partial class visAgregarCiudadano : System.Web.UI.Page
	{
		
		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCEncryption gcEncryption = new GCEncryption();
		GCJavascript gcJavascript = new GCJavascript();

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


		// Rutinas el programador

		void ClearForm(){
			this.rblPresente.Items[0].Selected = true;

			this.txtCiudadano.Text = "";
			this.hddCiudadanoId.Value = "";
		}

		void DeleteExpedienteCiudadano(Int32 CiudadanoId) {
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();

			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

			    // Formulario
			    oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
			    oENTVisitaduria.CiudadanoId = CiudadanoId;
				oENTVisitaduria.ModuloId = 3; // Visitadurías

			    // Transacción
			    oENTResponse = oBPVisitaduria.DeleteExpedienteCiudadano(oENTVisitaduria);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void InsertExpedienteCiudadano() {
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();

			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			String CiudadanoId;
			String CiudadanoNombre;

			try
			{

			    // Obtener información del ciudadano del Autosuggest
			    CiudadanoId = this.Request.Form[this.hddCiudadanoId.UniqueID];
			    CiudadanoNombre = this.Request.Form[this.txtCiudadano.UniqueID];

			    // Normalización
			    if (CiudadanoId == "") { CiudadanoId = "0"; }
			    CiudadanoNombre = CiudadanoNombre.Trim();

			    // Validaciones
			    if (CiudadanoNombre == "" ) { throw new Exception("El campo [Nombre del ciudadano] es requerido"); }
			    if (this.ddlTipoParticipacion.SelectedItem.Value == "0") { throw new Exception("El campo [Tipo de Participación] es requerido"); }

			    // Obtener la sesión
			    SessionEntity = (ENTSession)Session["oENTSession"];
				
			    // Formulario
			    oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
			    oENTVisitaduria.UsuarioId = SessionEntity.idUsuario;
			    oENTVisitaduria.CiudadanoId = Int32.Parse(CiudadanoId);
				oENTVisitaduria.ModuloId = 3; // Visitadurías
			    oENTVisitaduria.TipoParticipacionId = Int32.Parse(this.ddlTipoParticipacion.SelectedItem.Value);
			    oENTVisitaduria.Check = 1; // Validar el Nombre del control con el Id debido al Bug del Autosuggest
			    oENTVisitaduria.CheckNombre = CiudadanoNombre;
			    oENTVisitaduria.Presente = Int16.Parse((this.rblPresente.Items[0].Selected ? 1 : 0).ToString());

			    // Transacción
			    oENTResponse = oBPVisitaduria.InsertExpedienteCiudadano(oENTVisitaduria);

			    // Errores y Warnings
			    if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage));  }

			}catch (Exception ex){
			    throw (ex);
			}
		}

		void SelectCiudadanoByID(String CiudadanoId){
			BPCiudadano BPCiudadano = new BPCiudadano();
			ENTResponse oENTResponse = new ENTResponse();
			ENTCiudadano oENTCiudadano = new ENTCiudadano();

			try
			{

			    // Formulario
			    oENTCiudadano.CiudadanoId = Int32.Parse(CiudadanoId);

			    // Transacción
			    oENTResponse = BPCiudadano.SelectCiudadano_ByID(oENTCiudadano);

			    // Validación
			    if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
			    if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

			    // Cargar el Autosuggest de Búsqueda de ciudadano
				this.txtCiudadano.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NombreCompleto"].ToString();
				this.hddCiudadanoId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["CiudadanoId"].ToString();

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
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlTipoParticipacion.DataTextField = "Nombre";
				this.ddlTipoParticipacion.DataValueField = "TipoCiudadanoId";
				this.ddlTipoParticipacion.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlTipoParticipacion.DataBind();

				// Opción todos
				this.ddlTipoParticipacion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

				// Sólo es posible agregar Testigos
				this.ddlTipoParticipacion.SelectedValue = "5";
				this.ddlTipoParticipacion.Enabled = false;

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			String sKey = "";
			String CiudadanoId;

			try
            {

				// Validaciones de llamada
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Validaciones de parámetros
				sKey = GetKey(this.Request.QueryString["key"].ToString());
				if (sKey == "") { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (sKey.ToString().Split(new Char[] { '|' }).Length != 3) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddExpedienteId.Value = sKey.Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = sKey.Split(new Char[] { '|' })[1];

				// Obtener Ciudadano a Agregar ( viene desde la pantalla de catálogo de ciudadanos )
				CiudadanoId = sKey.Split(new Char[] { '|' })[2];

				// Tipo de participación
				SelectTipoParticipacion();

				// Agregar ciudadano
				if (CiudadanoId != "0") { SelectCiudadanoByID(CiudadanoId); }

				// Consultar la carátula
				SelectExpediente();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
            }
		}

		protected void btnAgregarCiudadano_Click(object sender, EventArgs e){
			try
			{

				// Transacción
				InsertExpedienteCiudadano();

				// Limpiar el formulario
				ClearForm();

				// Actualizar pantalla
				SelectExpediente();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
			}
		}

		protected void btnNuevoCiudadano_Click(object sender, EventArgs e){
			Response.Redirect("../Operation/opeRegistroCiudadano.aspx?visKey=" + this.hddExpedienteId.Value + "|" + this.SenderId.Value);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
            }
		}

		protected void gvCiudadano_RowCommand(object sender, GridViewCommandEventArgs e){
			String CiudadanoId = "";
			String strCommand = "";

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

					case "Editar":
						Response.Redirect("../Operation/opeRegistroCiudadano.aspx?s=" + CiudadanoId + "&visKey=" + this.hddExpedienteId.Value + "|" + this.SenderId.Value);
						break;

					case "Eliminar":

						// Eliminar el ciudadano de la solicitud
						DeleteExpedienteCiudadano(Int32.Parse(CiudadanoId));

						// Limpiar el formulario
						ClearForm();

						// Actualizar pantalla
						SelectExpediente();

						// Foco
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide(); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);

						break;

				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
			}
        }

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDelete = null;
			ImageButton imgEdit = null;

			String sCiudadanoId = "";
			String ModuloId = "";
			String sUsuarioId = "";
			String sNombreCiudadano = "";

			String sToolTip = "";
			String sImagesAttributes = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) { return; }

				// Obtener imagenes
				imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// DataKeys
				sCiudadanoId = gvCiudadano.DataKeys[e.Row.RowIndex]["CiudadanoId"].ToString();
				ModuloId = gvCiudadano.DataKeys[e.Row.RowIndex]["ModuloId"].ToString();
				sUsuarioId = gvCiudadano.DataKeys[e.Row.RowIndex]["UsuarioId"].ToString();
				sNombreCiudadano = this.gvCiudadano.DataKeys[e.Row.RowIndex]["NombreCompleto"].ToString();

				// Si el ciudadano no fue capturado en el módulo de Visitadurías no se permite eliminar
				if( ModuloId!= "3" ){

					imgDelete.Visible = false;

					// Tooltip Editar
					sToolTip = "Editar ciudadano [" + sNombreCiudadano + "]";
					imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
					imgEdit.Attributes.Add("style", "curosr:hand;");

					// Atributos Over
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

					// Atributos Out
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

				}else{

					// Tooltip Editar
					sToolTip = "Editar ciudadano [" + sNombreCiudadano + "]";
					imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
					imgEdit.Attributes.Add("style", "curosr:hand;");
					
					// Tooltip Eliminar
					sToolTip = "Eliminar de la Solicitud a [" + sNombreCiudadano + "]";
					imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
					imgDelete.Attributes.Add("style", "cursor:hand;");

					// Atributos Over
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

					// Atributos Out
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
					sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

				}

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

	}
}