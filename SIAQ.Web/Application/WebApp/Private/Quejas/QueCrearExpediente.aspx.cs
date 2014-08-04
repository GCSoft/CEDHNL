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


		// Rutinas del programador

		void CreateFolio(){
			BPQueja oBPQueja = new BPQueja();
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			String CalificacionId = this.hddCalificacionId.Value;

			try
			{

				// Validaciones - A excepcion de la clasificación Orientación/Apoyo, será necesario seleccionar una visitaduría
				if (CalificacionId != "3" && CalificacionId != "9"){
					if (this.ddlVisitaduria.SelectedItem.Value == "0") { throw (new Exception("Es necesario seleccionar una Visitaduría")); }
				}

				// Determinar el Tipo de Folio
				switch (CalificacionId){
					case "2": // Queja
					case "4": // SI
					case "5": // Otra CEDH
					case "6": // Comisión Nacional de los Derechos Humanos

						oENTQueja.TipoFolio = 1; // Folio de Queja
						break;

					case "3": // Orientación
					case "9": // Apoyo o colaboración

						oENTQueja.TipoFolio = 2; // Folio de Orientacion
						break;

					case "7": // Solicitud de gestión

						if(this.ddlVisitaduria.SelectedItem.Value == "3"){
							oENTQueja.TipoFolio = 3; // Folio de GestionQuejas
						}else{
							oENTQueja.TipoFolio = 4; // Folio de GestionPenitenciaria
						}
						
						break;

					case "8": // Medidas Cautelares

						oENTQueja.TipoFolio = 5; // Folio de Medida Cautelar
						break;

					default: // No configurada

						throw (new Exception("Opción no configurada"));
				}

				// Transacción
				oENTResponse = oBPQueja.CreateFolio(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

				// Transación exitosa
				this.lblExpediente.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["NumeroFolio"].ToString();

			}catch(Exception ex){
				throw(ex);
			}
		}

		void InsertExpediente() {
			ENTQueja oENTQueja = new ENTQueja();
			ENTResponse oENTResponse = new ENTResponse();

			BPQueja oBPQueja = new BPQueja();

			try
			{

				// Validaciones
				if (this.lblExpediente.Text.Trim() == "") { throw (new Exception("Es necesario generar el folio del expediente")); }

				// Formulario
				oENTQueja.SolicitudId = Int32.Parse(this.hddSolicitudId.Value);
				oENTQueja.AreaId = Int32.Parse(this.ddlVisitaduria.SelectedItem.Value);
				oENTQueja.CalificacionId = Int32.Parse(this.hddCalificacionId.Value);
				oENTQueja.NumeroFolio = this.lblExpediente.Text.Trim();

				// Transacción
				oENTResponse = oBPQueja.InsertExpediente(oENTQueja);

				// Errores y Warnings
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }
				if (oENTResponse.sMessage != "") { throw (new Exception(oENTResponse.sMessage)); }

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
				
				// Campos ocultos
				this.hddCalificacionId.Value = oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString();

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

				// Llenado de Visitadurias en base al catálogo de Áreas y la calificación de la Solicitud
				switch (oENTResponse.dsResponse.Tables[1].Rows[0]["CalificacionId"].ToString()){
					case "2": // Queja
					case "4": // SI
					case "8": // Medidas Cautelares

						this.ddlVisitaduria.Items.Insert(0, new ListItem("Tercera Visitaduría", "6"));
						this.ddlVisitaduria.Items.Insert(0, new ListItem("Segunda Visitaduría", "5"));
						this.ddlVisitaduria.Items.Insert(0, new ListItem("Primera Visitaduría", "4"));
						this.ddlVisitaduria.Items.Insert(0, new ListItem("[Seleccione]", "0"));
						break;

					case "7": // Solicitud de gestión

						this.ddlVisitaduria.Items.Insert(0, new ListItem("Dirección de Orientación y Recepción de Quejas", "3"));
						this.ddlVisitaduria.Items.Insert(0, new ListItem("Coordinación Penitenciaria", "10"));
						this.ddlVisitaduria.Items.Insert(0, new ListItem("[Seleccione]", "0"));
						break;

					case "5": // Otra CEDH
					case "6": // Comisión Nacional de los Derechos Humanos

						this.ddlVisitaduria.Items.Insert(0, new ListItem("Primera Visitaduría", "4"));
						this.ddlVisitaduria.Items.Insert(0, new ListItem("[Seleccione]", "0"));
						break;

					case "3": // Orientación
					case "9": // Apoyo o colaboración

						this.ddlVisitaduria.Items.Insert(0, new ListItem("", "0"));
						this.ddlVisitaduria.Enabled = false;
						break;

					default: // No configurada

						this.ddlVisitaduria.Enabled = false;
						this.btnCrearFolio.Enabled = false;
						this.btnCrearFolio.CssClass = "Button_General_Disabled";
						break;
				}

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

				// Transación exitosa
				Response.Redirect("QueListadoSolicitudesAprobacion.aspx", false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlVisitaduria.ClientID + "'); }", true);
            }
		}

		protected void btnCancelar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitudCierre.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
		}

		protected void btnCrearFolio_Click(object sender, EventArgs e){
			try
            {

				// Crear Folio
				CreateFolio();

				// Inhabilitar controles de folio
				this.ddlVisitaduria.Enabled = false;
				this.btnCrearFolio.Enabled = false;
				this.btnCrearFolio.CssClass = "Button_General_Disabled";

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true); function pageLoad(){ focusControl('" + this.ddlVisitaduria.ClientID + "'); }", true);
            }
		}

	}
}