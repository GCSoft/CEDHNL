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
using SIAQ.BusinessProcess.Object;
using SIAQ.BusinessProcess.Page;
using SIAQ.Entity.Object;
using System.Data;

namespace SIAQ.Web.Application.WebApp.Private.Operation
{
	public partial class opeRegistroSolicitud : BPPage
   {

		// Utilerías
		Function utilFunction = new Function();

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
			//		* Si se selecciona un nombre válido, enseguida se borra y se pone uno inválido, el control almacena el ID del nombre válido, se implemento el siguiente Script en la transacción
			//			If Not Exists ( Select 1 From Ciudadano Where CiudadanoId = @CiudadanoId And ( Nombre + ' ' + ApellidoPaterno  + ' ' +  IsNull(ApellidoMaterno, '') = @NombreTemporal ) )
			//				Begin
			//					Set @CiudadanoId = 0
			//				End

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
			this.txtCiudadano.Text = "";
			this.hddCiudadanoId.Value = "";
			this.ddlFuncionario.SelectedValue = "0";
			this.ckeObservaciones.Text = "";
		}

		void InsertSolicitud(){
			BPSolicitud oBPSolicitud = new BPSolicitud();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSolicitud oENTSolicitud = new ENTSolicitud();

			String JSMensaje = "";
			String JSScript = "";

			String SolicitudId = "";
			String sFolio = "";

			String CiudadanoId;
			String CiudadanoNombre;

			try{

				// Obtener información del ciudadano del Autosuggest
				CiudadanoId = this.Request.Form[this.hddCiudadanoId.UniqueID];
				CiudadanoNombre = this.Request.Form[this.txtCiudadano.UniqueID];

				// Normalización
				if (CiudadanoId == "") { CiudadanoId = "0"; }
				CiudadanoNombre = CiudadanoNombre.Trim();

				// Validaciones
				if (CiudadanoNombre == "") { throw new Exception("El campo [Nombre del ciudadano] es requerido"); }
				if (this.ddlFormaContacto.SelectedItem.Value == "0") { throw new Exception("El campo [Forma de Contacto] es requerido"); }
				if (this.ckeObservaciones.Text.Trim() == "") { throw new Exception("El campo [Observaciones] es requerido"); }

			    // Formulario
			    oENTSolicitud.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedValue);
			    oENTSolicitud.CalificacionId = 1;	// Sin calificar
			    oENTSolicitud.TipoSolicitudId = 1;	// Individual
			    oENTSolicitud.LugarHechosId = 5;	// Otro
			    oENTSolicitud.EstatusId = (this.ddlFuncionario.SelectedValue == "0" ? 1 : 2);	// Por Asignar o Por Atender
			    oENTSolicitud.CiudadanoId = Int32.Parse(CiudadanoId);
			    oENTSolicitud.FormaContactoId = Int32.Parse(this.ddlFormaContacto.SelectedItem.Value);
				oENTSolicitud.NombreTemporal = CiudadanoNombre;
			    oENTSolicitud.Observaciones = this.ckeObservaciones.Text.Trim();

			    // Transacción
			    oENTResponse = oBPSolicitud.InsertSolicitud(oENTSolicitud);

			    // Validación de error
			    if (oENTResponse.GeneratesException){
			        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sErrorMessage) + "', 'Fail', true);;", true);
			        return;
			    }

			    if (oENTResponse.sMessage != ""){
			        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', false);", true);
			        return;
			    }

			    // Obtener el folio y las Solicitud generados
			    sFolio = oENTResponse.dsResponse.Tables[1].Rows[0]["Folio"].ToString();
			    SolicitudId = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudId"].ToString();

				// Se limpia el formulario
				Clear();

			    // Mensaje a desplegar
				JSMensaje = "Se registro la solicitud exitosamente para el ciudadano [" + CiudadanoNombre + "] con folio: " + sFolio;
			    JSScript = "if( confirm('" + JSMensaje + "¿Desea ir al detalle para continuar con la captura?') ) { window.location.href('../Quejas/QueDetalleSolicitud.aspx?key=" + SolicitudId + "|3'); } else { tinyboxMessage('" + JSMensaje + "', 'Success', true);  }";

			    // Registrar Script
			    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), JSScript, true);

			}catch (Exception ex){
			    throw(ex);
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

		void SelectFormaContacto() {
			try
			{

				// Transporte
				BPFormaContacto BPFormaContacto = new BPFormaContacto();

				// COnfguración del objeto
				ddlFormaContacto.DataTextField = "Nombre";
				ddlFormaContacto.DataValueField = "FormaContactoId";

				// Transacción
				ddlFormaContacto.DataSource = BPFormaContacto.SelectFormaContacto();

				// Bind
				ddlFormaContacto.DataBind();
				ddlFormaContacto.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', true);", true); }

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

				// Llenado de controles
				SelectFuncionario();
				SelectFormaContacto();
				if (CiudadanoId != "0") { SelectCiudadanoByID(CiudadanoId); }

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + ex.Message + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
			}
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			try
			{

				// Transacción
				InsertSolicitud();

			}catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.txtCiudadano.ClientID + "'); }", true);
			}
		}

		protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
		}
   
   }
}