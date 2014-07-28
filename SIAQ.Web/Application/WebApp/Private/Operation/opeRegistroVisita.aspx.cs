﻿// Referencias
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
    public partial class opeRegistroVisita : BPPage
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


		// Funciones del programador

		void Clear(){
			this.wucFixedDateTime.SetDateTime();
			this.ddlArea.SelectedIndex = 0;
			this.ddlFuncionario.SelectedIndex = 0;
			this.ddlMotivo.SelectedIndex = 0;
			this.ckeObservaciones.Text = "";

			this.txtCiudadano.Text = "";
			this.hddCiudadanoId.Value = "";
		}

		void InsertVisita(){
			BPVisita BPVisita = new BPVisita();

			ENTResponse oENTResponse = new ENTResponse();
			ENTVisita oENTVisita = new ENTVisita();
			ENTSession oENTSession;

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
				if (this.ddlArea.SelectedValue == "0") { throw new Exception("El campo [Área] es requerido"); }
				if (this.ddlFuncionario.SelectedValue == "0") { throw new Exception("El campo [Funcionario] es requerido"); }
				if (this.ddlMotivo.SelectedValue == "0") { throw new Exception("El campo [Motivo] es requerido"); }
				if (CiudadanoNombre == "") { throw new Exception("El campo [Visitante] es requerido"); }
				if ( Int32.Parse(CiudadanoId) <= 0) { throw new Exception("Es necesario seleccionar un ciudadano válido"); }
				if (this.ckeObservaciones.Text.Trim() == "") { throw new Exception("El campo [Observaciones] es requerido"); }

				// Obtener la sesión
				oENTSession = (ENTSession)this.Session["oENTSession"];

				//Formulario
				oENTVisita.AreaId = Int32.Parse(this.ddlArea.SelectedValue);
				oENTVisita.FuncionarioId = Int32.Parse(this.ddlFuncionario.SelectedValue);
				oENTVisita.MotivoId = Int32.Parse(this.ddlMotivo.SelectedValue);
				oENTVisita.CiudadanoId = Int32.Parse(CiudadanoId);
				oENTVisita.UsuarioIdInsert = oENTSession.idUsuario;
				oENTVisita.Visitante = CiudadanoNombre;
				oENTVisita.Observaciones = this.ckeObservaciones.Text.Trim();

				//Transacción
				oENTResponse = BPVisita.InsertVisita(oENTVisita);

				//Validación
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }

				if (oENTResponse.sMessage != ""){
			        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', false);", true);
			        return;
			    }

				// Transacción exitosa
				Clear();

				//Mensaje de usuario
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Visita registrada con éxito', 'Success', false); focusControl('" + this.ddlArea.ClientID + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectArea(){
            ENTArea oENTArea = new ENTArea();
            ENTResponse oENTResponse = new ENTResponse();

            BPArea oBPArea = new BPArea();
            String sMessage = "tinyboxToolTipMessage_ClearOld();";

            try
            {

                // Parámetros de consulta
                oENTArea.idArea = 0;
                oENTArea.sNombre = "";
                oENTArea.tiActivo = 1;
                oENTArea.tiVisitaduria = 2;
				oENTArea.tiVisita = 1;

                // Transacción
                oENTResponse = oBPArea.SelectArea(oENTArea);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

                // Mensaje de la BD
                if (oENTResponse.sMessage != "") { sMessage = "tinyboxMessage('" + utilFunction.JSClearText(oENTResponse.sMessage) + "', 'Warning', true);"; }

                // Llenado de controles
                this.ddlArea.DataValueField = "idArea";
                this.ddlArea.DataTextField = "sNombre";

                this.ddlArea.DataSource = oENTResponse.dsResponse.Tables[1];
                this.ddlArea.DataBind();
				this.ddlArea.Items.Insert(0, new ListItem("[Seleccione]", "0"));

                // Mensaje al usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), sMessage, true);

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

		void SelectFuncionario(){
			ENTFuncionario oENTFuncionario = new ENTFuncionario();
			ENTResponse oENTResponse = new ENTResponse();
			BPFuncionario BPFuncionario = new BPFuncionario();

			ddlFuncionario.DataValueField = "FuncionarioId";
			ddlFuncionario.DataTextField = "sFullName";

			oENTResponse = BPFuncionario.SelectFuncionario(oENTFuncionario);

			ddlFuncionario.DataSource = oENTResponse.dsResponse.Tables[1];
			ddlFuncionario.DataBind();
			ddlFuncionario.Items.Insert(0, new ListItem("[Seleccione]", "0"));
		}

		void SelectMotivo(){
			BPMotivo BPMotivo = new BPMotivo();
			ddlMotivo.DataValueField = "MotivoId";
			ddlMotivo.DataTextField = "Nombre";

			ddlMotivo.DataSource = BPMotivo.SelectMotivo().Tables[1];
			ddlMotivo.DataBind();
			ddlMotivo.Items.Insert(0, new ListItem("[Seleccione]", "0"));
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
				SelectArea();
				SelectFuncionario();
				SelectMotivo();
				if (CiudadanoId != "0") { SelectCiudadanoByID(CiudadanoId); }

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlArea.ClientID + "');", true);
				
            }catch (Exception ex){
				this.btnGuardar.Visible = false;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlArea.ClientID + "');", true);
            }
		}

        protected void btnGuardar_Click(object sender, EventArgs e){
			try
            {

				// Transacción
				InsertVisita();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); focusControl('" + this.ddlArea.ClientID + "');", true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect(this.Sender.Value);
        }

    }
}