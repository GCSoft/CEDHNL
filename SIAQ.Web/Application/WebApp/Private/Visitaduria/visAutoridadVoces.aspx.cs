﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	visAutoridadVoces
' Autor:	Ruben.Cobos
' Fecha:	27-Agosto-2014
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
	public partial class visAutoridadVoces : System.Web.UI.Page
	{
		

		// Utilerías
		GCCommon gcCommon = new GCCommon();
		GCJavascript gcJavascript = new GCJavascript();
		GCEncryption gcEncryption = new GCEncryption();


		// Variables globales
		DataTable tblCalificacionAutoridad;


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


		// Rutinas del programador

		void SelectAutoridad_ForEdit(){
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.AutoridadId = Int32.Parse(this.hddAutoridadId.Value);

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpedienteAutoridad_Detalle(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Llenado de control
				this.ddlAutoridadNivel1.SelectedValue = oENTResponse.dsResponse.Tables[0].Rows[0]["NivelId1"].ToString();
				SelectAutoridadNivel2();

				this.ddlAutoridadNivel2.SelectedValue = oENTResponse.dsResponse.Tables[0].Rows[0]["NivelId2"].ToString();
				SelectAutoridadNivel3();

				this.ddlAutoridadNivel3.SelectedValue = oENTResponse.dsResponse.Tables[0].Rows[0]["NivelId3"].ToString();
				this.ddlCalificacionAutoridad.SelectedValue = oENTResponse.dsResponse.Tables[0].Rows[0]["CalificacionAutoridadId"].ToString();

				tbActionNombreFuncionario.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Nombre"].ToString();
				tbActionPuestoActual.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Puesto"].ToString();
				tbActionComentarios.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Comentarios"].ToString();

				this.btnActionAutoridad.Text = "Confirmar autoridad";
				this.lblActionTitle.Text = "Confirmar autoridad";
				this.pnlAction.Visible = true;

				// Foco
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCalificacionAutoridad.ClientID + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectAutoridadNivel1(){
			BPAutoridad oBPAutoridad = new BPAutoridad();

			try
			{

				// Formulario
				oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = 0;
				oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
				
				// Transacción
				oBPAutoridad.SelectNivelesAutoridad();

				// Validaciones
				if (oBPAutoridad.ErrorId != 0) { throw new Exception(oBPAutoridad.ErrorDescription); }

				// Llenado de controles
				if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
					this.ddlAutoridadNivel1.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[0];
					this.ddlAutoridadNivel1.DataTextField = "Nombre";
					this.ddlAutoridadNivel1.DataValueField = "AutoridadId";
					this.ddlAutoridadNivel1.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectAutoridadNivel2(){
			BPAutoridad oBPAutoridad = new BPAutoridad();

			try
			{

				// Formulario
				oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(this.ddlAutoridadNivel1.SelectedValue);
				oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = 0;
				
				// Transacción
				oBPAutoridad.SelectNivelesAutoridad();

				// Validaciones
				if (oBPAutoridad.ErrorId != 0) { throw new Exception(oBPAutoridad.ErrorDescription); }

				// Llenado de controles
				if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
					this.ddlAutoridadNivel2.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[1];
					this.ddlAutoridadNivel2.DataTextField = "Nombre";
					this.ddlAutoridadNivel2.DataValueField = "AutoridadId";
					this.ddlAutoridadNivel2.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectAutoridadNivel3(){
			BPAutoridad oBPAutoridad = new BPAutoridad();

			try
			{

				// Formulario
				oBPAutoridad.AutoridadEntity.AutoridadIdPadrePrimerNivel = Convert.ToInt32(ddlAutoridadNivel1.SelectedValue);
				oBPAutoridad.AutoridadEntity.AutoridadIdPadreSegundoNivel = Convert.ToInt32(ddlAutoridadNivel2.SelectedValue);
				
				// Transacción
				oBPAutoridad.SelectNivelesAutoridad();

				// Validaciones
				if (oBPAutoridad.ErrorId != 0) { throw new Exception(oBPAutoridad.ErrorDescription); }

				// Llenado de controles
				if (oBPAutoridad.AutoridadEntity.dsResponse.Tables[0].Rows.Count > 0){
					this.ddlAutoridadNivel3.DataSource = oBPAutoridad.AutoridadEntity.dsResponse.Tables[2];
					this.ddlAutoridadNivel3.DataTextField = "Nombre";
					this.ddlAutoridadNivel3.DataValueField = "AutoridadId";
					this.ddlAutoridadNivel3.DataBind();
				}

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
		}

		void SelectCalificacionAutoridad() { 
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.CalificacionAutoridadId = 0;
				oENTVisitaduria.Nombre = "";

				// Transacción
				oENTResponse = oBPVisitaduria.SelectCalificacionAutoridad(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de control
				this.ddlCalificacionAutoridad.DataTextField = "Nombre";
				this.ddlCalificacionAutoridad.DataValueField = "CalificacionAutoridadId";
				this.ddlCalificacionAutoridad.DataSource = oENTResponse.dsResponse.Tables[1];
				this.ddlCalificacionAutoridad.DataBind();

				// Opción todos
				this.ddlCalificacionAutoridad.Items.Insert(0, new ListItem("[Seleccione]", "0"));

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectCalificacionAutoridad_Variable() { 
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.CalificacionAutoridadId = 0;
				oENTVisitaduria.Nombre = "";

				// Transacción
				oENTResponse = oBPVisitaduria.SelectCalificacionAutoridad(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Warnings
				if (oENTResponse.sMessage != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + oENTResponse.sMessage + "');", true); }

				// Llenado de variable
				tblCalificacionAutoridad = oENTResponse.dsResponse.Tables[1];

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

				// Canalizaciones
				if (oENTResponse.dsResponse.Tables[2].Rows.Count > 0){

					this.CanalizacionesLabel.Visible = true;

					this.grdCanalizacion.DataSource = oENTResponse.dsResponse.Tables[2];
					this.grdCanalizacion.DataBind();
				}

				// Autoridades
				this.gvAutoridades.DataSource = oENTResponse.dsResponse.Tables[10];
				this.gvAutoridades.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
		}

		void SelectVoz_Detalle(ref GridView grdDetalle, Int32 AutoridadId){
            BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.AutoridadId = AutoridadId;

				// Transacción
				oENTResponse = oBPVisitaduria.SelectExpedienteAutoridadVoces(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Llenado de control
				grdDetalle.DataSource = oENTResponse.dsResponse.Tables[0];
				grdDetalle.DataBind();

			}catch (Exception ex){
				throw (ex);
			}
        }

		void SelectVoz_ForEdit(){
            BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.AutoridadId = Int32.Parse(this.hddAutoridadId.Value);

				// Consulta de autoridades
				oENTResponse = oBPVisitaduria.SelectExpedienteAutoridad_Detalle(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Llenado de formulario
				this.lblVocesNivel1.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Nivel1"].ToString();
				this.lblVocesNivel2.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Nivel2"].ToString();
				this.lblVocesNivel3.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Nivel3"].ToString();
				this.lblVocesNombre.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Nombre"].ToString();
				this.lblVocesPuesto.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Puesto"].ToString();
				this.lblVocesObservaciones.Text = oENTResponse.dsResponse.Tables[0].Rows[0]["Comentarios"].ToString();

				// Consulta de voces
				oENTResponse = new ENTResponse();
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.AutoridadId = Int32.Parse(this.hddAutoridadId.Value);
				oENTResponse = oBPVisitaduria.SelectExpedienteAutoridadVoces(oENTVisitaduria);

				// Errores
				if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.sErrorMessage)); }

				// Llenado de voces
				this.gvAutoridadVoces.DataSource = oENTResponse.dsResponse.Tables[0];
				this.gvAutoridadVoces.DataBind();

				// Mostrar el panel
				this.btnActionAutoridad.Text = "Confirmar voces";
				this.lblActionTitle.Text = "Confirmar voces";
				this.pnlVoces.Visible = true;

				// Foco
				//ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlCalificacionAutoridad.ClientID + "');", true);

			}catch (Exception ex){
				throw (ex);
			}
        }

		void UpdateExpedienteAutoridad() {
			BPVisitaduria oBPVisitaduria = new BPVisitaduria();
			ENTVisitaduria oENTVisitaduria = new ENTVisitaduria();
			ENTResponse oENTResponse = new ENTResponse();

			try
			{

				// Validaciones
				if (this.ddlCalificacionAutoridad.SelectedValue == "0") { throw new Exception("Debe seleccionar una calificación para la autoridad"); }
				if (this.ddlCalificacionAutoridad.SelectedValue == "1") { throw new Exception("Debe seleccionar una calificación para la autoridad"); }
                if (String.IsNullOrEmpty(this.tbActionNombreFuncionario.Text)) { throw new Exception("El campo [Nombre] es requerido"); }
				if (String.IsNullOrEmpty(this.tbActionPuestoActual.Text)) { throw new Exception("El campo [Puesto Actual] es requerido"); }
				if (String.IsNullOrEmpty(this.tbActionComentarios.Text)) { throw new Exception("El campo [Comentarios] es requerido"); }

				// Formulario
				oENTVisitaduria.ExpedienteId = Int32.Parse(this.hddExpedienteId.Value);
				oENTVisitaduria.AutoridadId = Int32.Parse(this.hddAutoridadId.Value);
				oENTVisitaduria.CalificacionAutoridadId = Int32.Parse(this.ddlCalificacionAutoridad.SelectedItem.Value);
				oENTVisitaduria.ModuloId = 3; // Visitadurías
				oENTVisitaduria.Nombre = tbActionNombreFuncionario.Text;
				oENTVisitaduria.Puesto = tbActionPuestoActual.Text;
				oENTVisitaduria.Comentario = tbActionComentarios.Text;

				// Transacción
				oENTResponse = oBPVisitaduria.UpdateExpedienteAutoridad(oENTVisitaduria);

				//Validaciones 
				if (oENTResponse.GeneratesException) { throw new Exception(oENTResponse.sErrorMessage); }
				if (oENTResponse.sMessage != "") { throw new Exception(oENTResponse.sMessage); }

				// Transacción exitosa
				this.pnlAction.Visible = false;
				ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Autoridad actualizada con éxito');", true);


			}catch (Exception ex){
				throw (ex);
			}
		}


		// Rutinas del PopUp

		void ClearActionPanel(Boolean EnableDDL, Int32 AutoridadId){
            try
            {

                // Limpiar formulario de Nueva Autoridad
                this.ddlAutoridadNivel1.SelectedIndex = 0;
                this.ddlAutoridadNivel2.SelectedIndex = 0;
                this.ddlAutoridadNivel3.SelectedIndex = 0;
				this.ddlCalificacionAutoridad.SelectedIndex = 0;
                this.tbActionNombreFuncionario.Text = "";
                this.tbActionPuestoActual.Text = "";
                this.tbActionComentarios.Text = "";

                // Estado de DropDownList
                this.ddlAutoridadNivel1.Enabled = EnableDDL;
                this.ddlAutoridadNivel2.Enabled = EnableDDL;
                this.ddlAutoridadNivel3.Enabled = EnableDDL;

                // Estado incial de controles
                this.pnlAction.Visible = false;
                this.lblActionMessage.Text = "";

                // Autoridad como parámetro
                this.hddAutoridadId.Value = AutoridadId.ToString();

            }catch (Exception ex){
                throw (ex);
            }
        }

		void SwapGrid(int iRow){
            Panel oPanelDetail = new Panel();
            ImageButton oImageSwapGrid = new ImageButton();

            ImageButton imgEdit = null;
			ImageButton imgSeleccionar = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAutoridades.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("imgSwapGrid");
                imgEdit = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("EditButton");
				imgSeleccionar = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("SelectButton");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (oPanelDetail.Visible ? "Expand_Over" : "Collapse_Over") + ".png'; ";
                

                //Puntero y Sombra en fila Over
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
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

		void SwapGridByHeader(Int32 iRow, Boolean isVisible){
            ImageButton oImageSwapGrid = null;
            Panel oPanelDetail = null;

            ImageButton imgEdit = null;
			ImageButton imgSeleccionar = null;

            String sImagesAttributes = null;

            try
            {

                // Acceso al Panel y a la Imagen
                oPanelDetail = (Panel)this.gvAutoridades.Rows[iRow].FindControl("pnlGridDetail");
                oImageSwapGrid = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("imgSwapGrid");
                imgEdit = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("EditButton");
				imgSeleccionar = (ImageButton)this.gvAutoridades.Rows[iRow].FindControl("SelectButton");

                // Validaciones
                if (oPanelDetail == null) { return; }
                if (oImageSwapGrid == null) { return; }

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + oImageSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/" + (isVisible ? "Expand_Over" : "Collapse_Over") + ".png'; ";


                //Puntero y Sombra en fila Over
                this.gvAutoridades.Rows[iRow].Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
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


		// Rutinas del Popup Voces

		void ClearVocesPanel(Int32 AutoridadId){
            try
            {

                // Limpiar formulario de Nueva Autoridad
                lblVocesNombre.Text = String.Empty;
                lblVocesPuesto.Text = String.Empty;
                lblVocesObservaciones.Text = String.Empty;
                lblVocesNivel1.Text = String.Empty;
                lblVocesNivel2.Text = String.Empty;
                lblVocesNivel3.Text = String.Empty;

                // Estado incial de controles
                this.pnlVoces.Visible = false;
                this.lblAutoridadVoces_Message.Text = "";

                // Autoridad como parámetro
                this.hddAutoridadId.Value = AutoridadId.ToString();

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
				SelectCalificacionAutoridad();
				SelectAutoridadNivel1();
				SelectAutoridadNivel2();
				SelectAutoridadNivel3();

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

		protected void gvAutoridades_RowCommand(object sender, GridViewCommandEventArgs e){
            try
            {

                switch (e.CommandName.ToString()){
                    case "Editar": // Editar Autoridad
                        ClearActionPanel(false, Convert.ToInt32(e.CommandArgument.ToString()));
                        SelectAutoridad_ForEdit();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
                        break;

					case "Seleccionar": // Editar Voces
						ClearVocesPanel(Convert.ToInt32(e.CommandArgument.ToString()));
						SelectVoz_ForEdit();
						ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "tooltip.hide();", true);
						break;

                    case "SwapGrid": // Expande/Contrae una fila del grid (Aquí el Command Argument contiene el índice de la fila)
						SwapGrid(Convert.ToInt32(e.CommandArgument.ToString()));
                        break;
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

        protected void gvAutoridades_RowDataBound(object sender, GridViewRowEventArgs e){
            ImageButton imgEdit = null;
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
				imgSeleccionar = (ImageButton)e.Row.FindControl("SelectButton");
                imgSwapGrid = (ImageButton)e.Row.FindControl("imgSwapGrid");

                // DataKeys
                AutoridadId = gvAutoridades.DataKeys[e.Row.RowIndex]["AutoridadId"].ToString();
                sAutoridad = gvAutoridades.DataKeys[e.Row.RowIndex]["Nombre"].ToString();

				// Tooltip Editar Voz
				sToolTip = "Editar voces de autoridad [" + sAutoridad + "]";
				imgSeleccionar.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
				imgSeleccionar.Attributes.Add("onmouseout", "tooltip.hide();");
				imgSeleccionar.Attributes.Add("style", "cursor:hand;");

                // Tooltip Editar Autoridad
                sToolTip = "Editar autoridad [" + sAutoridad + "]";
                imgEdit.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Izq');");
                imgEdit.Attributes.Add("onmouseout", "tooltip.hide();");
                imgEdit.Attributes.Add("style", "curosr:hand;");

                // Atributos Over
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit_Over.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita_Over.png'; ";
                sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Expand_Over.png'; ";

                //Puntero y Sombra en fila Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                sImagesAttributes = "document.getElementById('" + imgEdit.ClientID + "').src='../../../../Include/Image/Buttons/Edit.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSeleccionar.ClientID + "').src='../../../../Include/Image/Buttons/AgregarVisita.png'; ";
				sImagesAttributes = sImagesAttributes + "document.getElementById('" + imgSwapGrid.ClientID + "').src='../../../../Include/Image/Buttons/Expand.png'; ";

                //Puntero y Sombra en fila Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

                // Tooltip Swap (por default está expandida)
                sToolTip = "Expander el detalle";
                imgSwapGrid.Attributes.Add("onmouseover", "tooltip.show('" + sToolTip + "', 'Der');");
                imgSwapGrid.Attributes.Add("onmouseout", "tooltip.hide();");
                imgSwapGrid.Attributes.Add("style", "cursor:hand;");

				// Sólo autoridades
				oPanelDetail = (Panel)e.Row.FindControl("pnlGridDetail");

				// Voces Agregadas
				grdVocesAgregadas = new GridView();
				grdVocesAgregadas = (GridView)e.Row.FindControl("gvVocesDetalle");
				SelectVoz_Detalle(ref grdVocesAgregadas, Int32.Parse(AutoridadId));
				oPanelDetail.Visible = false;

            }catch (Exception ex){
                throw (ex);
            }
        }

        protected void gvAutoridades_Sorting(object sender, GridViewSortEventArgs e){
           try
			{

				gcCommon.SortGridView(ref this.gvAutoridades, ref this.hddSort, e.SortExpression);

			}catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
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
                    SwapGridByHeader(rowVozDetalle.DataItemIndex, isVisible);
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

		
		// Eventos del PopUp

		protected void btnActionAutoridad_Click(object sender, EventArgs e){
			try
			{

				// Actualizar datos de la Autoridad
				UpdateExpedienteAutoridad();

			}catch (Exception ex){
				this.lblActionMessage.Text = ex.Message;
			}
		}

        protected void btnActionCancelar_Click(object sender, EventArgs e){
            try
            {

                // Cerrar el panel
                this.pnlAction.Visible = false;

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

		protected void imgActionCloseWindow_Click(object sender, ImageClickEventArgs e){
            try
            {

                // Cerrar el panel
                this.pnlAction.Visible = false;

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

		
		// Eventos del PopUp Voces

		protected void btnAutoridadVoces_Regresar_Click(object sender, EventArgs e){
            try
            {

                // Cerrar el panel
                this.pnlVoces.Visible = false;

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

        protected void btnAutoridadVoces_Editar_Click(object sender, EventArgs e){
			//String SolicitudId = this.hddSolicitudId.Value;
			//String AutoridadId = this.hddAutoridadId.Value;

            try
            {

				//// Agregar la Voz
				//AgregarVoz(Convert.ToInt32(SolicitudId), Convert.ToInt32(AutoridadId));

				//// Recargar grid del listado de autoridades asociadas al expediente
				//LlenarGridAutoridades(Convert.ToInt32(this.hddSolicitudId.Value));

				//// Recacular los combos en cascada
				//ddlVocesTemporal_Nivel1.SelectedIndex = 0;
				//ComboVocesTemporalSegundoNivel();
				//ComboVocesTemporalTercerNivel();

				//// Comentarios
				//this.txtVocesTemporal_Comentarios.Text = "";

				//// Mensajes de error previos
				//this.lblAutoridadVoces_Message.Text = "";

				//// Foco
				//ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlVocesTemporal_Nivel1.ClientID + "');", true);

            }catch (Exception ex){
                this.lblAutoridadVoces_Message.Text = ex.Message;
            }
        }

		protected void imgVocesCloseWindow_Click(object sender, ImageClickEventArgs e){
            try
            {

                // Cerrar el panel
                this.pnlVoces.Visible = false;

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

		protected void gvAutoridadVoces_RowDataBound(object sender, GridViewRowEventArgs e){
			DropDownList ddlCalificacionAutoridad = null;
			TextBox txtComentario = null;

            String sImagesAttributes = "";

            try
            {

				// En el header consultar el catálogo de CalificacionAutoridad
				if (e.Row.RowType == DataControlRowType.Header) { SelectCalificacionAutoridad_Variable(); }

                // Validación de que sea fila
                if (e.Row.RowType != DataControlRowType.DataRow) { return; }

                // Obtener controles
				txtComentario = (TextBox)e.Row.FindControl("txtComentarioVoz");
				ddlCalificacionAutoridad = (DropDownList)e.Row.FindControl("ddlCalificacionVoz");

				// Llenar combo de calificaciones de la fila actual
				ddlCalificacionAutoridad.DataTextField = "Nombre";
				ddlCalificacionAutoridad.DataValueField = "CalificacionAutoridadId";
				ddlCalificacionAutoridad.DataSource = tblCalificacionAutoridad;
				ddlCalificacionAutoridad.DataBind();
				ddlCalificacionAutoridad.Items.Insert(0, new ListItem("[Seleccione]", "0"));

				// Llenado de controles
				txtComentario.Text = this.gvAutoridadVoces.DataKeys[e.Row.RowIndex]["Comentarios"].ToString();
				ddlCalificacionAutoridad.SelectedValue = this.gvAutoridadVoces.DataKeys[e.Row.RowIndex]["CalificacionAutoridadId"].ToString();

                // Atributos Over
                e.Row.Attributes.Add("onmouseover", "this.className='Grid_Row_Over'; " + sImagesAttributes);

                // Atributos Out
                e.Row.Attributes.Add("onmouseout", "this.className='" + ((e.Row.RowIndex % 2) != 0 ? "Grid_Row_Alternating" : "Grid_Row") + "'; " + sImagesAttributes);

            }catch (Exception ex){
                throw (ex);
            }
        }

	}
}