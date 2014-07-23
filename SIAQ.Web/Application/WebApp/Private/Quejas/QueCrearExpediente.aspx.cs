/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueCrearExpediente
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
	public partial class QueCrearExpediente : System.Web.UI.Page
	{
		
		// Utilerías
		Function utilFunction = new Function();
		Encryption utilEncryption = new Encryption();


		// Funciones el programador

		void InsertExpediente() {
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			BPQueja oBPQueja = new BPQueja();

			try
			{

				// Validaciones
				if (this.ddlVisitaduria.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar una Visitaduría")); }
				
				//// Formulario
				//oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				//oENTQueja.FuncionarioId = Int32.Parse(this.ddlVisitaduria.SelectedItem.Value);

				//// Transacción
				//oENTResponse = oBPQueja.InsertSolicitudFuncionario(oENTQueja);

				//// Errores y Warnings
				//if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				//if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transación exitosa
				Response.Redirect("QueListadoSolicitudesAprobacion.aspx", false);

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

				//// Formulario
				//oENTFuncionario.FuncionarioId = 0;
				//oENTFuncionario.idUsuario = 0;
				//oENTFuncionario.idArea = 3;			// Sólo del área de Quejas
				//oENTFuncionario.TituloId = 0;
				//oENTFuncionario.PuestoId = 0;
				//oENTFuncionario.Nombre = "";

				//// Transacción
				//oENTResponse = oBPFuncionario.SelectFuncionario(oENTFuncionario);

				//// Errores
				//if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				//// Warnings
				//if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + oENTResponse.sMessage + "', 'Warning', true);", true); }

				//// Llenado de control
				//this.ddlVisitaduria.DataTextField = "sFullName";
				//this.ddlVisitaduria.DataValueField = "FuncionarioId";
				//this.ddlVisitaduria.DataSource = oENTResponse.dsResponse.Tables[1];
				//this.ddlVisitaduria.DataBind();

				// Opción todos
				this.ddlVisitaduria.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectSolicitud() {
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);

				// Transacción
				oENTResponse = oBPQueja.SelectSolicitud_Cierre(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Formulario
				this.SolicitudNumero.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["SolicitudNumero"].ToString();
				this.CalificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionNombre"].ToString();
				this.EstatusaLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["EstatusNombre"].ToString();
				this.FuncionarioLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FuncionarioNombre"].ToString();
				this.ContactoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FormaContactoNombre"].ToString();
				this.TipoSolicitudLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoSolicitudNombre"].ToString();

				this.FechaRecepcionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaRecepcion"].ToString();
				this.FechaAsignacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaAsignacion"].ToString();
				this.FechaGestionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaInicioGestion"].ToString();
				this.FechaModificacionLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["FechaUltimaModificacion"].ToString();

				this.LugarHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["LugarHechosNombre"].ToString();
				this.DireccionHechosLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DireccionHechos"].ToString();
				this.ObservacionesLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Observaciones"].ToString();
				this.FundamentoLabel.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["Fundamento"].ToString();

			}catch (Exception ex){
				throw (ex);
			}
		}


		// Eventos de la página

		protected void Page_Load(object sender, EventArgs e){
			try
            {

				// Validaciones
				if (Page.IsPostBack) { return; }
				if (this.Request.QueryString["key"] == null) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }
				if (this.Request.QueryString["key"].ToString().Split(new Char[] { '|' }).Length != 2) { this.Response.Redirect("~/Application/WebApp/Private/SysApp/saNotificacion.aspx", false); return; }

				// Obtener ExpedienteId
				this.hddSolicitudId.Value = this.Request.QueryString["key"].ToString().Split(new Char[] { '|' })[0];

				// Obtener Sender
				this.SenderId.Value = this.Request.QueryString["key"].ToString().ToString().Split(new Char[] { '|' })[1];

				// Llenado de controles
				SelectFuncionario();

				// Carátula
				SelectSolicitud();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlVisitaduria.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlVisitaduria.ClientID + "'); }", true);
            }
		}

		protected void btnAprobar_Click(object sender, EventArgs e){
			try
            {

				// Asignar el Defensor
				InsertExpediente();

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlVisitaduria.ClientID + "'); }", true);
            }
		}

		protected void btnCancelar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitudCierre.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

	}
}