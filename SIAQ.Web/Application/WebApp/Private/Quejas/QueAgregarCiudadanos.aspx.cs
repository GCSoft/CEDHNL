/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueAgregarCiudadanos
' Autor:	Ruben.Cobos
' Fecha:	17-Julio-2014
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

namespace SIAQ.Web.Application.WebApp.Private.Quejas
{
	public partial class QueAgregarCiudadanos : System.Web.UI.Page
	{

		// Utilerías
		Function utilFunction = new Function();

		// Variables globales
		ENTSession oENTSession = null;

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

		void ClearForm() {

			this.ddlTipoParticipacion.SelectedIndex = 0;
			this.chkPresente.Checked = true;

			this.txtCiudadano.Text = "";
			this.hddCiudadanoId.Value = "";
		}

		void DeleteSolicitudCiudadano(Int32 CiudadanoId) {
			BPQueja oBPQueja = new BPQueja();

			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			try
			{

				// Obtener la sesión
				SessionEntity = (ENTSession)Session["oENTSession"];
				
				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.FuncionarioId = SessionEntity.FuncionarioId;
				oENTQueja.CiudadanoId = CiudadanoId;

				// Transacción
				oENTResponse = oBPQueja.DeleteSolicitudCiudadano(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', false);", true); }

			}catch (Exception ex){
				throw (ex);
			}
		}

		void InsertSolicitudCiudadano() {
			BPQueja oBPQueja = new BPQueja();

			ENTQueja oENTQueja = new ENTQueja();
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
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.UsuarioId = SessionEntity.idUsuario;
				oENTQueja.CiudadanoId = Int32.Parse(CiudadanoId);
				oENTQueja.TipoParticipacionId = Int32.Parse(this.ddlTipoParticipacion.SelectedItem.Value);
				oENTQueja.Check = 1; // Validar el Nombre del control con el Id debido al Bug del Autosuggest
				oENTQueja.CheckNombre = CiudadanoNombre;
				oENTQueja.Presente = Int16.Parse( (this.chkPresente.Checked ? 1 : 0).ToString() );

				// Transacción
				oENTResponse = oBPQueja.InsertSolicitudCiudadano(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', false);", true); }

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

		void SelectSolicitud(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);

				// Transacción
				oENTResponse = oBPQueja.SelectSolicitud_Detalle(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Formulario
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.AfectadoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Afectado"].ToString();

				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();
				this.ProblematicaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaNombre"].ToString();
				this.ProblematicaDetalleLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["ProblematicaDetalleNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();
				this.NivelAutoridadLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["MecanismoAperturaNombre"].ToString();
				this.MecanismoAperturaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NivelAutoridadNombre"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();

				// Ciudadanos
				this.gvCiudadano.DataSource = oENTResponse.dsResponse.Tables[2];
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
			String CiudadanoId;

			try
			{

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 3) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Obtener Ciudadano a Agregar ( viene desde la pantalla de catálogo de ciudadanos )
				CiudadanoId = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[2];

				// Tipo de participación
				SelectTipoParticipacion();

				// Agregar ciudadano
				if (CiudadanoId != "0") { SelectCiudadanoByID(CiudadanoId); }

				// Consultar la carátula
				SelectSolicitud();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
			}
		}

		protected void btnAgregarCiudadano_Click(object sender, EventArgs e){
			try
			{

				// Transacción
				InsertSolicitudCiudadano();

				// Limpiar el formulario
				ClearForm();

				// Actualizar pantalla
				SelectSolicitud();

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
			}
		}

		protected void btnNuevoCiudadano_Click(object sender, EventArgs e){
			Response.Redirect("../Operation/opeRegistroCiudadano.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value);
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
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

					case "Eliminar":

						// Eliminar el ciudadano de la solicitud
						DeleteSolicitudCiudadano(Int32.Parse(CiudadanoId));

						// Limpiar el formulario
						ClearForm();

						// Actualizar pantalla
						SelectSolicitud();

						// Foco
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);

						break;

				}

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
			}
        }

		protected void gvCiudadano_RowDataBound(object sender, GridViewRowEventArgs e){
			ImageButton imgDelete = null;

			String sCiudadanoId = "";
			String sUsuarioId = "";
			String sNombreCiudadano = "";

			String sToolTip = "";
			String sImagesAttributes = "";

			try
			{
				
				// Validación de que sea fila 
				if (e.Row.RowType != DataControlRowType.DataRow) {
					oENTSession = (ENTSession)Session["oENTSession"];
					return;
				}

				// Obtener imagenes
				imgDelete = (ImageButton)e.Row.FindControl("imgDelete");

				// DataKeys
				sCiudadanoId = gvCiudadano.DataKeys[e.Row.RowIndex]["CiudadanoId"].ToString();
				sUsuarioId = gvCiudadano.DataKeys[e.Row.RowIndex]["UsuarioId"].ToString();
				sNombreCiudadano = this.gvCiudadano.DataKeys[e.Row.RowIndex]["NombreCompleto"].ToString();

				// Si el usuario que está consultando es Funcionario no se permite que elimine ciudadanos que él no haya registrado
				if( oENTSession.idRol == 5 && oENTSession.idUsuario.ToString() != sUsuarioId ){

					imgDelete.Visible = false;

					// Atributos Over y Out
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; ");
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; ");

				}else{
					
					// Tooltips
					sToolTip = "Eliminar de la Solicitud a [" + sNombreCiudadano + "]";
					imgDelete.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
					imgDelete.Attributes.Add("onmouseout", "tooltip.hide();");
					imgDelete.Attributes.Add("style", "cursor:hand;");

					// Atributos Over
					sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
					e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

					// Atributos Out
					sImagesAttributes = "document.getElementById('" + imgDelete.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
					e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		protected void gvCiudadano_Sorting(object sender, GridViewSortEventArgs e){
			DataTable tblData = null;
			DataView viewData = null;

			try
			{
				//Obtener DataTable y View del GridView
				tblData = utilFunction.ParseGridViewToDataTable(gvCiudadano, false);
				viewData = new DataView(tblData);

				//Determinar ordenamiento
				hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

				//Ordenar Vista
				viewData.Sort = hddSort.Value;

				//Vaciar datos
				this.gvCiudadano.DataSource = viewData;
				this.gvCiudadano.DataBind();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
			}
		}

	}
}