/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	QueAgregarAutoridadSenalada
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
	public partial class QueAgregarAutoridadSenalada : System.Web.UI.Page
	{
		

		// Utilerías
        Function utilFunction = new Function();
        Encryption utilEncryption = new Encryption();


		void SelectSolicitud() {
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

			}catch (Exception ex){
				throw (ex);
			}
		}

      
        // Rutinas del programador

        private void AgregarAutoridad(int SolicitudId){
            BPAutoridad oBPAutoridad = new BPAutoridad();
            ENTAutoridad oENTAutoridad = new ENTAutoridad();
            ENTResponse oENTResponse = new ENTResponse();

            Int32 AutoridadId = 0;

            try
            {

                // Validaciones
                if (this.ddlActionPrimerNivel.SelectedValue == "0") { throw new Exception("Debe elegir una autoridad"); }
                if (String.IsNullOrEmpty(this.tbActionNombreFuncionario.Text)) { throw new Exception("El campo [Nombre] es requerido"); }

                // Determinar la última autoridad seleccionada
                AutoridadId = Convert.ToInt32(this.ddlActionPrimerNivel.SelectedValue);
                if (this.ddlActionSegundoNivel.SelectedIndex > 0) { AutoridadId = Convert.ToInt32(this.ddlActionSegundoNivel.SelectedValue); }
                if (this.ddlActionTercerNivel.SelectedIndex > 0) { AutoridadId = Convert.ToInt32(this.ddlActionTercerNivel.SelectedValue); }

                // Formulario 
                oENTAutoridad.SolicitudId = SolicitudId;
                oENTAutoridad.AutoridadId = AutoridadId;
                oENTAutoridad.Nombre = tbActionNombreFuncionario.Text;
                oENTAutoridad.Puesto = tbActionPuestoActual.Text;
                oENTAutoridad.Comentario = tbActionComentarios.Text;

                //Transacción 
                oENTResponse = oBPAutoridad.InsertSolicitudAutoridad(oENTAutoridad);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                // Transacción exitosa
                this.pnlAction.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Autoridad agregada con éxito', 'Success', false);", true);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlActionPrimerNivel.ClientID + "');", true);
                throw (ex);
            }
        }

        private void AgregarVoz(int SolicitudId, int AutoridadId){
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();
            ENTVocesSenaladas oENTVocesSenaladas = new ENTVocesSenaladas();
            ENTResponse oENTResponse = new ENTResponse();

            Int32 VozId = 0;

            try
            {

                // Validaciones
                if (this.ddlVocesTemporal_Nivel1.SelectedValue == "0") { throw new Exception("Debe elegir una voz señalada"); }

                // Determinar la última voz seleccionada
                VozId = Convert.ToInt32(this.ddlVocesTemporal_Nivel1.SelectedValue);
                if (this.ddlVocesTemporal_Nivel2.SelectedIndex > 0) { VozId = Convert.ToInt32(this.ddlVocesTemporal_Nivel2.SelectedValue); }
                if (this.ddlVocesTemporal_Nivel3.SelectedIndex > 0) { VozId = Convert.ToInt32(this.ddlVocesTemporal_Nivel3.SelectedValue); }

                // Formulario 
                oENTVocesSenaladas.SolicitudId = SolicitudId;
                oENTVocesSenaladas.AutoridadId = AutoridadId;
                oENTVocesSenaladas.VozId = VozId;
				oENTVocesSenaladas.Comentarios = this.txtVocesTemporal_Comentarios.Text.Trim();

                //Transacción 
                oENTResponse = oBPVocesSenaladas.InsertSolicitudAutoridadVoces(oENTVocesSenaladas);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                // Refrescar Grid
                LlenarGridVoces_Temporal(SolicitudId, AutoridadId);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlVocesTemporal_Nivel1.ClientID + "');", true);
                throw (ex);
            }
        }

        private void BorrarAutoridad(int SolicitudId, int AutoridadId){
            BPAutoridad oBPAutoridad = new BPAutoridad();
            ENTAutoridad oENTAutoridad = new ENTAutoridad();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                // Formulario 
                oENTAutoridad.SolicitudId = SolicitudId;
                oENTAutoridad.AutoridadId = AutoridadId;

                // Transacción 
                oENTResponse = oBPAutoridad.DeleteSolicitudAutoridad(oENTAutoridad);

                // Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                // Recargar grid del listado de autoridades asociadas al expediente
                LlenarGridAutoridades(Convert.ToInt32(hddSolicitudId.Value));

                // Trasacción exitosa
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Autoridad eliminada con éxito', 'Success', false);", true);

            }catch (Exception ex){
                throw (ex);
            }
        }

        private void BorrarVoz(int SolicitudId, int AutoridadId, int VozId){
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();
            ENTVocesSenaladas oENTVocesSenaladas = new ENTVocesSenaladas();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {
                // Formulario 
                oENTVocesSenaladas.SolicitudId = SolicitudId;
                oENTVocesSenaladas.AutoridadId = AutoridadId;
                oENTVocesSenaladas.VozId = VozId;

                //Transacción 
                oENTResponse = oBPVocesSenaladas.DeleteSolicitudAutoridadVoces(oENTVocesSenaladas);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                // Recargar grid del listado de autoridades asociadas al expediente
                LlenarGridAutoridades(SolicitudId);

                // Recargar grid de Voces
                LlenarGridVoces_Temporal(SolicitudId, AutoridadId);

            }catch (Exception ex){
                throw (ex);
            }
        }

        private void ClearActionPanel(Boolean EnableDDL, Int32 AutoridadId){
            try
            {

                // Limpiar formulario de Nueva Autoridad
                this.ddlActionPrimerNivel.SelectedIndex = 0;
                this.ddlActionSegundoNivel.SelectedIndex = 0;
                this.ddlActionTercerNivel.SelectedIndex = 0;
                this.tbActionNombreFuncionario.Text = "";
                this.tbActionPuestoActual.Text = "";
                this.tbActionComentarios.Text = "";

                // Estado de DropDownList
                this.ddlActionPrimerNivel.Enabled = EnableDDL;
                this.ddlActionSegundoNivel.Enabled = EnableDDL;
                this.ddlActionTercerNivel.Enabled = EnableDDL;

                // Estado incial de controles
                this.pnlAction.Visible = false;
                this.lblActionMessage.Text = "";

                // Autoridad como parámetro
                this.hdnAutoridadId.Value = AutoridadId.ToString();

            }catch (Exception ex){
                throw (ex);
            }
        }

        private void ClearVocesPanel(Int32 AutoridadId){
            try
            {

                // Limpiar formulario de Nueva Autoridad
                lblVocesNombre.Text = String.Empty;
                lblVocesPuesto.Text = String.Empty;
                lblVocesObservaciones.Text = String.Empty;
                lblVocesNivel1.Text = String.Empty;
                lblVocesNivel2.Text = String.Empty;
                lblVocesNivel3.Text = String.Empty;
				this.txtVocesTemporal_Comentarios.Text = "";

                // Estado incial de controles
                this.pnlVoces.Visible = false;
                this.lblVocesMessage.Text = "";

                // Autoridad como parámetro
                this.hdnAutoridadId.Value = AutoridadId.ToString();

            }catch (Exception ex){
                throw (ex);
            }
        }

        private void ComboAutoridadPrimerNivel(){
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = 0;
            oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
            oBPAutoridad.SelectNivelesAutoridad();

            if (oBPAutoridad.ErrorId == 0){
                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
                    ddlActionPrimerNivel.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0];
                    ddlActionPrimerNivel.DataTextField = "Nombre";
                    ddlActionPrimerNivel.DataValueField = "AutoridadId";
                    ddlActionPrimerNivel.DataBind();
                }
            }
        }

        private void ComboAutoridadSegundoNivel(){
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(ddlActionPrimerNivel.SelectedValue);
            oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
            oBPAutoridad.SelectNivelesAutoridad();

            if (oBPAutoridad.ErrorId == 0){
                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
                    ddlActionSegundoNivel.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[1];
                    ddlActionSegundoNivel.DataTextField = "Nombre";
                    ddlActionSegundoNivel.DataValueField = "AutoridadId";
                    ddlActionSegundoNivel.DataBind();
                }
            }
        }

        private void ComboAutoridadTercerNivel(){
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(ddlActionPrimerNivel.SelectedValue);
            oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = Convert.ToInt32(ddlActionSegundoNivel.SelectedValue);
            oBPAutoridad.SelectNivelesAutoridad();

            if (oBPAutoridad.ErrorId == 0){
                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
                    ddlActionTercerNivel.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[2];
                    ddlActionTercerNivel.DataTextField = "Nombre";
                    ddlActionTercerNivel.DataValueField = "AutoridadId";
                    ddlActionTercerNivel.DataBind();
                }
            }
        }

        private void ComboVocesTemporalPrimerNivel(){
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();

            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadrePrimerNivel = 0;
            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadreSegundoNivel = 0;

            oBPVocesSenaladas.SelectNivelesVoces();

            if (oBPVocesSenaladas.ErrorId == 0)
            {
                if (oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[0].Rows.Count > 0)
                {
                    ddlVocesTemporal_Nivel1.DataSource = oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[0];
                    ddlVocesTemporal_Nivel1.DataTextField = "Nombre";
                    ddlVocesTemporal_Nivel1.DataValueField = "VozId";
                    ddlVocesTemporal_Nivel1.DataBind();
                }
            }
        }

        private void ComboVocesTemporalSegundoNivel(){
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();

            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadrePrimerNivel = Convert.ToInt32(ddlVocesTemporal_Nivel1.SelectedValue);
            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadreSegundoNivel = 0;

            oBPVocesSenaladas.SelectNivelesVoces();

            if (oBPVocesSenaladas.ErrorId == 0)
            {
                if (oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[1].Rows.Count > 0)
                {
                    ddlVocesTemporal_Nivel2.DataSource = oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[1];
                    ddlVocesTemporal_Nivel2.DataTextField = "Nombre";
                    ddlVocesTemporal_Nivel2.DataValueField = "VozId";
                    ddlVocesTemporal_Nivel2.DataBind();
                }
            }
        }

        private void ComboVocesTemporalTercerNivel(){
            BPVocesSenaladas oBPVocesSenaladas = new BPVocesSenaladas();

            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadrePrimerNivel = Convert.ToInt32(ddlVocesTemporal_Nivel1.SelectedValue);
            oBPVocesSenaladas.VocesSenaladasEntity.VozIdPadreSegundoNivel = Convert.ToInt32(ddlVocesTemporal_Nivel2.SelectedValue);

            oBPVocesSenaladas.SelectNivelesVoces();

            if (oBPVocesSenaladas.ErrorId == 0)
            {
                if (oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[2].Rows.Count > 0)
                {
                    ddlVocesTemporal_Nivel3.DataSource = oBPVocesSenaladas.VocesSenaladasEntity.dsResponse.Tables[2];
                    ddlVocesTemporal_Nivel3.DataTextField = "Nombre";
                    ddlVocesTemporal_Nivel3.DataValueField = "VozId";
                    ddlVocesTemporal_Nivel3.DataBind();
                }
            }
        }

        private void LlenarGridAutoridades(int SolicitudId){
            BPSolicitud oBPSolicitud = new BPSolicitud();

            // Estado inicial del grid
            this.gvAutoridades.DataSource = null;
            this.gvAutoridades.DataBind();

            // Transacción
            oBPSolicitud.SolicitudEntity.SolicitudId = SolicitudId;
            oBPSolicitud.SelectSolicitudAutoridad();

            // Validaciones
            if (oBPSolicitud.ErrorId != 0){ return; }

            // Listado de autoridades
            if (oBPSolicitud.SolicitudEntity.ResultData.Tables[0].Rows.Count > 0){

                this.gvAutoridades.DataSource = oBPSolicitud.SolicitudEntity.ResultData;
                this.gvAutoridades.DataBind();
            }

			//// Número de solicitud
			//this.SolicitudLabel.Text = oBPSolicitud.SolicitudEntity.ResultData.Tables[1].Rows[0]["Numero"].ToString();

        }

        private void LlenarGridVoces_Detalle(ref GridView grdDetalle, Int32 SolicitudId, Int32 AutoridadId){
            BPSolicitud oBPSolicitud = new BPSolicitud();

            // Estado inicial del grid
            grdDetalle.DataSource = null;
            grdDetalle.DataBind();

            // Transacción
            oBPSolicitud.AutoridadEntity.SolicitudId = SolicitudId;
            oBPSolicitud.AutoridadEntity.AutoridadId = AutoridadId;
            oBPSolicitud.SelectSolicitudAutoridadVoces();

            // Validaciones
            if (oBPSolicitud.ErrorId != 0) { return; }

            // Listado de voces
            if (oBPSolicitud.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
                grdDetalle.DataSource = oBPSolicitud.AutoridadEntity.dsResponse;
                grdDetalle.DataBind();
            }

        }

        private void LlenarGridVoces_Temporal(int SolicitudId, int AutoridadId){
            BPSolicitud oBPSolicitud = new BPSolicitud();

            // Estado inicial del grid
            this.gvVocesTemporal.DataSource = null;
            this.gvVocesTemporal.DataBind();

            // Transacción
            oBPSolicitud.AutoridadEntity.SolicitudId = SolicitudId;
            oBPSolicitud.AutoridadEntity.AutoridadId = AutoridadId;
            oBPSolicitud.SelectSolicitudAutoridadVoces();

            // Validaciones
            if (oBPSolicitud.ErrorId != 0) { return; }

            // Listado de voces
            if (oBPSolicitud.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
                this.gvVocesTemporal.DataSource = oBPSolicitud.AutoridadEntity.dsResponse;
                this.gvVocesTemporal.DataBind();
            }

        }

        private void ModificarAutoridad(int SolicitudId){
            BPAutoridad oBPAutoridad = new BPAutoridad();
            ENTAutoridad oENTAutoridad = new ENTAutoridad();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Validaciones
                if (this.ddlActionPrimerNivel.SelectedValue == "0") { throw new Exception("Debe elegir una autoridad"); }
                if (String.IsNullOrEmpty(this.tbActionNombreFuncionario.Text)) { throw new Exception("El campo [Nombre] es requerido"); }

                // Formulario 
                oENTAutoridad.SolicitudId = SolicitudId;
                oENTAutoridad.AutoridadId = Convert.ToInt32(this.hdnAutoridadId.Value);
                oENTAutoridad.Nombre = tbActionNombreFuncionario.Text;
                oENTAutoridad.Puesto = tbActionPuestoActual.Text;
                oENTAutoridad.Comentario = tbActionComentarios.Text;

                //Transacción 
                oENTResponse = oBPAutoridad.UpdateSolicitudAutoridad(oENTAutoridad);

                //Validaciones 
                if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
                if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

                // Transacción exitosa
                this.pnlAction.Visible = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('Autoridad modificada con éxito', 'Success', false);", true);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.tbActionNombreFuncionario.ClientID + "');", true);
                throw (ex);
            }
        }

        private void MostrarDetalleAutoridad(int SolicitudId, int AutoridadId){
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.SolicitudId = SolicitudId;
            oBPAutoridad.AutoridadEntity.AutoridadId = AutoridadId;

            oBPAutoridad.SelectDetalleAutoridadesSolicitud();

            if (oBPAutoridad.ErrorId == 0){

                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
                    lblVocesNivel1.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nivel1"].ToString();
                    lblVocesNivel2.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nivel2"].ToString();
                    lblVocesNivel3.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nivel3"].ToString();
                    lblVocesNombre.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nombre"].ToString();
                    lblVocesPuesto.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Puesto"].ToString();
                    lblVocesObservaciones.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Comentarios"].ToString();

                    // Estado inicial del PopUp
                    ComboVocesTemporalPrimerNivel();
                    LlenarGridVoces_Temporal(Convert.ToInt32(SolicitudId), Convert.ToInt32(AutoridadId));

                    // Foco
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlVocesTemporal_Nivel1.ClientID + "');", true);

                    // Panel Visible
                    this.pnlVoces.Visible = true;
                }

            }
        }

        private void MostrarDetalleAutoridadPopUp(int SolicitudId, int AutoridadId){
            BPAutoridad oBPAutoridad = new BPAutoridad();

            oBPAutoridad.AutoridadEntity.SolicitudId = SolicitudId;
            oBPAutoridad.AutoridadEntity.AutoridadId = AutoridadId;

            oBPAutoridad.SelectDetalleAutoridadesSolicitud();

            if (oBPAutoridad.ErrorId == 0){

                if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){

                    this.ddlActionPrimerNivel.SelectedValue = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["NivelId1"].ToString();
                    ComboAutoridadSegundoNivel();

                    this.ddlActionSegundoNivel.SelectedValue = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["NivelId2"].ToString();
                    ComboAutoridadTercerNivel();

                    this.ddlActionTercerNivel.SelectedValue = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["NivelId3"].ToString();

                    tbActionNombreFuncionario.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Nombre"].ToString();
                    tbActionPuestoActual.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Puesto"].ToString();
                    tbActionComentarios.Text = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows[0]["Comentarios"].ToString();

                    this.btnActionAgregarAutoridad.Text = "Modificar autoridad";
                    this.lblActionTitle.Text = "Modificar autoridad";
                    this.pnlAction.Visible = true;

                    // Foco
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.tbActionNombreFuncionario.ClientID + "');", true);

                }

            }
        }

        private void swapGrid(int iRow){
            Panel oPanelDetail = new Panel();
            ImageButton oImageSwapGrid = new ImageButton();

            ImageButton imgEdit = null;
            ImageButton imgBorrar = null;
            ImageButton imgSeleccionar = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAutoridades.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("imgSwapGrid");
                imgEdit = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("EditButton");
                imgBorrar = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("DeleteButton");
                imgSeleccionar = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("SelectButton");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand_Over" : "Collapse_Over") + ".png'; ";
                

                //Puntero y Sombra en fila Over
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand" : "Collapse") + ".png'; ";

                //Puntero y Sombra en fila Out
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);
                                
                // Cambiar estados
                if (oPanelDetail.Visible){

                    oPanelDetail.Visible = false;
                    oImageSwapGrid.ImageUrl = "~/Include/Image/Buttons/Expand.png";
                    oImageSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Mostrar el detalle', 'Der');");
                    oImageSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }else{

                    oPanelDetail.Visible = true;
                    oImageSwapGrid.ImageUrl = "~/Include/Image/Buttons/Collapse.png";
                    oImageSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Ocultar el detalle', 'Der');");
                    oImageSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }

            }catch (Exception ex){
                throw (ex);
            }
        }

        private void swapGridByHeader(Int32 iRow, Boolean isVisible){
            ImageButton oImageSwapGrid = null;
            Panel oPanelDetail = null;

            ImageButton imgEdit = null;
            ImageButton imgBorrar = null;
            ImageButton imgSeleccionar = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAutoridades.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("imgSwapGrid");
                imgEdit = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("EditButton");
                imgBorrar = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("DeleteButton");
                imgSeleccionar = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("SelectButton");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand_Over" : "Collapse_Over") + ".png'; ";


                //Puntero y Sombra en fila Over
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand" : "Collapse") + ".png'; ";

                //Puntero y Sombra en fila Out
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseout", "this.className='" + ((iRow % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

                // Cambiar estados
                if (isVisible){

                    oPanelDetail.Visible = false;
                    oImageSwapGrid.ImageUrl = "~/Include/Image/Buttons/Expand.png";
                    oImageSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Mostrar el detalle', 'Der');");
                    oImageSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }else{

                    oPanelDetail.Visible = true;
                    oImageSwapGrid.ImageUrl = "~/Include/Image/Buttons/Collapse.png";
                    oImageSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Ocultar el detalle', 'Der');");
                    oImageSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
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

				// Llenado de controles
				ComboAutoridadPrimerNivel();
				ComboAutoridadSegundoNivel();
				ComboAutoridadTercerNivel();

				// Carátula
				SelectSolicitud();

				// Listado de autoridades asociadas al expediente
				LlenarGridAutoridades(Convert.ToInt32(hddSolicitudId.Value));
				
				// Foco
				//ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "function pageLoad(){ focusControl('" + this.ddlFuncionario.ClientID + "'); }", true);

            }catch (Exception ex){
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void btnAgregarAutoridad_Click(object sender, EventArgs e){
            try
            {

                //Abrir popup
                ClearActionPanel(true, 0);
                
                // Leyendas
                this.btnActionAgregarAutoridad.Text = "Agregar autoridad";
                this.lblActionTitle.Text = "Agregar autoridad";

                // Mostrar Panel
                this.pnlAction.Visible = true;

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlActionPrimerNivel.ClientID + "');", true);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e){
			Response.Redirect("QueDetalleSolicitud.aspx?key=" + this.hddSolicitudId.Value + "|" + this.SenderId.Value, false);
        }

        protected void gvAutoridades_RowCommand(object sender, GridViewCommandEventArgs e){
            try
            {

                switch (e.CommandName.ToString())
                {
                    case "Seleccionar": // Agregar Voces
                        ClearVocesPanel(Convert.ToInt32(e.CommandArgument.ToString()));
                        MostrarDetalleAutoridad(Convert.ToInt32(hddSolicitudId.Value), Convert.ToInt32(e.CommandArgument.ToString()));
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
                        break;

                    case "Editar": // Editar Autoridad
                        ClearActionPanel(false, Convert.ToInt32(e.CommandArgument.ToString()));
                        MostrarDetalleAutoridadPopUp(Convert.ToInt32(hddSolicitudId.Value), Convert.ToInt32(e.CommandArgument.ToString()));
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
                        break;

                    case "Borrar": // Eliminar Autoridad con voces
                        BorrarAutoridad(Convert.ToInt32(hddSolicitudId.Value), Convert.ToInt32(e.CommandArgument.ToString()));
                        break;

                    case "SwapGrid": // Expande/Contrae una fila del grid (Aquí el Command Argument contiene el índice de la fila)
                        swapGrid(Convert.ToInt32(e.CommandArgument.ToString()));
                        break;
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void gvAutoridades_RowDataBound(object sender, GridViewRowEventArgs e){
            ImageButton imgEdit = null;
            ImageButton imgBorrar = null;
            ImageButton imgSeleccionar = null;

            String AutoridadId = "";
            String sAutoridad = "";
            String sImagesAttributes = "";
            String sToolTip = "";

            Panel oPanelDetail = null;
            GridView grdVocesAgregadas = null;
            ImageButton imgSwapGrid = null;

            try
            {
                // Validación de que sea fila 
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener imagenes
                imgEdit = (ImageButton)e.Row.FindControl("EditButton");
                imgBorrar = (ImageButton)e.Row.FindControl("DeleteButton");
                imgSeleccionar = (ImageButton)e.Row.FindControl("SelectButton");
                imgSwapGrid = (ImageButton)e.Row.FindControl("imgSwapGrid");

                // DataKeys
                AutoridadId = gvAutoridades.DataKeys[e.Row.RowIndex]["AutoridadId"].ToString();
                sAutoridad = gvAutoridades.DataKeys[e.Row.RowIndex]["Nombre"].ToString();

                // Tooltip Agregar Voz
                sToolTip = "Agregar voces a autoridad [" + sAutoridad + "]";
                imgSeleccionar.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgSeleccionar.Attributes.Add("onmouseout", "tooltip.hide();");
                imgSeleccionar.Attributes.Add("style", "cursor:hand;");

                // Tooltip Editar Autoridad
                sToolTip = "Editar autoridad [" + sAutoridad + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                // Tooltip Borrar Autoridad
                sToolTip = "Borrar autoridad [" + sAutoridad + "] con sus voces";
                imgBorrar.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgBorrar.Attributes.Add("onmouseout", "tooltip.hide();");
                imgBorrar.Attributes.Add("style", "cursor:hand;");

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Collapse_Over.png'; ";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgBorrar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Collapse.png'; ";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

                // Tooltip Swap (por default está expandida)
                sToolTip = "Ocultar el detalle";
                imgSwapGrid.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Der');");
                imgSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                imgSwapGrid.Attributes.Add("style", "cursor:hand;");

                // Voces Agregadas
                grdVocesAgregadas = new GridView();
                grdVocesAgregadas = (GridView)e.Row.FindControl("gvVocesDetalle");
                LlenarGridVoces_Detalle(ref grdVocesAgregadas, Int32.Parse(this.hddSolicitudId.Value), Int32.Parse(AutoridadId));

                // Panel visible
                oPanelDetail = (Panel)e.Row.FindControl("pnlGridDetail");
                oPanelDetail.Visible = true;

            }catch (Exception ex){
                throw (ex);
            }
        }

        protected void gvAutoridades_Sorting(object sender, GridViewSortEventArgs e){
            DataTable TableAutoridad = null;
            DataView ViewAutoridad = null;

            try
            {
                //Obtener DataTable y View del GridView
                TableAutoridad = utilFunction.ParseGridViewToDataTable(gvAutoridades, false);
                ViewAutoridad = new DataView(TableAutoridad);

                //Determinar ordenamiento
                hddSort.Value = (hddSort.Value == e.SortExpression ? e.SortExpression + " DESC" : e.SortExpression);

                //Ordenar Vista
                ViewAutoridad.Sort = hddSort.Value;

                //Vaciar datos
                this.gvAutoridades.DataSource = ViewAutoridad;
                this.gvAutoridades.DataBind();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void imgSwapAll_Click(object sender, ImageClickEventArgs e){
            ImageButton imgHeaderSwapGrid = null;
            Boolean isVisible;

            try
            {

                // Acceso a la imagen
                imgHeaderSwapGrid = (ImageButton)sender;

                if (imgHeaderSwapGrid.ImageUrl == "~/Include/Image/Buttons/Expand_Header.png"){

                    // Expander todo
                    isVisible = false;
                    imgHeaderSwapGrid.ImageUrl = "~/Include/Image/Buttons/Collapse_Header.png";
                    imgHeaderSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Contraer todos los elementos', 'Der');");
                    imgHeaderSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }else{

                    // Contraer todo
                    isVisible = true;
                    imgHeaderSwapGrid.ImageUrl = "~/Include/Image/Buttons/Expand_Header.png";
                    imgHeaderSwapGrid.Attributes.Add("onmouseover", "tooltip.show('Expandir todos los elementos', 'Der');");
                    imgHeaderSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                }

                foreach (GridViewRow rowVozDetalle in this.gvAutoridades.Rows){
                    swapGridByHeader(rowVozDetalle.DataItemIndex, isVisible);
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }


        
        // Eventos del panel Action (Agregar autoridad)

        protected void btnActionAgregarAutoridad_Click(object sender, EventArgs e){
            try
            {

                // Tipo de transacción
                if (this.hdnAutoridadId.Value == "0"){

                    AgregarAutoridad(Convert.ToInt32(this.hddSolicitudId.Value));

                }else{

                    ModificarAutoridad(Convert.ToInt32(this.hddSolicitudId.Value));

                }

                // Recargar grid del listado de autoridades asociadas al expediente
                LlenarGridAutoridades(Convert.ToInt32(this.hddSolicitudId.Value));

            }catch (Exception ex){
                this.lblActionMessage.Text = ex.Message;
            }
        }

        protected void btnActionRegresarPop_Click(object sender, EventArgs e){
            try
            {

                // Cerrar el panel
                this.pnlAction.Visible = false;

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void ddlActionPrimerNivel_SelectedIndexChanged(object sender, EventArgs e){
            try
            {

                // Consulta de combo en cascada
                ComboAutoridadSegundoNivel();
                ComboAutoridadTercerNivel();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlActionSegundoNivel.ClientID + "');", true);

            }catch (Exception ex){
                this.lblActionMessage.Text = ex.Message;
            }
        }

        protected void ddlActionSegundoNivel_SelectedIndexChanged(object sender, EventArgs e){
            try
            {

                // Consulta de combo en cascada
                ComboAutoridadTercerNivel();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlActionTercerNivel.ClientID + "');", true);

            }catch (Exception ex){
                this.lblActionMessage.Text = ex.Message;
            }
        }

        protected void imgActionCloseWindow_Click(object sender, ImageClickEventArgs e){
            try
            {

                // Cerrar el panel
                this.pnlAction.Visible = false;

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }



        // Eventos del panel Voces

        protected void btnVocesRegresar_Click(object sender, EventArgs e){
            try
            {

                // Cerrar el panel
                this.pnlVoces.Visible = false;

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void btnVocesTemporal_Nuevo_Click(object sender, EventArgs e){
            String SolicitudId = this.hddSolicitudId.Value;
            String AutoridadId = this.hdnAutoridadId.Value;

            try
            {

                // Agregar la Voz
                AgregarVoz(Convert.ToInt32(SolicitudId), Convert.ToInt32(AutoridadId));

                // Recargar grid del listado de autoridades asociadas al expediente
                LlenarGridAutoridades(Convert.ToInt32(this.hddSolicitudId.Value));

                // Recacular los combos en cascada
                ddlVocesTemporal_Nivel1.SelectedIndex = 0;
                ComboVocesTemporalSegundoNivel();
                ComboVocesTemporalTercerNivel();

				// Comentarios
				this.txtVocesTemporal_Comentarios.Text = "";

                // Mensajes de error previos
                this.lblVocesMessage.Text = "";

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlVocesTemporal_Nivel1.ClientID + "');", true);

            }catch (Exception ex){
                this.lblVocesMessage.Text = ex.Message;
            }
        }

        protected void gvVocesTemporal_RowCommand(object sender, GridViewCommandEventArgs e){
            String strCommand = "";
            String VozId = "";

            try
            {

                // Opción seleccionada
                strCommand = e.CommandName.ToString();

                // Limpiar mensajes de error anteriores
                this.lblVocesMessage.Text = "";

                // Se dispara el evento RowCommand en el ordenamiento
                if (strCommand == "Sort") { return; }

                // Voz
                VozId = this.gvVocesTemporal.DataKeys[Int32.Parse(e.CommandArgument.ToString())]["VozId"].ToString();

                // Acción
                switch (strCommand){
                    case "Eliminar":
                        BorrarVoz(Int32.Parse(this.hddSolicitudId.Value), Int32.Parse(this.hdnAutoridadId.Value), Int32.Parse(VozId));
                        break;
                }

            }catch (Exception ex){
                this.lblVocesMessage.Text = ex.Message;
            }
        }

        protected void gvVocesTemporal_RowDataBound(object sender, GridViewRowEventArgs e){
            ImageButton imgEliminar = null;
            String sImagesAttributes = "";

            try
            {

                // Validación de que sea fila
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener imagenes
                imgEliminar = (ImageButton)e.Row.FindControl("imgEliminar");

                // Atributos Over
                sImagesAttributes = " document.getElementById('" + imgEliminar.ClientID + "').src='../../../../Include/Image/Buttons/Delete_Over.png';";
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = " document.getElementById('" + imgEliminar.ClientID + "').src='../../../../Include/Image/Buttons/Delete.png';";
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            }catch (Exception ex){
                throw (ex);
            }
        }

        protected void imgVocesCloseWindow_Click(object sender, ImageClickEventArgs e){
            try
            {

                // Cerrar el panel
                this.pnlVoces.Visible = false;

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tinyboxMessage('" + utilFunction.JSClearText(ex.Message) + "', 'Fail', true);", true);
            }
        }

        protected void ddlVocesNivel1_SelectedIndexChanged(object sender, EventArgs e){
            try
            {

                // Consulta de combo en cascada
                ComboVocesTemporalSegundoNivel();
                ComboVocesTemporalTercerNivel();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlVocesTemporal_Nivel2.ClientID + "');", true);

            }catch (Exception ex){
                this.lblVocesMessage.Text = ex.Message;
            }
        }

        protected void ddlVocesNivel2_SelectedIndexChanged(object sender, EventArgs e){
             try
            {

                // Consulta de combo en cascada
                ComboVocesTemporalTercerNivel();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlVocesTemporal_Nivel3.ClientID + "');", true);

            }catch (Exception ex){
                this.lblVocesMessage.Text = ex.Message;
            }
        }

	}
}