/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visResolucionExpediente
' Autor:	Ruben.Cobos
' Fecha:	30-Agosto-2014
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
    public partial class visResolucionExpediente : System.Web.UI.Page
    {

		// Utilerías
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();

		// Rutinas del programador

		String GetKey(String sKey) {
			String Response = "";

			try{

				Response = gcEncryption.DecryptString(sKey, true);

			}catch(Exception){
				Response = "";
			}

			return Response;
		}


		// Funciones el programador

		void InsertExpedienteResolucion() {
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();
			ENTSession SessionEntity = new ENTSession();

			BPVisitaduria oBPVisitaduria = new BPVisitaduria();

			try
			{

				// Validaciones
				if (this.ddlTipoResolucion.SelectedIndex == 0) { throw new Exception("El campo [Tipo de Resolución] es requerido"); }
				if (this.ddlTipoResolucion.SelectedItem.Value == "1") { throw new Exception("Es necesario determinar el Tipo de Resolución"); }
				if (this.ckeDetalle.Text.Trim() == "") { throw (new Exception("Es necesario ingresar un detalle de la resolución")); }

				// Obtener sesión
				SessionEntity = (ENTSession)Session["oENTSession"];
				
				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.FuncionarioId = SessionEntity.FuncionarioId;
				oENTVisitaduria.TipoResolucionId = Int32.Parse(this.ddlTipoResolucion.SelectedItem.Value);
				oENTVisitaduria.Detalle = this.ckeDetalle.Text.Trim();

				// Transacción
				oENTResponse = oBPVisitaduria.InsertExpedienteResolucion(oENTVisitaduria);

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

				// Resolución
				this.ddlTipoResolucion.SelectedValue = oENTResponse.dsResponse.Tables[1].Rows[0]["TipoResolucionId"].ToString();
				this.ckeDetalle.Text = oENTResponse.dsResponse.Tables[1].Rows[0]["DetalleResolucion"].ToString();

				// Script de Validación de cambio de estatus (Antes Queja)
				if (oENTResponse.dsResponse.Tables[1].Rows[0]["TipoResolucionId"].ToString() == "2"){
					this.btnGuardar.Attributes.Add("onclick", " if ( document.getElementById('" + this.ddlTipoResolucion.ClientID + "').options[document.getElementById('" + this.ddlTipoResolucion.ClientID + "').selectedIndex].value != 2 ) { return confirm('Al cambiar la resolución se eliminarán todas las capturas de Recomendaciones realizadas en el Expediente, ¿Seguro que desea continuar?'); }");
				}

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectTipoResolucion(){
			BPTipoResolucion oBPTipoResolucion = new BPTipoResolucion();
			ENTTipoResolucion oENTTipoResolucion = new ENTTipoResolucion();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTTipoResolucion.TipoResolucionId = 0;
				oENTTipoResolucion.Nombre = "";

				// Transacción
				oENTResponse = oBPTipoResolucion.SelectTipoResolucion(oENTTipoResolucion);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlTipoResolucion.DataTextField = "Nombre";
				this.ddlTipoResolucion.DataValueField = "TipoResolucionId";
				this.ddlTipoResolucion.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlTipoResolucion.DataBind();

				// Opción todos
				this.ddlTipoResolucion.Items.Insert(0, new ListItem("[Seleccione]", "0"));

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

				// Llenado de controles
				SelectTipoResolucion();

				// Carátula
				SelectExpediente();
				
				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlTipoResolucion.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoResolucion.ClientID + "'); }", true);
            }
		}

		protected void btnGuardar_Click(object sender, EventArgs e){
			String sKey = "";

			try
            {

				// Asignar el Defensor
				InsertExpedienteResolucion();

				// Llave encriptada
				sKey = this.hddExpedienteId.Value + "|" + this.SenderId.Value;
				sKey = gcEncryption.EncryptString(sKey, true);
				this.Response.Redirect("visDetalleExpediente.aspx?key=" + sKey, false);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoResolucion.ClientID + "'); }", true);
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
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); function pageLoad(){ focusControl('" + this.ddlTipoResolucion.ClientID + "'); }", true);
            }
		}

    }
}